using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeRollProject.DataAccessLayer.Migrations
{
    public partial class addedEventIDintoUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventID",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventID",
                table: "Users");
        }
    }
}
