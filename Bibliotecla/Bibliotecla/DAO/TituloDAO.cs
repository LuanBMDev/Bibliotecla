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
            string sql = "INSERT INTO Titulo (NomeTitulo, GeneroTitulo, AutorTitulo) " +
                         "VALUES (@NomeTitulo, @GeneroTitulo, @AutorTitulo)";

            int linhas_afetadas = 0;

            conexao.Open();

            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@NomeTitulo", entity.NomeTitulo);
                cmd.Parameters.AddWithValue("@GeneroTitulo", entity.GeneroTitulo);
                cmd.Parameters.AddWithValue("@AutorTitulo", entity.AutorTitulo);

                linhas_afetadas = cmd.ExecuteNonQuery();
                conexao.Close();
            }

            return linhas_afetadas >= 1;
        }

        public bool Alterar(Titulo entity)
        {
            string sql = "UPDATE Titulo SET " +
                         "nomeTitulo = @NomeTitulo, " +
                         "generoTitulo = @GeneroTitulo, " +
                         "autorTitulo = @AutorTitulo " +
                         "WHERE CodTitulo = @CodTitulo";
            int linhas_afetadas = 0;
            conexao.Open();

            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@NomeTitulo", entity.NomeTitulo);
                cmd.Parameters.AddWithValue("@GeneroTitulo", entity.GeneroTitulo);
                cmd.Parameters.AddWithValue("@AutorTitulo", entity.AutorTitulo);
                cmd.Parameters.AddWithValue("@CodTitulo", entity.CodTitulo);
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
                cmd.Parameters.AddWithValue("@CodTitulo", entity.CodTitulo);
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
                cmd.Parameters.AddWithValue("@CodTitulo", entity.CodTitulo);
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        titulo = new Titulo
                        {
                            CodTitulo = Convert.ToInt32(reader["CodTitulo"]),
                            NomeTitulo = reader["NomeTitulo"].ToString(),
                            GeneroTitulo = reader["GeneroTitulo"].ToString(),
                            AutorTitulo = reader["AutorTitulo"].ToString()
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
                            NomeTitulo = reader["NomeTitulo"].ToString(),
                            GeneroTitulo = reader["GeneroTitulo"].ToString(),
                            AutorTitulo = reader["AutorTitulo"].ToString()
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
