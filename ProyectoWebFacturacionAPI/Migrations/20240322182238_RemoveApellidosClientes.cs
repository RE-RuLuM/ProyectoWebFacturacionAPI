using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoWebFacturacionAPI.Migrations
{
    /// <inheritdoc />
    public partial class RemoveApellidosClientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellidos",
                table: "Clientes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Apellidos",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
