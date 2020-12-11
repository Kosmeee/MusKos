using Microsoft.EntityFrameworkCore.Migrations;

namespace MusKos.Data.Migrations
{
    public partial class UserEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlaylistId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PlaylistId",
                table: "AspNetUsers",
                column: "PlaylistId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Playlists_PlaylistId",
                table: "AspNetUsers",
                column: "PlaylistId",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Playlists_PlaylistId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PlaylistId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PlaylistId",
                table: "AspNetUsers");
        }
    }
}
