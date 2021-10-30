using InventorySystem.Data; //Para usar el dbcontext
using InventorySystem.DataAccess.Repositories.IRepositories; //IbodegaRepo
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.DataAccess.Repositories
{
    public class WorkUnity : IWorkUnity
    {
        private readonly ApplicationDbContext _context;
        public IBodegaRepo Bodega { get; private set; }

        public ICategoriaRepo Categoria { get; private set; }

        public IMarcaRepo Marca { get; private set; }

        public IProductoRepo Producto { get; private set; }

        public IUsuarioAppRepo UsuarioApp { get; private set; }

        public WorkUnity(ApplicationDbContext context)
        {
            _context = context;
            Bodega = new BodegaRepo(_context); //Inicializamos la propiedad
            Categoria = new CategoriaRepo(_context); //Categoria inicializada con el dbcontext por parametro
            Marca = new MarcaRepo(_context);//Ini Marca
            Producto = new ProductoRepo(_context);//Ini Producto
            UsuarioApp = new UsuarioAppRepo(_context);//Ini Usuarios del login
        }

        //Creamos un metodo para guardar cambios
        public void SaveData()
        {
            _context.SaveChanges();
        }

        //Metodo liberar memoria
        public void Dispose()
        {
            _context.Dispose(); //Liberamos memoria con el metodo
        }

        //NOTA: Para hacer accesibles a todo nuestro proyecto debemos hacer inyeccion de dependencias dentro de nuestro StartUp. 
    }
}
