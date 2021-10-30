using InventorySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.DataAccess.Repositories.IRepositories
{
    public interface ICategoriaRepo : IRepository<Categoria>
    {
        //Metodo actualizar de categorias
        void Update(Categoria categoria);
    }
}
