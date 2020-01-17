using Microsoft.EntityFrameworkCore.Migrations;

namespace record_backend.Migrations
{
    public partial class addedLinks2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Records",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "https://www.bengans.se/bilder/artiklar/liten/1689651_S.jpg");

            migrationBuilder.UpdateData(
                table: "Records",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "https://www.bengans.se/bilder/artiklar/liten/619835_S.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Records",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "'https://www.bengans.se/bilder/artiklar/liten/1689651_S.jpg");

            migrationBuilder.UpdateData(
                table: "Records",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "'https://www.bengans.se/bilder/artiklar/liten/619835_S.jpg");
        }
    }
}
