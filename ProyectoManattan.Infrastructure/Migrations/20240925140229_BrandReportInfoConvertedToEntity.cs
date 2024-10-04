using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProyectoManhattan.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BrandReportInfoConvertedToEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrandReportInfos_Capacity",
                table: "Reports");

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

            migrationBuilder.CreateTable(
                name: "BrandReportInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BrandId = table.Column<int>(type: "integer", nullable: false),
                    ReportId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandReportInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrandReportInfo_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BrandReportInfo_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "Id");
                });

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
                name: "IX_BrandReportInfo_BrandId",
                table: "BrandReportInfo",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_BrandReportInfo_ReportId",
                table: "BrandReportInfo",
                column: "ReportId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoeModel_BrandReportInfo_BrandReportInfoId",
                table: "ShoeModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoeModel_BrandReportInfo_BrandReportInfoId1",
                table: "ShoeModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoeModel_BrandReportInfo_BrandReportInfoId2",
                table: "ShoeModel");

            migrationBuilder.DropTable(
                name: "BrandReportInfo");

            migrationBuilder.DropIndex(
                name: "IX_ShoeModel_BrandReportInfoId",
                table: "ShoeModel");

            migrationBuilder.DropIndex(
                name: "IX_ShoeModel_BrandReportInfoId1",
                table: "ShoeModel");

            migrationBuilder.DropIndex(
                name: "IX_ShoeModel_BrandReportInfoId2",
                table: "ShoeModel");

            migrationBuilder.DropColumn(
                name: "BrandReportInfoId",
                table: "ShoeModel");

            migrationBuilder.DropColumn(
                name: "BrandReportInfoId1",
                table: "ShoeModel");

            migrationBuilder.DropColumn(
                name: "BrandReportInfoId2",
                table: "ShoeModel");

            migrationBuilder.AddColumn<int>(
                name: "BrandReportInfos_Capacity",
                table: "Reports",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
