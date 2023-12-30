using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeRollProject.DataAccessLayer.Migrations
{
    public partial class addedtablerelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventUser_Events_EventsEventID",
                table: "EventUser");

            migrationBuilder.DropColumn(
                name: "EventID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "EventsEventID",
                table: "EventUser",
                newName: "EventID");

            migrationBuilder.AddForeignKey(
                name: "FK_EventUser_Events_EventID",
                table: "EventUser",
                column: "EventID",
                principalTable: "Events",
                principalColumn: "EventID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventUser_Events_EventID",
                table: "EventUser");

            migrationBuilder.RenameColumn(
                name: "EventID",
                table: "EventUser",
                newName: "EventsEventID");

            migrationBuilder.AddColumn<int>(
                name: "EventID",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EventUser_Events_EventsEventID",
                table: "EventUser",
                column: "EventsEventID",
                principalTable: "Events",
                principalColumn: "EventID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
