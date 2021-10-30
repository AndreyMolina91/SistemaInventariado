using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.DataAccess.Repositories.IRepositories
{
    //Repositorio Generico para los metodos obtener 1 objeto, obtener listado con todos los objetos, obtener el primer objeto donde T es la clase
    //en la que implementaremos las interfaces
    public interface IRepository<T> where T : class
    {
        //Clase obtener clase por id
        T GetT(int id);

        // Obtenemos una lista de tipo ienumerable de la clase obtener todo
        //Por parametros recibimos : una expresion de Linq dentro recibimos una func de tipo T donde T es la clase a la que vamos a aplicar el filtro
        //y un true o false, además lo inicializamos como nulo
        //En el segundo parametro recibimos una func de linq de tipo Interfaz Query de linq de tipo T, y un OrderQueryAble para ordenar por: inicializado nulo
        //un string el cual correspondrá a una de las propiedades del objeto, ejemplo: Nombre o id
        IEnumerable<T> GetTAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
            string includeprops = null
            );
        //otenemos el primer objeto de la lista de la clase segun la porpiedad que pasemos con el string
        T GetFirst(
            Expression<Func<T, bool>> filter = null,
            string includeprops = null
            );

        //Agregar donde recibiremos por parametro el objeto del tipo de la clase ejemplo bodega o producto
        void Add(T entity);

        //borrar por id
        void Remove(int id);

        //borrar por objeto o clase
        void Remove(T entity);

        //borrar un rango determinado en una lista
        void RemoveRange(IEnumerable<T> entitylist);
    }
}
