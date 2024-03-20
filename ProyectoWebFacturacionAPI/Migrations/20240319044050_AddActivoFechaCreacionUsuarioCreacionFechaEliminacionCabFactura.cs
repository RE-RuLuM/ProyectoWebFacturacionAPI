using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoWebFacturacionAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddActivoFechaCreacionUsuarioCreacionFechaEliminacionCabFactura : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "CabFacturas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "CabFacturas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaEliminacion",
                table: "CabFacturas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioCreacion",
                table: "CabFacturas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activo",
                table: "CabFacturas");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "CabFacturas");

            migrationBuilder.DropColumn(
                name: "FechaEliminacion",
                table: "CabFacturas");

            migrationBuilder.DropColumn(
                name: "UsuarioCreacion",
                table: "CabFacturas");
        }
    }
}
