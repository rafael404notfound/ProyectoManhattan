using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoManhattan.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedUnecotoBrand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Uneco",
                table: "Brands",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Uneco",
                table: "Brands");
        }
    }
}
