using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GradeManagementData.EntityFramework.Concrete.Context.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentGrades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    { new Guid("76c31a19-2262-4765-b7fc-2b7f55734a97"), 35, "Stevie", "Wonder", 42 },
                    { new Guid("2fc5eb80-8aa2-45f2-b01b-e378e474a702"), 45, "David", "Bowie", 45 },
                    { new Guid("b8b7e13f-8e0d-456e-aaec-f2fc26a54e4c"), 83, "Robert", "Plant", 70 },
                    { new Guid("e1782faf-6d29-46be-9d0a-813166ced636"), 95, "Elton", "John", 90 },
                    { new Guid("8f2f2192-72cf-41ee-a06f-4c426db21ec8"), 99, "Bob", "Marley", 8 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentGrades");
        }
    }
}
