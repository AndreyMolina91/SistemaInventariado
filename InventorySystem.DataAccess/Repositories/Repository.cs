using InventorySystem.Data; //Using para el uso de nuestro appdbcontext
using InventorySystem.DataAccess.Repositories.IRepositories; //Para poder implementar la interfaz importamos el using
using Microsoft.EntityFrameworkCore;//Using para usar dbset
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.DataAccess.Repositories
{

    //Acá crearemos los metodos genericos para ser implementados en los Repos definidos para Bodega o productos
    public class Repository<T> : IRepository<T> where T : class //Interfaz a implementar
    {
        
        //Inicialización de Context y un DbSet interno para nuestra clase que implementará la interfaz
        private readonly ApplicationDbContext _context;
        internal DbSet<T> _dbset;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }

        //Implementación de la interfaz

        public void Add(T entity)
        {
            _dbset.Add(entity); //Nuestro dbset mediante el metodo add le asignamos la entidad recibida por parametro
        }

        public T GetFirst(Expression<Func<T, bool>> filter = null, string includeprops = null)
        {
            IQueryable<T> query = _dbset; //Creamos una variable de tipo IQueryable y será igual a nuestro dbset

            if (filter != null)
            {
                query = query.Where(filter); // similar a un select * from where... donde filter nos hará las veces del where

            }

            if (includeprops != null)
            {
                //para cada item en nuestras propiedades del objeto sea producto por ejemplo, lo vamos a separar con split cuando encuentre una ,
                //de esta manera estará referenciando un objeto diferente.
                foreach (var item in includeprops.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }

            return query.FirstOrDefault(); //Retornamos el primero de la lista
        }

        public T GetT(int id)
        {
            return _dbset.Find(id); //Por medio del dbset metodo find encontramos el objeto por id y lo retornamos
        }

        public IEnumerable<T> GetTAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, string includeprops = null)
        {
            IQueryable<T> query = _dbset; //Creamos una variable de tipo IQueryable y será igual a nuestro dbset

            if (filter != null)
            {
                query = query.Where(filter); // similar a un select * from where... donde filter nos hará las veces del where

            }

            if (includeprops != null)
            {
                //para cada objeto que contenga propiedades como el modelo marca o categoria por ejemplo, lo vamos a separar con split cuando encuentre una ,
                //de esta manera estará referenciando un objeto diferente al que viene vacio.
                foreach (var item in includeprops.Split(new char[] { ','}, StringSplitOptions.RemoveEmptyEntries ))
                {
                    query = query.Include(item);
                }
            }

            if (orderby != null)
            {
                return orderby(query).ToList(); //Listamos segun el dato recibido por medio del query
            }

            return query.ToList(); //Listamos una vez pasadas todas las validaciones

        }

        public void Remove(int id)
        {
            T entity = _dbset.Find(id); //Creamos una entidad de tipo clase generica donde T es la Clase a buscar segun el id
            Remove(entity); //llamamos el metodo remover por entidad y eliminamos todo el objeto
        }

        public void Remove(T entity)
        {
            _dbset.Remove(entity); //Eliminamos la entidad recibida por parametros
        }

        public void RemoveRange(IEnumerable<T> entitylist)
        {
            _dbset.RemoveRange(entitylist);
        }
    }
}
