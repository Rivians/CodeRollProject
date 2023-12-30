using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeRollProject.DataAccessLayer.Migrations
{
    public partial class userToUserseventToEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventUser_Events_EventID",
                table: "EventUser");

            migrationBuilder.DropForeignKey(
                name: "FK_EventUser_Users_UserID",
                table: "EventUser");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "EventUser",
                newName: "UsersUserID");

            migrationBuilder.RenameColumn(
                name: "EventID",
                table: "EventUser",
                newName: "EventsEventID");

            migrationBuilder.RenameIndex(
                name: "IX_EventUser_UserID",
                table: "EventUser",
                newName: "IX_EventUser_UsersUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_EventUser_Events_EventsEventID",
                table: "EventUser",
                column: "EventsEventID",
                principalTable: "Events",
                principalColumn: "EventID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventUser_Users_UsersUserID",
                table: "EventUser",
                column: "UsersUserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventUser_Events_EventsEventID",
                table: "EventUser");

            migrationBuilder.DropForeignKey(
                name: "FK_EventUser_Users_UsersUserID",
                table: "EventUser");

            migrationBuilder.RenameColumn(
                name: "UsersUserID",
                table: "EventUser",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "EventsEventID",
                table: "EventUser",
                newName: "EventID");

            migrationBuilder.RenameIndex(
                name: "IX_EventUser_UsersUserID",
                table: "EventUser",
                newName: "IX_EventUser_UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_EventUser_Events_EventID",
                table: "EventUser",
                column: "EventID",
                principalTable: "Events",
                principalColumn: "EventID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventUser_Users_UserID",
                table: "EventUser",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
