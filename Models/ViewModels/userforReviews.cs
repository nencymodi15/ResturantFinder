using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResturantFinder.Models.ViewModels
{
    public class userforReviews
    {
        public UserTableDto userinfo { get; set; }

        public IEnumerable<RestaurantDto> resturantOptions { get; set; }
    }
}