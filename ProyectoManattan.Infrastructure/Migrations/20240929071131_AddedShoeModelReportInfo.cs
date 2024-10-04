using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProyectoManhattan.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedShoeModelReportInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BrandReportInfo_Brands_BrandParkingStockId",
                table: "BrandReportInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoeModel_BrandReportInfo_BrandReportInfoId",
                table: "ShoeModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoeModel_BrandReportInfo_BrandReportInfoId1",
                table: "ShoeModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoeModel_BrandReportInfo_BrandReportInfoId2",
                table: "ShoeModel");

            migrationBuilder.DropIndex(
                name: "IX_ShoeModel_BrandReportInfoId",
                table: "ShoeModel");

            migrationBuilder.DropIndex(
                name: "IX_ShoeModel_BrandReportInfoId1",
                table: "ShoeModel");

            migrationBuilder.DropIndex(
                name: "IX_ShoeModel_BrandReportInfoId2",
                table: "ShoeModel");

            migrationBuilder.DropIndex(
                name: "IX_BrandReportInfo_BrandParkingStockId",
                table: "BrandReportInfo");

            migrationBuilder.DropColumn(
                name: "BrandReportInfoId",
                table: "ShoeModel");

            migrationBuilder.DropColumn(
                name: "BrandReportInfoId1",
                table: "ShoeModel");

            migrationBuilder.DropColumn(
                name: "BrandReportInfoId2",
                table: "ShoeModel");

            migrationBuilder.DropColumn(
                name: "BrandParkingStockId",
                table: "BrandReportInfo");

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "BrandReportInfo",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "BrandReportInfo",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SapName",
                table: "BrandReportInfo",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Uneco",
                table: "BrandReportInfo",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShoeModelReportInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RefWithOutSize = table.Column<string>(type: "text", nullable: true),
                    ShoeModelId = table.Column<int>(type: "integer", nullable: true),
                    Uneco = table.Column<string>(type: "text", nullable: true),
                    Family = table.Column<string>(type: "text", nullable: true),
                    Model = table.Column<string>(type: "text", nullable: true),
                    BrandSapName = table.Column<string>(type: "text", nullable: true),
                    BrandReportInfoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoeModelReportInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoeModelReportInfo_BrandReportInfo_BrandReportInfoId",
                        column: x => x.BrandReportInfoId,
                        principalTable: "BrandReportInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShoeReportInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ShoeId = table.Column<int>(type: "integer", nullable: true),
                    Ean = table.Column<string>(type: "text", nullable: true),
                    Matnr = table.Column<string>(type: "text", nullable: true),
                    Reference = table.Column<string>(type: "text", nullable: true),
                    BrandSapName = table.Column<string>(type: "text", nullable: true),
                    Size = table.Column<int>(type: "integer", nullable: false),
                    Parking = table.Column<int>(type: "integer", nullable: false),
                    Total = table.Column<int>(type: "integer", nullable: false),
                    Missing = table.Column<int>(type: "integer", nullable: false),
                    Surplus = table.Column<int>(type: "integer", nullable: false),
                    ShoeModelReportInfoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoeReportInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoeReportInfo_ShoeModelReportInfo_ShoeModelReportInfoId",
                        column: x => x.ShoeModelReportInfoId,
                        principalTable: "ShoeModelReportInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoeModelReportInfo_BrandReportInfoId",
                table: "ShoeModelReportInfo",
                column: "BrandReportInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoeReportInfo_ShoeModelReportInfoId",
                table: "ShoeReportInfo",
                column: "ShoeModelReportInfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoeReportInfo");

            migrationBuilder.DropTable(
                name: "ShoeModelReportInfo");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "BrandReportInfo");

            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "BrandReportInfo");

            migrationBuilder.DropColumn(
                name: "SapName",
                table: "BrandReportInfo");

            migrationBuilder.DropColumn(
                name: "Uneco",
                table: "BrandReportInfo");

            migrationBuilder.AddColumn<int>(
                name: "BrandReportInfoId",
                table: "ShoeModel",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BrandReportInfoId1",
                table: "ShoeModel",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BrandReportInfoId2",
                table: "ShoeModel",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BrandParkingStockId",
                table: "BrandReportInfo",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShoeModel_BrandReportInfoId",
                table: "ShoeModel",
                column: "BrandReportInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoeModel_BrandReportInfoId1",
                table: "ShoeModel",
                column: "BrandReportInfoId1");

            migrationBuilder.CreateIndex(
                name: "IX_ShoeModel_BrandReportInfoId2",
                table: "ShoeModel",
                column: "BrandReportInfoId2");

            migrationBuilder.CreateIndex(
                name: "IX_BrandReportInfo_BrandParkingStockId",
                table: "BrandReportInfo",
                column: "BrandParkingStockId");

            migrationBuilder.AddForeignKey(
                name: "FK_BrandReportInfo_Brands_BrandParkingStockId",
                table: "BrandReportInfo",
                column: "BrandParkingStockId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoeModel_BrandReportInfo_BrandReportInfoId",
                table: "ShoeModel",
                column: "BrandReportInfoId",
                principalTable: "BrandReportInfo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoeModel_BrandReportInfo_BrandReportInfoId1",
                table: "ShoeModel",
                column: "BrandReportInfoId1",
                principalTable: "BrandReportInfo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoeModel_BrandReportInfo_BrandReportInfoId2",
                table: "ShoeModel",
                column: "BrandReportInfoId2",
                principalTable: "BrandReportInfo",
                principalColumn: "Id");
        }
    }
}
