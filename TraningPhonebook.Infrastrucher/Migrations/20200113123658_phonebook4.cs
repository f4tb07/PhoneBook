using Microsoft.EntityFrameworkCore.Migrations;

namespace TraningPhonebook.Infrastrucher.Migrations
{
    public partial class phonebook4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactTypeTable_UserTable_RelatedUserId",
                table: "ContactTypeTable");

            migrationBuilder.DropIndex(
                name: "IX_ContactTypeTable_RelatedUserId",
                table: "ContactTypeTable");

            migrationBuilder.DropColumn(
                name: "RelatedUserId",
                table: "ContactTypeTable");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RelatedUserId",
                table: "ContactTypeTable",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactTypeTable_RelatedUserId",
                table: "ContactTypeTable",
                column: "RelatedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactTypeTable_UserTable_RelatedUserId",
                table: "ContactTypeTable",
                column: "RelatedUserId",
                principalTable: "UserTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
