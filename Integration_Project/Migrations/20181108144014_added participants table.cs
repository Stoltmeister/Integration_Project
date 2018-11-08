using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Integration_Project.Migrations
{
    public partial class addedparticipantstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    InvitedDate = table.Column<DateTime>(nullable: false),
                    ConfirmedDate = table.Column<DateTime>(nullable: false),
                    InvitedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participants_StandardUsers_InvitedBy",
                        column: x => x.InvitedBy,
                        principalTable: "StandardUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Participants_StandardUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "StandardUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "Description", "Name" },
                values: new object[] { "Doubles or Singles Tennis Match", "Doubles or Singles Tennis Match" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "Description", "Name" },
                values: new object[] { "Weekly Meditation Practice", "Weekly Meditation Practice" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "Description", "Name" },
                values: new object[] { "Weekly morning meditation sit", "Weekly Morning Meditation Sit" });

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
                name: "IX_Participants_InvitedBy",
                table: "Participants",
                column: "InvitedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_UserId",
                table: "Participants",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "Description", "Name" },
                values: new object[] { "Doubles or Singles Tennis", null });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "Description", "Name" },
                values: new object[] { "Weekly Practice", null });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "Description", "Name" },
                values: new object[] { "Weekly morning meditation sit.", null });

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
