using Microsoft.EntityFrameworkCore.Migrations;

namespace TraningPhonebook.Infrastrucher.Migrations
{
    public partial class phonebook2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_User_RelatedUserId",
                table: "Contact");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactItemTable_Contact_RelatedContactId",
                table: "ContactItemTable");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactTypeTable_User_RelatedUserId",
                table: "ContactTypeTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contact",
                table: "Contact");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "UserTable");

            migrationBuilder.RenameTable(
                name: "Contact",
                newName: "ContactTable");

            migrationBuilder.RenameIndex(
                name: "IX_Contact_RelatedUserId",
                table: "ContactTable",
                newName: "IX_ContactTable_RelatedUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTable",
                table: "UserTable",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactTable",
                table: "ContactTable",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactItemTable_ContactTable_RelatedContactId",
                table: "ContactItemTable",
                column: "RelatedContactId",
                principalTable: "ContactTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactTable_UserTable_RelatedUserId",
                table: "ContactTable",
                column: "RelatedUserId",
                principalTable: "UserTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactTypeTable_UserTable_RelatedUserId",
                table: "ContactTypeTable",
                column: "RelatedUserId",
                principalTable: "UserTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactItemTable_ContactTable_RelatedContactId",
                table: "ContactItemTable");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactTable_UserTable_RelatedUserId",
                table: "ContactTable");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactTypeTable_UserTable_RelatedUserId",
                table: "ContactTypeTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTable",
                table: "UserTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactTable",
                table: "ContactTable");

            migrationBuilder.RenameTable(
                name: "UserTable",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "ContactTable",
                newName: "Contact");

            migrationBuilder.RenameIndex(
                name: "IX_ContactTable_RelatedUserId",
                table: "Contact",
                newName: "IX_Contact_RelatedUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contact",
                table: "Contact",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_User_RelatedUserId",
                table: "Contact",
                column: "RelatedUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactItemTable_Contact_RelatedContactId",
                table: "ContactItemTable",
                column: "RelatedContactId",
                principalTable: "Contact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactTypeTable_User_RelatedUserId",
                table: "ContactTypeTable",
                column: "RelatedUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
