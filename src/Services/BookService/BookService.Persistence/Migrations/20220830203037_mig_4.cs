using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookService.Persistence.Migrations
{
    public partial class mig_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publishes_Books_Id",
                table: "Publishes");

            migrationBuilder.AddColumn<Guid>(
                name: "BookId",
                table: "Publishes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PublishId",
                table: "Books",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Publishes_BookId",
                table: "Publishes",
                column: "BookId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Publishes_Books_BookId",
                table: "Publishes",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publishes_Books_BookId",
                table: "Publishes");

            migrationBuilder.DropIndex(
                name: "IX_Publishes_BookId",
                table: "Publishes");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Publishes");

            migrationBuilder.DropColumn(
                name: "PublishId",
                table: "Books");

            migrationBuilder.AddForeignKey(
                name: "FK_Publishes_Books_Id",
                table: "Publishes",
                column: "Id",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
