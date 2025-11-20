using Bibliotecla.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotecla.DAO
{
    internal class TituloDAO : DAO<Titulo>
    {
        private readonly MySqlConnection conexao;

        public TituloDAO(MySqlConnection conexao)
        {
            this.conexao = conexao;
        }

        public bool Inserir(Titulo entity)
        {
            string sql = "INSERT INTO titulo (nomeTitulo, generoTitulo, autorTitulo) " +
                         "VALUES (@nomeTitulo, @generoTitulo, @autorTitulo)";

            int linhas_afetadas = 0;

            conexao.Open();

            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@nomeTitulo", entity.NomeTitulo);
                cmd.Parameters.AddWithValue("@generoTitulo", entity.GeneroTitulo);
                cmd.Parameters.AddWithValue("@autorTitulo", entity.AutorTitulo);

                linhas_afetadas = cmd.ExecuteNonQuery();
                conexao.Close();
            }

            return linhas_afetadas >= 1;
        }

        public bool Alterar(Titulo entity)
        {
            string sql = "UPDATE Titulo SET " +
                         "nomeTitulo = @nomeTitulo, " +
                         "generoTitulo = @generoTitulo, " +
                         "autorTitulo = @autorTitulo " +
                         "WHERE CodTitulo = @CodTitulo";
            int linhas_afetadas = 0;
            conexao.Open();

            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@nomeTitulo", entity.NomeTitulo);
                cmd.Parameters.AddWithValue("@generoTitulo", entity.GeneroTitulo);
                cmd.Parameters.AddWithValue("@autorTitulo", entity.AutorTitulo);
                cmd.Parameters.AddWithValue("@codTitulo", entity.CodTitulo);
                linhas_afetadas = cmd.ExecuteNonQuery();
                conexao.Close();
            }

            return linhas_afetadas >= 1;
        }

        public bool Remover(Titulo entity)
        {
            string sql = "DELETE FROM Titulo WHERE CodTitulo = @CodTitulo";

            int linhas_afetadas = 0;

            conexao.Open();

            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@codTitulo", entity.CodTitulo);
                linhas_afetadas = cmd.ExecuteNonQuery();
                conexao.Close();
            }

            return linhas_afetadas >= 1;
        }

        public Titulo BuscarID(Titulo entity)
        {
            string sql = "SELECT * FROM Titulo WHERE CodTitulo = @CodTitulo";
            Titulo titulo = null;
            conexao.Open();

            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@codTitulo", entity.CodTitulo);
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        titulo = new Titulo
                        {
                            CodTitulo = Convert.ToInt32(reader["CodTitulo"]),
                            NomeTitulo = reader["nomeTitulo"].ToString(),
                            GeneroTitulo = reader["generoTitulo"].ToString(),
                            AutorTitulo = reader["autorTitulo"].ToString()
                        };
                    }
                }
                conexao.Close();
            }

            return titulo;
        }

        public List<Titulo> Listar(string critério)
        {
            string sql = "SELECT * FROM Titulo";

            if (!string.IsNullOrEmpty(critério))
            {
                sql += " WHERE " + critério;
            }
            List<Titulo> titulos = new List<Titulo>();
            Titulo titulo = null;

            conexao.Open();

            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        titulo = new Titulo
                        {
                            CodTitulo = Convert.ToInt32(reader["CodTitulo"]),
                            NomeTitulo = reader["nomeTitulo"].ToString(),
                            GeneroTitulo = reader["generoTitulo"].ToString(),
                            AutorTitulo = reader["autorTitulo"].ToString()
                        };
                        titulos.Add(titulo);
                    }
                }
                conexao.Close();
            }
            return titulos;
        }
    }
}
