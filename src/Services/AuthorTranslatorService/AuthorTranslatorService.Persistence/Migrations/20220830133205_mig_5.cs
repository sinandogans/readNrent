using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthorTranslatorService.Persistence.Migrations
{
    public partial class mig_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBookModel_BookModels_BooksId",
                table: "AuthorBookModel");

            migrationBuilder.DropForeignKey(
                name: "FK_BookModelTranslator_BookModels_BooksId",
                table: "BookModelTranslator");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookModels",
                table: "BookModels");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BookModels");

            migrationBuilder.RenameColumn(
                name: "BooksId",
                table: "BookModelTranslator",
                newName: "BooksBookId");

            migrationBuilder.RenameColumn(
                name: "BooksId",
                table: "AuthorBookModel",
                newName: "BooksBookId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorBookModel_BooksId",
                table: "AuthorBookModel",
                newName: "IX_AuthorBookModel_BooksBookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookModels",
                table: "BookModels",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBookModel_BookModels_BooksBookId",
                table: "AuthorBookModel",
                column: "BooksBookId",
                principalTable: "BookModels",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookModelTranslator_BookModels_BooksBookId",
                table: "BookModelTranslator",
                column: "BooksBookId",
                principalTable: "BookModels",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBookModel_BookModels_BooksBookId",
                table: "AuthorBookModel");

            migrationBuilder.DropForeignKey(
                name: "FK_BookModelTranslator_BookModels_BooksBookId",
                table: "BookModelTranslator");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookModels",
                table: "BookModels");

            migrationBuilder.RenameColumn(
                name: "BooksBookId",
                table: "BookModelTranslator",
                newName: "BooksId");

            migrationBuilder.RenameColumn(
                name: "BooksBookId",
                table: "AuthorBookModel",
                newName: "BooksId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorBookModel_BooksBookId",
                table: "AuthorBookModel",
                newName: "IX_AuthorBookModel_BooksId");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "BookModels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookModels",
                table: "BookModels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBookModel_BookModels_BooksId",
                table: "AuthorBookModel",
                column: "BooksId",
                principalTable: "BookModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookModelTranslator_BookModels_BooksId",
                table: "BookModelTranslator",
                column: "BooksId",
                principalTable: "BookModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
