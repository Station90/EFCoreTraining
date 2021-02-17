using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreTraining.Migrations
{
    public partial class InsertProcedureTemplateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InsertProcedureTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsertProcedureTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SPResult",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsertProcedureTemplates");

            migrationBuilder.DropTable(
                name: "SPResult");
        }
    }
}
