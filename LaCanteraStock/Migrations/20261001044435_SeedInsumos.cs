using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LaCanteraStock.Migrations
{
    /// <inheritdoc />
    public partial class SeedInsumos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "CategoriaID", "Activo", "Descripcion", "Nombre" },
                values: new object[,]
                {
                    { 1, true, "Camisetas deportivas", "Camiseta" },
                    { 2, true, "Shorts deportivos", "Short" },
                    { 3, true, "Pantalones deportivos", "Pantalón" },
                    { 4, true, "Casacas y abrigos", "Casaca" }
                });

            migrationBuilder.InsertData(
                table: "Tallas",
                columns: new[] { "TallaID", "Nombre", "Orden" },
                values: new object[,]
                {
                    { (short)1, "S", (byte)0 },
                    { (short)2, "M", (byte)0 },
                    { (short)3, "L", (byte)0 },
                    { (short)4, "XL", (byte)0 },
                    { (short)5, "XXL", (byte)0 }
                });

            migrationBuilder.InsertData(
                table: "Telas",
                columns: new[] { "TelaID", "Activo", "Descripcion", "Nombre" },
                values: new object[,]
                {
                    { 1, true, "Suave y transpirable", "Algodón peinado" },
                    { 2, true, "Secado rápido", "Poliéster Dry-Fit" },
                    { 3, true, "Elástico y cómodo", "Jersey deportivo" }
                });

            migrationBuilder.InsertData(
                table: "TiposEstampado",
                columns: new[] { "TipoEstampadoID", "Nombre" },
                values: new object[,]
                {
                    { (byte)1, "Sublimado" },
                    { (byte)2, "Serigrafía" },
                    { (byte)3, "Bordado" },
                    { (byte)4, "Vinil" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "CategoriaID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "CategoriaID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "CategoriaID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "CategoriaID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tallas",
                keyColumn: "TallaID",
                keyValue: (short)1);

            migrationBuilder.DeleteData(
                table: "Tallas",
                keyColumn: "TallaID",
                keyValue: (short)2);

            migrationBuilder.DeleteData(
                table: "Tallas",
                keyColumn: "TallaID",
                keyValue: (short)3);

            migrationBuilder.DeleteData(
                table: "Tallas",
                keyColumn: "TallaID",
                keyValue: (short)4);

            migrationBuilder.DeleteData(
                table: "Tallas",
                keyColumn: "TallaID",
                keyValue: (short)5);

            migrationBuilder.DeleteData(
                table: "Telas",
                keyColumn: "TelaID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Telas",
                keyColumn: "TelaID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Telas",
                keyColumn: "TelaID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TiposEstampado",
                keyColumn: "TipoEstampadoID",
                keyValue: (byte)1);

            migrationBuilder.DeleteData(
                table: "TiposEstampado",
                keyColumn: "TipoEstampadoID",
                keyValue: (byte)2);

            migrationBuilder.DeleteData(
                table: "TiposEstampado",
                keyColumn: "TipoEstampadoID",
                keyValue: (byte)3);

            migrationBuilder.DeleteData(
                table: "TiposEstampado",
                keyColumn: "TipoEstampadoID",
                keyValue: (byte)4);
        }
    }
}
