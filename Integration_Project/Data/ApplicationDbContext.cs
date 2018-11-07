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

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "00df3fb1-fe99-4400-bf75-6d19c31662a6f",
                    UserName = "c.james.obrien@gmail.com",
                    NormalizedUserName = "C.JAMES.OBRIEN@GMAIL.COM",
                    Email = "c.james.obrien@gmail.com",
                    NormalizedEmail = "C.JAMES.OBRIEN@GMAIL.COM",
                    PasswordHash = "AQAAAAEAACcQAAAAEJG8SzwSAu8tIzIHfAIwjt+5rY6LxLg5k3mXSBRGKxGwIzDWkQT1TpQUozpuBjY1ng==",
                    SecurityStamp = "GSZ7JNO4GZ7JR6W2NU7MQZIZGU5BBEJS",
                    ConcurrencyStamp = "baddab696890",
                    PhoneNumber = null,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,
                    LockoutEnd = null
                }
            );
            
            modelBuilder.Entity<StandardUser>().HasData(
                new StandardUser
                {
                    Id = "b7813711-0140-4696-b984-8bd4569c7bba",
                    ApplicationUserId = "00df3fb1-fe99-4400-bf75-6d19c31662a6f",
                    Bio = "Tennis. Code. Meditation.",
                    FirstName = "Casey",
                    LastName = "O'Brien",
                    Email = "c.james.obrien@gmail.com",
                    City = "Milwaukee",
                    State = "WI",
                    ZipCode = 53202
                }
            );
           

            modelBuilder.Entity<Interest>().HasData(
                new Interest
                {
                    Id = "1",
                    Name = "Tennis",
                    Description = "Tennis",
                    Verified = false,
                    CreationDate = new DateTime(2018, 11, 6)
                },
                new Interest
                {
                    Id = "2",
                    Name = "Meditation",
                    Description = "Vipassana Meditation",
                    Verified = false,
                    CreationDate = new DateTime(2018, 11, 6)
                },
                new Interest
                {
                    Id = "3",
                    Name = "Coding",
                    Description = "Computer Coding",
                    Verified = false,
                    CreationDate = new DateTime(2018, 11, 6)
                },
                new Interest
                {
                    Id = "4",
                    Name = "American Football",
                    Description = "American Football",
                    Verified = false,
                    CreationDate = new DateTime(2018, 11, 6)
                }
            );

            modelBuilder.Entity<Venue>().HasData(
                new Venue
                {
                    Id = "1",
                    CreatedBy = "00df3fb1-fe99-4400-bf75-6d19c31662a6f",
                    Name = "McKinley Park Tennis Courts",
                    Address = "1750 N Lincoln Memorial Dr",
                    City = "Milwaukee",
                    State = "WI",
                    Zipcode = 53202,
                    Latitude = (float)43.0539474,
                    Longitude = (float)-87.88557,
                    Description = "6 public hard court tennis courts",
                    CreationDate = new DateTime(2018, 11, 6),
                    IsPrivate = false,
                    WebsiteUrl = "https://county.milwaukee.gov/EN/Parks/Explore/Lakefront/McKinley-Marina",
                    ProfilePicture = null
                },
                new Venue
                {
                    Id = "2",
                    CreatedBy = "00df3fb1-fe99-4400-bf75-6d19c31662a6f",
                    Name = "Shambhala Meditation Center of Milwaukee",
                    Address = "2344 N Oakland Ave",
                    City = "Milwaukee",
                    State = "WI",
                    Zipcode = 53211,
                    Latitude = (float)43.06116,
                    Longitude = (float)-87.88788,
                    Description = "Local meditation center in Milwaukee in Shambhala tradition.",
                    CreationDate = new DateTime(2018, 11, 6),
                    IsPrivate = false,
                    WebsiteUrl = "https://milwaukee.shambhala.org",
                    ProfilePicture = null
                },
                new Venue
                {
                    Id = "3",
                    CreatedBy = "00df3fb1-fe99-4400-bf75-6d19c31662a6f",
                    Name = "Morning Meditation Group",
                    Address = "1660 N Prospect Ave",
                    City = "Milwaukee",
                    State = "WI",
                    Zipcode = 53202,
                    Latitude = (float)43.0519066,
                    Longitude = (float)-87.89092,
                    Description = "Morning meditation group.Meets on Mondays for 30 minutes.",
                    CreationDate = new DateTime(2018, 11, 6),
                    IsPrivate = true,
                    WebsiteUrl = null,
                    ProfilePicture = null
                }
            );

            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    Id = "1",
                    VenueId = "1",
                    StartDate = new DateTime(2018, 11, 14, 16, 00, 00),
                    EndDate = new DateTime(2018, 11, 14, 18, 00, 00),
                    Desciption = "Doubles or Singles Tennis",
                    Premium = 0,
                    IsPrivate = false,
                    IsWeatherDependent = true,
                    CreatedDate = new DateTime(2018, 11, 6),
                    ModifiedDate = new DateTime(2018, 11, 6),
                    MinParticipants = 2,
                    MaxParticipants = 4,
                    CanInviteParticipants = true
                },
                new Event
                {
                    Id = "2",
                    VenueId = "2",
                    StartDate = new DateTime(2018, 11, 18, 9, 00, 00),
                    EndDate = new DateTime(2018, 11, 18, 11, 00, 00),
                    Desciption = "Weekly Practice",
                    Premium = 1,
                    IsPrivate = false,
                    IsWeatherDependent = false,
                    CreatedDate = new DateTime(2018, 11, 6),
                    ModifiedDate = new DateTime(2018, 11, 6),
                    MinParticipants = 2,
                    MaxParticipants = 15,
                    CanInviteParticipants = true
                },
                new Event
                {
                    Id = "3",
                    VenueId = "3",
                    StartDate = new DateTime(2018, 11, 12, 6, 30, 00),
                    EndDate = new DateTime(2018, 11, 12, 7, 00, 00),
                    Desciption = "Weekly morning meditation sit.",
                    Premium = 0,
                    IsPrivate = true,
                    IsWeatherDependent = false,
                    CreatedDate = new DateTime(2018, 11, 6),
                    ModifiedDate = new DateTime(2018, 11, 6),
                    MinParticipants = 2,
                    MaxParticipants = 8,
                    CanInviteParticipants = false
                }
            );

            modelBuilder.Entity<EventInterest>().HasData(
                new EventInterest { Id = "1", EventId = "1", InterestId = "1" },
                new EventInterest { Id = "2", EventId = "2", InterestId = "2" },
                new EventInterest { Id = "3", EventId = "3", InterestId = "2" }
            );

            modelBuilder.Entity<UserInterest>().HasData(
                new UserInterest { Id = 1, StandardUserId = "b7813711-0140-4696-b984-8bd4569c7bba", InterestId = "1" },
                new UserInterest { Id = 2, StandardUserId = "b7813711-0140-4696-b984-8bd4569c7bba", InterestId = "2" },
                new UserInterest { Id = 3, StandardUserId = "b7813711-0140-4696-b984-8bd4569c7bba", InterestId = "3" }
                );

            modelBuilder.Entity<VenueInterest>().HasData(
                new VenueInterest { Id = 1, VenueID = "1", InterestId = "1"},
                new VenueInterest { Id = 2, VenueID = "2", InterestId = "2"},
                new VenueInterest { Id = 3, VenueID = "3", InterestId = "2"}
            );
    
            
        }
    }
}
 