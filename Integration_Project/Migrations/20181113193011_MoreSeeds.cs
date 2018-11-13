using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Integration_Project.Migrations
{
    public partial class MoreSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Participants",
                columns: new[] { "Id", "ConfirmedDate", "EventId", "InvitedBy", "InvitedDate", "UserId" },
                values: new object[] { "4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2", "b7813711-0140-4696-b984-8bd4569c7bba", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "b7813711-0140-4696-b984-8bd4569c7bba" });

            migrationBuilder.InsertData(
                table: "Participants",
                columns: new[] { "Id", "ConfirmedDate", "EventId", "InvitedBy", "InvitedDate", "UserId" },
                values: new object[] { "5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", "b7813711-0140-4696-b984-8bd4569c7bba", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "b7813711-0140-4696-b984-8bd4569c7bba" });

            migrationBuilder.InsertData(
                table: "Participants",
                columns: new[] { "Id", "ConfirmedDate", "EventId", "InvitedBy", "InvitedDate", "UserId" },
                values: new object[] { "6", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2", "b7813711-0140-4696-b984-8bd4569c7bba", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "b7813711-0140-4696-b984-8bd4569c7bba" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Participants",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "Participants",
                keyColumn: "Id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "Participants",
                keyColumn: "Id",
                keyValue: "6");
        }
    }
}
