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
using System.Web.Mvc;
using ResturantFinder.Models;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace ResturantFinder.Controllers
{
    public class RestaurantsDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/RestaurantsData/ListRestaurants
        [HttpGet]
        public IEnumerable<RestaurantDto> ListRestaurants()
        {
            List< Restaurant> Restaurant=  db.Restaurants.ToList();
            List<RestaurantDto> restaurantDtos = new List<RestaurantDto>();

            Restaurant.ForEach(a => restaurantDtos.Add(new RestaurantDto(){
                Id = a.Id,
                Name = a.Name,
                EmailId = a.EmailId,
                FoodNationality = a.FoodNationality,
                Adress=a.Adress
            }));
            return restaurantDtos;
        }
        // GET: api/RestaurantsData/FindReviews/2
        [HttpGet]
        [ResponseType(typeof(ReviewDto))]
        public IHttpActionResult FindReviews(int id)
        {
            List<Review> Review = db.Reviews.Where(a => a.Id == id).ToList();
            List<ReviewDto> ReviewDtos = new List<ReviewDto>();

            Review.ForEach(a => ReviewDtos.Add(new ReviewDto()
            {
                ReviewId = a.ReviewId,
                ResturantName = a.ResturantName,
                RatingFood = a.RatingFood,
                RatingAsthetics = a.RatingAsthetics,
                RatingFeeling = a.RatingFeeling,
                ReviewsDes = a.ReviewsDes,
                UserId = a.UserTable.UserId,
                Id = a.Restaurant.Id
            }));

            return Ok(ReviewDtos);
        }

        // GET: api/RestaurantsData/FindRestaurant/5

        [ResponseType(typeof(Restaurant))]
        [HttpGet]
        public IHttpActionResult FindRestaurant(int id)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            RestaurantDto RestaurantDto = new RestaurantDto()
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                EmailId = restaurant.EmailId,
                FoodNationality = restaurant.FoodNationality,
                Adress = restaurant.Adress

            };
            if (restaurant == null)
            {
                return NotFound();
            }

                return Ok(RestaurantDto);
        }
         
        // POST: api/RestaurantsData/UpdateRestaurant/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdateRestaurant(int id, Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restaurant.Id)
            {
                return BadRequest();
            }

            db.Entry(restaurant).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantExists(id))
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

        // POST: api/RestaurantsData/AddRestaurant
        [ResponseType(typeof(Restaurant))]
        [HttpPost]
        public IHttpActionResult AddRestaurant(Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Restaurants.Add(restaurant);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = restaurant.Id }, restaurant);
        }

        // POST: api/RestaurantsData/DeleteRestaurant/7
        [ResponseType(typeof(Restaurant))]
        [HttpPost]
        public IHttpActionResult DeleteRestaurant(int id)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            db.Restaurants.Remove(restaurant);
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

        private bool RestaurantExists(int id)
        {
            return db.Restaurants.Count(e => e.Id == id) > 0;
        }
    }
}