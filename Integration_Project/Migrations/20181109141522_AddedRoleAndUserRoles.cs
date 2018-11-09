using Microsoft.EntityFrameworkCore.Migrations;

namespace Integration_Project.Migrations
{
    public partial class AddedRoleAndUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUserRoles",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ApplicationRole",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationRole", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ApplicationRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "49573032-75a1-4a20-a956-9bc2b8f95fa6", "fab9889c-afd4-40ff-91a5-ad7dbae0aedc", "Standard", "STANDARD" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId", "Discriminator" },
                values: new object[,]
                {
                    { "00df3fb1-fe99-4400-bf75-6d19c31662a6f", "49573032-75a1-4a20-a956-9bc2b8f95fa6", "ApplicationUserRole" },
                    { "aaf5b1d2-e64c-4c8e-9a8b-41eaec051fb6", "49573032-75a1-4a20-a956-9bc2b8f95fa6", "ApplicationUserRole" },
                    { "b69a12da-22da-41b4-9cda-a58600ae433c", "49573032-75a1-4a20-a956-9bc2b8f95fa6", "ApplicationUserRole" }
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationRole");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "00df3fb1-fe99-4400-bf75-6d19c31662a6f", "49573032-75a1-4a20-a956-9bc2b8f95fa6" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "aaf5b1d2-e64c-4c8e-9a8b-41eaec051fb6", "49573032-75a1-4a20-a956-9bc2b8f95fa6" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "b69a12da-22da-41b4-9cda-a58600ae433c", "49573032-75a1-4a20-a956-9bc2b8f95fa6" });

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUserRoles");

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
