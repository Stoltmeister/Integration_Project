using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Integration_Project.Data;
using Integration_Project.Models;
using Integration_Project.Assets;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Web;

namespace Integration_Project.Controllers
{
    public class VenuesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VenuesController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> SendgridTest()
        {
            string emailAddress = "esoemad5@gmail.com";
            Sendgrid.SendMail(emailAddress, "It's me!", ", Todd Kraines! Why do you keep hanging up on me? It's Todd Kraines!!").Wait();
            return View("Index", await _context.Venues.ToListAsync());
        }

        public async Task<IActionResult> InterestSelection(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var currentVenue = await _context.Venues.FirstOrDefaultAsync(v => v.Id == id);
            if (currentVenue == null)
            {
                return NotFound();
            }
            VenueInterestsViewModel venueInterests = new VenueInterestsViewModel();
            List<Interest> likedInterests = new List<Interest>();
            venueInterests.CurrentVenue = currentVenue;
            var interestEntries = await _context.VenueInterests.Where(i => i.VenueID == currentVenue.Id).ToListAsync(); //try catch?
            var interests = await _context.Interests.ToListAsync();
            foreach (VenueInterest i in interestEntries)
            {
                likedInterests.Add(i.Interest);
                interests.Remove(i.Interest);
            }
            venueInterests.AddedInterests = likedInterests;
            venueInterests.Interests = interests;

            return View(venueInterests);
        }

        //AddInterest
        public async Task<IActionResult> AddInterest(string interestId, string venueId)
        {
            // Add interest to userinterest junction table
            var currentVenue = await _context.Venues.Where(v => v.Id == venueId).SingleAsync();
            VenueInterest venueInterest = new VenueInterest();
            venueInterest.InterestId = interestId;
            venueInterest.VenueID = venueId;
            await _context.VenueInterests.AddAsync(venueInterest);
            await _context.SaveChangesAsync();
            return RedirectToAction("InterestSelection", new { id = venueId });
        }

        //RemoveInterest
        public async Task<IActionResult> RemoveInterest(string interestId, string venueId)
        {
            var currentVenue = await _context.Venues.FirstOrDefaultAsync(v => v.Id == venueId);
            var currentVenueInterests = await _context.VenueInterests.Include(v => v.Interest).Where(v => v.VenueID == venueId).ToListAsync();
            VenueInterest deletingInterest = currentVenueInterests.Where(u => u.InterestId == interestId).SingleOrDefault();
            _context.VenueInterests.Remove(deletingInterest);
            await _context.SaveChangesAsync();
            return RedirectToAction("InterestSelection", new { id = venueId });
        }

        public IActionResult CreateInterest(string id)
        {
            VenueInterestCreator venueInterest = new VenueInterestCreator();
            Interest newInterest = new Interest();
            venueInterest.CurrentVenueID = id;
            venueInterest.NewInterest = newInterest;
            return View(venueInterest);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateInterest([Bind("Name,Description")] Interest newInterest, VenueInterestCreator venueInterest)
        {
            if (ModelState.IsValid)
            {
                newInterest.CreationDate = DateTime.Today;
                newInterest.Verified = false;
                await _context.AddAsync(newInterest);
                await _context.SaveChangesAsync();
                return RedirectToAction("InterestSelection", new { id = venueInterest.CurrentVenueID });
            }
            return View(newInterest);
        }


        // GET: Venues
        public async Task<IActionResult> Index()
        {
            TempData["controllerCheck"] = "";
            TempData["eventId"] = "";
            return View(await _context.Venues.ToListAsync());
        }

        // GET: Venues/Details/5
        public async Task<IActionResult> Details(string id)
        {
            ViewBag.googleMapsKey = ApiKeys.googleMapsKey;
            if (id == null)
            {
                return NotFound();
            }

            var venue = await _context.Venues
                .FirstOrDefaultAsync(m => m.Id == id);
            if (venue == null)
            {
                return NotFound();
            }

            VenueInterestsViewModel venueInterests = new VenueInterestsViewModel();
            List<Interest> likedInterests = new List<Interest>();
            venueInterests.CurrentVenue = venue;
            var interestEntries = await _context.VenueInterests.Include(i => i.Interest).Where(i => i.VenueID == venue.Id).ToListAsync(); //try catch?
            
            foreach (VenueInterest i in interestEntries)
            {
                likedInterests.Add(i.Interest);
            }
            venueInterests.AddedInterests = likedInterests;
            venueInterests.Interests = likedInterests;

            venueInterests.CurrentVenue = venue;
            string cCheck = (string)TempData["controllerCheck"];
            string eId = (string)TempData["eventId"];
            venueInterests.controller = cCheck;
            venueInterests.eventId = eId;

            return View(venueInterests);
        }

        // GET: Venues/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Venues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,City,State,Zipcode,Description,IsPrivate,WebsiteUrl,TwitterHandle,ProfilePicture")] Venue venue, IFormFile picture)
        {
            // Picture does not get saved
            venue = await StorePicture(venue, picture);
            if (ModelState.IsValid)
            {
                
                venue.CreatedBy = User.Identity.GetUserId();
                venue.CreationDate = DateTime.Now;
                venue.UpdateLatitudeAndLongitude();
                _context.Add(venue);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", _context.Venues.Where(v => v.Id == venue.Id).Single());
            }
            return View(venue);
        }

        // GET: Venues/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venue = await _context.Venues.FindAsync(id);
            if (venue == null)
            {
                return NotFound();
            }
            return View(venue);
        }
        private async Task<Venue> StorePicture(Venue _venue, IFormFile picture)
        {
            if (picture != null)
            {
                using (var stream = new MemoryStream())
                {
                    await picture.CopyToAsync(stream);
                    _venue.ProfilePicture = stream.ToArray();
                }
            }

            // Database gets upset
            //else
            //{
            //    try
            //    {
            //        var pictureInDatabase = _context.Venues.Where(v => v.Id == _venue.Id).Single().ProfilePicture;
            //        if (pictureInDatabase != null)
            //        {
            //            _venue.ProfilePicture = pictureInDatabase;
            //        }
            //    }
            //    catch (InvalidOperationException)
            //    {
            //        Either no user in database(create), or 2 users have the same primary key.
            //    }
            //}

            return _venue;
        }
        // POST: Venues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Address,City,State,Zipcode,Description,CreationDate,IsPrivate,WebsiteUrl,TwitterHandle,ProfilePicture")] Venue venue, IFormFile picture)
        {
            if (id != venue.Id)
            {
                return NotFound();
            }
            // If the user does not upload an image, the image will be the default image, even if the venue already had an image
            venue = await StorePicture(venue, picture);




            if (ModelState.IsValid)
            {
                try
                {
                    venue.UpdateLatitudeAndLongitude();
                    _context.Update(venue);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VenueExists(venue.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(venue);
        }

        // GET: Venues/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venue = await _context.Venues
                .FirstOrDefaultAsync(m => m.Id == id);
            if (venue == null)
            {
                return NotFound();
            }

            return View(venue);
        }

        // POST: Venues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var venue = await _context.Venues.FindAsync(id);
            _context.Venues.Remove(venue);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VenueExists(string id)
        {
            return _context.Venues.Any(e => e.Id == id);
        }
    }
}
