using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpecimenApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSpecimensData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Provider",
                table: "Specimens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Provider",
                table: "Specimens");
        }
    }
}
