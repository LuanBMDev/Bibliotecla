using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotecla.DAO
{
    internal interface DAO<T>
    {
        void Add(T entity);
        T GetByID(int id);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetAll();
    }
}
