using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlashCards.Api.Repository.Migrations
{
    public partial class AddUserDirectoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user_directories",
                columns: table => new
                {
                    user_directory_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_directory_parent_id = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_directory_id", x => x.user_directory_id);
                    table.ForeignKey(
                        name: "FK_user_directories_user_directories_user_directory_parent_id",
                        column: x => x.user_directory_parent_id,
                        principalTable: "user_directories",
                        principalColumn: "user_directory_id");
                    table.ForeignKey(
                        name: "FK_user_directories_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlashCardCollection",
                columns: table => new
                {
                    FlashCardCollectionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    UserDirectoryID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlashCardCollection", x => x.FlashCardCollectionID);
                    table.ForeignKey(
                        name: "FK_FlashCardCollection_categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "categories",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlashCardCollection_user_directories_UserDirectoryID",
                        column: x => x.UserDirectoryID,
                        principalTable: "user_directories",
                        principalColumn: "user_directory_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlashCardItem",
                columns: table => new
                {
                    FlashCardItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FrontDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerseDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CollectionFlashCardCollectionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlashCardItem", x => x.FlashCardItemID);
                    table.ForeignKey(
                        name: "FK_FlashCardItem_FlashCardCollection_CollectionFlashCardCollectionID",
                        column: x => x.CollectionFlashCardCollectionID,
                        principalTable: "FlashCardCollection",
                        principalColumn: "FlashCardCollectionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlashCardRating",
                columns: table => new
                {
                    FlashCardRatingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CollectionFlashCardCollectionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlashCardRating", x => x.FlashCardRatingID);
                    table.ForeignKey(
                        name: "FK_FlashCardRating_FlashCardCollection_CollectionFlashCardCollectionID",
                        column: x => x.CollectionFlashCardCollectionID,
                        principalTable: "FlashCardCollection",
                        principalColumn: "FlashCardCollectionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlashCardTag",
                columns: table => new
                {
                    FlashCardTagID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CollectionFlashCardCollectionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlashCardTag", x => x.FlashCardTagID);
                    table.ForeignKey(
                        name: "FK_FlashCardTag_FlashCardCollection_CollectionFlashCardCollectionID",
                        column: x => x.CollectionFlashCardCollectionID,
                        principalTable: "FlashCardCollection",
                        principalColumn: "FlashCardCollectionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlashCardCollection_CategoryID",
                table: "FlashCardCollection",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_FlashCardCollection_UserDirectoryID",
                table: "FlashCardCollection",
                column: "UserDirectoryID");

            migrationBuilder.CreateIndex(
                name: "IX_FlashCardItem_CollectionFlashCardCollectionID",
                table: "FlashCardItem",
                column: "CollectionFlashCardCollectionID");

            migrationBuilder.CreateIndex(
                name: "IX_FlashCardRating_CollectionFlashCardCollectionID",
                table: "FlashCardRating",
                column: "CollectionFlashCardCollectionID");

            migrationBuilder.CreateIndex(
                name: "IX_FlashCardTag_CollectionFlashCardCollectionID",
                table: "FlashCardTag",
                column: "CollectionFlashCardCollectionID");

            migrationBuilder.CreateIndex(
                name: "IX_user_directories_user_directory_parent_id",
                table: "user_directories",
                column: "user_directory_parent_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_directories_user_id",
                table: "user_directories",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlashCardItem");

            migrationBuilder.DropTable(
                name: "FlashCardRating");

            migrationBuilder.DropTable(
                name: "FlashCardTag");

            migrationBuilder.DropTable(
                name: "FlashCardCollection");

            migrationBuilder.DropTable(
                name: "user_directories");
        }
    }
}
