using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Integration_Project.Data.Migrations
{
    public partial class AddedProfilePicturetoVenuemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                table: "Venues",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "Venues");
        }
    }
}
