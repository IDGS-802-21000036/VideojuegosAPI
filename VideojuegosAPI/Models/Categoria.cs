using System.Text.Json.Serialization;

namespace VideojuegosAPI.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        [JsonIgnore]
        public virtual ICollection<Videojuego> Videojuegos { get; set; }


    }
}
