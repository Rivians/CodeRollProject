using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeRollProject.DataAccessLayer.Migrations
{
    public partial class addedeventurleventfullrulintoeventEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EventFullUrl",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EventUrl",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventFullUrl",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventUrl",
                table: "Events");
        }
    }
}
