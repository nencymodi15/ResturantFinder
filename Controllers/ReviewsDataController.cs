using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ResturantFinder.Models;

namespace ResturantFinder.Controllers
{
    public class ReviewsDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ReviewsData/ListReviews
        [HttpGet]
        public IEnumerable<ReviewDto> ListReviews()
        {
            List<Review> Review = db.Reviews.ToList();
            List<ReviewDto> ReviewDtos = new List<ReviewDto>();

            Review.ForEach(a => ReviewDtos.Add(new ReviewDto()
            {
                ReviewId = a.ReviewId,
                ResturantName = a.ResturantName,
                RatingFood = a.RatingFood,
                RatingAsthetics = a.RatingAsthetics,
                RatingFeeling = a.RatingFeeling,
                ReviewsDes = a.ReviewsDes,
                UserId = a.UserTable.UserId,
                Id = a.Restaurant.Id
            }));
            return ReviewDtos;
        }

        // GET: api/ReviewsData/FindReview/5
        [ResponseType(typeof(Review))]
        [HttpGet]
        public IHttpActionResult FindReview(int id)
        {
            Review Review = db.Reviews.Find(id);
            ReviewDto ReviewDto = new ReviewDto()
            {
                ReviewId = Review.ReviewId,
                ResturantName = Review.ResturantName,
                RatingFood = Review.RatingFood,
                RatingAsthetics = Review.RatingAsthetics,
                RatingFeeling = Review.RatingFeeling,
                ReviewsDes = Review.ReviewsDes,
                UserId = Review.UserId,
                Id = Review.Id,
            };
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return NotFound();
            }

            return Ok(review);
        }

        // PUT: api/ReviewsData/UpdateReview/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdateReview(int id, Review review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != review.ReviewId)
            {
                return BadRequest();
            }

            db.Entry(review).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ReviewsData/AddReview
        [ResponseType(typeof(Review))]
        [HttpPost]
        public IHttpActionResult AddReview(Review review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Reviews.Add(review);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = review.ReviewId }, review);
        }

        // DELETE: api/ReviewsData/DeleteReview/5
        [ResponseType(typeof(Review))]
        [HttpPost]
        public IHttpActionResult DeleteReview(int id)
        {
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return NotFound();
            }

            db.Reviews.Remove(review);
            db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReviewExists(int id)
        {
            return db.Reviews.Count(e => e.ReviewId == id) > 0;
        }
    }
}