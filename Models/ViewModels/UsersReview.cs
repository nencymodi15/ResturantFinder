using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResturantFinder.Models.ViewModels
{
    public class UsersReview
    {
        public UserTableDto selectedUser { get; set; }

        public IEnumerable<ReviewDto> Releatedreviews { get; set; }
    }
}