using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Football_League_Maker.Migrations
{
    public partial class AddIsCompletedColumnToTableLeagues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Leagues",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Leagues");
        }
    }
}
