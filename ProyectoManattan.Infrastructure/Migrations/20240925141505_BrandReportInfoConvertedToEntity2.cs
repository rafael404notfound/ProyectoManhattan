using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoManhattan.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BrandReportInfoConvertedToEntity2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BrandReportInfo_Brands_BrandId",
                table: "BrandReportInfo");

            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "BrandReportInfo",
                newName: "BrandParkingStockId");

            migrationBuilder.RenameIndex(
                name: "IX_BrandReportInfo_BrandId",
                table: "BrandReportInfo",
                newName: "IX_BrandReportInfo_BrandParkingStockId");

            migrationBuilder.AddForeignKey(
                name: "FK_BrandReportInfo_Brands_BrandParkingStockId",
                table: "BrandReportInfo",
                column: "BrandParkingStockId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BrandReportInfo_Brands_BrandParkingStockId",
                table: "BrandReportInfo");

            migrationBuilder.RenameColumn(
                name: "BrandParkingStockId",
                table: "BrandReportInfo",
                newName: "BrandId");

            migrationBuilder.RenameIndex(
                name: "IX_BrandReportInfo_BrandParkingStockId",
                table: "BrandReportInfo",
                newName: "IX_BrandReportInfo_BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_BrandReportInfo_Brands_BrandId",
                table: "BrandReportInfo",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
