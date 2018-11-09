using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Integration_Project.Migrations
{
    public partial class MoreSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventOrganizers_StandardUsers_UserId",
                table: "EventOrganizers");

            migrationBuilder.UpdateData(
                table: "EventOrganizers",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "00df3fb1-fe99-4400-bf75-6d19c31662a6f");

            migrationBuilder.UpdateData(
                table: "EventOrganizers",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "00df3fb1-fe99-4400-bf75-6d19c31662a6f");

            migrationBuilder.UpdateData(
                table: "EventOrganizers",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: "00df3fb1-fe99-4400-bf75-6d19c31662a6f");

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "CreationDate", "Description", "Name", "Verified" },
                values: new object[,]
                {
                    { "6", new DateTime(2018, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Magic: The Gathering Game", "Magic: The Gathering", false },
                    { "7", new DateTime(2018, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dungeons & Dragons 5e", "Dungeons & Dragons 5e", false },
                    { "8", new DateTime(2018, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pathfinder", "Pathfinder", false },
                    { "9", new DateTime(2018, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "League of Legends", "League of Legends", false }
                });

            migrationBuilder.InsertData(
                table: "UserInterests",
                columns: new[] { "Id", "InterestId", "StandardUserId" },
                values: new object[] { 5, "5", "51e53b9a-f338-4211-9d7a-8be20bc068a9" });

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

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "Id", "Address", "City", "CreatedBy", "CreationDate", "Description", "IsPrivate", "Latitude", "Longitude", "Name", "OverallRating", "ProfilePicture", "State", "TwitterHandle", "WebsiteUrl", "Zipcode" },
                values: new object[,]
                {
                    { "4", "1717 E Kensington Blvd", "Shorewood", "aaf5b1d2-e64c-4c8e-9a8b-41eaec051fb6", new DateTime(2018, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Game night!", true, 43.09802f, -87.88787f, "My Mom's Basement", 0m, null, "WI", null, null, 53211 },
                    { "5", "1204 Minnesota Ave", "South Milwaukee", "aaf5b1d2-e64c-4c8e-9a8b-41eaec051fb6", new DateTime(2018, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gaming Venue", false, 42.91303f, -87.86496f, "Pink Bunny Games", 0m, null, "WI", null, "pinkbunnygames.com", 53172 },
                    { "6", "12714 W Hampton Ave", "Butler", "aaf5b1d2-e64c-4c8e-9a8b-41eaec051fb6", new DateTime(2018, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gaming Venue", false, 43.10522f, -88.07062f, "Evolution Gaming", 0m, null, "WI", null, "evo-game.com", 53007 }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CanInviteParticipants", "CreatedDate", "Description", "EndDate", "EventPicture", "IsPrivate", "IsWeatherDependent", "MaxParticipants", "MinParticipants", "ModifiedDate", "Name", "Premium", "StartDate", "VenueId" },
                values: new object[,]
                {
                    { "6", false, new DateTime(2018, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "D&D homebrew group", new DateTime(2018, 11, 22, 18, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, 6, 4, new DateTime(2018, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "D&D homebrew group", 0, new DateTime(2018, 11, 22, 15, 30, 0, 0, DateTimeKind.Unspecified), "4" },
                    { "4", false, new DateTime(2018, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Friday Night Magic", new DateTime(2018, 11, 20, 18, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, 36, 4, new DateTime(2018, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Friday Night Magic", 0, new DateTime(2018, 11, 20, 15, 30, 0, 0, DateTimeKind.Unspecified), "5" },
                    { "7", false, new DateTime(2018, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Weekly One-Shot", new DateTime(2018, 11, 23, 18, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, 6, 4, new DateTime(2018, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Weekly One-Shot", 0, new DateTime(2018, 11, 23, 15, 30, 0, 0, DateTimeKind.Unspecified), "5" },
                    { "5", false, new DateTime(2018, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "MTG Draft", new DateTime(2018, 11, 21, 18, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, 8, 6, new DateTime(2018, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "MTG Draft", 0, new DateTime(2018, 11, 21, 15, 30, 0, 0, DateTimeKind.Unspecified), "6" }
                });

            migrationBuilder.InsertData(
                table: "UserInterests",
                columns: new[] { "Id", "InterestId", "StandardUserId" },
                values: new object[,]
                {
                    { 6, "6", "51e53b9a-f338-4211-9d7a-8be20bc068a9" },
                    { 7, "7", "51e53b9a-f338-4211-9d7a-8be20bc068a9" },
                    { 8, "8", "51e53b9a-f338-4211-9d7a-8be20bc068a9" },
                    { 9, "9", "51e53b9a-f338-4211-9d7a-8be20bc068a9" }
                });

            migrationBuilder.InsertData(
                table: "EventInterests",
                columns: new[] { "Id", "EventId", "InterestId" },
                values: new object[,]
                {
                    { "6", "6", "7" },
                    { "8", "6", "8" },
                    { "4", "4", "6" },
                    { "7", "7", "7" },
                    { "9", "7", "8" },
                    { "5", "5", "6" }
                });

            migrationBuilder.InsertData(
                table: "EventOrganizers",
                columns: new[] { "Id", "EventId", "IsCreator", "UserId" },
                values: new object[,]
                {
                    { 6, "6", true, "aaf5b1d2-e64c-4c8e-9a8b-41eaec051fb6" },
                    { 4, "4", true, "aaf5b1d2-e64c-4c8e-9a8b-41eaec051fb6" },
                    { 7, "7", true, "aaf5b1d2-e64c-4c8e-9a8b-41eaec051fb6" },
                    { 5, "5", true, "aaf5b1d2-e64c-4c8e-9a8b-41eaec051fb6" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_EventOrganizers_AspNetUsers_UserId",
                table: "EventOrganizers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventOrganizers_AspNetUsers_UserId",
                table: "EventOrganizers");

            migrationBuilder.DeleteData(
                table: "EventInterests",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "EventInterests",
                keyColumn: "Id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "EventInterests",
                keyColumn: "Id",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "EventInterests",
                keyColumn: "Id",
                keyValue: "7");

            migrationBuilder.DeleteData(
                table: "EventInterests",
                keyColumn: "Id",
                keyValue: "8");

            migrationBuilder.DeleteData(
                table: "EventInterests",
                keyColumn: "Id",
                keyValue: "9");

            migrationBuilder.DeleteData(
                table: "EventOrganizers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EventOrganizers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EventOrganizers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "EventOrganizers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "UserInterests",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UserInterests",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "UserInterests",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "UserInterests",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "UserInterests",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: "7");

            migrationBuilder.DeleteData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: "7");

            migrationBuilder.DeleteData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: "8");

            migrationBuilder.DeleteData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: "9");

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: "6");

            migrationBuilder.UpdateData(
                table: "EventOrganizers",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "b7813711-0140-4696-b984-8bd4569c7bba");

            migrationBuilder.UpdateData(
                table: "EventOrganizers",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "b7813711-0140-4696-b984-8bd4569c7bba");

            migrationBuilder.UpdateData(
                table: "EventOrganizers",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: "b7813711-0140-4696-b984-8bd4569c7bba");

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

            migrationBuilder.AddForeignKey(
                name: "FK_EventOrganizers_StandardUsers_UserId",
                table: "EventOrganizers",
                column: "UserId",
                principalTable: "StandardUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
