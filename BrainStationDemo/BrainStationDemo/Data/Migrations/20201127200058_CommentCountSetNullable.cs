using Microsoft.EntityFrameworkCore.Migrations;

namespace BrainStationDemo.Data.Migrations
{
    public partial class CommentCountSetNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TotalComments",
                table: "Posts",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TotalComments",
                table: "Posts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
