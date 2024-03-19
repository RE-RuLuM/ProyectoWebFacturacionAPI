using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoWebFacturacionAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddNumeroIntentosUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumeroIntentos",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroIntentos",
                table: "Usuarios");
        }
    }
}
