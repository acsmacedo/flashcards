using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlashCards.Api.Repository.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    account_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    password = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_account_id", x => x.account_id);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    image = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_category_id", x => x.category_id);
                });

            migrationBuilder.CreateTable(
                name: "notification_settings",
                columns: table => new
                {
                    notification_setting_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    description = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_notification_setting_id", x => x.notification_setting_id);
                });

            migrationBuilder.CreateTable(
                name: "subscription_types",
                columns: table => new
                {
                    subscription_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    price = table.Column<decimal>(type: "smallmoney", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_subscription_type_id", x => x.subscription_type_id);
                });

            migrationBuilder.CreateTable(
                name: "subscription_type_benefits",
                columns: table => new
                {
                    subscription_type_benefit_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subscription_type_id = table.Column<int>(type: "int", nullable: false),
                    benefit = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_subscription_type_benefit_id", x => x.subscription_type_benefit_id);
                    table.ForeignKey(
                        name: "FK_subscription_type_benefits_subscription_types_subscription_type_id",
                        column: x => x.subscription_type_id,
                        principalTable: "subscription_types",
                        principalColumn: "subscription_type_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    account_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    instagram = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: true),
                    interests = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: true),
                    SubscriptionTypeID = table.Column<int>(type: "int", nullable: true),
                    photo = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_id", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_users_accounts_account_id",
                        column: x => x.account_id,
                        principalTable: "accounts",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_users_subscription_types_SubscriptionTypeID",
                        column: x => x.SubscriptionTypeID,
                        principalTable: "subscription_types",
                        principalColumn: "subscription_type_id");
                });

            migrationBuilder.CreateTable(
                name: "denunciations",
                columns: table => new
                {
                    denunciation_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    accuser_id = table.Column<int>(type: "int", nullable: false),
                    suspect_id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_denunciation_id", x => x.denunciation_id);
                    table.ForeignKey(
                        name: "FK_denunciations_users_accuser_id",
                        column: x => x.accuser_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                    table.ForeignKey(
                        name: "FK_denunciations_users_suspect_id",
                        column: x => x.suspect_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "notifications",
                columns: table => new
                {
                    notification_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    notification_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    sent_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    read_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    message = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_notification_id", x => x.notification_id);
                    table.ForeignKey(
                        name: "FK_notifications_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "user_notification_settings",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false),
                    notification_setting_id = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_notification_setting_id", x => new { x.user_id, x.notification_setting_id });
                    table.ForeignKey(
                        name: "FK_user_notification_settings_notification_settings_notification_setting_id",
                        column: x => x.notification_setting_id,
                        principalTable: "notification_settings",
                        principalColumn: "notification_setting_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_notification_settings_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "flash_card_collections",
                columns: table => new
                {
                    flash_card_collection_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    user_directory_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    description = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_flash_card_collection_id", x => x.flash_card_collection_id);
                    table.ForeignKey(
                        name: "FK_flash_card_collections_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_flash_card_collections_user_directories_user_directory_id",
                        column: x => x.user_directory_id,
                        principalTable: "user_directories",
                        principalColumn: "user_directory_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "flash_card_items",
                columns: table => new
                {
                    flash_card_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    flash_card_collection_id = table.Column<int>(type: "int", nullable: false),
                    front_description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    verse_description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_flash_card_id", x => x.flash_card_id);
                    table.ForeignKey(
                        name: "FK_flash_card_items_flash_card_collections_flash_card_collection_id",
                        column: x => x.flash_card_collection_id,
                        principalTable: "flash_card_collections",
                        principalColumn: "flash_card_collection_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "flash_card_ratings",
                columns: table => new
                {
                    flash_card_rating_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    flash_card_collection_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: false),
                    comment = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_flash_card_rating_id", x => x.flash_card_rating_id);
                    table.ForeignKey(
                        name: "FK_flash_card_ratings_flash_card_collections_flash_card_collection_id",
                        column: x => x.flash_card_collection_id,
                        principalTable: "flash_card_collections",
                        principalColumn: "flash_card_collection_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "flash_card_tags",
                columns: table => new
                {
                    flash_card_tag_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_flash_card_tag_id", x => x.flash_card_tag_id);
                    table.ForeignKey(
                        name: "FK_flash_card_tags_flash_card_collections_flash_card_tag_id",
                        column: x => x.flash_card_tag_id,
                        principalTable: "flash_card_collections",
                        principalColumn: "flash_card_collection_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_denunciations_accuser_id",
                table: "denunciations",
                column: "accuser_id");

            migrationBuilder.CreateIndex(
                name: "IX_denunciations_suspect_id",
                table: "denunciations",
                column: "suspect_id");

            migrationBuilder.CreateIndex(
                name: "IX_flash_card_collections_category_id",
                table: "flash_card_collections",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_flash_card_collections_user_directory_id",
                table: "flash_card_collections",
                column: "user_directory_id");

            migrationBuilder.CreateIndex(
                name: "IX_flash_card_items_flash_card_collection_id",
                table: "flash_card_items",
                column: "flash_card_collection_id");

            migrationBuilder.CreateIndex(
                name: "IX_flash_card_ratings_flash_card_collection_id",
                table: "flash_card_ratings",
                column: "flash_card_collection_id");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_user_id",
                table: "notifications",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_subscription_type_benefits_subscription_type_id",
                table: "subscription_type_benefits",
                column: "subscription_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_directories_user_directory_parent_id",
                table: "user_directories",
                column: "user_directory_parent_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_directories_user_id",
                table: "user_directories",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_notification_settings_notification_setting_id",
                table: "user_notification_settings",
                column: "notification_setting_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_relationships_follower_id",
                table: "user_relationships",
                column: "follower_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_account_id",
                table: "users",
                column: "account_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_SubscriptionTypeID",
                table: "users",
                column: "SubscriptionTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "denunciations");

            migrationBuilder.DropTable(
                name: "flash_card_items");

            migrationBuilder.DropTable(
                name: "flash_card_ratings");

            migrationBuilder.DropTable(
                name: "flash_card_tags");

            migrationBuilder.DropTable(
                name: "notifications");

            migrationBuilder.DropTable(
                name: "subscription_type_benefits");

            migrationBuilder.DropTable(
                name: "user_notification_settings");

            migrationBuilder.DropTable(
                name: "user_relationships");

            migrationBuilder.DropTable(
                name: "flash_card_collections");

            migrationBuilder.DropTable(
                name: "notification_settings");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "user_directories");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "subscription_types");
        }
    }
}
