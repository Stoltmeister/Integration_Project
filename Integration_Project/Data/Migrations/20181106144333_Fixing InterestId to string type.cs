using Microsoft.EntityFrameworkCore.Migrations;

namespace Integration_Project.Data.Migrations
{
    public partial class FixingInterestIdtostringtype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInterests_Interests_InterestId1",
                table: "UserInterests");

            migrationBuilder.DropIndex(
                name: "IX_UserInterests_InterestId1",
                table: "UserInterests");

            migrationBuilder.DropColumn(
                name: "InterestId1",
                table: "UserInterests");

            migrationBuilder.AlterColumn<string>(
                name: "InterestId",
                table: "UserInterests",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_UserInterests_InterestId",
                table: "UserInterests",
                column: "InterestId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInterests_Interests_InterestId",
                table: "UserInterests",
                column: "InterestId",
                principalTable: "Interests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInterests_Interests_InterestId",
                table: "UserInterests");

            migrationBuilder.DropIndex(
                name: "IX_UserInterests_InterestId",
                table: "UserInterests");

            migrationBuilder.AlterColumn<int>(
                name: "InterestId",
                table: "UserInterests",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InterestId1",
                table: "UserInterests",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserInterests_InterestId1",
                table: "UserInterests",
                column: "InterestId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInterests_Interests_InterestId1",
                table: "UserInterests",
                column: "InterestId1",
                principalTable: "Interests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
