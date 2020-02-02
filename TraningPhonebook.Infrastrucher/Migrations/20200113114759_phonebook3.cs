using Microsoft.EntityFrameworkCore.Migrations;

namespace TraningPhonebook.Infrastrucher.Migrations
{
    public partial class phonebook3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "PersonelId",
                table: "UserTable",
                maxLength: 6,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "UserTable",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ContactTypeTable",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContactItemId",
                table: "ContactTypeTable",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "ContactTable",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "ContactTable",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "ContactTable",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "ContactTable",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "ContactItemTable",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactTypeTable_ContactItemTable_ContactItemId",
                table: "ContactTypeTable");

            migrationBuilder.DropIndex(
                name: "IX_ContactTypeTable_ContactItemId",
                table: "ContactTypeTable");

            migrationBuilder.DropColumn(
                name: "ContactItemId",
                table: "ContactTypeTable");

            migrationBuilder.AlterColumn<string>(
                name: "PersonelId",
                table: "UserTable",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 6,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "UserTable",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ContactTypeTable",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "ContactTable",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "ContactTable",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "ContactTable",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "ContactTable",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "ContactItemTable",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemTypeId",
                table: "ContactItemTable",
                type: "int",
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
    }
}
