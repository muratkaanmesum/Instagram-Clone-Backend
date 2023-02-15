using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Instagram_Clone_Backend.Migrations
{
    public partial class te4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Followers_Profiles_FollowerProfileId",
                table: "Followers");

            migrationBuilder.DropIndex(
                name: "IX_Followers_FollowerProfileId",
                table: "Followers");

            migrationBuilder.DropColumn(
                name: "FollowerProfileId",
                table: "Followers");

            migrationBuilder.CreateIndex(
                name: "IX_Followers_FollowerId",
                table: "Followers",
                column: "FollowerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Followers_Profiles_FollowerId",
                table: "Followers",
                column: "FollowerId",
                principalTable: "Profiles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Followers_Profiles_FollowerId",
                table: "Followers");

            migrationBuilder.DropIndex(
                name: "IX_Followers_FollowerId",
                table: "Followers");

            migrationBuilder.AddColumn<int>(
                name: "FollowerProfileId",
                table: "Followers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Followers_FollowerProfileId",
                table: "Followers",
                column: "FollowerProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Followers_Profiles_FollowerProfileId",
                table: "Followers",
                column: "FollowerProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
