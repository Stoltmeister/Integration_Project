using Microsoft.EntityFrameworkCore.Migrations;

namespace Integration_Project.Migrations
{
    public partial class ChangedVenueforratings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "OverallRating",
                table: "Venues",
                nullable: false,
                defaultValue: 0m);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OverallRating",
                table: "Venues");

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
