using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Integration_Project.Data.Migrations
{
    public partial class Addinguserintereststabletest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserInterests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StandardUserId = table.Column<string>(nullable: true),
                    InterestId = table.Column<int>(nullable: false),
                    InterestId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInterests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInterests_Interests_InterestId1",
                        column: x => x.InterestId1,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserInterests_StandardUsers_StandardUserId",
                        column: x => x.StandardUserId,
                        principalTable: "StandardUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserInterests_InterestId1",
                table: "UserInterests",
                column: "InterestId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserInterests_StandardUserId",
                table: "UserInterests",
                column: "StandardUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserInterests");
        }
    }
}
