using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthorTranslatorService.Persistence.Migrations
{
    public partial class mig_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorReviews_Authors_AuthorId",
                table: "AuthorReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthor_Authors_AuthorId",
                table: "BookAuthor");

            migrationBuilder.DropForeignKey(
                name: "FK_BookTranslator_Translators_TranslatorId",
                table: "BookTranslator");

            migrationBuilder.DropForeignKey(
                name: "FK_TranslatorReviews_Translators_TranslatorId",
                table: "TranslatorReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Translators",
                table: "Translators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.RenameTable(
                name: "Translators",
                newName: "Translator");

            migrationBuilder.RenameTable(
                name: "Authors",
                newName: "Author");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "AuthorReviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Author",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReviewCount",
                table: "Author",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Translator",
                table: "Translator",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Author",
                table: "Author",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorReviews_Author_AuthorId",
                table: "AuthorReviews",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthor_Translator_AuthorId",
                table: "BookAuthor",
                column: "AuthorId",
                principalTable: "Translator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookTranslator_Translator_TranslatorId",
                table: "BookTranslator",
                column: "TranslatorId",
                principalTable: "Translator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TranslatorReviews_Translator_TranslatorId",
                table: "TranslatorReviews",
                column: "TranslatorId",
                principalTable: "Translator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorReviews_Author_AuthorId",
                table: "AuthorReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthor_Translator_AuthorId",
                table: "BookAuthor");

            migrationBuilder.DropForeignKey(
                name: "FK_BookTranslator_Translator_TranslatorId",
                table: "BookTranslator");

            migrationBuilder.DropForeignKey(
                name: "FK_TranslatorReviews_Translator_TranslatorId",
                table: "TranslatorReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Translator",
                table: "Translator");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Author",
                table: "Author");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "AuthorReviews");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Author");

            migrationBuilder.DropColumn(
                name: "ReviewCount",
                table: "Author");

            migrationBuilder.RenameTable(
                name: "Translator",
                newName: "Translators");

            migrationBuilder.RenameTable(
                name: "Author",
                newName: "Authors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Translators",
                table: "Translators",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorReviews_Authors_AuthorId",
                table: "AuthorReviews",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthor_Authors_AuthorId",
                table: "BookAuthor",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookTranslator_Translators_TranslatorId",
                table: "BookTranslator",
                column: "TranslatorId",
                principalTable: "Translators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TranslatorReviews_Translators_TranslatorId",
                table: "TranslatorReviews",
                column: "TranslatorId",
                principalTable: "Translators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
