using System;
using Microsoft.EntityFrameworkCore;
using SGI.Aplicacion;
namespace SGI.Repositorios;

public class SGIContext : DbContext
{
    #nullable disable
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Transaccion> Transacciones { get; set; }

    #nullable restore

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=DATABASE.db");
    }
     protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>()
                .Property(c => c.ID)
                .ValueGeneratedOnAdd(); // Asegúrate de que el ID se genere automáticamente
        }

}
