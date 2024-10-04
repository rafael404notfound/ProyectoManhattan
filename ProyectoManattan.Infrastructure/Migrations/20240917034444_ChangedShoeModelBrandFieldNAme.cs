using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoManhattan.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedShoeModelBrandFieldNAme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Brand",
                table: "ShoeModel",
                newName: "BrandSapName");

            migrationBuilder.RenameColumn(
                name: "Brand",
                table: "Shoe",
                newName: "BrandSapName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BrandSapName",
                table: "ShoeModel",
                newName: "Brand");

            migrationBuilder.RenameColumn(
                name: "BrandSapName",
                table: "Shoe",
                newName: "Brand");
        }
    }
}
