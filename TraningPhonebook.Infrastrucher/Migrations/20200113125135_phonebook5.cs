using Microsoft.EntityFrameworkCore.Migrations;

namespace TraningPhonebook.Infrastrucher.Migrations
{
    public partial class phonebook5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactTypeTable_ContactItemTable_ContactItemId",
                table: "ContactTypeTable");

            migrationBuilder.DropIndex(
                name: "IX_ContactTypeTable_ContactItemId",
                table: "ContactTypeTable");

            migrationBuilder.AddColumn<int>(
                name: "ItemTypeId",
                table: "ContactItemTable",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactItemTable_ItemTypeId",
                table: "ContactItemTable",
                column: "ItemTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactItemTable_ContactTypeTable_ItemTypeId",
                table: "ContactItemTable",
                column: "ItemTypeId",
                principalTable: "ContactTypeTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactItemTable_ContactTypeTable_ItemTypeId",
                table: "ContactItemTable");

            migrationBuilder.DropIndex(
                name: "IX_ContactItemTable_ItemTypeId",
                table: "ContactItemTable");

            migrationBuilder.DropColumn(
                name: "ItemTypeId",
                table: "ContactItemTable");

            migrationBuilder.CreateIndex(
                name: "IX_ContactTypeTable_ContactItemId",
                table: "ContactTypeTable",
                column: "ContactItemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactTypeTable_ContactItemTable_ContactItemId",
                table: "ContactTypeTable",
                column: "ContactItemId",
                principalTable: "ContactItemTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
