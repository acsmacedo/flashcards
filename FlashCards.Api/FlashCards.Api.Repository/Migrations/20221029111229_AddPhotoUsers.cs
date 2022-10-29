using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlashCards.Api.Repository.Migrations
{
    public partial class AddPhotoUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: -10,
                column: "photo",
                value: "http://acsmacedo.somee.com/photos/photo--10.png");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: -9,
                column: "photo",
                value: "http://acsmacedo.somee.com/photos/photo--9.png");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: -8,
                column: "photo",
                value: "http://acsmacedo.somee.com/photos/photo--8.png");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: -7,
                column: "photo",
                value: "http://acsmacedo.somee.com/photos/photo--7.png");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: -6,
                column: "photo",
                value: "http://acsmacedo.somee.com/photos/photo--6.png");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: -5,
                column: "photo",
                value: "http://acsmacedo.somee.com/photos/photo--5.png");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: -4,
                column: "photo",
                value: "http://acsmacedo.somee.com/photos/photo--4.png");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: -3,
                column: "photo",
                value: "http://acsmacedo.somee.com/photos/photo--3.png");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: -2,
                column: "photo",
                value: "http://acsmacedo.somee.com/photos/photo--2.png");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: -1,
                column: "photo",
                value: "http://acsmacedo.somee.com/photos/photo--1.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: -10,
                column: "photo",
                value: null);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: -9,
                column: "photo",
                value: null);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: -8,
                column: "photo",
                value: null);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: -7,
                column: "photo",
                value: null);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: -6,
                column: "photo",
                value: null);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: -5,
                column: "photo",
                value: null);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: -4,
                column: "photo",
                value: null);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: -3,
                column: "photo",
                value: null);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: -2,
                column: "photo",
                value: null);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: -1,
                column: "photo",
                value: null);
        }
    }
}
