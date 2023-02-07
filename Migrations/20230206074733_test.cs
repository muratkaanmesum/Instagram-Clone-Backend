using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Instagram_Clone_Backend.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stories_Profiles_UserProfileId",
                table: "Stories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stories",
                table: "Stories");

            migrationBuilder.RenameTable(
                name: "Stories",
                newName: "Story");

            migrationBuilder.RenameIndex(
                name: "IX_Stories_UserProfileId",
                table: "Story",
                newName: "IX_Story_UserProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Story",
                table: "Story",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Story_Profiles_UserProfileId",
                table: "Story",
                column: "UserProfileId",
                principalTable: "Profiles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Story_Profiles_UserProfileId",
                table: "Story");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Story",
                table: "Story");

            migrationBuilder.RenameTable(
                name: "Story",
                newName: "Stories");

            migrationBuilder.RenameIndex(
                name: "IX_Story_UserProfileId",
                table: "Stories",
                newName: "IX_Stories_UserProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stories",
                table: "Stories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stories_Profiles_UserProfileId",
                table: "Stories",
                column: "UserProfileId",
                principalTable: "Profiles",
                principalColumn: "Id");
        }
    }
}
