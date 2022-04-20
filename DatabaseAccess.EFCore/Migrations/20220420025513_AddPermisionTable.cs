using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseAccess.EFCore.Migrations
{
    public partial class AddPermisionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permisions",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "NVARCHAR(70)", maxLength: 70, nullable: false),
                    Value = table.Column<string>(type: "NVARCHAR(70)", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permisions", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permisions");
        }
    }
}
