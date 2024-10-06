using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProyectoManhattan.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DisplayName = table.Column<string>(type: "text", nullable: true),
                    SapName = table.Column<string>(type: "text", nullable: true),
                    Uneco = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CalculationTime = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    IsFinished = table.Column<bool>(type: "boolean", nullable: false),
                    Base64Pdf = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoeModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Uneco = table.Column<string>(type: "text", nullable: true),
                    Family = table.Column<string>(type: "text", nullable: true),
                    Model = table.Column<string>(type: "text", nullable: true),
                    RefWithOutSize = table.Column<string>(type: "text", nullable: true),
                    BrandSapName = table.Column<string>(type: "text", nullable: true),
                    BrandId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoeModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoeModel_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BrandReportInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BrandId = table.Column<int>(type: "integer", nullable: true),
                    SapName = table.Column<string>(type: "text", nullable: true),
                    DisplayName = table.Column<string>(type: "text", nullable: true),
                    Uneco = table.Column<string>(type: "text", nullable: true),
                    ReportId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandReportInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrandReportInfo_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Shoe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ean = table.Column<string>(type: "text", nullable: true),
                    Matnr = table.Column<string>(type: "text", nullable: true),
                    Reference = table.Column<string>(type: "text", nullable: true),
                    BrandSapName = table.Column<string>(type: "text", nullable: true),
                    Size = table.Column<int>(type: "integer", nullable: false),
                    Count = table.Column<int>(type: "integer", nullable: false),
                    ShoeModelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shoe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shoe_ShoeModel_ShoeModelId",
                        column: x => x.ShoeModelId,
                        principalTable: "ShoeModel",
                        principalColumn: "Id");
                });

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
                name: "IX_BrandReportInfo_ReportId",
                table: "BrandReportInfo",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Shoe_ShoeModelId",
                table: "Shoe",
                column: "ShoeModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoeModel_BrandId",
                table: "ShoeModel",
                column: "BrandId");

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
                name: "Shoe");

            migrationBuilder.DropTable(
                name: "ShoeReportInfo");

            migrationBuilder.DropTable(
                name: "ShoeModel");

            migrationBuilder.DropTable(
                name: "ShoeModelReportInfo");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "BrandReportInfo");

            migrationBuilder.DropTable(
                name: "Reports");
        }
    }
}
