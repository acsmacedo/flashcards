using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlashCards.Api.Repository.Migrations
{
    public partial class teste2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "accounts",
                keyColumn: "account_id",
                keyValue: -10,
                column: "email",
                value: "teste");

            migrationBuilder.UpdateData(
                table: "accounts",
                keyColumn: "account_id",
                keyValue: -9,
                column: "email",
                value: "bruno");

            migrationBuilder.UpdateData(
                table: "accounts",
                keyColumn: "account_id",
                keyValue: -8,
                column: "email",
                value: "otavio");

            migrationBuilder.UpdateData(
                table: "accounts",
                keyColumn: "account_id",
                keyValue: -7,
                column: "email",
                value: "fernanda");

            migrationBuilder.UpdateData(
                table: "accounts",
                keyColumn: "account_id",
                keyValue: -6,
                column: "email",
                value: "patricia");

            migrationBuilder.UpdateData(
                table: "accounts",
                keyColumn: "account_id",
                keyValue: -5,
                column: "email",
                value: "ana");

            migrationBuilder.UpdateData(
                table: "accounts",
                keyColumn: "account_id",
                keyValue: -4,
                column: "email",
                value: "paulo");

            migrationBuilder.UpdateData(
                table: "accounts",
                keyColumn: "account_id",
                keyValue: -3,
                column: "email",
                value: "gustavo");

            migrationBuilder.UpdateData(
                table: "accounts",
                keyColumn: "account_id",
                keyValue: -2,
                column: "email",
                value: "maria");

            migrationBuilder.UpdateData(
                table: "accounts",
                keyColumn: "account_id",
                keyValue: -1,
                column: "email",
                value: "anderson");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "accounts",
                keyColumn: "account_id",
                keyValue: -10,
                column: "email",
                value: "teste@flashcard.com.br");

            migrationBuilder.UpdateData(
                table: "accounts",
                keyColumn: "account_id",
                keyValue: -9,
                column: "email",
                value: "bruno@flashcard.com.br");

            migrationBuilder.UpdateData(
                table: "accounts",
                keyColumn: "account_id",
                keyValue: -8,
                column: "email",
                value: "otavio@flashcard.com.br");

            migrationBuilder.UpdateData(
                table: "accounts",
                keyColumn: "account_id",
                keyValue: -7,
                column: "email",
                value: "fernanda@flashcard.com.br");

            migrationBuilder.UpdateData(
                table: "accounts",
                keyColumn: "account_id",
                keyValue: -6,
                column: "email",
                value: "patricia@flashcard.com.br");

            migrationBuilder.UpdateData(
                table: "accounts",
                keyColumn: "account_id",
                keyValue: -5,
                column: "email",
                value: "ana@flashcard.com.br");

            migrationBuilder.UpdateData(
                table: "accounts",
                keyColumn: "account_id",
                keyValue: -4,
                column: "email",
                value: "paulo@flashcard.com.br");

            migrationBuilder.UpdateData(
                table: "accounts",
                keyColumn: "account_id",
                keyValue: -3,
                column: "email",
                value: "gustavo@flashcard.com.br");

            migrationBuilder.UpdateData(
                table: "accounts",
                keyColumn: "account_id",
                keyValue: -2,
                column: "email",
                value: "maria@flashcard.com.br");

            migrationBuilder.UpdateData(
                table: "accounts",
                keyColumn: "account_id",
                keyValue: -1,
                column: "email",
                value: "anderson@flashcard.com.br");
        }
    }
}
