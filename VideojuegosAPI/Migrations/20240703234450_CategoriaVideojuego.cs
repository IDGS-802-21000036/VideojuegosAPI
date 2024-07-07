using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VideojuegosAPI.Migrations
{
    /// <inheritdoc />
    public partial class CategoriaVideojuego : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genero",
                table: "Videojuegos");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Videojuegos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[,]
                {
                    { 1, "Juegos de aventura", "Aventura" },
                    { 2, "Juegos de deportes", "Deportes" },
                    { 3, "Juegos de estrategia", "Estrategia" },
                    { 4, "Juegos de rol", "Rol" },
                    { 5, "Juegos de shooter", "Shooter" },
                    { 6, "Juegos de simulacion", "Simulacion" },
                    { 7, "Juegos de survival", "Survival" },
                    { 8, "Juegos de plataformas", "Plataformas" },
                    { 9, "Juegos de puzzle", "Puzzle" },
                    { 10, "Juegos musicales", "Musical" },
                    { 11, "Juegos de carreras", "Carreras" },
                    { 12, "Juegos de lucha", "Lucha" },
                    { 13, "Juegos MMORPG", "MMORPG" },
                    { 14, "Juegos MOBA", "MOBA" },
                    { 15, "Juegos Battle Royale", "Battle Royale" },
                    { 16, "Juegos de terror", "Terror" },
                    { 17, "Juegos de ciencia ficcion", "Ciencia Ficcion" },
                    { 18, "Juegos de fantasia", "Fantasia" },
                    { 19, "Juegos historicos", "Historico" },
                    { 20, "Juegos de mundo abierto", "Mundo Abierto" },
                    { 21, "Juegos indie", "Indie" },
                    { 22, "Juegos retro", "Retro" },
                    { 23, "Juegos de realidad virtual", "Realidad Virtual" },
                    { 24, "Juegos de realidad aumentada", "Realidad Aumentada" },
                    { 25, "Juegos cooperativos", "Cooperativo" },
                    { 26, "Juegos competitivos", "Competitivo" },
                    { 27, "Juegos multijugador", "Multijugador" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Videojuegos_CategoriaId",
                table: "Videojuegos",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Videojuegos_Categorias",
                table: "Videojuegos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videojuegos_Categorias",
                table: "Videojuegos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropIndex(
                name: "IX_Videojuegos_CategoriaId",
                table: "Videojuegos");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Videojuegos");

            migrationBuilder.AddColumn<string>(
                name: "Genero",
                table: "Videojuegos",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
