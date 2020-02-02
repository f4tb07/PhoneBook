using Microsoft.EntityFrameworkCore.Migrations;

namespace TraningPhonebook.Infrastrucher.Migrations
{
    public partial class phonebook1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_User_UserId",
                table: "Contact");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Contact_ProfileContactId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ProfileContactId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Contact_UserId",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "ProfileContactId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Contact");

            migrationBuilder.AddColumn<int>(
                name: "ProfileContact",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RelatedUserId",
                table: "Contact",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contact_RelatedUserId",
                table: "Contact",
                column: "RelatedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_User_RelatedUserId",
                table: "Contact",
                column: "RelatedUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_User_RelatedUserId",
                table: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_Contact_RelatedUserId",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "ProfileContact",
                table: "User");

            migrationBuilder.DropColumn(
                name: "RelatedUserId",
                table: "Contact");

            migrationBuilder.AddColumn<int>(
                name: "ProfileContactId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Contact",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_ProfileContactId",
                table: "User",
                column: "ProfileContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_UserId",
                table: "Contact",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_User_UserId",
                table: "Contact",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Contact_ProfileContactId",
                table: "User",
                column: "ProfileContactId",
                principalTable: "Contact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
