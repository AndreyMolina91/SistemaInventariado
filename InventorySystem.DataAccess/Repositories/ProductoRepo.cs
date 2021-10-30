using InventorySystem.Data;
using InventorySystem.DataAccess.Repositories.IRepositories;
using InventorySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.DataAccess.Repositories
{
    class ProductoRepo : Repository<Producto>, IProductoRepo
    {
        private readonly ApplicationDbContext _context;

        public ProductoRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public void Update(Producto producto)
        {
            var productoDb = _context.Productos.FirstOrDefault(x => x.Id == producto.Id);
            if (productoDb != null)
            {
                if (producto.UrlImagen != null)
                {
                    productoDb.UrlImagen = producto.UrlImagen;
                }
                if (producto.PadreId == 0)
                {
                    productoDb.PadreId = null;
                }
                else
                {
                    productoDb.PadreId = producto.PadreId;
                }

                productoDb.SerieId = producto.SerieId;
                productoDb.Descripcion = producto.Descripcion;
                productoDb.Precio = producto.Precio;
                productoDb.Costo = producto.Costo;
                productoDb.CategoriaId = producto.CategoriaId;
                productoDb.MarcaId = producto.MarcaId;


            }
        }
    }
}
