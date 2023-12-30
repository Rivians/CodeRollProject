using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeRollProject.DataAccessLayer.Migrations
{
    public partial class addedUserIDint0EventEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Events",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Events");
        }
    }
}
