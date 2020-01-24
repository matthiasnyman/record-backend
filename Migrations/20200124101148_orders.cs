using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace record_backend.Migrations
{
    public partial class orders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Artist = table.Column<string>(nullable: false),
                    Album = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Sale = table.Column<decimal>(nullable: false),
                    Info = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductsInGenre",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GenreId = table.Column<int>(nullable: false),
                    RecordId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsInGenre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductsInGenre_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsInGenre_Records_RecordId",
                        column: x => x.RecordId,
                        principalTable: "Records",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RecordId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carts_Records_RecordId",
                        column: x => x.RecordId,
                        principalTable: "Records",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Pop" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Rock" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Blues" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Hiphop" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Raggae" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "Punk" });

            migrationBuilder.InsertData(
                table: "Records",
                columns: new[] { "Id", "Album", "Artist", "Image", "Info", "Price", "Sale" },
                values: new object[] { 1, "ABBA the album", "ABBA", "https://www.bengans.se/bilder/artiklar/liten/2572243_S.jpg", "Skivan är ok..", 120.00m, 0m });

            migrationBuilder.InsertData(
                table: "Records",
                columns: new[] { "Id", "Album", "Artist", "Image", "Info", "Price", "Sale" },
                values: new object[] { 2, "Röd", "Kent", "https://www.bengans.se/bilder/artiklar/liten/1689651_S.jpg", "Skivan är fantastisk!", 200.00m, 0m });

            migrationBuilder.InsertData(
                table: "Records",
                columns: new[] { "Id", "Album", "Artist", "Image", "Info", "Price", "Sale" },
                values: new object[] { 3, "2 steg från paridise", "Håkan Hellström", "https://www.bengans.se/bilder/artiklar/liten/619835_S.jpg", "Håkan bråkan!", 130.00m, 0m });

            migrationBuilder.InsertData(
                table: "Records",
                columns: new[] { "Id", "Album", "Artist", "Image", "Info", "Price", "Sale" },
                values: new object[] { 4, "Boston vol:2", "Fleetwood mac", "https://www.bengans.se/bilder/artiklar/liten/3601538_S.jpg", "Simon gillat!", 200.00m, 0m });

            migrationBuilder.InsertData(
                table: "Records",
                columns: new[] { "Id", "Album", "Artist", "Image", "Info", "Price", "Sale" },
                values: new object[] { 5, "Bourn in the USA", "Bruse Springstin", "https://www.bengans.se/bilder/artiklar/liten/1533609_S.jpg", "brusse!", 20.00m, 0m });

            migrationBuilder.InsertData(
                table: "Records",
                columns: new[] { "Id", "Album", "Artist", "Image", "Info", "Price", "Sale" },
                values: new object[] { 6, "Hot in the shade", "Kiss", "https://www.bengans.se/bilder/artiklar/liten/3496044_S.jpg", "brusse!", 2000.00m, 0m });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[] { 7, "att@att.se", "Matthias", "Nyman" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[] { 8, "Kalle@attd.se", "Kalle", "Nyman" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Created", "UserId" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Created", "UserId" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 });

            migrationBuilder.InsertData(
                table: "ProductsInGenre",
                columns: new[] { "Id", "GenreId", "RecordId" },
                values: new object[] { 1, 2, 1 });

            migrationBuilder.InsertData(
                table: "ProductsInGenre",
                columns: new[] { "Id", "GenreId", "RecordId" },
                values: new object[] { 2, 1, 2 });

            migrationBuilder.InsertData(
                table: "ProductsInGenre",
                columns: new[] { "Id", "GenreId", "RecordId" },
                values: new object[] { 3, 1, 3 });

            migrationBuilder.InsertData(
                table: "ProductsInGenre",
                columns: new[] { "Id", "GenreId", "RecordId" },
                values: new object[] { 4, 1, 4 });

            migrationBuilder.InsertData(
                table: "ProductsInGenre",
                columns: new[] { "Id", "GenreId", "RecordId" },
                values: new object[] { 5, 3, 4 });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "OrderId", "RecordId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "OrderId", "RecordId" },
                values: new object[] { 2, 1, 2 });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "OrderId", "RecordId" },
                values: new object[] { 3, 1, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_OrderId",
                table: "Carts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_RecordId",
                table: "Carts",
                column: "RecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsInGenre_GenreId",
                table: "ProductsInGenre",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsInGenre_RecordId",
                table: "ProductsInGenre",
                column: "RecordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "ProductsInGenre");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Records");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
