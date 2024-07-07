using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideojuegosAPI.Migrations
{
    /// <inheritdoc />
    public partial class PrecioImagenVideojuego : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Videojuegos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "Imagen",
                table: "Videojuegos",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<double>(
                name: "Precio",
                table: "Videojuegos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Videojuegos");

            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "Videojuegos");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "Videojuegos");
        }
    }
}
