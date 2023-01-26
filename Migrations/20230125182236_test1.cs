using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Instagram_Clone_Backend.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Like",
                newName: "UserProfileId");

            migrationBuilder.AddColumn<string>(
                name: "Caption",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Caption",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "UserProfileId",
                table: "Like",
                newName: "UserId");
        }
    }
}
