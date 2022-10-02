using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlashCards.Api.Repository.Migrations
{
    public partial class AddSubscriptionAndNotificationSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubscriptionTypeID",
                table: "users",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_users_SubscriptionTypeID",
                table: "users",
                column: "SubscriptionTypeID",
                unique: true,
                filter: "[SubscriptionTypeID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_subscription_type_benefits_subscription_type_id",
                table: "subscription_type_benefits",
                column: "subscription_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_notification_settings_notification_setting_id",
                table: "user_notification_settings",
                column: "notification_setting_id");

            migrationBuilder.AddForeignKey(
                name: "FK_users_subscription_types_SubscriptionTypeID",
                table: "users",
                column: "SubscriptionTypeID",
                principalTable: "subscription_types",
                principalColumn: "subscription_type_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_subscription_types_SubscriptionTypeID",
                table: "users");

            migrationBuilder.DropTable(
                name: "subscription_type_benefits");

            migrationBuilder.DropTable(
                name: "user_notification_settings");

            migrationBuilder.DropTable(
                name: "subscription_types");

            migrationBuilder.DropTable(
                name: "notification_settings");

            migrationBuilder.DropIndex(
                name: "IX_users_SubscriptionTypeID",
                table: "users");

            migrationBuilder.DropColumn(
                name: "SubscriptionTypeID",
                table: "users");
        }
    }
}
