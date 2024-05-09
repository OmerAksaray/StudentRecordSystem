using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SRS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ultimatom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeacherModels",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherModels", x => x.TeacherId);
                });

            migrationBuilder.CreateTable(
                name: "StudentModels",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SchoolNumber = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentModels", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_StudentModels_TeacherModels_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "TeacherModels",
                        principalColumn: "TeacherId");
                });

            migrationBuilder.InsertData(
                table: "TeacherModels",
                columns: new[] { "TeacherId", "Name", "Surname" },
                values: new object[,]
                {
                    { 2, "Omer", "Aksaray" },
                    { 5, "Yilmaz", "Aksaray" }
                });

            migrationBuilder.InsertData(
                table: "StudentModels",
                columns: new[] { "StudentId", "Name", "SchoolNumber", "Surname", "TeacherId" },
                values: new object[] { 2, "Sevgi", 167, "Aksaray", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_StudentModels_TeacherId",
                table: "StudentModels",
                column: "TeacherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentModels");

            migrationBuilder.DropTable(
                name: "TeacherModels");
        }
    }
}
