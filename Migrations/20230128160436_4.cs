using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Instagram_Clone_Backend.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentUserProfiles_Profiles_UserProfileId",
                table: "CommentUserProfiles");

            migrationBuilder.DropIndex(
                name: "IX_CommentUserProfiles_UserProfileId",
                table: "CommentUserProfiles");

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Comments");

            migrationBuilder.CreateIndex(
                name: "IX_CommentUserProfiles_UserProfileId",
                table: "CommentUserProfiles",
                column: "UserProfileId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentUserProfiles_Profiles_UserProfileId",
                table: "CommentUserProfiles",
                column: "UserProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
