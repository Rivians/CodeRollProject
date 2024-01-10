using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeRollProject.DataAccessLayer.Migrations
{
    public partial class newRelationsSecondGeneration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Users_UserID",
                table: "Votes");

            migrationBuilder.DropTable(
                name: "EventsUsers");

            migrationBuilder.DropIndex(
                name: "IX_Votes_UserID",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "EventTitle",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Votes",
                newName: "ParticipantName");

            migrationBuilder.RenameColumn(
                name: "EventTime",
                table: "Events",
                newName: "EventTime3");

            migrationBuilder.AddColumn<DateTime>(
                name: "EventTime1",
                table: "Events",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EventTime2",
                table: "Events",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Events_UserID",
                table: "Events",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Users_UserID",
                table: "Events",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Users_UserID",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_UserID",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventTime1",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventTime2",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "ParticipantName",
                table: "Votes",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "EventTime3",
                table: "Events",
                newName: "EventTime");

            migrationBuilder.AddColumn<string>(
                name: "EventTitle",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EventsUsers",
                columns: table => new
                {
                    EventUserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsUsers", x => x.EventUserID);
                    table.ForeignKey(
                        name: "FK_EventsUsers_Events_EventID",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventsUsers_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Votes_UserID",
                table: "Votes",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_EventsUsers_EventID",
                table: "EventsUsers",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_EventsUsers_UserID",
                table: "EventsUsers",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Users_UserID",
                table: "Votes",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
