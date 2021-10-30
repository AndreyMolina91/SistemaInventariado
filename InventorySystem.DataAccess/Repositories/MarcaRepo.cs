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
    public class MarcaRepo : Repository<Marca>, IMarcaRepo
    {
        private readonly ApplicationDbContext _context;

        public MarcaRepo(ApplicationDbContext context) :base(context)
        {
            _context = context;
        }
        public void Update(Marca marca)
        {
            var marcaDb = _context.Marcas.FirstOrDefault(x => x.Id == marca.Id);
            if (marcaDb != null)
            {
                marcaDb.Nombre = marca.Nombre;
                marcaDb.Estado = marca.Estado;
            }
        }
    }
}
