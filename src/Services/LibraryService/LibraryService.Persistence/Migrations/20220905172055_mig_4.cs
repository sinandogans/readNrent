using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryService.Persistence.Migrations
{
    public partial class mig_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LibraryBook_Books_BookId",
                table: "LibraryBook");

            migrationBuilder.DropForeignKey(
                name: "FK_LibraryBook_UserLibrarys_UserLibraryId",
                table: "LibraryBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLibrarys",
                table: "UserLibrarys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LibraryBook",
                table: "LibraryBook");

            migrationBuilder.RenameTable(
                name: "UserLibrarys",
                newName: "UserLibraries");

            migrationBuilder.RenameTable(
                name: "LibraryBook",
                newName: "LibraryBooks");

            migrationBuilder.RenameIndex(
                name: "IX_LibraryBook_UserLibraryId",
                table: "LibraryBooks",
                newName: "IX_LibraryBooks_UserLibraryId");

            migrationBuilder.RenameIndex(
                name: "IX_LibraryBook_BookId",
                table: "LibraryBooks",
                newName: "IX_LibraryBooks_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLibraries",
                table: "UserLibraries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LibraryBooks",
                table: "LibraryBooks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LibraryBooks_Books_BookId",
                table: "LibraryBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LibraryBooks_UserLibraries_UserLibraryId",
                table: "LibraryBooks",
                column: "UserLibraryId",
                principalTable: "UserLibraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LibraryBooks_Books_BookId",
                table: "LibraryBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_LibraryBooks_UserLibraries_UserLibraryId",
                table: "LibraryBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLibraries",
                table: "UserLibraries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LibraryBooks",
                table: "LibraryBooks");

            migrationBuilder.RenameTable(
                name: "UserLibraries",
                newName: "UserLibrarys");

            migrationBuilder.RenameTable(
                name: "LibraryBooks",
                newName: "LibraryBook");

            migrationBuilder.RenameIndex(
                name: "IX_LibraryBooks_UserLibraryId",
                table: "LibraryBook",
                newName: "IX_LibraryBook_UserLibraryId");

            migrationBuilder.RenameIndex(
                name: "IX_LibraryBooks_BookId",
                table: "LibraryBook",
                newName: "IX_LibraryBook_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLibrarys",
                table: "UserLibrarys",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LibraryBook",
                table: "LibraryBook",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LibraryBook_Books_BookId",
                table: "LibraryBook",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LibraryBook_UserLibrarys_UserLibraryId",
                table: "LibraryBook",
                column: "UserLibraryId",
                principalTable: "UserLibrarys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
