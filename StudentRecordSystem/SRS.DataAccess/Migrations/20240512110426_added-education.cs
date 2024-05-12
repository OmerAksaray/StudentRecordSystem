using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SRS.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addededucation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Education",
                table: "StudentModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "StudentModels",
                keyColumn: "StudentId",
                keyValue: 2,
                column: "Education",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Education",
                table: "StudentModels");
        }
    }
}
