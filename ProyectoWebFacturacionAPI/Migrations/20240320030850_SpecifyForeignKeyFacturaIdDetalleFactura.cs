using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoWebFacturacionAPI.Migrations
{
    /// <inheritdoc />
    public partial class SpecifyForeignKeyFacturaIdDetalleFactura : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleFacturas_CabFacturas_CabFacturaId",
                table: "DetalleFacturas");

            migrationBuilder.DropIndex(
                name: "IX_DetalleFacturas_CabFacturaId",
                table: "DetalleFacturas");

            migrationBuilder.DropColumn(
                name: "CabFacturaId",
                table: "DetalleFacturas");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleFacturas_FacturaId",
                table: "DetalleFacturas",
                column: "FacturaId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleFacturas_CabFacturas_FacturaId",
                table: "DetalleFacturas",
                column: "FacturaId",
                principalTable: "CabFacturas",
                principalColumn: "FacturaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleFacturas_CabFacturas_FacturaId",
                table: "DetalleFacturas");

            migrationBuilder.DropIndex(
                name: "IX_DetalleFacturas_FacturaId",
                table: "DetalleFacturas");

            migrationBuilder.AddColumn<int>(
                name: "CabFacturaId",
                table: "DetalleFacturas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DetalleFacturas_CabFacturaId",
                table: "DetalleFacturas",
                column: "CabFacturaId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleFacturas_CabFacturas_CabFacturaId",
                table: "DetalleFacturas",
                column: "CabFacturaId",
                principalTable: "CabFacturas",
                principalColumn: "FacturaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
