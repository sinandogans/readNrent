using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthorTranslatorService.Persistence.Migrations
{
    public partial class mig_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthor");

            migrationBuilder.DropTable(
                name: "BookTranslator");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "TranslatorReviews",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Translator",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReviewCount",
                table: "Translator",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BookModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthorBookModel",
                columns: table => new
                {
                    AuthorsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BooksId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBookModel", x => new { x.AuthorsId, x.BooksId });
                    table.ForeignKey(
                        name: "FK_AuthorBookModel_Author_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBookModel_BookModels_BooksId",
                        column: x => x.BooksId,
                        principalTable: "BookModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookModelTranslator",
                columns: table => new
                {
                    BooksId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TranslatorsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookModelTranslator", x => new { x.BooksId, x.TranslatorsId });
                    table.ForeignKey(
                        name: "FK_BookModelTranslator_BookModels_BooksId",
                        column: x => x.BooksId,
                        principalTable: "BookModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookModelTranslator_Translator_TranslatorsId",
                        column: x => x.TranslatorsId,
                        principalTable: "Translator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBookModel_BooksId",
                table: "AuthorBookModel",
                column: "BooksId");

            migrationBuilder.CreateIndex(
                name: "IX_BookModelTranslator_TranslatorsId",
                table: "BookModelTranslator",
                column: "TranslatorsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorBookModel");

            migrationBuilder.DropTable(
                name: "BookModelTranslator");

            migrationBuilder.DropTable(
                name: "BookModels");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "TranslatorReviews");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Translator");

            migrationBuilder.DropColumn(
                name: "ReviewCount",
                table: "Translator");

            migrationBuilder.CreateTable(
                name: "BookAuthor",
                columns: table => new
                {
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_BookAuthor_Translator_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Translator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookTranslator",
                columns: table => new
                {
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TranslatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_BookTranslator_Translator_TranslatorId",
                        column: x => x.TranslatorId,
                        principalTable: "Translator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthor_AuthorId",
                table: "BookAuthor",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BookTranslator_TranslatorId",
                table: "BookTranslator",
                column: "TranslatorId");
        }
    }
}
