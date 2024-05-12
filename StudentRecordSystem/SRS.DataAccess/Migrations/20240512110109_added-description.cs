using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SRS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addeddescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "StudentModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "StudentModels",
                keyColumn: "StudentId",
                keyValue: 2,
                column: "Description",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "StudentModels");
        }
    }
}
