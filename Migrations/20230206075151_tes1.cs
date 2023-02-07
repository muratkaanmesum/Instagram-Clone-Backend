using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Instagram_Clone_Backend.Migrations
{
    public partial class tes1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Like_Posts_PostId",
                table: "Like");

            migrationBuilder.DropForeignKey(
                name: "FK_Like_Profiles_UserProfileId",
                table: "Like");

            migrationBuilder.DropForeignKey(
                name: "FK_Story_Profiles_UserProfileId",
                table: "Story");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Story",
                table: "Story");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Like",
                table: "Like");

            migrationBuilder.RenameTable(
                name: "Story",
                newName: "Stories");

            migrationBuilder.RenameTable(
                name: "Like",
                newName: "Likes");

            migrationBuilder.RenameIndex(
                name: "IX_Story_UserProfileId",
                table: "Stories",
                newName: "IX_Stories_UserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Like_UserProfileId",
                table: "Likes",
                newName: "IX_Likes_UserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Like_PostId",
                table: "Likes",
                newName: "IX_Likes_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stories",
                table: "Stories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Likes",
                table: "Likes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Posts_PostId",
                table: "Likes",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Profiles_UserProfileId",
                table: "Likes",
                column: "UserProfileId",
                principalTable: "Profiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stories_Profiles_UserProfileId",
                table: "Stories",
                column: "UserProfileId",
                principalTable: "Profiles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Posts_PostId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Profiles_UserProfileId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Stories_Profiles_UserProfileId",
                table: "Stories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stories",
                table: "Stories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Likes",
                table: "Likes");

            migrationBuilder.RenameTable(
                name: "Stories",
                newName: "Story");

            migrationBuilder.RenameTable(
                name: "Likes",
                newName: "Like");

            migrationBuilder.RenameIndex(
                name: "IX_Stories_UserProfileId",
                table: "Story",
                newName: "IX_Story_UserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_UserProfileId",
                table: "Like",
                newName: "IX_Like_UserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_PostId",
                table: "Like",
                newName: "IX_Like_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Story",
                table: "Story",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Like",
                table: "Like",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Like_Posts_PostId",
                table: "Like",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Like_Profiles_UserProfileId",
                table: "Like",
                column: "UserProfileId",
                principalTable: "Profiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Story_Profiles_UserProfileId",
                table: "Story",
                column: "UserProfileId",
                principalTable: "Profiles",
                principalColumn: "Id");
        }
    }
}
