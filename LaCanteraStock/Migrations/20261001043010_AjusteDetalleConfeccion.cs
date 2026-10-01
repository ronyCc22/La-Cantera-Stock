using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaCanteraStock.Migrations
{
    /// <inheritdoc />
    public partial class AjusteDetalleConfeccion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisenoDescripcion",
                table: "DetallesConfeccion");

            migrationBuilder.DropColumn(
                name: "RutaImagenDiseno",
                table: "DetallesConfeccion");

            migrationBuilder.RenameColumn(
                name: "DetallePedidoID",
                table: "DetallesConfeccion",
                newName: "DetalleConfeccionID");

            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "DetallesConfeccion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistro",
                table: "DetallesConfeccion",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Observacion",
                table: "DetallesConfeccion",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "DetallesConfeccion");

            migrationBuilder.DropColumn(
                name: "FechaRegistro",
                table: "DetallesConfeccion");

            migrationBuilder.DropColumn(
                name: "Observacion",
                table: "DetallesConfeccion");

            migrationBuilder.RenameColumn(
                name: "DetalleConfeccionID",
                table: "DetallesConfeccion",
                newName: "DetallePedidoID");

            migrationBuilder.AddColumn<string>(
                name: "DisenoDescripcion",
                table: "DetallesConfeccion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RutaImagenDiseno",
                table: "DetallesConfeccion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
