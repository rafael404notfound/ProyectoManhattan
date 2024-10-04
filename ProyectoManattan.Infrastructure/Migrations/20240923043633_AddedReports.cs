using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProyectoManhattan.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedReports : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReportId",
                table: "ShoeModel",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReportId1",
                table: "ShoeModel",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReportId2",
                table: "ShoeModel",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReportId3",
                table: "ShoeModel",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReportId4",
                table: "ShoeModel",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CalculationTime = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoeModel_ReportId",
                table: "ShoeModel",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoeModel_ReportId1",
                table: "ShoeModel",
                column: "ReportId1");

            migrationBuilder.CreateIndex(
                name: "IX_ShoeModel_ReportId2",
                table: "ShoeModel",
                column: "ReportId2");

            migrationBuilder.CreateIndex(
                name: "IX_ShoeModel_ReportId3",
                table: "ShoeModel",
                column: "ReportId3");

            migrationBuilder.CreateIndex(
                name: "IX_ShoeModel_ReportId4",
                table: "ShoeModel",
                column: "ReportId4");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoeModel_Reports_ReportId",
                table: "ShoeModel",
                column: "ReportId",
                principalTable: "Reports",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoeModel_Reports_ReportId1",
                table: "ShoeModel",
                column: "ReportId1",
                principalTable: "Reports",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoeModel_Reports_ReportId2",
                table: "ShoeModel",
                column: "ReportId2",
                principalTable: "Reports",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoeModel_Reports_ReportId3",
                table: "ShoeModel",
                column: "ReportId3",
                principalTable: "Reports",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoeModel_Reports_ReportId4",
                table: "ShoeModel",
                column: "ReportId4",
                principalTable: "Reports",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoeModel_Reports_ReportId",
                table: "ShoeModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoeModel_Reports_ReportId1",
                table: "ShoeModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoeModel_Reports_ReportId2",
                table: "ShoeModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoeModel_Reports_ReportId3",
                table: "ShoeModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoeModel_Reports_ReportId4",
                table: "ShoeModel");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_ShoeModel_ReportId",
                table: "ShoeModel");

            migrationBuilder.DropIndex(
                name: "IX_ShoeModel_ReportId1",
                table: "ShoeModel");

            migrationBuilder.DropIndex(
                name: "IX_ShoeModel_ReportId2",
                table: "ShoeModel");

            migrationBuilder.DropIndex(
                name: "IX_ShoeModel_ReportId3",
                table: "ShoeModel");

            migrationBuilder.DropIndex(
                name: "IX_ShoeModel_ReportId4",
                table: "ShoeModel");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "ShoeModel");

            migrationBuilder.DropColumn(
                name: "ReportId1",
                table: "ShoeModel");

            migrationBuilder.DropColumn(
                name: "ReportId2",
                table: "ShoeModel");

            migrationBuilder.DropColumn(
                name: "ReportId3",
                table: "ShoeModel");

            migrationBuilder.DropColumn(
                name: "ReportId4",
                table: "ShoeModel");
        }
    }
}
