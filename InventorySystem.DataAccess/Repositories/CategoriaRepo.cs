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
    class CategoriaRepo : Repository<Categoria>, ICategoriaRepo
    {

        private readonly ApplicationDbContext _context;

        public CategoriaRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        
        public void Update(Categoria categoria)
        {
            //variable va a ser igual a lo encontrado por medio del id
            var categoriaDB = _context.Categorias.FirstOrDefault(x => x.Id == categoria.Id);
            if (categoria != null)
            {
                //Si no es nula la categoria entonces el nombre y estado de categoria sera igual a lo que reciba por parametro
                categoriaDB.Nombre = categoria.Nombre;
                categoriaDB.Estado = categoria.Estado;
            }
        }

    }
}
