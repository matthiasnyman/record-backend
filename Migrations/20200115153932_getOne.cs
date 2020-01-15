using Microsoft.EntityFrameworkCore.Migrations;

namespace record_backend.Migrations
{
    public partial class getOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(nullable: true),
                    Recomend = table.Column<bool>(nullable: false)
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
                name: "ProductGenres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GenreId = table.Column<int>(nullable: false),
                    RecordId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGenres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductGenres_Records_RecordId",
                        column: x => x.RecordId,
                        principalTable: "Records",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(nullable: false),
                    RecordId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Records_RecordId",
                        column: x => x.RecordId,
                        principalTable: "Records",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CartId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Records",
                columns: new[] { "Id", "Album", "Artist", "Image", "Info", "Price", "Sale" },
                values: new object[] { 1, "Greatest hits", "ABBA", "/image1", "Skivan är ok..", 120.00m, 0m });

            migrationBuilder.InsertData(
                table: "Records",
                columns: new[] { "Id", "Album", "Artist", "Image", "Info", "Price", "Sale" },
                values: new object[] { 2, "Röd", "Kent", "'/image2", "Skivan är fantastisk!", 200.00m, 0m });

            migrationBuilder.InsertData(
                table: "Records",
                columns: new[] { "Id", "Album", "Artist", "Image", "Info", "Price", "Sale" },
                values: new object[] { 3, "2 steg från paridise", "Håkan Hellström", "'/image2", "Håkan bråkan!", 130.00m, 0m });

            migrationBuilder.InsertData(
                table: "Records",
                columns: new[] { "Id", "Album", "Artist", "Image", "Info", "Price", "Sale" },
                values: new object[] { 4, "The roumers", "Fleetwood mac", "'/image2", "Simon gillat!", 200.00m, 0m });

            migrationBuilder.InsertData(
                table: "Records",
                columns: new[] { "Id", "Album", "Artist", "Image", "Info", "Price", "Sale" },
                values: new object[] { 5, "Bourn in the USA", "Bruse Springstin", "'/image7", "brusse!", 20.00m, 0m });

            migrationBuilder.InsertData(
                table: "Records",
                columns: new[] { "Id", "Album", "Artist", "Image", "Info", "Price", "Sale" },
                values: new object[] { 6, "Dynasti", "Kiss", "'/image7", "brusse!", 2000.00m, 0m });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[] { 7, "att@att.se", "Matthias", "Nyman" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[] { 8, "Kalle@attd.se", "Kalle", "Nyman" });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_RecordId",
                table: "Carts",
                column: "RecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CartId",
                table: "Orders",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGenres_GenreId",
                table: "ProductGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGenres_RecordId",
                table: "ProductGenres",
                column: "RecordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ProductGenres");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Records");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
