using Bibliotecla.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotecla.DAO
{
    internal class ExemplarDAO : DAO<Exemplar>
    {
        private readonly MySqlConnection conexao;

        public ExemplarDAO(MySqlConnection conexao)
        {
            this.conexao = conexao;
        }

        public bool Inserir(Exemplar entity)
        {
            string sql = "INSERT INTO Exemplar (AnoPubli, EstadoFisc, Editora, CodTitulo) " +
                         "VALUES (@AnoPubli, @EstadoFisc, @Editora, @CodTitulo)";
            int linhas_afetadas = 0;
            conexao.Open();

            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@AnoPubli", entity.AnoPubli);
                cmd.Parameters.AddWithValue("@EstadoFisc", entity.EstadoFisico);
                cmd.Parameters.AddWithValue("@Editora", entity.EditoraExemplar);
                cmd.Parameters.AddWithValue("@CodTitulo", entity.Titulo.CodTitulo);
                linhas_afetadas = cmd.ExecuteNonQuery();
                conexao.Close();
            }

            return linhas_afetadas >= 1;
        }

        public bool Alterar(Exemplar entity)
        {
            string sql = "UPDATE Exemplar SET " +
                         "AnoPubli = @AnoPubli, " +
                         "EstadoFisc = @EstadoFisc, " +
                         "Editora = @Editora, " +
                         "CodTitulo = @CodTitulo " +
                         "WHERE CodExempl = @CodExempl";
            int linhas_afetadas = 0;

            conexao.Open();

            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@AnoPubli", entity.AnoPubli);
                cmd.Parameters.AddWithValue("@EstadoFisc", entity.EstadoFisico);
                cmd.Parameters.AddWithValue("@Editora", entity.EditoraExemplar);
                cmd.Parameters.AddWithValue("@CodTitulo", entity.Titulo.CodTitulo);
                cmd.Parameters.AddWithValue("@CodExempl", entity.CodExemplar);

                linhas_afetadas = cmd.ExecuteNonQuery();

                conexao.Close();
            }

            return linhas_afetadas >= 1;
        }

        public bool Remover(Exemplar entity)
        {
            string sql = "DELETE FROM Exemplar WHERE CodExempl = @CodExempl";
            int linhas_afetadas = 0;
            conexao.Open();

            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@CodExempl", entity.CodExemplar);
                linhas_afetadas = cmd.ExecuteNonQuery();
                conexao.Close();
            }

            return linhas_afetadas >= 1;
        }

        public Exemplar BuscarID(Exemplar entity)
        {
            string sql = "SELECT * FROM Exemplar WHERE CodExempl = @CodExempl";
            Exemplar exemplar = null;
            conexao.Open();

            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@CodExempl", entity.CodExemplar);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int codExemplar = reader.GetInt32("CodExempl");
                        string anoPubli = reader.GetString("AnoPubli");
                        string estadoFisico = reader.GetString("EstadoFisc");
                        string editoraExemplar = reader.GetString("Editora");
                        int codTitulo = reader.GetInt32("CodTitulo");
                        TituloDAO tituloDAO = new TituloDAO(conexao);
                        Titulo titulo = tituloDAO.BuscarID(new Titulo { CodTitulo = codTitulo });
                        exemplar = new Exemplar(codExemplar, anoPubli, estadoFisico, editoraExemplar, titulo);
                    }
                }
                conexao.Close();
            }

            return exemplar;
        }

        public List<Exemplar> Listar(string critério)
        {
            string sql = "SELECT * FROM Exemplar";
            if (!string.IsNullOrEmpty(critério))
            {
                sql += " WHERE " + critério;
            }

            List<Exemplar> exemplares = new List<Exemplar>();

            conexao.Open();

            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int codExemplar = reader.GetInt32("CodExempl");
                        string anoPubli = reader.GetString("AnoPubli");
                        string estadoFisico = reader.GetString("EstadoFisc");
                        string editoraExemplar = reader.GetString("Editora");
                        int codTitulo = reader.GetInt32("CodTitulo");
                        TituloDAO tituloDAO = new TituloDAO(conexao);
                        Titulo titulo = tituloDAO.BuscarID(new Titulo { CodTitulo = codTitulo });
                        Exemplar exemplar = new Exemplar(codExemplar, anoPubli, estadoFisico, editoraExemplar, titulo);
                        exemplares.Add(exemplar);
                    }
                }
                conexao.Close();
            }

            return exemplares;
        }
    }
}
