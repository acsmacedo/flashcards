using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlashCards.Api.Repository.Migrations
{
    public partial class UpdatePhotosUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: -10,
                column: "photo",
                value: "http://acsmacedo.somee.com/images/photos/photo--10.jpg");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: -9,
                column: "photo",
                value: "http://acsmacedo.somee.com/images/photos/photo--9.jpg");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: -8,
                column: "photo",
                value: "http://acsmacedo.somee.com/images/photos/photo--8.jpg");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: -7,
                column: "photo",
                value: "http://acsmacedo.somee.com/images/photos/photo--7.jpg");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: -6,
                column: "photo",
                value: "http://acsmacedo.somee.com/images/photos/photo--6.jpg");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: -5,
                columns: new[] { "name", "photo" },
                values: new object[] { "Aldo Ferreira", "http://acsmacedo.somee.com/images/photos/photo--5.jpg" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: -4,
                column: "photo",
                value: "http://acsmacedo.somee.com/images/photos/photo--4.jpg");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: -3,
                column: "photo",
                value: "http://acsmacedo.somee.com/images/photos/photo--3.jpg");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: -2,
                column: "photo",
                value: "http://acsmacedo.somee.com/images/photos/photo--2.jpg");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: -1,
                column: "photo",
                value: "http://acsmacedo.somee.com/images/photos/photo--1.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "name", "photo" },
                values: new object[] { "Ana Ferreira", "http://acsmacedo.somee.com/photos/photo--5.png" });

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
    }
}
