namespace VideojuegosAPI.Models
{
    public partial class Videojuego
    {
        public int Id { get; set; }

        public int CategoriaId { get; set; }
        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }
        public string? Desarrollador { get; set; }
        public int Anio { get; set; }

        public double Precio { get; set; }

        public string? Imagen { get; set; }

        public virtual Categoria? Categoria { get; set; }
    }
}
