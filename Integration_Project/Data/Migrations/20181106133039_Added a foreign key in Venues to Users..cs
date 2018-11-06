using Microsoft.EntityFrameworkCore.Migrations;

namespace Integration_Project.Data.Migrations
{
    public partial class AddedaforeignkeyinVenuestoUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Venues",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Venues_CreatedBy",
                table: "Venues",
                column: "CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Venues_AspNetUsers_CreatedBy",
                table: "Venues",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Venues_AspNetUsers_CreatedBy",
                table: "Venues");

            migrationBuilder.DropIndex(
                name: "IX_Venues_CreatedBy",
                table: "Venues");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Venues");
        }
    }
}
