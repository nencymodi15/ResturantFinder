using ResturantFinder.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using ResturantFinder.Controllers;
using ResturantFinder.Models.ViewModels;

namespace ResturantFinder.Controllers
{
    public class UserTablesController : Controller
    {

        private static readonly HttpClient Client;
        JavaScriptSerializer jss = new JavaScriptSerializer();

        static UserTablesController()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:44338/api/");
        }
        // GET: UserTables/UserList
        public ActionResult UserList()
        {
            string Url = "UserTablesData/ListUsers";

            HttpResponseMessage response = Client.GetAsync(Url).Result;
            IEnumerable<UserTableDto> userTables = response.Content.ReadAsAsync<IEnumerable<UserTableDto>>().Result;
            return View(userTables);
        }

        public ActionResult loginUser()
        {
            string Url = "UserTablesData/ListUsers";

            HttpResponseMessage response = Client.GetAsync(Url).Result;
            IEnumerable<UserTableDto> userTables = response.Content.ReadAsAsync<IEnumerable<UserTableDto>>().Result;
            return View(userTables);
        }

        // GET: UserTables/Details/5
        public ActionResult Details(int id)
        {
            UsersReview viewmodel = new UsersReview();
            string Url = "UserTablesData/FindUserTable/" + id;
            HttpResponseMessage response = Client.GetAsync(Url).Result;

            UserTableDto SelectedUser = response.Content.ReadAsAsync<UserTableDto>().Result;
            viewmodel.selectedUser = SelectedUser;

            Url = "UserTablesData/FindReviews/" + id;
            response = Client.GetAsync(Url).Result;

            IEnumerable<ReviewDto> SelectedReviews = response.Content.ReadAsAsync<IEnumerable<ReviewDto>>().Result;
            viewmodel.Releatedreviews = SelectedReviews;

            return View(viewmodel);
        }
        public ActionResult Error()
        {
            return View();
        }

        // GET: UserTables/Create
        public ActionResult New()
        {
            return View();
        }

        // POST: UserTables/Add
        [HttpPost]
        public ActionResult Add(UserTable userTable)
        {
            string Url = "UserTablesData/AddUserTable";
            string jsonpayload = jss.Serialize(userTable);
            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";
            HttpResponseMessage response = Client.PostAsync(Url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("UserList");

            }
            else
            {
                return RedirectToAction("Error");
            }

        }

        // GET: UserTables/Edit/5
        public ActionResult Edit(int id)
        {
            string Url = "UserTablesData/FindUserTable/" + id;
            HttpResponseMessage response = Client.GetAsync(Url).Result;

            UserTableDto SelectedUser = response.Content.ReadAsAsync<UserTableDto>().Result;

            return View(SelectedUser);
        }

        // POST: UserTables/Update/5
        [HttpPost]
        public ActionResult Update(int id, UserTable userTable)
        {
            string Url = "UserTablesData/UpdateUserTable/" + id;
            string jsonpayload = jss.Serialize(userTable);
            Debug.WriteLine("This is the ");
            Debug.WriteLine(jsonpayload);
            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";
            HttpResponseMessage response = Client.PostAsync(Url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("UserList");

            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        // GET: UserTables/Delete/5
        public ActionResult DeleteConfirm(int id)
        {
            string Url = "UserTablesData/FindUserTable/" + id;
            HttpResponseMessage response = Client.GetAsync(Url).Result;

            UserTableDto SelectedUser = response.Content.ReadAsAsync<UserTableDto>().Result;

            return View(SelectedUser);
        }

        // POST: UserTables/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, UserTable userTable)
        {
            string Url = "UserTablesData/DeleteUserTable/" + id;
            string jsonpayload = jss.Serialize(userTable);
            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";
            HttpResponseMessage response = Client.PostAsync(Url, content).Result;
            Debug.WriteLine("This is the ");
            Debug.WriteLine(response);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("UserList");

            }
            else
            {
                return RedirectToAction("Error");
            }
        }
    }
}
