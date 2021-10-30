using InventorySystem.Models; //Uso del modelo bodega
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.DataAccess.Repositories.IRepositories
{
    public interface IBodegaRepo : IRepository<Bodega>
    {
        void Update(Bodega bodega);
       
    }
}
