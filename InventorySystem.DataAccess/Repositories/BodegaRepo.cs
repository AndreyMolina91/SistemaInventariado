using InventorySystem.Data; //Para usar context
using InventorySystem.DataAccess.Repositories.IRepositories; //Para poder heredar de IBodegaRepo
using InventorySystem.Models; //uso de modelo bodega
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.DataAccess.Repositories
{
    public class BodegaRepo : Repository<Bodega>, IBodegaRepo
    {
        private readonly ApplicationDbContext _context;
        //Generar el constructor es necesario para poder usar Repository ya que dentro de esta clase se utiliza 1 context en el constructor
        public BodegaRepo(ApplicationDbContext context) : base(context)
        {
            _context = context; //Inicializamos el contexto con el contexto que generamos con nuestro appdbcontext
        }

        //Implementacion de la interfaz IBodegaRepo
        public void Update(Bodega bodega)
        {
            var bodegaDB = _context.Bodegas.FirstOrDefault(x => x.Id == bodega.Id);
            if (bodegaDB != null)
            {
                bodegaDB.Nombre = bodega.Nombre;
                bodegaDB.Descripcion = bodega.Descripcion;
                bodegaDB.Estado = bodega.Estado;

                _context.SaveChanges(); 
            }
        }
    }
}
