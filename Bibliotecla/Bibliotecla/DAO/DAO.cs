using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotecla.DAO
{
    internal interface DAO<T>
    {
        bool Inserir(T entity);
        T BuscarID(T entity);
        bool Alterar(T entity);
        bool Remover(T entity);
        List<T> Listar(string critério);
    }
}
