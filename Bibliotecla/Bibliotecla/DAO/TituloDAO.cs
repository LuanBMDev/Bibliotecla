using Bibliotecla.model;
using Bibliotecla.banco;
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
        private MySqlConnection conexao;

        public bool Inserir(Titulo entity)
        {
            string sql = "INSERT INTO Titulo (NomeTitulo, Genero, Autor) " +
                         "VALUES (@NomeTitulo, @Genero, @Autor)";

            int linhas_afetadas = 0;

            conexao = Conexao.Conectar();

            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@NomeTitulo", entity.NomeTitulo);
                cmd.Parameters.AddWithValue("@Genero", entity.GeneroTitulo);
                cmd.Parameters.AddWithValue("@Autor", entity.AutorTitulo);

                linhas_afetadas = cmd.ExecuteNonQuery();
                Conexao.Desconectar(conexao);
            }

            return linhas_afetadas >= 1;
        }

        public bool Alterar(Titulo entity)
        {
            string sql = "UPDATE Titulo SET " +
                         "NomeTitulo = @NomeTitulo, " +
                         "Genero = @Genero, " +
                         "Autor = @Autor " +
                         "WHERE CodTitulo = @CodTitulo";
            int linhas_afetadas = 0;
            conexao = Conexao.Conectar();

            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@NomeTitulo", entity.NomeTitulo);
                cmd.Parameters.AddWithValue("@Genero", entity.GeneroTitulo);
                cmd.Parameters.AddWithValue("@Autor", entity.AutorTitulo);
                cmd.Parameters.AddWithValue("@CodTitulo", entity.CodTitulo);
                linhas_afetadas = cmd.ExecuteNonQuery();
                Conexao.Desconectar(conexao);
            }

            return linhas_afetadas >= 1;
        }

        public bool Remover(Titulo entity)
        {
            string sql = "DELETE FROM Titulo WHERE CodTitulo = @CodTitulo";

            int linhas_afetadas = 0;

            conexao = Conexao.Conectar();

            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@CodTitulo", entity.CodTitulo);
                linhas_afetadas = cmd.ExecuteNonQuery();
                Conexao.Desconectar(conexao);
            }

            return linhas_afetadas >= 1;
        }

        public Titulo BuscarID(Titulo entity)
        {
            string sql = "SELECT * FROM Titulo WHERE CodTitulo = @CodTitulo";
            Titulo titulo = null;
            conexao = Conexao.Conectar();

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
                            GeneroTitulo = reader["Genero"].ToString(),
                            AutorTitulo = reader["Autor"].ToString()
                        };
                    }
                }
                Conexao.Desconectar(conexao);
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

            conexao = Conexao.Conectar();

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
                            GeneroTitulo = reader["Genero"].ToString(),
                            AutorTitulo = reader["Autor"].ToString()
                        };
                        titulos.Add(titulo);
                    }
                }
                Conexao.Desconectar(conexao);
            }
            return titulos;
        }
    }
}
