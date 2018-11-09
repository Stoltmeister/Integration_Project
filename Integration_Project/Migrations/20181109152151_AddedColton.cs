using Microsoft.EntityFrameworkCore.Migrations;

namespace Integration_Project.Migrations
{
    public partial class AddedColton : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0c5b6110-5e5a-4af6-9b2e-f5736a26fa5b", 0, "01fdf294-e754-4f63-b6f8-09f751f90dbe", "ApplicationUser", "coltonsells@coltonsells.com", false, false, null, "COLTONSELLS@COLTONSELLS.COM", "COLTONSELLS@COLTONSELLS.COM", "AQAAAAEAACcQAAAAEKUbqok+BMkAOlt1LOKHV/3m+dGHuYx8dAyoyaE5E2230M1bGw+aGRAfiGFAx4sACQ==", null, false, "WKFLXKLHAWKHJXOU4SD4S4B6GHYCIID5", false, "coltonsells@coltonsells.com" });

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

            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: "5",
                column: "Latitude",
                value: 42.91303f);

            migrationBuilder.InsertData(
                table: "StandardUsers",
                columns: new[] { "Id", "ApplicationUserId", "Bio", "City", "Email", "FirstName", "LastName", "State", "ZipCode" },
                values: new object[] { "90754d36-88ff-4c8b-a595-d95d46200a52", "0c5b6110-5e5a-4af6-9b2e-f5736a26fa5b", "Code. Games. Tennis.", "Brookfield", "coltonsells@coltonsells.com", "Colton", "Sells", "WI", 53045 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StandardUsers",
                keyColumn: "Id",
                keyValue: "90754d36-88ff-4c8b-a595-d95d46200a52");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "0c5b6110-5e5a-4af6-9b2e-f5736a26fa5b", "01fdf294-e754-4f63-b6f8-09f751f90dbe" });

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

            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: "5",
                column: "Latitude",
                value: 42.91303f);
        }
    }
}
