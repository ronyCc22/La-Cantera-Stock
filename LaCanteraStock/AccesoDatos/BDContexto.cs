using LaCanteraStock.Models;
using Microsoft.EntityFrameworkCore;

namespace LaCanteraStock.AccesoDatos
{
    public class BDContexto : DbContext
    {
        public BDContexto(DbContextOptions<BDContexto> options)
            : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Talla> Tallas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<ProductoTalla> ProductoTallas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<TipoDocumento> TiposDocumento { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<EstadoPedido> EstadosPedido { get; set; }
        public DbSet<ModalidadPedido> ModalidadesPedido { get; set; }
        public DbSet<Tela> Telas { get; set; }
        public DbSet<DetallePedido> DetallesPedido { get; set; }
        public DbSet<TipoEstampado> TiposEstampado { get; set; }
        public DbSet<DetalleConfeccion> DetallesConfeccion { get; set; }
        public DbSet<TipoMovimiento> TiposMovimiento { get; set; }
        public DbSet<MovimientoStock> MovimientosStock { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TipoPago> TiposPago { get; set; }
        public DbSet<MetodoPago> MetodosPago { get; set; }
        public DbSet<Pago> Pagos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Producto>()
                .HasOne<Categoria>()
                .WithMany()
                .HasForeignKey(x => x.CategoriaID);

            modelBuilder.Entity<ProductoTalla>()
                .HasOne<Producto>()
                .WithMany()
                .HasForeignKey(x => x.ProductoID);

            modelBuilder.Entity<ProductoTalla>()
                .HasOne<Talla>()
                .WithMany()
                .HasForeignKey(x => x.TallaID);

            modelBuilder.Entity<Cliente>()
                .HasOne<TipoDocumento>()
                .WithMany()
                .HasForeignKey(x => x.TipoDocumentoID);

            modelBuilder.Entity<Pedido>()
                .HasOne<Cliente>()
                .WithMany()
                .HasForeignKey(x => x.ClienteID);

            modelBuilder.Entity<Pedido>()
                .HasOne<ModalidadPedido>()
                .WithMany()
                .HasForeignKey(x => x.ModalidadID);

            modelBuilder.Entity<Pedido>()
                .HasOne<EstadoPedido>()
                .WithMany()
                .HasForeignKey(x => x.EstadoPedidoID);

            modelBuilder.Entity<Pedido>()
                .HasOne<Usuario>()
                .WithMany()
                .HasForeignKey(x => x.UsuarioID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DetallePedido>()
                .HasOne<Pedido>()
                .WithMany()
                .HasForeignKey(x => x.PedidoID);

            modelBuilder.Entity<DetallePedido>()
                .HasOne<ProductoTalla>()
                .WithMany()
                .HasForeignKey(x => x.ProductoTallaID);

            // ===== Relaciones de DetalleConfeccion =====
            modelBuilder.Entity<DetalleConfeccion>()
                .HasOne(d => d.Categoria)
                .WithMany()
                .HasForeignKey(d => d.CategoriaID);

            modelBuilder.Entity<DetalleConfeccion>()
                .HasOne(d => d.Tela)
                .WithMany()
                .HasForeignKey(d => d.TelaID);

            modelBuilder.Entity<DetalleConfeccion>()
                .HasOne(d => d.Talla)
                .WithMany()
                .HasForeignKey(d => d.TallaID);

            modelBuilder.Entity<DetalleConfeccion>()
                .HasOne(d => d.TipoEstampado)
                .WithMany()
                .HasForeignKey(d => d.TipoEstampadoID);

            // ===== Movimientos y Pagos =====
            modelBuilder.Entity<MovimientoStock>()
                .HasOne<ProductoTalla>()
                .WithMany()
                .HasForeignKey(x => x.ProductoTallaID);

            modelBuilder.Entity<MovimientoStock>()
                .HasOne<TipoMovimiento>()
                .WithMany()
                .HasForeignKey(x => x.TipoMovimientoID);

            modelBuilder.Entity<MovimientoStock>()
                .HasOne<Pedido>()
                .WithMany()
                .HasForeignKey(x => x.PedidoID)
                .IsRequired(false);

            modelBuilder.Entity<MovimientoStock>()
                .HasOne<Usuario>()
                .WithMany()
                .HasForeignKey(x => x.UsuarioID);

            modelBuilder.Entity<Pago>()
                .HasOne<Pedido>()
                .WithMany()
                .HasForeignKey(x => x.PedidoID);

            modelBuilder.Entity<Pago>()
                .HasOne<TipoPago>()
                .WithMany()
                .HasForeignKey(x => x.TipoPagoID);

            modelBuilder.Entity<Pago>()
                .HasOne<MetodoPago>()
                .WithMany()
                .HasForeignKey(x => x.MetodoPagoID);

            modelBuilder.Entity<Pago>()
                .HasOne<Usuario>()
                .WithMany()
                .HasForeignKey(x => x.UsuarioID);

            // Precisión decimal
            modelBuilder.Entity<Producto>()
                .Property(x => x.PrecioUnitario)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Pedido>()
                .Property(x => x.Total)
                .HasPrecision(10, 2);

            modelBuilder.Entity<DetallePedido>()
                .Property(x => x.PrecioUnitario)
                .HasPrecision(10, 2);

            modelBuilder.Entity<DetallePedido>()
                .Property(x => x.Subtotal)
                .HasPrecision(12, 2);

            modelBuilder.Entity<Pago>()
                .Property(x => x.Monto)
                .HasPrecision(10, 2);

            // ===== DATOS INICIALES (SEED) =====
            modelBuilder.Entity<Categoria>().HasData(
            new Categoria { CategoriaID = 1, Nombre = "Camiseta", Descripcion = "Camisetas deportivas", Activo = true },
            new Categoria { CategoriaID = 2, Nombre = "Short", Descripcion = "Shorts deportivos", Activo = true },
            new Categoria { CategoriaID = 3, Nombre = "Pantalón", Descripcion = "Pantalones deportivos", Activo = true },
            new Categoria { CategoriaID = 4, Nombre = "Casaca", Descripcion = "Casacas y abrigos", Activo = true }
            );

            modelBuilder.Entity<Talla>().HasData(
                new Talla { TallaID = 1, Nombre = "S" },
                new Talla { TallaID = 2, Nombre = "M" },
                new Talla { TallaID = 3, Nombre = "L" },
                new Talla { TallaID = 4, Nombre = "XL" },
                new Talla { TallaID = 5, Nombre = "XXL" }
            );

            modelBuilder.Entity<TipoEstampado>().HasData(
                new TipoEstampado { TipoEstampadoID = 1, Nombre = "Sublimado" },
                new TipoEstampado { TipoEstampadoID = 2, Nombre = "Serigrafía" },
                new TipoEstampado { TipoEstampadoID = 3, Nombre = "Bordado" },
                new TipoEstampado { TipoEstampadoID = 4, Nombre = "Vinil" }
            );

            modelBuilder.Entity<Tela>().HasData(
                new Tela { TelaID = 1, Nombre = "Algodón peinado", Descripcion = "Suave y transpirable", Activo = true },
                new Tela { TelaID = 2, Nombre = "Poliéster Dry-Fit", Descripcion = "Secado rápido", Activo = true },
                new Tela { TelaID = 3, Nombre = "Jersey deportivo", Descripcion = "Elástico y cómodo", Activo = true }
            );
        }
    }
}