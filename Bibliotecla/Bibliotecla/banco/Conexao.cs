using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Bibliotecla.banco
{
    internal class Conexao
    {
        private static readonly string strConexao = 
            "Server=localhost;Database=bibliotecladb;Uid=root;";

        public static MySqlConnection Conectar()
        {
            var conexao = new MySqlConnection(strConexao);
            conexao.Open();
            return conexao;
        }

        public static void Desconectar(MySqlConnection conexao)
        {
            if (conexao != null && conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
        }
    }
}
