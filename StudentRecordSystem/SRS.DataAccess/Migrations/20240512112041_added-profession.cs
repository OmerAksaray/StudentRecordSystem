using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SRS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addedprofession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Profession",
                table: "TeacherModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "TeacherModels",
                keyColumn: "TeacherId",
                keyValue: 2,
                column: "Profession",
                value: null);

            migrationBuilder.UpdateData(
                table: "TeacherModels",
                keyColumn: "TeacherId",
                keyValue: 5,
                column: "Profession",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Profession",
                table: "TeacherModels");
        }
    }
}
