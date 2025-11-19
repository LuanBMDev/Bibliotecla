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

        public void Add(Titulo entity)
        {
            string sql = "INSERT INTO Titulo (NomeTitulo, Genero, Autor) " +
                         "VALUES (@NomeTitulo, @Genero, @Autor)";

            using (var cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@NomeTitulo", entity.NomeTitulo);
                cmd.Parameters.AddWithValue("@Genero", entity.GeneroTitulo);
                cmd.Parameters.AddWithValue("@Autor", entity.AutorTitulo);

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(Titulo entity)
        {
            string sql = "DELETE FROM Titulo WHERE CodTitulo = @CodTitulo";

            using (var cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@CodTitulo", entity.CodTitulo);

                cmd.ExecuteNonQuery();
            }
        }

        public List<Titulo> GetAll(string criterio)
        {
            string sql = "SELECT * FROM Titulo";

            if (!string.IsNullOrEmpty(criterio))
            {
                sql += " WHERE NomeTitulo LIKE @Criterio " +
                       "OR Genero LIKE @Criterio " +
                       "OR Autor LIKE @Criterio";
            }

            var titulos = new List<Titulo>();
            using (var cmd = new MySqlCommand(sql, conexao))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        titulos.Add(new Titulo
                        {
                            CodTitulo = reader.GetInt32("CodTitulo"),
                            NomeTitulo = reader.GetString("NomeTitulo"),
                            GeneroTitulo = reader.GetString("Genero"),
                            AutorTitulo = reader.GetString("Autor")
                        });
                    }
                }
            }
            return titulos;
        }

        public Titulo GetByID(int id)
        {
            string sql = "SELECT * FROM Titulo WHERE CodTitulo = @CodTitulo";

            using (var cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@CodTitulo", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Titulo
                        {
                            CodTitulo = reader.GetInt32("CodTitulo"),
                            NomeTitulo = reader.GetString("NomeTitulo"),
                            GeneroTitulo = reader.GetString("Genero"),
                            AutorTitulo = reader.GetString("Autor")
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public void Update(Titulo entity)
        {
            string sql = "UPDATE Titulo SET NomeTitulo = @NomeTitulo, " +
                         "Genero = @Genero, Autor = @Autor " +
                         "WHERE CodTitulo = @CodTitulo";

            using (var cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@NomeTitulo", entity.NomeTitulo);
                cmd.Parameters.AddWithValue("@Genero", entity.GeneroTitulo);
                cmd.Parameters.AddWithValue("@Autor", entity.AutorTitulo);
                cmd.Parameters.AddWithValue("@CodTitulo", entity.CodTitulo);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
