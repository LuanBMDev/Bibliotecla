using Bibliotecla.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotecla.DAO
{
    internal class LeitorDAO : DAO<Leitor>
    {
        private readonly MySqlConnection conexao;

        public LeitorDAO(MySqlConnection conexao)
        {
            this.conexao = conexao;
        }

        public bool Inserir(Leitor entity)
        {
            throw new NotImplementedException();
        }

        public bool Alterar(Leitor entity)
        {
            throw new NotImplementedException();
        }

        public bool Remover(Leitor entity)
        {
            throw new NotImplementedException();
        }

        public Leitor BuscarID(Leitor entity)
        {
            throw new NotImplementedException();
        }

        public List<Leitor> Listar(string critério)
        {
            throw new NotImplementedException();
        }
    }
}
