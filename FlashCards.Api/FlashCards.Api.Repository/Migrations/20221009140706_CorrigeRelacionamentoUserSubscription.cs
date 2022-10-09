using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlashCards.Api.Repository.Migrations
{
    public partial class CorrigeRelacionamentoUserSubscription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_users_SubscriptionTypeID",
                table: "users");

            migrationBuilder.CreateIndex(
                name: "IX_users_SubscriptionTypeID",
                table: "users",
                column: "SubscriptionTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_users_SubscriptionTypeID",
                table: "users");

            migrationBuilder.CreateIndex(
                name: "IX_users_SubscriptionTypeID",
                table: "users",
                column: "SubscriptionTypeID",
                unique: true,
                filter: "[SubscriptionTypeID] IS NOT NULL");
        }
    }
}
