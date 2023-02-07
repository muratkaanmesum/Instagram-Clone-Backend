using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Instagram_Clone_Backend.Migrations
{
    public partial class te3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FollowerId",
                table: "Followers",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Followers_Profiles_FollowerProfileId",
                table: "Followers");

            migrationBuilder.DropIndex(
                name: "IX_Followers_FollowerProfileId",
                table: "Followers");

            migrationBuilder.DropColumn(
                name: "FollowerId",
                table: "Followers");

            migrationBuilder.DropColumn(
                name: "FollowerProfileId",
                table: "Followers");
        }
    }
}
