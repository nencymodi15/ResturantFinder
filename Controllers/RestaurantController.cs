using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using ResturantFinder.Models;
using System.Web.Script.Serialization;
using ResturantFinder.Models.ViewModels;

namespace ResturantFinder.Controllers
{
    public class RestaurantController : Controller
    {
        public object Debuge { get; private set; }

        private static readonly HttpClient Client;
        JavaScriptSerializer jss = new JavaScriptSerializer();

        static RestaurantController()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:44338/api/");
        }

        // GET: Restaurant/list
        public ActionResult List()
        {
            string Url = "RestaurantsData/ListRestaurants";
            HttpResponseMessage response = Client.GetAsync(Url).Result;

            IEnumerable<RestaurantDto> restaurants = response.Content.ReadAsAsync<IEnumerable<RestaurantDto>>().Result;

            return View(restaurants);
        }

        // GET: Restaurant/ShowResturant/5
        public ActionResult ShowResturant(int id)
        {
            allReviewsofresturant viewmodel = new allReviewsofresturant();
            string Url = "RestaurantsData/FindRestaurant/" + id;
            HttpResponseMessage response = Client.GetAsync(Url).Result;

            RestaurantDto Selectedrestaurants = response.Content.ReadAsAsync<RestaurantDto>().Result;

            viewmodel.selectedRestaurant = Selectedrestaurants;
            Url = "RestaurantsData/FindReviews/" + id;
            response = Client.GetAsync(Url).Result;
            IEnumerable<ReviewDto> reviews = response.Content.ReadAsAsync<IEnumerable<ReviewDto>>().Result;
            
            viewmodel.Releatedreviews = reviews;
            return View(viewmodel);
        }

        public ActionResult Error()
        {
            return View();
        }

        // GET: Restaurant/New
        public ActionResult New()
        {
            return View();
        }

        // POST: Restaurant/Create
        [HttpPost]
        public ActionResult Create(Restaurant restaurant)
        {

            //curl -H "Contet-Type:application/json" -d @Resturant.json https://localhost:44338/api/RestaurantsData/AddRestaurant
            string Url = "RestaurantsData/AddRestaurant";
            string jsonpayload = jss.Serialize(restaurant);
            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";
            HttpResponseMessage response = Client.PostAsync(Url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");

            }
            else
            {
                return RedirectToAction("Error");
            }
            

        }

        // GET: Restaurant/Edit/5
        public ActionResult Edit(int id)
        {
            string Url = "RestaurantsData/FindRestaurant/" + id;
            HttpResponseMessage response = Client.GetAsync(Url).Result;

            RestaurantDto Selectedrestaurants = response.Content.ReadAsAsync<RestaurantDto>().Result;

            return View(Selectedrestaurants);
        }

        // POST: Restaurant/Update/5 
        [HttpPost]
        public ActionResult Update(int id, Restaurant restaurant)
        {
            string Url = "RestaurantsData/UpdateRestaurant/" + id;
            string jsonpayload = jss.Serialize(restaurant);
            Debug.WriteLine("This is the ");
            Debug.WriteLine(jsonpayload);
            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";
            HttpResponseMessage response = Client.PostAsync(Url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");

            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        // GET: Restaurant/Delete/5
        public ActionResult DeleteConfirm(int id)
        {
            string Url = "RestaurantsData/FindRestaurant/" + id;
            HttpResponseMessage response = Client.GetAsync(Url).Result;

            RestaurantDto Selectedrestaurants = response.Content.ReadAsAsync<RestaurantDto>().Result;

            return View(Selectedrestaurants);
        }

        // POST: Restaurant/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Restaurant restaurant)
        {
            string Url = "RestaurantsData/DeleteRestaurant/" + id;
            string jsonpayload = jss.Serialize(restaurant);
            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";
            HttpResponseMessage response = Client.PostAsync(Url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");

            }
            else
            {
                return RedirectToAction("Error");
            }
        }
    }
}
