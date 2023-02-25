using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResturantFinder.Models.ViewModels
{
    public class UpdateReview
    {
        public ReviewDto Selectedreview { get; set; }

        public IEnumerable<RestaurantDto> restaurantsoptions { get; set; }
    }
}