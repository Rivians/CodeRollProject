using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeRollProject.DataAccessLayer.Migrations
{
    public partial class addedlogoutwithdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Events_EventID",
                table: "Votes");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Users_UserID",
                table: "Votes");

            migrationBuilder.DropTable(
                name: "EventUser");

            migrationBuilder.DropIndex(
                name: "IX_Votes_EventID",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Votes_UserID",
                table: "Votes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventUser",
                columns: table => new
                {
                    EventsEventID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventUser", x => new { x.EventsEventID, x.UserID });
                    table.ForeignKey(
                        name: "FK_EventUser_Events_EventsEventID",
                        column: x => x.EventsEventID,
                        principalTable: "Events",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventUser_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Votes_EventID",
                table: "Votes",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_UserID",
                table: "Votes",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_EventUser_UserID",
                table: "EventUser",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Events_EventID",
                table: "Votes",
                column: "EventID",
                principalTable: "Events",
                principalColumn: "EventID");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Users_UserID",
                table: "Votes",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID");
        }
    }
}
