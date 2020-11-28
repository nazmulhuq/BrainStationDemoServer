using Microsoft.EntityFrameworkCore.Migrations;

namespace BrainStationDemo.Data.Migrations
{
    public partial class AddedUserNameToPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Posts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Posts");
        }
    }
}
