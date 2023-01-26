using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Instagram_Clone_Backend.Migrations
{
    public partial class test5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Like_UserProfileId",
                table: "Like",
                column: "UserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Like_Profiles_UserProfileId",
                table: "Like",
                column: "UserProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Like_Profiles_UserProfileId",
                table: "Like");

            migrationBuilder.DropIndex(
                name: "IX_Like_UserProfileId",
                table: "Like");
        }
    }
}
