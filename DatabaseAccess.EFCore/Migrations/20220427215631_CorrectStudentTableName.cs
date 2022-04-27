using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseAccess.EFCore.Migrations
{
    public partial class CorrectStudentTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentDomains",
                table: "StudentDomains");

            migrationBuilder.RenameTable(
                name: "StudentDomains",
                newName: "Students");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "StudentDomains");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentDomains",
                table: "StudentDomains",
                column: "Id");
        }
    }
}
