using Microsoft.EntityFrameworkCore.Migrations;

namespace Integration_Project.Data.Migrations
{
    public partial class AddedCityStateandZipcodetoVenuemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Venues",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Venues",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Zipcode",
                table: "Venues",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Venues");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Venues");

            migrationBuilder.DropColumn(
                name: "Zipcode",
                table: "Venues");
        }
    }
}
