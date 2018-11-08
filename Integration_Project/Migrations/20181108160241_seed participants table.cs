using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Integration_Project.Migrations
{
    public partial class seedparticipantstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "aaf5b1d2-e64c-4c8e-9a8b-41eaec051fb6", 0, "009d8a32-2338-41c6-8715-ba819eb861c2", "ApplicationUser", "esoemad5@gmail.com", false, false, null, "ESOEMAD5@GMAIL.COM", "ESOEMAD5@GMAIL.COM", "AQAAAAEAACcQAAAAEPDcXogAFBdXHB/ILP//pOgad2XY2YtsOMzQhutbq3vwWLMberWfDDTc5S0bKNtgiw==", null, false, "BEMZA2GJMIASDNCYCHHKQYFZCLX7TG3L", false, "esoemad5@gmail.com" });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "CreationDate", "Description", "Name", "Verified" },
                values: new object[] { "5", new DateTime(2018, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kite flying enthusiasts", "Kites", false });

            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: "1",
                column: "Latitude",
                value: 43.05395f);

            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: "3",
                column: "Latitude",
                value: 43.05191f);

            migrationBuilder.InsertData(
                table: "StandardUsers",
                columns: new[] { "Id", "ApplicationUserId", "Bio", "City", "Email", "FirstName", "LastName", "State", "ZipCode" },
                values: new object[] { "51e53b9a-f338-4211-9d7a-8be20bc068a9", "aaf5b1d2-e64c-4c8e-9a8b-41eaec051fb6", "Code. Milwaukee. Games.", "Shorewood", "esoemad5@gmail.com", "Elliot", "Soemadi", "Wisconsin", 53211 });

            migrationBuilder.InsertData(
                table: "Participants",
                columns: new[] { "Id", "ConfirmedDate", "EventId", "InvitedBy", "InvitedDate", "UserId" },
                values: new object[] { "2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", "b7813711-0140-4696-b984-8bd4569c7bba", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "51e53b9a-f338-4211-9d7a-8be20bc068a9" });

            migrationBuilder.InsertData(
                table: "Participants",
                columns: new[] { "Id", "ConfirmedDate", "EventId", "InvitedBy", "InvitedDate", "UserId" },
                values: new object[] { "3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2", "b7813711-0140-4696-b984-8bd4569c7bba", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "51e53b9a-f338-4211-9d7a-8be20bc068a9" });

            migrationBuilder.InsertData(
                table: "UserInterests",
                columns: new[] { "Id", "InterestId", "StandardUserId" },
                values: new object[] { 4, "4", "51e53b9a-f338-4211-9d7a-8be20bc068a9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "Participants",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Participants",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "UserInterests",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StandardUsers",
                keyColumn: "Id",
                keyValue: "51e53b9a-f338-4211-9d7a-8be20bc068a9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "aaf5b1d2-e64c-4c8e-9a8b-41eaec051fb6", "009d8a32-2338-41c6-8715-ba819eb861c2" });

            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: "1",
                column: "Latitude",
                value: 43.05395f);

            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: "3",
                column: "Latitude",
                value: 43.05191f);
        }
    }
}
