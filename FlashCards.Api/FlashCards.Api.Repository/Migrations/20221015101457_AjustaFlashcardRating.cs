using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlashCards.Api.Repository.Migrations
{
    public partial class AjustaFlashcardRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_flash_card_ratings_flash_card_collections_flash_card_collection_id",
                table: "flash_card_ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_flash_card_ratings_users_user_id",
                table: "flash_card_ratings");

            migrationBuilder.AddForeignKey(
                name: "FK_flash_card_ratings_flash_card_collections_flash_card_collection_id",
                table: "flash_card_ratings",
                column: "flash_card_collection_id",
                principalTable: "flash_card_collections",
                principalColumn: "flash_card_collection_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_flash_card_ratings_users_user_id",
                table: "flash_card_ratings",
                column: "user_id",
                principalTable: "users",
                principalColumn: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_flash_card_ratings_flash_card_collections_flash_card_collection_id",
                table: "flash_card_ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_flash_card_ratings_users_user_id",
                table: "flash_card_ratings");

            migrationBuilder.AddForeignKey(
                name: "FK_flash_card_ratings_flash_card_collections_flash_card_collection_id",
                table: "flash_card_ratings",
                column: "flash_card_collection_id",
                principalTable: "flash_card_collections",
                principalColumn: "flash_card_collection_id");

            migrationBuilder.AddForeignKey(
                name: "FK_flash_card_ratings_users_user_id",
                table: "flash_card_ratings",
                column: "user_id",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
