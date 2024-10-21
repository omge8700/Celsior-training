using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirstDatabase.Migrations
{
    public partial class CodeFirstAddClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MyProperty",
                table: "Students",
                newName: "Standard");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Standard",
                table: "Students",
                newName: "MyProperty");
        }
    }
}
