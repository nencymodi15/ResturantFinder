using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ResturantFinder.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public string ResturantName { get; set; }

        public int RatingFood { get; set; }

        public int RatingAsthetics { get; set; }

        public int RatingFeeling { get; set; }

        public string ReviewsDes { get; set; }

        //a user can write many reviws 
        //A reviw can have only one user
        
        [ForeignKey("UserTable")]
        public int UserId { get; set; }
        public virtual UserTable UserTable { get; set; }

        //a Resturant can Have many reviws 
        //A reviw can have only one ResturantName

        [ForeignKey("Restaurant")]
        public int Id { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
    public class ReviewDto
    {
        [Key]
        public int ReviewId { get; set; }
        public string ResturantName { get; set; }

        public int RatingFood { get; set; }

        public int RatingAsthetics { get; set; }

        public int RatingFeeling { get; set; }

        public string ReviewsDes { get; set; }

        public int UserId { get; set; }

        public int Id { get; set; }

    }
}