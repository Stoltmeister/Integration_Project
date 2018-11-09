using Microsoft.EntityFrameworkCore.Migrations;

namespace Integration_Project.Migrations
{
    public partial class AddedUserJosh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b69a12da-22da-41b4-9cda-a58600ae433c", 0, "e001d86c-27e1-43ed-9b5f-a4a54e9ea1eb", "ApplicationUser", "stoltenberg96@gmail.com", false, false, null, "STOLTENBERG96@GMAIL.COM", "STOLTENBERG96@GMAIL.COM", "AQAAAAEAACcQAAAAELw3XmOscJd2XVFufXA0AEASpKA+PRKGF4dDv7QAwaAgNTPaBe5Sm3nI5LL0BmNV4A==", null, false, "5D6YY3GMYCV6ZDFWTS4MIAIT6KS2WQUW", false, "stoltenberg96@gmail.com" });

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
                values: new object[] { "789e4076-5d71-4e12-b146-2c8f38622f13", "b69a12da-22da-41b4-9cda-a58600ae433c", "Games. Code. Pathfinder.", "South Milwaukee", "stoltenberg96@gmail.com", "Josh", "Stoltenberg", "WI", 53172 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StandardUsers",
                keyColumn: "Id",
                keyValue: "789e4076-5d71-4e12-b146-2c8f38622f13");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "b69a12da-22da-41b4-9cda-a58600ae433c", "e001d86c-27e1-43ed-9b5f-a4a54e9ea1eb" });

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
