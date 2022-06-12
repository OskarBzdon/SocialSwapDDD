using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialSwap.Api.Migrations
{
    public partial class TitleItemAdeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_User_ClientId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_ClientId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Items",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Items_OwnerId",
                table: "Items",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_User_OwnerId",
                table: "Items",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_User_OwnerId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_OwnerId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_ClientId",
                table: "Items",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_User_ClientId",
                table: "Items",
                column: "ClientId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
