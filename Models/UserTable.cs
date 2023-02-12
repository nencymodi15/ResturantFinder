using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ResturantFinder.Models
{
    public class UserTable
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }

        public string EmailId { get; set; }
        public string Nationality { get; set; }

        public string Type { get; set; }

        public string Gender { get; set; }

    }
    public class UserTableDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        public string EmailId { get; set; }
        public string Nationality { get; set; }

        public string Type { get; set; }

        public string Gender { get; set; }

    }
}