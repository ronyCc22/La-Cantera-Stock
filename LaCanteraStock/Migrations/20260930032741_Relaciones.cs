using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaCanteraStock.Migrations
{
    /// <inheritdoc />
    public partial class Relaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProductoTallas_ProductoID",
                table: "ProductoTallas",
                column: "ProductoID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoTallas_TallaID",
                table: "ProductoTallas",
                column: "TallaID");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaID",
                table: "Productos",
                column: "CategoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteID",
                table: "Pedidos",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_EstadoPedidoID",
                table: "Pedidos",
                column: "EstadoPedidoID");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ModalidadID",
                table: "Pedidos",
                column: "ModalidadID");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_UsuarioID",
                table: "Pedidos",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_MetodoPagoID",
                table: "Pagos",
                column: "MetodoPagoID");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_PedidoID",
                table: "Pagos",
                column: "PedidoID");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_TipoPagoID",
                table: "Pagos",
                column: "TipoPagoID");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_UsuarioID",
                table: "Pagos",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosStock_PedidoID",
                table: "MovimientosStock",
                column: "PedidoID");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosStock_ProductoTallaID",
                table: "MovimientosStock",
                column: "ProductoTallaID");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosStock_TipoMovimientoID",
                table: "MovimientosStock",
                column: "TipoMovimientoID");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosStock_UsuarioID",
                table: "MovimientosStock",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesPedido_PedidoID",
                table: "DetallesPedido",
                column: "PedidoID");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesPedido_ProductoTallaID",
                table: "DetallesPedido",
                column: "ProductoTallaID");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesConfeccion_CategoriaID",
                table: "DetallesConfeccion",
                column: "CategoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesConfeccion_TallaID",
                table: "DetallesConfeccion",
                column: "TallaID");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesConfeccion_TelaID",
                table: "DetallesConfeccion",
                column: "TelaID");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesConfeccion_TipoEstampadoID",
                table: "DetallesConfeccion",
                column: "TipoEstampadoID");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_TipoDocumentoID",
                table: "Clientes",
                column: "TipoDocumentoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_TiposDocumento_TipoDocumentoID",
                table: "Clientes",
                column: "TipoDocumentoID",
                principalTable: "TiposDocumento",
                principalColumn: "TipoDocumentoID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesConfeccion_Categorias_CategoriaID",
                table: "DetallesConfeccion",
                column: "CategoriaID",
                principalTable: "Categorias",
                principalColumn: "CategoriaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesConfeccion_Tallas_TallaID",
                table: "DetallesConfeccion",
                column: "TallaID",
                principalTable: "Tallas",
                principalColumn: "TallaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesConfeccion_Telas_TelaID",
                table: "DetallesConfeccion",
                column: "TelaID",
                principalTable: "Telas",
                principalColumn: "TelaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesConfeccion_TiposEstampado_TipoEstampadoID",
                table: "DetallesConfeccion",
                column: "TipoEstampadoID",
                principalTable: "TiposEstampado",
                principalColumn: "TipoEstampadoID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesPedido_Pedidos_PedidoID",
                table: "DetallesPedido",
                column: "PedidoID",
                principalTable: "Pedidos",
                principalColumn: "PedidoID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesPedido_ProductoTallas_ProductoTallaID",
                table: "DetallesPedido",
                column: "ProductoTallaID",
                principalTable: "ProductoTallas",
                principalColumn: "ProductoTallaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovimientosStock_Pedidos_PedidoID",
                table: "MovimientosStock",
                column: "PedidoID",
                principalTable: "Pedidos",
                principalColumn: "PedidoID");

            migrationBuilder.AddForeignKey(
                name: "FK_MovimientosStock_ProductoTallas_ProductoTallaID",
                table: "MovimientosStock",
                column: "ProductoTallaID",
                principalTable: "ProductoTallas",
                principalColumn: "ProductoTallaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovimientosStock_TiposMovimiento_TipoMovimientoID",
                table: "MovimientosStock",
                column: "TipoMovimientoID",
                principalTable: "TiposMovimiento",
                principalColumn: "TipoMovimientoID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovimientosStock_Usuarios_UsuarioID",
                table: "MovimientosStock",
                column: "UsuarioID",
                principalTable: "Usuarios",
                principalColumn: "UsuarioID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pagos_MetodosPago_MetodoPagoID",
                table: "Pagos",
                column: "MetodoPagoID",
                principalTable: "MetodosPago",
                principalColumn: "MetodoPagoID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pagos_Pedidos_PedidoID",
                table: "Pagos",
                column: "PedidoID",
                principalTable: "Pedidos",
                principalColumn: "PedidoID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pagos_TiposPago_TipoPagoID",
                table: "Pagos",
                column: "TipoPagoID",
                principalTable: "TiposPago",
                principalColumn: "TipoPagoID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pagos_Usuarios_UsuarioID",
                table: "Pagos",
                column: "UsuarioID",
                principalTable: "Usuarios",
                principalColumn: "UsuarioID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_ClienteID",
                table: "Pedidos",
                column: "ClienteID",
                principalTable: "Clientes",
                principalColumn: "ClienteID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_EstadosPedido_EstadoPedidoID",
                table: "Pedidos",
                column: "EstadoPedidoID",
                principalTable: "EstadosPedido",
                principalColumn: "EstadoPedidoID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_ModalidadesPedido_ModalidadID",
                table: "Pedidos",
                column: "ModalidadID",
                principalTable: "ModalidadesPedido",
                principalColumn: "ModalidadID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Usuarios_UsuarioID",
                table: "Pedidos",
                column: "UsuarioID",
                principalTable: "Usuarios",
                principalColumn: "UsuarioID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Categorias_CategoriaID",
                table: "Productos",
                column: "CategoriaID",
                principalTable: "Categorias",
                principalColumn: "CategoriaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductoTallas_Productos_ProductoID",
                table: "ProductoTallas",
                column: "ProductoID",
                principalTable: "Productos",
                principalColumn: "ProductoID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductoTallas_Tallas_TallaID",
                table: "ProductoTallas",
                column: "TallaID",
                principalTable: "Tallas",
                principalColumn: "TallaID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_TiposDocumento_TipoDocumentoID",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_DetallesConfeccion_Categorias_CategoriaID",
                table: "DetallesConfeccion");

            migrationBuilder.DropForeignKey(
                name: "FK_DetallesConfeccion_Tallas_TallaID",
                table: "DetallesConfeccion");

            migrationBuilder.DropForeignKey(
                name: "FK_DetallesConfeccion_Telas_TelaID",
                table: "DetallesConfeccion");

            migrationBuilder.DropForeignKey(
                name: "FK_DetallesConfeccion_TiposEstampado_TipoEstampadoID",
                table: "DetallesConfeccion");

            migrationBuilder.DropForeignKey(
                name: "FK_DetallesPedido_Pedidos_PedidoID",
                table: "DetallesPedido");

            migrationBuilder.DropForeignKey(
                name: "FK_DetallesPedido_ProductoTallas_ProductoTallaID",
                table: "DetallesPedido");

            migrationBuilder.DropForeignKey(
                name: "FK_MovimientosStock_Pedidos_PedidoID",
                table: "MovimientosStock");

            migrationBuilder.DropForeignKey(
                name: "FK_MovimientosStock_ProductoTallas_ProductoTallaID",
                table: "MovimientosStock");

            migrationBuilder.DropForeignKey(
                name: "FK_MovimientosStock_TiposMovimiento_TipoMovimientoID",
                table: "MovimientosStock");

            migrationBuilder.DropForeignKey(
                name: "FK_MovimientosStock_Usuarios_UsuarioID",
                table: "MovimientosStock");

            migrationBuilder.DropForeignKey(
                name: "FK_Pagos_MetodosPago_MetodoPagoID",
                table: "Pagos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pagos_Pedidos_PedidoID",
                table: "Pagos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pagos_TiposPago_TipoPagoID",
                table: "Pagos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pagos_Usuarios_UsuarioID",
                table: "Pagos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_ClienteID",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_EstadosPedido_EstadoPedidoID",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_ModalidadesPedido_ModalidadID",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Usuarios_UsuarioID",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Categorias_CategoriaID",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductoTallas_Productos_ProductoID",
                table: "ProductoTallas");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductoTallas_Tallas_TallaID",
                table: "ProductoTallas");

            migrationBuilder.DropIndex(
                name: "IX_ProductoTallas_ProductoID",
                table: "ProductoTallas");

            migrationBuilder.DropIndex(
                name: "IX_ProductoTallas_TallaID",
                table: "ProductoTallas");

            migrationBuilder.DropIndex(
                name: "IX_Productos_CategoriaID",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_ClienteID",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_EstadoPedidoID",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_ModalidadID",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_UsuarioID",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pagos_MetodoPagoID",
                table: "Pagos");

            migrationBuilder.DropIndex(
                name: "IX_Pagos_PedidoID",
                table: "Pagos");

            migrationBuilder.DropIndex(
                name: "IX_Pagos_TipoPagoID",
                table: "Pagos");

            migrationBuilder.DropIndex(
                name: "IX_Pagos_UsuarioID",
                table: "Pagos");

            migrationBuilder.DropIndex(
                name: "IX_MovimientosStock_PedidoID",
                table: "MovimientosStock");

            migrationBuilder.DropIndex(
                name: "IX_MovimientosStock_ProductoTallaID",
                table: "MovimientosStock");

            migrationBuilder.DropIndex(
                name: "IX_MovimientosStock_TipoMovimientoID",
                table: "MovimientosStock");

            migrationBuilder.DropIndex(
                name: "IX_MovimientosStock_UsuarioID",
                table: "MovimientosStock");

            migrationBuilder.DropIndex(
                name: "IX_DetallesPedido_PedidoID",
                table: "DetallesPedido");

            migrationBuilder.DropIndex(
                name: "IX_DetallesPedido_ProductoTallaID",
                table: "DetallesPedido");

            migrationBuilder.DropIndex(
                name: "IX_DetallesConfeccion_CategoriaID",
                table: "DetallesConfeccion");

            migrationBuilder.DropIndex(
                name: "IX_DetallesConfeccion_TallaID",
                table: "DetallesConfeccion");

            migrationBuilder.DropIndex(
                name: "IX_DetallesConfeccion_TelaID",
                table: "DetallesConfeccion");

            migrationBuilder.DropIndex(
                name: "IX_DetallesConfeccion_TipoEstampadoID",
                table: "DetallesConfeccion");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_TipoDocumentoID",
                table: "Clientes");
        }
    }
}
