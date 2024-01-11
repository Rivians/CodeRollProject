using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeRollProject.DataAccessLayer.Migrations
{
    public partial class addedVoteValueintoVoteOptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VoteOptions_Votes_VoteID",
                table: "VoteOptions");

            migrationBuilder.AlterColumn<int>(
                name: "VoteID",
                table: "VoteOptions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VoteValue",
                table: "VoteOptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VoteOptions_Votes_VoteID",
                table: "VoteOptions",
                column: "VoteID",
                principalTable: "Votes",
                principalColumn: "VoteID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VoteOptions_Votes_VoteID",
                table: "VoteOptions");

            migrationBuilder.DropColumn(
                name: "VoteValue",
                table: "VoteOptions");

            migrationBuilder.AlterColumn<int>(
                name: "VoteID",
                table: "VoteOptions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_VoteOptions_Votes_VoteID",
                table: "VoteOptions",
                column: "VoteID",
                principalTable: "Votes",
                principalColumn: "VoteID");
        }
    }
}
