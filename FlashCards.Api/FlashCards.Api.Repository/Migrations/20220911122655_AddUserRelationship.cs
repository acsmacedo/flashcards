using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlashCards.Api.Repository.Migrations
{
    public partial class AddUserRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user_relationships",
                columns: table => new
                {
                    followed_id = table.Column<int>(type: "int", nullable: false),
                    follower_id = table.Column<int>(type: "int", nullable: false),
                    enable_notification = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_relationship", x => new { x.followed_id, x.follower_id });
                    table.ForeignKey(
                        name: "FK_user_relationships_users_followed_id",
                        column: x => x.followed_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                    table.ForeignKey(
                        name: "FK_user_relationships_users_follower_id",
                        column: x => x.follower_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_relationships_follower_id",
                table: "user_relationships",
                column: "follower_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_relationships");
        }
    }
}
