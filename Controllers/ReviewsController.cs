using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using ResturantFinder.Models;
using ResturantFinder.Models.ViewModels;

namespace ResturantFinder.Controllers
{
    public class ReviewsController : Controller
    {

        private static readonly HttpClient Client;
        JavaScriptSerializer jss = new JavaScriptSerializer();

        static ReviewsController()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:44338/api/");
        }
        // GET: Reviews/ReviewsList
        public ActionResult ReviewsList()
        {
            string Url = "ReviewsData/ListReviews";

            HttpResponseMessage response = Client.GetAsync(Url).Result;
            IEnumerable<ReviewDto> Review = response.Content.ReadAsAsync<IEnumerable<ReviewDto>>().Result;
            return View(Review);
        }

        // GET: Reviews/Details/5
        public ActionResult Details(int id)
        {
            string Url = "ReviewsData/FindReview/" + id;
            HttpResponseMessage response = Client.GetAsync(Url).Result;

            ReviewDto SelectedReview = response.Content.ReadAsAsync<ReviewDto>().Result;

            return View(SelectedReview);
        }
        public ActionResult Error()
        {
            return View();
        }

        // GET: Reviews/New/
        public ActionResult New()
        {
            userforReviews viewmodel = new userforReviews();
            string Url = "RestaurantsData/ListRestaurants";
            HttpResponseMessage response = Client.GetAsync(Url).Result;

            IEnumerable<RestaurantDto> restaurantsoptions = response.Content.ReadAsAsync<IEnumerable<RestaurantDto>>().Result;

            viewmodel.resturantOptions = restaurantsoptions;
             Url = "UserTablesData/FindUserTable";
             response = Client.GetAsync(Url).Result;
             UserTableDto SelectedUser = response.Content.ReadAsAsync<UserTableDto>().Result;
            viewmodel.userinfo = SelectedUser;

            return View(viewmodel);
        }

        // POST: Reviews/Add
        [HttpPost]
        public ActionResult Add(Review review)
        {
            string Url = "ReviewsData/AddReview";
            string jsonpayload = jss.Serialize(review);
            Debug.WriteLine("This is the ");
            Debug.WriteLine(jsonpayload);
            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";
            HttpResponseMessage response = Client.PostAsync(Url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ReviewsList");

            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        // GET: Reviews/Edit/5
        public ActionResult Edit(int id)
        {

            UpdateReview updateReview = new UpdateReview();
            string Url = "ReviewsData/FindReview/" + id;
            HttpResponseMessage response = Client.GetAsync(Url).Result;
            ReviewDto Selectedreview = response.Content.ReadAsAsync<ReviewDto>().Result;
            updateReview.Selectedreview = Selectedreview;

            Url = "RestaurantsData/ListRestaurants";
            response = Client.GetAsync(Url).Result;
            IEnumerable<RestaurantDto> Restaurantoptions = response.Content.ReadAsAsync<IEnumerable<RestaurantDto>>().Result;

            updateReview.restaurantsoptions = Restaurantoptions;


            return View(updateReview);
        }

        // POST: Reviews/Update/5
        [HttpPost]
        public ActionResult Update(int id, Review review)
        {
            string Url = "ReviewsData/UpdateReview/" + id;
            string jsonpayload = jss.Serialize(review);
            Debug.WriteLine("This is the ");
            Debug.WriteLine(jsonpayload);
            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";
            HttpResponseMessage response = Client.PostAsync(Url, content).Result;
            Debug.WriteLine("This is the ");
            Debug.WriteLine(response);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ReviewsList");

            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        // GET: Reviews/DeleteConfirm/5
        public ActionResult DeleteConfirm(int id)
        {
            string Url = "ReviewsData/FindReview/" + id;
            HttpResponseMessage response = Client.GetAsync(Url).Result;

            ReviewDto SelectedReview = response.Content.ReadAsAsync<ReviewDto>().Result;

            return View(SelectedReview);
        }

        // POST: Reviews/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            string Url = "ReviewsData/DeleteReview/" + id;
            HttpContent content = new StringContent("");
            content.Headers.ContentType.MediaType = "application/json";
            HttpResponseMessage response = Client.PostAsync(Url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ReviewsList");

            }
            else
            {
                return RedirectToAction("Error");
            }
        }
    }
}
