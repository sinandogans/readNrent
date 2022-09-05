using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryService.Persistence.Migrations
{
    public partial class mig_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_UserLibrarys_UserLibraryId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_UserLibraryId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BeginDate",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "UserLibraryId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "UserRating",
                table: "Books");

            migrationBuilder.CreateTable(
                name: "LibraryBook",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BeginDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserRating = table.Column<int>(type: "int", nullable: false),
                    UserLibraryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryBook", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LibraryBook_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibraryBook_UserLibrarys_UserLibraryId",
                        column: x => x.UserLibraryId,
                        principalTable: "UserLibrarys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LibraryBook_BookId",
                table: "LibraryBook",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryBook_UserLibraryId",
                table: "LibraryBook",
                column: "UserLibraryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibraryBook");

            migrationBuilder.AddColumn<DateTime>(
                name: "BeginDate",
                table: "Books",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Books",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "UserLibraryId",
                table: "Books",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserRating",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Books_UserLibraryId",
                table: "Books",
                column: "UserLibraryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_UserLibrarys_UserLibraryId",
                table: "Books",
                column: "UserLibraryId",
                principalTable: "UserLibrarys",
                principalColumn: "Id");
        }
    }
}
