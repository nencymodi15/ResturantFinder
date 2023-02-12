using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ResturantFinder.Models
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string EmailId { get; set; }

        public string FoodNationality { get; set; }

        public string Adress { get; set; }
    }
    public class RestaurantDto
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public string EmailId { get; set; }

        public string FoodNationality { get; set; }

        public string Adress { get; set; }
    }
}