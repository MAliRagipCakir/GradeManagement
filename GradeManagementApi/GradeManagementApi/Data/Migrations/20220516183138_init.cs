using Microsoft.EntityFrameworkCore.Migrations;

namespace GradeManagementApi.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentGrades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MidTerm = table.Column<int>(type: "int", nullable: false),
                    Final = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentGrades", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "StudentGrades",
                columns: new[] { "Id", "Final", "FirstName", "LastName", "MidTerm" },
                values: new object[,]
                {
                    { 1, 35, "Stevie", "Wonder", 42 },
                    { 2, 45, "David", "Bowie", 45 },
                    { 3, 83, "Robert", "Plant", 70 },
                    { 4, 95, "Elton", "John", 90 },
                    { 5, 99, "Bob", "Marley", 8 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentGrades");
        }
    }
}
