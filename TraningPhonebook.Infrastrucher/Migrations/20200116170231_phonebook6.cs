using Microsoft.EntityFrameworkCore.Migrations;

namespace TraningPhonebook.Infrastrucher.Migrations
{
    public partial class phonebook6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Scope",
                table: "ContactTable");

            migrationBuilder.AddColumn<bool>(
                name: "Scope",
                table: "ContactItemTable",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Scope",
                table: "ContactItemTable");

            migrationBuilder.AddColumn<bool>(
                name: "Scope",
                table: "ContactTable",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
