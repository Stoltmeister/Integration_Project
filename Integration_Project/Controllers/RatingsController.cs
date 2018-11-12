using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration_Project.Data;
using Integration_Project.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Integration_Project.Controllers
{
    public class RatingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RatingsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SetRating(string Id, decimal rank)
        {
            string userId = User.Identity.GetUserId();
            if (_context.Ratings.Where( r=> r.UserId == userId).Count() >= 1)
            {
                return RedirectToAction("Details", "Venues", new { id = Id });
            }
            Rating rating = new Rating();
            rating.Rank = rank;
            rating.VenueId = Id;
            rating.UserId = userId;

            try
            {
                _context.Venues.Where(v => v.Id == Id).Single().OverallRating = _context.Ratings.Where(r => r.VenueId == Id).ToList().Average(r => r.Rank);
            }
            catch (InvalidOperationException)
            {
                _context.Venues.Where(v => v.Id == Id).Single().OverallRating = rank;
            }
            _context.Ratings.Add(rating);
            _context.SaveChanges();

            //rating = _context.Ratings.Include(r => r.Rating);
            //rating = _context.Ratings.

            //return rating;
            return RedirectToAction("Details", "Venues", new { id = Id });
        }

        //public PartialViewResult RatingsControl(string venueId)
        //{
        //    Venue model = _context.Venues.Where(v => v.Id == venueId).Single();
        //    return PartialView("_RatingsControl", model);
        //}
    }
}