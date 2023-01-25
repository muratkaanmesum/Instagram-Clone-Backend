using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Instagram_Clone_Backend.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Profiles_UserProfileId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "UserProfileId",
                table: "Comments",
                newName: "ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserProfileId",
                table: "Comments",
                newName: "IX_Comments_ProfileId");

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Profiles_ProfileId",
                table: "Comments",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Profiles_ProfileId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_PostId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "Comments",
                newName: "UserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ProfileId",
                table: "Comments",
                newName: "IX_Comments_UserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Profiles_UserProfileId",
                table: "Comments",
                column: "UserProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
