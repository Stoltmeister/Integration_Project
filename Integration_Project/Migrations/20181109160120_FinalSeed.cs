using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Integration_Project.Migrations
{
    public partial class FinalSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Verified = table.Column<bool>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StandardUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    Bio = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    ZipCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StandardUsers_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Zipcode = table.Column<int>(nullable: false),
                    Latitude = table.Column<float>(nullable: false),
                    Longitude = table.Column<float>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    IsPrivate = table.Column<bool>(nullable: false),
                    WebsiteUrl = table.Column<string>(nullable: true),
                    ProfilePicture = table.Column<byte[]>(nullable: true),
                    TwitterHandle = table.Column<string>(nullable: true),
                    OverallRating = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Venues_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserInterests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StandardUserId = table.Column<string>(nullable: true),
                    InterestId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInterests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInterests_Interests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserInterests_StandardUsers_StandardUserId",
                        column: x => x.StandardUserId,
                        principalTable: "StandardUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    VenueId = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Premium = table.Column<int>(nullable: false),
                    IsPrivate = table.Column<bool>(nullable: false),
                    IsWeatherDependent = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    MinParticipants = table.Column<int>(nullable: false),
                    MaxParticipants = table.Column<int>(nullable: false),
                    CanInviteParticipants = table.Column<bool>(nullable: false),
                    EventPicture = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    VenueId = table.Column<string>(nullable: true),
                    Rank = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ratings_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VenueInterests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VenueID = table.Column<string>(nullable: true),
                    InterestId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VenueInterests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VenueInterests_Interests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VenueInterests_Venues_VenueID",
                        column: x => x.VenueID,
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventInterests",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    EventId = table.Column<string>(nullable: true),
                    InterestId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventInterests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventInterests_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventInterests_Interests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventOrganizers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    IsCreator = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventOrganizers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventOrganizers_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventOrganizers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    EventId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    InvitedDate = table.Column<DateTime>(nullable: false),
                    ConfirmedDate = table.Column<DateTime>(nullable: false),
                    InvitedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participants_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Participants_StandardUsers_InvitedBy",
                        column: x => x.InvitedBy,
                        principalTable: "StandardUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Participants_StandardUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "StandardUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "49573032-75a1-4a20-a956-9bc2b8f95fa6", "fab9889c-afd4-40ff-91a5-ad7dbae0aedc", "ApplicationRole", "Standard", "STANDARD" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "00df3fb1-fe99-4400-bf75-6d19c31662a6f", 0, "baddab696890", "ApplicationUser", "c.james.obrien@gmail.com", false, false, null, "C.JAMES.OBRIEN@GMAIL.COM", "C.JAMES.OBRIEN@GMAIL.COM", "AQAAAAEAACcQAAAAEJG8SzwSAu8tIzIHfAIwjt+5rY6LxLg5k3mXSBRGKxGwIzDWkQT1TpQUozpuBjY1ng==", null, false, "GSZ7JNO4GZ7JR6W2NU7MQZIZGU5BBEJS", false, "c.james.obrien@gmail.com" },
                    { "aaf5b1d2-e64c-4c8e-9a8b-41eaec051fb6", 0, "009d8a32-2338-41c6-8715-ba819eb861c2", "ApplicationUser", "esoemad5@gmail.com", false, false, null, "ESOEMAD5@GMAIL.COM", "ESOEMAD5@GMAIL.COM", "AQAAAAEAACcQAAAAEPDcXogAFBdXHB/ILP//pOgad2XY2YtsOMzQhutbq3vwWLMberWfDDTc5S0bKNtgiw==", null, false, "BEMZA2GJMIASDNCYCHHKQYFZCLX7TG3L", false, "esoemad5@gmail.com" },
                    { "b69a12da-22da-41b4-9cda-a58600ae433c", 0, "e001d86c-27e1-43ed-9b5f-a4a54e9ea1eb", "ApplicationUser", "stoltenberg96@gmail.com", false, false, null, "STOLTENBERG96@GMAIL.COM", "STOLTENBERG96@GMAIL.COM", "AQAAAAEAACcQAAAAELw3XmOscJd2XVFufXA0AEASpKA+PRKGF4dDv7QAwaAgNTPaBe5Sm3nI5LL0BmNV4A==", null, false, "5D6YY3GMYCV6ZDFWTS4MIAIT6KS2WQUW", false, "stoltenberg96@gmail.com" },
                    { "0c5b6110-5e5a-4af6-9b2e-f5736a26fa5b", 0, "01fdf294-e754-4f63-b6f8-09f751f90dbe", "ApplicationUser", "coltonsells@coltonsells.com", false, false, null, "COLTONSELLS@COLTONSELLS.COM", "COLTONSELLS@COLTONSELLS.COM", "AQAAAAEAACcQAAAAEKUbqok+BMkAOlt1LOKHV/3m+dGHuYx8dAyoyaE5E2230M1bGw+aGRAfiGFAx4sACQ==", null, false, "WKFLXKLHAWKHJXOU4SD4S4B6GHYCIID5", false, "coltonsells@coltonsells.com" }
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "CreationDate", "Description", "Name", "Verified" },
                values: new object[,]
                {
                    { "1", new DateTime(2018, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tennis", "Tennis", false },
                    { "2", new DateTime(2018, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vipassana Meditation", "Meditation", false },
                    { "3", new DateTime(2018, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Computer Coding", "Coding", false },
                    { "4", new DateTime(2018, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "American Football", "American Football", false },
                    { "5", new DateTime(2018, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kite flying enthusiasts", "Kites", false },
                    { "6", new DateTime(2018, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Magic: The Gathering Game", "Magic: The Gathering", false },
                    { "7", new DateTime(2018, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dungeons & Dragons 5e", "Dungeons & Dragons 5e", false },
                    { "8", new DateTime(2018, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pathfinder", "Pathfinder", false },
                    { "9", new DateTime(2018, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "League of Legends", "League of Legends", false }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId", "Discriminator" },
                values: new object[,]
                {
                    { "00df3fb1-fe99-4400-bf75-6d19c31662a6f", "49573032-75a1-4a20-a956-9bc2b8f95fa6", "ApplicationUserRole" },
                    { "aaf5b1d2-e64c-4c8e-9a8b-41eaec051fb6", "49573032-75a1-4a20-a956-9bc2b8f95fa6", "ApplicationUserRole" },
                    { "b69a12da-22da-41b4-9cda-a58600ae433c", "49573032-75a1-4a20-a956-9bc2b8f95fa6", "ApplicationUserRole" },
                    { "0c5b6110-5e5a-4af6-9b2e-f5736a26fa5b", "49573032-75a1-4a20-a956-9bc2b8f95fa6", "ApplicationUserRole" }
                });

            migrationBuilder.InsertData(
                table: "StandardUsers",
                columns: new[] { "Id", "ApplicationUserId", "Bio", "City", "Email", "FirstName", "LastName", "State", "ZipCode" },
                values: new object[,]
                {
                    { "b7813711-0140-4696-b984-8bd4569c7bba", "00df3fb1-fe99-4400-bf75-6d19c31662a6f", "Tennis. Code. Meditation.", "Milwaukee", "c.james.obrien@gmail.com", "Casey", "O'Brien", "WI", 53202 },
                    { "51e53b9a-f338-4211-9d7a-8be20bc068a9", "aaf5b1d2-e64c-4c8e-9a8b-41eaec051fb6", "Code. Milwaukee. Games.", "Shorewood", "esoemad5@gmail.com", "Elliot", "Soemadi", "Wisconsin", 53211 },
                    { "789e4076-5d71-4e12-b146-2c8f38622f13", "b69a12da-22da-41b4-9cda-a58600ae433c", "Games. Code. Pathfinder.", "South Milwaukee", "stoltenberg96@gmail.com", "Josh", "Stoltenberg", "WI", 53172 },
                    { "90754d36-88ff-4c8b-a595-d95d46200a52", "0c5b6110-5e5a-4af6-9b2e-f5736a26fa5b", "Code. Games. Tennis.", "Brookfield", "coltonsells@coltonsells.com", "Colton", "Sells", "WI", 53045 }
                });

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "Id", "Address", "City", "CreatedBy", "CreationDate", "Description", "IsPrivate", "Latitude", "Longitude", "Name", "OverallRating", "ProfilePicture", "State", "TwitterHandle", "WebsiteUrl", "Zipcode" },
                values: new object[,]
                {
                    { "1", "1750 N Lincoln Memorial Dr", "Milwaukee", "00df3fb1-fe99-4400-bf75-6d19c31662a6f", new DateTime(2018, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "6 public hard court tennis courts", false, 43.05395f, -87.88557f, "McKinley Park Tennis Courts", 0m, null, "WI", null, "https://county.milwaukee.gov/EN/Parks/Explore/Lakefront/McKinley-Marina", 53202 },
                    { "2", "2344 N Oakland Ave", "Milwaukee", "00df3fb1-fe99-4400-bf75-6d19c31662a6f", new DateTime(2018, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Local meditation center in Milwaukee in Shambhala tradition.", false, 43.06116f, -87.88788f, "Shambhala Meditation Center of Milwaukee", 0m, null, "WI", null, "https://milwaukee.shambhala.org", 53211 },
                    { "3", "1660 N Prospect Ave", "Milwaukee", "00df3fb1-fe99-4400-bf75-6d19c31662a6f", new DateTime(2018, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Morning meditation group.Meets on Mondays for 30 minutes.", true, 43.05191f, -87.89092f, "Morning Meditation Group", 0m, null, "WI", null, null, 53202 },
                    { "4", "1717 E Kensington Blvd", "Shorewood", "aaf5b1d2-e64c-4c8e-9a8b-41eaec051fb6", new DateTime(2018, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Game night!", true, 43.09802f, -87.88787f, "My Mom's Basement", 0m, null, "WI", null, null, 53211 },
                    { "5", "1204 Minnesota Ave", "South Milwaukee", "aaf5b1d2-e64c-4c8e-9a8b-41eaec051fb6", new DateTime(2018, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gaming Venue", false, 42.91303f, -87.86496f, "Pink Bunny Games", 0m, null, "WI", null, "pinkbunnygames.com", 53172 },
                    { "6", "12714 W Hampton Ave", "Butler", "aaf5b1d2-e64c-4c8e-9a8b-41eaec051fb6", new DateTime(2018, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gaming Venue", false, 43.10522f, -88.07062f, "Evolution Gaming", 0m, null, "WI", null, "evo-game.com", 53007 }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CanInviteParticipants", "CreatedDate", "Description", "EndDate", "EventPicture", "IsPrivate", "IsWeatherDependent", "MaxParticipants", "MinParticipants", "ModifiedDate", "Name", "Premium", "StartDate", "VenueId" },
                values: new object[,]
                {
                    { "5", false, new DateTime(2018, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "MTG Draft", new DateTime(2018, 11, 21, 18, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, 8, 6, new DateTime(2018, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "MTG Draft", 0, new DateTime(2018, 11, 21, 15, 30, 0, 0, DateTimeKind.Unspecified), "6" },
                    { "4", false, new DateTime(2018, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Friday Night Magic", new DateTime(2018, 11, 20, 18, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, 36, 4, new DateTime(2018, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Friday Night Magic", 0, new DateTime(2018, 11, 20, 15, 30, 0, 0, DateTimeKind.Unspecified), "5" },
                    { "6", false, new DateTime(2018, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "D&D homebrew group", new DateTime(2018, 11, 22, 18, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 6, 4, new DateTime(2018, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "D&D homebrew group", 0, new DateTime(2018, 11, 22, 15, 30, 0, 0, DateTimeKind.Unspecified), "4" },
                    { "1", true, new DateTime(2018, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doubles or Singles Tennis Match", new DateTime(2018, 11, 14, 18, 0, 0, 0, DateTimeKind.Unspecified), null, false, true, 4, 2, new DateTime(2018, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doubles or Singles Tennis Match", 0, new DateTime(2018, 11, 14, 16, 0, 0, 0, DateTimeKind.Unspecified), "1" },
                    { "2", true, new DateTime(2018, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Weekly Meditation Practice", new DateTime(2018, 11, 18, 11, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, 15, 2, new DateTime(2018, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Weekly Meditation Practice", 1, new DateTime(2018, 11, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), "2" },
                    { "3", false, new DateTime(2018, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Weekly morning meditation sit", new DateTime(2018, 11, 12, 7, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 8, 2, new DateTime(2018, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Weekly Morning Meditation Sit", 0, new DateTime(2018, 11, 12, 6, 30, 0, 0, DateTimeKind.Unspecified), "3" },
                    { "7", false, new DateTime(2018, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Weekly One-Shot", new DateTime(2018, 11, 23, 18, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, 6, 4, new DateTime(2018, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Weekly One-Shot", 0, new DateTime(2018, 11, 23, 15, 30, 0, 0, DateTimeKind.Unspecified), "5" }
                });

            migrationBuilder.InsertData(
                table: "UserInterests",
                columns: new[] { "Id", "InterestId", "StandardUserId" },
                values: new object[,]
                {
                    { 9, "9", "51e53b9a-f338-4211-9d7a-8be20bc068a9" },
                    { 8, "8", "51e53b9a-f338-4211-9d7a-8be20bc068a9" },
                    { 7, "7", "51e53b9a-f338-4211-9d7a-8be20bc068a9" },
                    { 6, "6", "51e53b9a-f338-4211-9d7a-8be20bc068a9" },
                    { 4, "4", "51e53b9a-f338-4211-9d7a-8be20bc068a9" },
                    { 3, "3", "b7813711-0140-4696-b984-8bd4569c7bba" },
                    { 2, "2", "b7813711-0140-4696-b984-8bd4569c7bba" },
                    { 5, "5", "51e53b9a-f338-4211-9d7a-8be20bc068a9" },
                    { 1, "1", "b7813711-0140-4696-b984-8bd4569c7bba" }
                });

            migrationBuilder.InsertData(
                table: "VenueInterests",
                columns: new[] { "Id", "InterestId", "VenueID" },
                values: new object[,]
                {
                    { 3, "2", "3" },
                    { 2, "2", "2" },
                    { 1, "1", "1" }
                });

            migrationBuilder.InsertData(
                table: "EventInterests",
                columns: new[] { "Id", "EventId", "InterestId" },
                values: new object[,]
                {
                    { "1", "1", "1" },
                    { "9", "7", "8" },
                    { "7", "7", "7" },
                    { "4", "4", "6" },
                    { "8", "6", "8" },
                    { "5", "5", "6" },
                    { "6", "6", "7" },
                    { "2", "2", "2" },
                    { "3", "3", "2" }
                });

            migrationBuilder.InsertData(
                table: "EventOrganizers",
                columns: new[] { "Id", "EventId", "IsCreator", "UserId" },
                values: new object[,]
                {
                    { 3, "3", true, "00df3fb1-fe99-4400-bf75-6d19c31662a6f" },
                    { 2, "2", true, "00df3fb1-fe99-4400-bf75-6d19c31662a6f" },
                    { 6, "6", true, "aaf5b1d2-e64c-4c8e-9a8b-41eaec051fb6" },
                    { 4, "4", true, "aaf5b1d2-e64c-4c8e-9a8b-41eaec051fb6" },
                    { 1, "1", true, "00df3fb1-fe99-4400-bf75-6d19c31662a6f" },
                    { 7, "7", true, "aaf5b1d2-e64c-4c8e-9a8b-41eaec051fb6" },
                    { 5, "5", true, "aaf5b1d2-e64c-4c8e-9a8b-41eaec051fb6" }
                });

            migrationBuilder.InsertData(
                table: "Participants",
                columns: new[] { "Id", "ConfirmedDate", "EventId", "InvitedBy", "InvitedDate", "UserId" },
                values: new object[,]
                {
                    { "3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2", "b7813711-0140-4696-b984-8bd4569c7bba", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "51e53b9a-f338-4211-9d7a-8be20bc068a9" },
                    { "2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", "b7813711-0140-4696-b984-8bd4569c7bba", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "51e53b9a-f338-4211-9d7a-8be20bc068a9" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EventInterests_EventId",
                table: "EventInterests",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventInterests_InterestId",
                table: "EventInterests",
                column: "InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_EventOrganizers_EventId",
                table: "EventOrganizers",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventOrganizers_UserId",
                table: "EventOrganizers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_VenueId",
                table: "Events",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_EventId",
                table: "Participants",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_InvitedBy",
                table: "Participants",
                column: "InvitedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_UserId",
                table: "Participants",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_VenueId",
                table: "Ratings",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_StandardUsers_ApplicationUserId",
                table: "StandardUsers",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInterests_InterestId",
                table: "UserInterests",
                column: "InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInterests_StandardUserId",
                table: "UserInterests",
                column: "StandardUserId");

            migrationBuilder.CreateIndex(
                name: "IX_VenueInterests_InterestId",
                table: "VenueInterests",
                column: "InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_VenueInterests_VenueID",
                table: "VenueInterests",
                column: "VenueID");

            migrationBuilder.CreateIndex(
                name: "IX_Venues_CreatedBy",
                table: "Venues",
                column: "CreatedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "EventInterests");

            migrationBuilder.DropTable(
                name: "EventOrganizers");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "UserInterests");

            migrationBuilder.DropTable(
                name: "VenueInterests");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "StandardUsers");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Venues");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
