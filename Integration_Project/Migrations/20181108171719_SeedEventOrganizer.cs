using Microsoft.EntityFrameworkCore.Migrations;

namespace Integration_Project.Migrations
{
    public partial class SeedEventOrganizer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "EventOrganizers",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "EventOrganizers",
                columns: new[] { "Id", "EventId", "IsCreator", "UserId" },
                values: new object[,]
                {
                    { 1, "1", true, "b7813711-0140-4696-b984-8bd4569c7bba" },
                    { 2, "2", true, "b7813711-0140-4696-b984-8bd4569c7bba" },
                    { 3, "3", true, "b7813711-0140-4696-b984-8bd4569c7bba" }
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

            migrationBuilder.CreateIndex(
                name: "IX_EventOrganizers_UserId",
                table: "EventOrganizers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventOrganizers_StandardUsers_UserId",
                table: "EventOrganizers",
                column: "UserId",
                principalTable: "StandardUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventOrganizers_StandardUsers_UserId",
                table: "EventOrganizers");

            migrationBuilder.DropIndex(
                name: "IX_EventOrganizers_UserId",
                table: "EventOrganizers");

            migrationBuilder.DeleteData(
                table: "EventOrganizers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EventOrganizers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EventOrganizers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "EventOrganizers",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

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
