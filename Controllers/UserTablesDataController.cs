using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.AspNet.Identity;
using ResturantFinder.Models;

namespace ResturantFinder.Controllers
{
    public class UserTablesDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/UserTablesData/ListUsers
        [HttpGet]
        public IEnumerable<UserTableDto> ListUsers()
        {
            List<UserTable> UserTable = db.Users.ToList();
            List<UserTableDto> userTableDto = new List<UserTableDto>();

            UserTable.ForEach(a => userTableDto.Add(new UserTableDto()
            {
                UserId = a.UserId,
                UserName = a.UserName,
                EmailId = a.EmailId,
                Nationality = a.Nationality,
                Type = a.Type,
                Gender = a.Gender
            }));
            return userTableDto;
        }

        // GET: api/UserTablesData/FindUserTable/5
        [ResponseType(typeof(UserTable))]
        [HttpGet]
        public IHttpActionResult FindUserTable(int id)
        {
            UserTable UserTable = db.Users.Find(id);
            UserTableDto UserTableDto = new UserTableDto()
            {
                UserId = UserTable.UserId,
                UserName = UserTable.UserName,
                EmailId = UserTable.EmailId,
                Nationality = UserTable.Nationality,
                Type = UserTable.Type,
                Gender = UserTable.Gender

            };
            UserTable userTable = db.Users.Find(id);
            if (userTable == null)
            {
                return NotFound();
            }

            return Ok(UserTableDto);
        }

        // POST: api/UserTablesData/UpdateUserTable/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdateUserTable(int id, UserTable userTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userTable.UserId)
            {
                return BadRequest();
            }

            db.Entry(userTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserTableExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/UserTablesData/AddUserTable
        [ResponseType(typeof(UserTable))]
        [HttpPost]
        public IHttpActionResult AddUserTable(UserTable userTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(userTable);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = userTable.UserId }, userTable);
        }

        // Post: api/UserTablesData/DeleteUserTable/5
        [ResponseType(typeof(UserTable))]
        [HttpPost]
        public IHttpActionResult DeleteUserTable(int id)
        {
            UserTable userTable = db.Users.Find(id);
            if (userTable == null)
            {
                return NotFound();
            }

            db.Users.Remove(userTable);
            db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserTableExists(int id)
        {
            return db.Users.Count(e => e.UserId == id) > 0;
        }
    }
}