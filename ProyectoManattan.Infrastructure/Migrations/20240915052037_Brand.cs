using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProyectoManhattan.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Brand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shoe_ShoeModels_ShoeModelId",
                table: "Shoe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoeModels",
                table: "ShoeModels");

            migrationBuilder.RenameTable(
                name: "ShoeModels",
                newName: "ShoeModel");

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "ShoeModel",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoeModel",
                table: "ShoeModel",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DisplayName = table.Column<string>(type: "text", nullable: true),
                    SapName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoeModel_BrandId",
                table: "ShoeModel",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shoe_ShoeModel_ShoeModelId",
                table: "Shoe",
                column: "ShoeModelId",
                principalTable: "ShoeModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoeModel_Brands_BrandId",
                table: "ShoeModel",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shoe_ShoeModel_ShoeModelId",
                table: "Shoe");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoeModel_Brands_BrandId",
                table: "ShoeModel");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoeModel",
                table: "ShoeModel");

            migrationBuilder.DropIndex(
                name: "IX_ShoeModel_BrandId",
                table: "ShoeModel");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "ShoeModel");

            migrationBuilder.RenameTable(
                name: "ShoeModel",
                newName: "ShoeModels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoeModels",
                table: "ShoeModels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shoe_ShoeModels_ShoeModelId",
                table: "Shoe",
                column: "ShoeModelId",
                principalTable: "ShoeModels",
                principalColumn: "Id");
        }
    }
}
