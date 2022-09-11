using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlashCards.Api.Repository.Migrations
{
    public partial class AddNotificationAndDenunciationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_denunciations_accuser_id",
                table: "denunciations",
                column: "accuser_id");

            migrationBuilder.CreateIndex(
                name: "IX_denunciations_suspect_id",
                table: "denunciations",
                column: "suspect_id");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_user_id",
                table: "notifications",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "denunciations");

            migrationBuilder.DropTable(
                name: "notifications");
        }
    }
}
