using System;
using System.Collections.Generic;
using System.Text;
using Integration_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<EventOrganizer> EventOrganizers { get; set; }
        public DbSet<Participant> Participants { get; set; }

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

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "aaf5b1d2-e64c-4c8e-9a8b-41eaec051fb6",
                    UserName = "esoemad5@gmail.com",
                    NormalizedUserName = "ESOEMAD5@GMAIL.COM",
                    Email = "esoemad5@gmail.com",
                    NormalizedEmail = "ESOEMAD5@GMAIL.COM",
                    PasswordHash = "AQAAAAEAACcQAAAAEPDcXogAFBdXHB/ILP//pOgad2XY2YtsOMzQhutbq3vwWLMberWfDDTc5S0bKNtgiw==",
                    SecurityStamp = "BEMZA2GJMIASDNCYCHHKQYFZCLX7TG3L",
                    ConcurrencyStamp = "009d8a32-2338-41c6-8715-ba819eb861c2",
                    PhoneNumber = null,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,
                    LockoutEnd = null
                }
            );

            /*modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "b69a12da-22da-41b4-9cda-a58600ae433c",
                    UserName = "stoltenberg96@gmail.com",
                    NormalizedUserName = "STOLTENBERG96@GMAIL.COM",
                    Email = "stoltenberg96@gmail.com",
                    NormalizedEmail = "STOLTENBERG96@GMAIL.COM",
                    PasswordHash = "AQAAAAEAACcQAAAAELw3XmOscJd2XVFufXA0AEASpKA+PRKGF4dDv7QAwaAgNTPaBe5Sm3nI5LL0BmNV4A==",
                    SecurityStamp = "5D6YY3GMYCV6ZDFWTS4MIAIT6KS2WQUW",
                    ConcurrencyStamp = "e001d86c-27e1-43ed-9b5f-a4a54e9ea1eb",
                    PhoneNumber = null,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,
                    LockoutEnd = null
                }
            );*/

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

            modelBuilder.Entity<StandardUser>().HasData(
                new StandardUser
                {
                    Id = "51e53b9a-f338-4211-9d7a-8be20bc068a9",
                    ApplicationUserId = "aaf5b1d2-e64c-4c8e-9a8b-41eaec051fb6",
                    Bio = "Code. Milwaukee. Games.",
                    FirstName = "Elliot",
                    LastName = "Soemadi",
                    Email = "esoemad5@gmail.com",
                    City = "Shorewood",
                    State = "Wisconsin",
                    ZipCode = 53211
                }
            );

            /*modelBuilder.Entity<StandardUser>().HasData(
                new StandardUser
                {
                    Id = "789e4076-5d71-4e12-b146-2c8f38622f13",
                    ApplicationUserId = "b69a12da-22da-41b4-9cda-a58600ae433c",
                    Bio = "Games. Code. Pathfinder.",
                    FirstName = "Josh",
                    LastName = "Stoltenberg",
                    Email = "stoltenberg96@gmail.com",
                    City = "South Milwaukee",
                    State = "WI",
                    ZipCode = 53172
                }
            );*/

            

            // User Roles
            //modelBuilder.Entity<UserRole>().HasData(
            //    new UserRole
            //    {
            //        //UserId = "b7813711-0140-4696-b984-8bd4569c7bba",
            //        //RoleId = ""
            //    }
            //);
            
            

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
                },
                new Interest
                {
                    Id = "5",
                    Name = "Kites",
                    Description = "Kite flying enthusiasts",
                    Verified = false,
                    CreationDate = new DateTime(2018, 11, 8)
                },
                new Interest
                {
                    Id = "6",
                    Name = "Magic: The Gathering",
                    Description = "Magic: The Gathering Game",
                    Verified = false,
                    CreationDate = new DateTime(2018, 11, 9)
                },
                new Interest
                {
                    Id = "7",
                    Name = "Dungeons & Dragons 5e",
                    Description = "Dungeons & Dragons 5e",
                    Verified = false,
                    CreationDate = new DateTime(2018, 11, 9)
                },
                new Interest
                {
                    Id = "8",
                    Name = "Pathfinder",
                    Description = "Pathfinder",
                    Verified = false,
                    CreationDate = new DateTime(2018, 11, 9)
                },
                new Interest
                {
                    Id = "9",
                    Name = "League of Legends",
                    Description = "League of Legends",
                    Verified = false,
                    CreationDate = new DateTime(2018, 11, 9)
                }
            );

            // Venues

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
                },
                new Venue
                {
                    Id = "4",
                    CreatedBy = "aaf5b1d2-e64c-4c8e-9a8b-41eaec051fb6",
                    Name = "My Mom's Basement",
                    Address = "1717 E Kensington Blvd",
                    City = "Shorewood",
                    State = "WI",
                    Zipcode = 53211,
                    Latitude = (float)43.098018,
                    Longitude = (float)-87.887868,
                    Description = "Game night!",
                    CreationDate = new DateTime(2018, 11, 9),
                    IsPrivate = true,
                    WebsiteUrl = null,
                    ProfilePicture = null
                },
                new Venue
                {
                    Id = "5",
                    CreatedBy = "aaf5b1d2-e64c-4c8e-9a8b-41eaec051fb6",
                    Name = "Pink Bunny Games",
                    Address = "1204 Minnesota Ave",
                    City = "South Milwaukee",
                    State = "WI",
                    Zipcode = 53172,
                    Latitude = (float)42.913031,
                    Longitude = (float)-87.864957,
                    Description = "Gaming Venue",
                    CreationDate = new DateTime(2018, 11, 9),
                    IsPrivate = false,
                    WebsiteUrl = "pinkbunnygames.com",
                    ProfilePicture = null
                },
                new Venue
                {
                    Id = "6",
                    CreatedBy = "aaf5b1d2-e64c-4c8e-9a8b-41eaec051fb6",
                    Name = "Evolution Gaming",
                    Address = "12714 W Hampton Ave",
                    City = "Butler",
                    State = "WI",
                    Zipcode = 53007,
                    Latitude = (float)43.105221,
                    Longitude = (float)-88.070614,
                    Description = "Gaming Venue",
                    CreationDate = new DateTime(2018, 11, 9),
                    IsPrivate = false,
                    WebsiteUrl = "evo-game.com",
                    ProfilePicture = null
                }
            );

            // Events.

            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    Id = "1",
                    VenueId = "1",
                    StartDate = new DateTime(2018, 11, 14, 16, 00, 00),
                    EndDate = new DateTime(2018, 11, 14, 18, 00, 00),
                    Name = "Doubles or Singles Tennis Match",
                    Description = "Doubles or Singles Tennis Match",
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
                    Name = "Weekly Meditation Practice",
                    Description = "Weekly Meditation Practice",
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
                    Name = "Weekly Morning Meditation Sit",
                    Description = "Weekly morning meditation sit",
                    Premium = 0,
                    IsPrivate = true,
                    IsWeatherDependent = false,
                    CreatedDate = new DateTime(2018, 11, 6),
                    ModifiedDate = new DateTime(2018, 11, 6),
                    MinParticipants = 2,
                    MaxParticipants = 8,
                    CanInviteParticipants = false
                },
                new Event
                {
                    Id = "4",
                    VenueId = "5",
                    StartDate = new DateTime(2018, 11, 20, 15, 30, 00),
                    EndDate = new DateTime(2018, 11, 20, 18, 00, 00),
                    Name = "Friday Night Magic",
                    Description = "Friday Night Magic",
                    Premium = 0,
                    IsPrivate = false,
                    IsWeatherDependent = false,
                    CreatedDate = new DateTime(2018, 11, 9),
                    ModifiedDate = new DateTime(2018, 11, 9),
                    MinParticipants = 4,
                    MaxParticipants = 36,
                    CanInviteParticipants = false
                },
                new Event
                {
                    Id = "5",
                    VenueId = "6",
                    StartDate = new DateTime(2018, 11, 21, 15, 30, 00),
                    EndDate = new DateTime(2018, 11, 21, 18, 00, 00),
                    Name = "MTG Draft",
                    Description = "MTG Draft",
                    Premium = 0,
                    IsPrivate = false,
                    IsWeatherDependent = false,
                    CreatedDate = new DateTime(2018, 11, 9),
                    ModifiedDate = new DateTime(2018, 11, 9),
                    MinParticipants = 6,
                    MaxParticipants = 8,
                    CanInviteParticipants = false
                },
                new Event
                {
                    Id = "6",
                    VenueId = "4",
                    StartDate = new DateTime(2018, 11, 22, 15, 30, 00),
                    EndDate = new DateTime(2018, 11, 22, 18, 00, 00),
                    Name = "D&D homebrew group",
                    Description = "D&D homebrew group",
                    Premium = 0,
                    IsPrivate = true,
                    IsWeatherDependent = false,
                    CreatedDate = new DateTime(2018, 11, 9),
                    ModifiedDate = new DateTime(2018, 11, 9),
                    MinParticipants = 4,
                    MaxParticipants = 6,
                    CanInviteParticipants = false
                },
                new Event
                {
                    Id = "7",
                    VenueId = "5",
                    StartDate = new DateTime(2018, 11, 23, 15, 30, 00),
                    EndDate = new DateTime(2018, 11, 23, 18, 00, 00),
                    Name = "Weekly One-Shot",
                    Description = "Weekly One-Shot",
                    Premium = 0,
                    IsPrivate = false,
                    IsWeatherDependent = false,
                    CreatedDate = new DateTime(2018, 11, 9),
                    ModifiedDate = new DateTime(2018, 11, 9),
                    MinParticipants = 4,
                    MaxParticipants = 6,
                    CanInviteParticipants = false
                }
            );

            // EventOragnizer

            modelBuilder.Entity<EventOrganizer>().HasData(
                new EventOrganizer { Id = 1, EventId = "1", IsCreator = true, UserId = "00df3fb1-fe99-4400-bf75-6d19c31662a6f" },
                new EventOrganizer { Id = 2, EventId = "2", IsCreator = true, UserId = "00df3fb1-fe99-4400-bf75-6d19c31662a6f" },
                new EventOrganizer { Id = 3, EventId = "3", IsCreator = true, UserId = "00df3fb1-fe99-4400-bf75-6d19c31662a6f" },
                new EventOrganizer { Id = 4, EventId = "4", IsCreator = true, UserId = "aaf5b1d2-e64c-4c8e-9a8b-41eaec051fb6" },
                new EventOrganizer { Id = 5, EventId = "5", IsCreator = true, UserId = "aaf5b1d2-e64c-4c8e-9a8b-41eaec051fb6" },
                new EventOrganizer { Id = 6, EventId = "6", IsCreator = true, UserId = "aaf5b1d2-e64c-4c8e-9a8b-41eaec051fb6" },
                new EventOrganizer { Id = 7, EventId = "7", IsCreator = true, UserId = "aaf5b1d2-e64c-4c8e-9a8b-41eaec051fb6" }
            );
            
            modelBuilder.Entity<EventInterest>().HasData(
                new EventInterest { Id = "1", EventId = "1", InterestId = "1" },
                new EventInterest { Id = "2", EventId = "2", InterestId = "2" },
                new EventInterest { Id = "3", EventId = "3", InterestId = "2" },
                new EventInterest { Id = "4", EventId = "4", InterestId = "6" },
                new EventInterest { Id = "5", EventId = "5", InterestId = "6" },
                new EventInterest { Id = "6", EventId = "6", InterestId = "7" },
                new EventInterest { Id = "7", EventId = "7", InterestId = "7" },
                new EventInterest { Id = "8", EventId = "6", InterestId = "8" },
                new EventInterest { Id = "9", EventId = "7", InterestId = "8" }
            );

            modelBuilder.Entity<UserInterest>().HasData(
                new UserInterest { Id = 1, StandardUserId = "b7813711-0140-4696-b984-8bd4569c7bba", InterestId = "1" },
                new UserInterest { Id = 2, StandardUserId = "b7813711-0140-4696-b984-8bd4569c7bba", InterestId = "2" },
                new UserInterest { Id = 3, StandardUserId = "b7813711-0140-4696-b984-8bd4569c7bba", InterestId = "3" },
                new UserInterest { Id = 4, StandardUserId = "51e53b9a-f338-4211-9d7a-8be20bc068a9", InterestId = "4" },
                new UserInterest { Id = 5, StandardUserId = "51e53b9a-f338-4211-9d7a-8be20bc068a9", InterestId = "5" },
                new UserInterest { Id = 6, StandardUserId = "51e53b9a-f338-4211-9d7a-8be20bc068a9", InterestId = "6" },
                new UserInterest { Id = 7, StandardUserId = "51e53b9a-f338-4211-9d7a-8be20bc068a9", InterestId = "7" },
                new UserInterest { Id = 8, StandardUserId = "51e53b9a-f338-4211-9d7a-8be20bc068a9", InterestId = "8" },
                new UserInterest { Id = 9, StandardUserId = "51e53b9a-f338-4211-9d7a-8be20bc068a9", InterestId = "9" }

                );

            modelBuilder.Entity<VenueInterest>().HasData(
                new VenueInterest { Id = 1, VenueID = "1", InterestId = "1"},
                new VenueInterest { Id = 2, VenueID = "2", InterestId = "2"},
                new VenueInterest { Id = 3, VenueID = "3", InterestId = "2"}
            );

            // Participants.

            modelBuilder.Entity<Participant>().HasData(
                new Participant { Id = "2", EventId = "1", InvitedBy = "b7813711-0140-4696-b984-8bd4569c7bba", UserId = "51e53b9a-f338-4211-9d7a-8be20bc068a9" },
                new Participant { Id = "3", EventId = "2", InvitedBy = "b7813711-0140-4696-b984-8bd4569c7bba", UserId = "51e53b9a-f338-4211-9d7a-8be20bc068a9" }
            );
    
            
        }
    }
}
 