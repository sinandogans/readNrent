using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookService.Persistence.Migrations
{
    public partial class mig_6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TranslatorModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslatorModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthorModelBook",
                columns: table => new
                {
                    AuthorsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BooksId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorModelBook", x => new { x.AuthorsId, x.BooksId });
                    table.ForeignKey(
                        name: "FK_AuthorModelBook_AuthorModel_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "AuthorModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorModelBook_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookTranslatorModel",
                columns: table => new
                {
                    BooksId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TranslatorsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTranslatorModel", x => new { x.BooksId, x.TranslatorsId });
                    table.ForeignKey(
                        name: "FK_BookTranslatorModel_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookTranslatorModel_TranslatorModel_TranslatorsId",
                        column: x => x.TranslatorsId,
                        principalTable: "TranslatorModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorModelBook_BooksId",
                table: "AuthorModelBook",
                column: "BooksId");

            migrationBuilder.CreateIndex(
                name: "IX_BookTranslatorModel_TranslatorsId",
                table: "BookTranslatorModel",
                column: "TranslatorsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorModelBook");

            migrationBuilder.DropTable(
                name: "BookTranslatorModel");

            migrationBuilder.DropTable(
                name: "AuthorModel");

            migrationBuilder.DropTable(
                name: "TranslatorModel");
        }
    }
}
