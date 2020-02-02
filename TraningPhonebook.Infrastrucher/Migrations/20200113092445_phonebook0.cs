using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TraningPhonebook.Infrastrucher.Migrations
{
    public partial class phonebook0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactItemTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemTypeId = table.Column<int>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    RelatedContactId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactItemTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileContactId = table.Column<int>(nullable: true),
                    PersonelId = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true),
                    Scope = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contact_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContactTypeTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Icon = table.Column<byte[]>(nullable: true),
                    RelatedUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactTypeTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactTypeTable_User_RelatedUserId",
                        column: x => x.RelatedUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contact_UserId",
                table: "Contact",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactItemTable_ItemTypeId",
                table: "ContactItemTable",
                column: "ItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactItemTable_RelatedContactId",
                table: "ContactItemTable",
                column: "RelatedContactId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactTypeTable_RelatedUserId",
                table: "ContactTypeTable",
                column: "RelatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_ProfileContactId",
                table: "User",
                column: "ProfileContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactItemTable_ContactTypeTable_ItemTypeId",
                table: "ContactItemTable",
                column: "ItemTypeId",
                principalTable: "ContactTypeTable",
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
                name: "FK_User_Contact_ProfileContactId",
                table: "User",
                column: "ProfileContactId",
                principalTable: "Contact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_User_UserId",
                table: "Contact");

            migrationBuilder.DropTable(
                name: "ContactItemTable");

            migrationBuilder.DropTable(
                name: "ContactTypeTable");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Contact");
        }
    }
}
