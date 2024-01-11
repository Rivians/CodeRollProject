using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeRollProject.DataAccessLayer.Migrations
{
    public partial class newVoteOptionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Events_EventID",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "VoteOption",
                table: "Votes");

            migrationBuilder.AlterColumn<int>(
                name: "EventID",
                table: "Votes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "VoteOptions",
                columns: table => new
                {
                    VoteOptionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoteID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoteOptions", x => x.VoteOptionID);
                    table.ForeignKey(
                        name: "FK_VoteOptions_Votes_VoteID",
                        column: x => x.VoteID,
                        principalTable: "Votes",
                        principalColumn: "VoteID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_VoteOptions_VoteID",
                table: "VoteOptions",
                column: "VoteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Events_EventID",
                table: "Votes",
                column: "EventID",
                principalTable: "Events",
                principalColumn: "EventID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Events_EventID",
                table: "Votes");

            migrationBuilder.DropTable(
                name: "VoteOptions");

            migrationBuilder.AlterColumn<int>(
                name: "EventID",
                table: "Votes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VoteOption",
                table: "Votes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Events_EventID",
                table: "Votes",
                column: "EventID",
                principalTable: "Events",
                principalColumn: "EventID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
