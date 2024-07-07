using Microsoft.EntityFrameworkCore;

namespace VideojuegosAPI.Models
{
    public partial class BdVideojuegosContext: DbContext
    {
        public BdVideojuegosContext()
        {
        }
        public BdVideojuegosContext(DbContextOptions<BdVideojuegosContext> options) : base(options)
        {

        }

        public virtual DbSet<Videojuego> Videojuegos { get; set; }

        public virtual DbSet<Categoria> Categorias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Categorias");

                entity.ToTable("Categorias");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasData(
                    new Categoria { Id = 1, Nombre = "Aventura", Descripcion = "Juegos de aventura" },
                    new Categoria { Id = 2, Nombre = "Deportes", Descripcion = "Juegos de deportes" },
                    new Categoria { Id = 3, Nombre = "Estrategia", Descripcion = "Juegos de estrategia" },
                    new Categoria { Id = 4, Nombre = "Rol", Descripcion = "Juegos de rol" },
                    new Categoria { Id = 5, Nombre = "Shooter", Descripcion = "Juegos de shooter" },
                    new Categoria { Id = 6, Nombre = "Simulacion", Descripcion = "Juegos de simulacion" },
                    new Categoria { Id = 7, Nombre = "Survival", Descripcion = "Juegos de survival" },
                    new Categoria { Id = 8, Nombre = "Plataformas", Descripcion = "Juegos de plataformas" },
                    new Categoria { Id = 9, Nombre = "Puzzle", Descripcion = "Juegos de puzzle" },
                    new Categoria { Id = 10, Nombre = "Musical", Descripcion = "Juegos musicales" },
                    new Categoria { Id = 11, Nombre = "Carreras", Descripcion = "Juegos de carreras" },
                    new Categoria { Id = 12, Nombre = "Lucha", Descripcion = "Juegos de lucha" },
                    new Categoria { Id = 13, Nombre = "MMORPG", Descripcion = "Juegos MMORPG" },
                    new Categoria { Id = 14, Nombre = "MOBA", Descripcion = "Juegos MOBA" },
                    new Categoria { Id = 15, Nombre = "Battle Royale", Descripcion = "Juegos Battle Royale" },
                    new Categoria { Id = 16, Nombre = "Terror", Descripcion = "Juegos de terror" },
                    new Categoria { Id = 17, Nombre = "Ciencia Ficcion", Descripcion = "Juegos de ciencia ficcion" },
                    new Categoria { Id = 18, Nombre = "Fantasia", Descripcion = "Juegos de fantasia" },
                    new Categoria { Id = 19, Nombre = "Historico", Descripcion = "Juegos historicos" },
                    new Categoria { Id = 20, Nombre = "Mundo Abierto", Descripcion = "Juegos de mundo abierto" },
                    new Categoria { Id = 21, Nombre = "Indie", Descripcion = "Juegos indie" },
                    new Categoria { Id = 22, Nombre = "Retro", Descripcion = "Juegos retro" },
                    new Categoria { Id = 23, Nombre = "Realidad Virtual", Descripcion = "Juegos de realidad virtual" },
                    new Categoria { Id = 24, Nombre = "Realidad Aumentada", Descripcion = "Juegos de realidad aumentada" },
                    new Categoria { Id = 25, Nombre = "Cooperativo", Descripcion = "Juegos cooperativos" },
                    new Categoria { Id = 26, Nombre = "Competitivo", Descripcion = "Juegos competitivos" },
                    new Categoria { Id = 27, Nombre = "Multijugador", Descripcion = "Juegos multijugador" }
                    );
            }
            );

            modelBuilder.Entity<Videojuego>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Videojuegos");

                entity.ToTable("Videojuegos");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Desarrollador)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Anio).HasColumnName("Anio");

                entity.Property(e => e.Precio)
                    .IsRequired()
                    .HasColumnName("Precio");

                entity.Property(e => e.Imagen)
                    .IsRequired()
                    .HasColumnType("varbinary(max)")
                    .HasColumnName("Imagen");

                entity.HasOne(d => d.Categoria)
                .WithMany(p => p.Videojuegos)
                    .HasForeignKey(d => d.CategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Videojuegos_Categorias");
            });


            OnModelCreatingPartial(modelBuilder);
        }   

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
