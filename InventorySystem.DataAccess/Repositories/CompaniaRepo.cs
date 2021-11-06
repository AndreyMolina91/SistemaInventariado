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
    public class CompaniaRepo : Repository<Compania>, ICompaniaRepo
    {
        private readonly ApplicationDbContext _context;

        public CompaniaRepo(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
        public void Update(Compania compania)
        {
            throw new NotImplementedException();
            
        }
    }
}
