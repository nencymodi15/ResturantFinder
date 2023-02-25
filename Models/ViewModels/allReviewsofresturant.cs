using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ResturantFinder.Models;

namespace ResturantFinder.Models.ViewModels
{
    public class allReviewsofresturant
    {
        public RestaurantDto selectedRestaurant { get; set; }

        public IEnumerable<ReviewDto> Releatedreviews { get; set; }
    }
}