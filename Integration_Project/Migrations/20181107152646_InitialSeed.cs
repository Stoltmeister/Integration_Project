using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Integration_Project.Migrations
{
    public partial class InitialSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "00df3fb1-fe99-4400-bf75-6d19c31662a6f", 0, "baddab696890", "ApplicationUser", "c.james.obrien@gmail.com", false, false, null, "C.JAMES.OBRIEN@GMAIL.COM", "C.JAMES.OBRIEN@GMAIL.COM", "AQAAAAEAACcQAAAAEJG8SzwSAu8tIzIHfAIwjt+5rY6LxLg5k3mXSBRGKxGwIzDWkQT1TpQUozpuBjY1ng==", null, false, "GSZ7JNO4GZ7JR6W2NU7MQZIZGU5BBEJS", false, "c.james.obrien@gmail.com" });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "CreationDate", "Description", "Name", "Verified" },
                values: new object[,]
                {
                    { "1", new DateTime(2018, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tennis", "Tennis", false },
                    { "2", new DateTime(2018, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vipassana Meditation", "Meditation", false },
                    { "3", new DateTime(2018, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Computer Coding", "Coding", false },
                    { "4", new DateTime(2018, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "American Football", "American Football", false }
                });

            migrationBuilder.InsertData(
                table: "StandardUsers",
                columns: new[] { "Id", "ApplicationUserId", "Bio", "City", "Email", "FirstName", "LastName", "State", "ZipCode" },
                values: new object[] { "b7813711-0140-4696-b984-8bd4569c7bba", "00df3fb1-fe99-4400-bf75-6d19c31662a6f", "Tennis. Code. Meditation.", "Milwaukee", "c.james.obrien@gmail.com", "Casey", "O'Brien", "WI", 53202 });

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "Id", "Address", "City", "CreatedBy", "CreationDate", "Description", "IsPrivate", "Latitude", "Longitude", "Name", "ProfilePicture", "State", "TwitterHandle", "WebsiteUrl", "Zipcode" },
                values: new object[,]
                {
                    { "1", "1750 N Lincoln Memorial Dr", "Milwaukee", "00df3fb1-fe99-4400-bf75-6d19c31662a6f", new DateTime(2018, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "6 public hard court tennis courts", false, 43.05395f, -87.88557f, "McKinley Park Tennis Courts", null, "WI", null, "https://county.milwaukee.gov/EN/Parks/Explore/Lakefront/McKinley-Marina", 53202 },
                    { "2", "2344 N Oakland Ave", "Milwaukee", "00df3fb1-fe99-4400-bf75-6d19c31662a6f", new DateTime(2018, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Local meditation center in Milwaukee in Shambhala tradition.", false, 43.06116f, -87.88788f, "Shambhala Meditation Center of Milwaukee", null, "WI", null, "https://milwaukee.shambhala.org", 53211 },
                    { "3", "1660 N Prospect Ave", "Milwaukee", "00df3fb1-fe99-4400-bf75-6d19c31662a6f", new DateTime(2018, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Morning meditation group.Meets on Mondays for 30 minutes.", true, 43.05191f, -87.89092f, "Morning Meditation Group", null, "WI", null, null, 53202 }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CanInviteParticipants", "CreatedDate", "Desciption", "EndDate", "EventPicture", "IsPrivate", "IsWeatherDependent", "MaxParticipants", "MinParticipants", "ModifiedDate", "Name", "Premium", "StartDate", "VenueId" },
                values: new object[,]
                {
                    { "1", true, new DateTime(2018, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doubles or Singles Tennis", new DateTime(2018, 11, 14, 18, 0, 0, 0, DateTimeKind.Unspecified), null, false, true, 4, 2, new DateTime(2018, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, new DateTime(2018, 11, 14, 16, 0, 0, 0, DateTimeKind.Unspecified), "1" },
                    { "2", true, new DateTime(2018, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Weekly Practice", new DateTime(2018, 11, 18, 11, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, 15, 2, new DateTime(2018, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2018, 11, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), "2" },
                    { "3", false, new DateTime(2018, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Weekly morning meditation sit.", new DateTime(2018, 11, 12, 7, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 8, 2, new DateTime(2018, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, new DateTime(2018, 11, 12, 6, 30, 0, 0, DateTimeKind.Unspecified), "3" }
                });

            migrationBuilder.InsertData(
                table: "UserInterests",
                columns: new[] { "Id", "InterestId", "StandardUserId" },
                values: new object[,]
                {
                    { 1, "1", "b7813711-0140-4696-b984-8bd4569c7bba" },
                    { 2, "2", "b7813711-0140-4696-b984-8bd4569c7bba" },
                    { 3, "3", "b7813711-0140-4696-b984-8bd4569c7bba" }
                });

            migrationBuilder.InsertData(
                table: "VenueInterests",
                columns: new[] { "Id", "InterestId", "VenueID" },
                values: new object[,]
                {
                    { 1, "1", "1" },
                    { 2, "2", "2" },
                    { 3, "2", "3" }
                });

            migrationBuilder.InsertData(
                table: "EventInterests",
                columns: new[] { "Id", "EventId", "InterestId" },
                values: new object[] { "1", "1", "1" });

            migrationBuilder.InsertData(
                table: "EventInterests",
                columns: new[] { "Id", "EventId", "InterestId" },
                values: new object[] { "2", "2", "2" });

            migrationBuilder.InsertData(
                table: "EventInterests",
                columns: new[] { "Id", "EventId", "InterestId" },
                values: new object[] { "3", "3", "2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EventInterests",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "EventInterests",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "EventInterests",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "UserInterests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserInterests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserInterests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VenueInterests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VenueInterests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VenueInterests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "StandardUsers",
                keyColumn: "Id",
                keyValue: "b7813711-0140-4696-b984-8bd4569c7bba");

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "00df3fb1-fe99-4400-bf75-6d19c31662a6f", "baddab696890" });
        }
    }
}
