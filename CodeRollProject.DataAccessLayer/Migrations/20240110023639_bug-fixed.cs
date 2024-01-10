using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeRollProject.DataAccessLayer.Migrations
{
    public partial class bugfixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventCreatorID",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "EventUrl",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventUrl",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "EventCreatorID",
                table: "Events",
                type: "int",
                nullable: true);
        }
    }
}
