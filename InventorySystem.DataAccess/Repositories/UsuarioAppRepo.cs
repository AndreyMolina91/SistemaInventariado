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
    public class UsuarioAppRepo : Repository<UsuarioApp>, IUsuarioAppRepo
    {
        private readonly ApplicationDbContext _context;

        public UsuarioAppRepo(ApplicationDbContext context) :base(context)
        {
            _context = context;
        }

       
    }
}
