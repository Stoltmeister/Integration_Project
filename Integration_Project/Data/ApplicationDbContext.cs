using System;
using System.Collections.Generic;
using System.Text;
using Integration_Project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Integration_Project.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<StandardUser> StandardUsers { get; set; }
        public DbSet<EventInterest> EventInterests { get; set; }     
        public DbSet<UserInterest> UserInterests { get; set; }
        public DbSet<VenueInterest> VenueInterests { get; set; }
    }
}
