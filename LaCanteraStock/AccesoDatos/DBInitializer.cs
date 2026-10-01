using LaCanteraStock.Models;

namespace LaCanteraStock.AccesoDatos
{
    public class DBInitializer
    {
        public static void Initialize(BDContexto context)
        {
            // Si ya hay productos creados, no duplicar
            if (context.Productos.Any())
            {
                return;
            }

            // 1. TALLAS DEPORTIVAS 
            var tallas = new Talla[]
            {
                new Talla { Nombre = "14", Orden = 1 },
                new Talla { Nombre = "16", Orden = 2 },
                new Talla { Nombre = "S", Orden = 3 },
                new Talla { Nombre = "M", Orden = 4 },
                new Talla { Nombre = "L", Orden = 5 },
                new Talla { Nombre = "XL", Orden = 6 }
            };
            context.Tallas.AddRange(tallas);
            context.SaveChanges();

            // 2. CATEGORÍAS (Camisetas y Shorts)
            var catCamisetas = new Categoria
            {
                Nombre = "Camisetas",
                Descripcion = "Camisetas de fútbol nacionales e internacionales de mostrador",
                Activo = true
            };
            var catShorts = new Categoria
            {
                Nombre = "Shorts",
                Descripcion = "Shorts deportivos de juego y entrenamiento para mostrador",
                Activo = true
            };
            context.Categorias.AddRange(catCamisetas, catShorts);
            context.SaveChanges();

            // 3. PRODUCTOS 
            // Nota: En la descripción dejamos indicada la ruta de la foto local en wwwroot/images/catalogo/
            var productos = new Producto[]
            {
                // ========== 8 CAMISETAS ==========
                new Producto
                {
                    Nombre = "Camiseta Inter Miami Oficial",
                    CategoriaID = catCamisetas.CategoriaID,
                    Descripcion = "Confección oficial en tela win transpirable. Foto: /images/catalogo/camiseta_miami.jpg",
                    PrecioUnitario = 35.00m,
                    EsConjunto = false,
                    Activo = true
                },
                new Producto
                {
                    Nombre = "Camiseta Milan Retro",
                    CategoriaID = catCamisetas.CategoriaID,
                    Descripcion = "Cuello camisero, icónica. Foto: /images/catalogo/camiseta_milan.jpeg",
                    PrecioUnitario = 45.00m,
                    EsConjunto = false,
                    Activo = true
                },
                new Producto
                {
                    Nombre = "Camiseta Despedida de Messi de Argentina",
                    CategoriaID = catCamisetas.CategoriaID,
                    Descripcion = "El último baile de Messi. Foto: /images/catalogo/camiseta_argentina.jpeg",
                    PrecioUnitario = 50.00m,
                    EsConjunto = false,
                    Activo = true
                },
                new Producto
                {
                    Nombre = "Camiseta Real Madrid Cuello Camisero",
                    CategoriaID = catCamisetas.CategoriaID,
                    Descripcion = "Diseño clásico cuello polo con detalles oscuros. Foto: /images/catalogo/camiseta_madrid.jpg",
                    PrecioUnitario = 45.00m,
                    EsConjunto = false,
                    Activo = true
                },
                new Producto
                {
                    Nombre = "Camiseta Brasil Canarinha Clásica",
                    CategoriaID = catCamisetas.CategoriaID,
                    Descripcion = "Verdeamarela clásica con acabados en cuello y mangas. Foto: /images/catalogo/camiseta_brasil.jpg",
                    PrecioUnitario = 38.00m,
                    EsConjunto = false,
                    Activo = true
                },

                // ========== 5 SHORTS ==========
                new Producto
                {
                    Nombre = "Short Deportivo Alianza Lima Azul Marino",
                    CategoriaID = catShorts.CategoriaID,
                    Descripcion = "Short con pretina elástica y escudo bordado. Foto: /images/catalogo/short_alianza.jpg",
                    PrecioUnitario = 22.00m,
                    EsConjunto = false,
                    Activo = true
                },
                new Producto
                {
                    Nombre = "Short Selección Peruana Blanco Oficial",
                    CategoriaID = catShorts.CategoriaID,
                    Descripcion = "Short blanco de juego con vivos laterales rojos. Foto: /images/catalogo/short_peru.jpg",
                    PrecioUnitario = 20.00m,
                    EsConjunto = false,
                    Activo = true
                },
                new Producto
                {
                    Nombre = "Short Real Madrid Negro Alterno",
                    CategoriaID = catShorts.CategoriaID,
                    Descripcion = "Short negro con bandas laterales doradas. Foto: /images/catalogo/short_madrid.jpg",
                    PrecioUnitario = 22.00m,
                    EsConjunto = false,
                    Activo = true
                },
                new Producto
                {
                    Nombre = "Short Neutro Negro Deportivo Multiuso",
                    CategoriaID = catShorts.CategoriaID,
                    Descripcion = "Short negro clásico combinable con cualquier camiseta. Foto: /images/catalogo/short_neutro.jpg",
                    PrecioUnitario = 18.00m,
                    EsConjunto = false,
                    Activo = true
                },
                new Producto
                {
                    Nombre = "Short UTC Cajamarca Crema Titular",
                    CategoriaID = catShorts.CategoriaID,
                    Descripcion = "Short de competencia oficial UTC Cajamarca. Foto: /images/catalogo/short_utc.jpg",
                    PrecioUnitario = 20.00m,
                    EsConjunto = false,
                    Activo = true
                }
            };

            context.Productos.AddRange(productos);
            context.SaveChanges();

            // 4. EXISTENCIAS EN TIENDA POR TALLA (ProductoTalla)
            var productoTallas = new List<ProductoTalla>();
            foreach (var prod in productos)
            {
                // Talla S (TallaID = tallas[2])
                productoTallas.Add(new ProductoTalla
                {
                    ProductoID = prod.ProductoID,
                    TallaID = tallas[2].TallaID,
                    StockActual = 6,
                    StockMinimo = 2
                });

                // Talla M (TallaID = tallas[3])
                productoTallas.Add(new ProductoTalla
                {
                    ProductoID = prod.ProductoID,
                    TallaID = tallas[3].TallaID,
                    StockActual = 10,
                    StockMinimo = 3
                });

                // Talla L (TallaID = tallas[4])
                productoTallas.Add(new ProductoTalla
                {
                    ProductoID = prod.ProductoID,
                    TallaID = tallas[4].TallaID,
                    StockActual = 5,
                    StockMinimo = 2
                });
            }

            context.ProductoTallas.AddRange(productoTallas);
            context.SaveChanges();
        }
}
}
