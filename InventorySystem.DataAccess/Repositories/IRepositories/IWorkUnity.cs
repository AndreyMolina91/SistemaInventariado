using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.DataAccess.Repositories.IRepositories
{
    public interface IWorkUnity : IDisposable //IDIsposable Permite deshacer cualquier recurso obtenido del sistema y liberar objetos que ya no se esten usando
    {
        IBodegaRepo Bodega { get; }
        ICategoriaRepo Categoria { get; }
        IMarcaRepo Marca { get; }
        IProductoRepo Producto { get; }

        IUsuarioAppRepo UsuarioApp { get; }

        //Creamos un metodo guardar para implementar
        void SaveData();
    }
}
