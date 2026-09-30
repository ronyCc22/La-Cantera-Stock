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

            modelBuilder.Entity<DetalleConfeccion>()
                .HasOne<Categoria>()
                .WithMany()
                .HasForeignKey(x => x.CategoriaID);

            modelBuilder.Entity<DetalleConfeccion>()
                .HasOne<Tela>()
                .WithMany()
                .HasForeignKey(x => x.TelaID);

            modelBuilder.Entity<DetalleConfeccion>()
                .HasOne<Talla>()
                .WithMany()
                .HasForeignKey(x => x.TallaID);

            modelBuilder.Entity<DetalleConfeccion>()
                .HasOne<TipoEstampado>()
                .WithMany()
                .HasForeignKey(x => x.TipoEstampadoID);

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
        }
    }
}