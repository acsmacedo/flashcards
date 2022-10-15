using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlashCards.Api.Repository.Migrations
{
    public partial class AjustFlashcardRatingEAdicionaCategorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_flash_card_ratings_flash_card_collections_flash_card_collection_id",
                table: "flash_card_ratings");

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "category_id", "image", "name" },
                values: new object[,]
                {
                    { -8, "http://acsmacedo.somee.com/images/categories/categoria_saude.png", "Saúde" },
                    { -7, "http://acsmacedo.somee.com/images/categories/categoria_programacao.png", "Programação" },
                    { -6, "http://acsmacedo.somee.com/images/categories/categoria_literatura.png", "Literatura" },
                    { -5, "http://acsmacedo.somee.com/images/categories/categoria_geografia.png", "Geografia" },
                    { -4, "http://acsmacedo.somee.com/images/categories/categoria_financas.png", "Finanças" },
                    { -3, "http://acsmacedo.somee.com/images/categories/categoria_design.png", "Design" },
                    { -2, "http://acsmacedo.somee.com/images/categories/categoria_arquitetura.png", "Arquitetura" },
                    { -1, "http://acsmacedo.somee.com/images/categories/categoria_administracao.png", "Administração" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_flash_card_ratings_user_id",
                table: "flash_card_ratings",
                column: "user_id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_flash_card_ratings_flash_card_collections_flash_card_collection_id",
                table: "flash_card_ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_flash_card_ratings_users_user_id",
                table: "flash_card_ratings");

            migrationBuilder.DropIndex(
                name: "IX_flash_card_ratings_user_id",
                table: "flash_card_ratings");

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "category_id",
                keyValue: -8);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "category_id",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "category_id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "category_id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "category_id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "category_id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "category_id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "category_id",
                keyValue: -1);

            migrationBuilder.AddForeignKey(
                name: "FK_flash_card_ratings_flash_card_collections_flash_card_collection_id",
                table: "flash_card_ratings",
                column: "flash_card_collection_id",
                principalTable: "flash_card_collections",
                principalColumn: "flash_card_collection_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
