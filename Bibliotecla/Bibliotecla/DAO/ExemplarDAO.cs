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
            string sql = "INSERT INTO exemplar (anoPubli, estadoFisico, editoraExemplar, codTitulo) " +
                         "VALUES (@anoPubli, @estadoFisico, @editoraExemplar, @codTitulo)";
            int linhas_afetadas = 0;
            conexao.Open();

            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@anoPubli", entity.AnoPubli);
                cmd.Parameters.AddWithValue("@estadoFisico", entity.EstadoFisico);
                cmd.Parameters.AddWithValue("@editoraExemplar", entity.EditoraExemplar);
                cmd.Parameters.AddWithValue("@codTitulo", entity.Titulo.CodTitulo);
                linhas_afetadas = cmd.ExecuteNonQuery();
                conexao.Close();
            }

            return linhas_afetadas >= 1;
        }

        public bool Alterar(Exemplar entity)
        {
            string sql = "UPDATE exemplar SET " +
                         "anoPubli = @anoPubli, " +
                         "estadoFisico = @estadoFisico, " +
                         "editoraExemplar = @editoraExemplar, " +
                         "codTitulo = @codTitulo " +
                         "WHERE codExemplar = @codExemplar";
            int linhas_afetadas = 0;

            conexao.Open();

            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@anoPubli", entity.AnoPubli);
                cmd.Parameters.AddWithValue("@estadoFisico", entity.EstadoFisico);
                cmd.Parameters.AddWithValue("@editoraExemplar", entity.EditoraExemplar);
                cmd.Parameters.AddWithValue("@codTitulo", entity.Titulo.CodTitulo);
                cmd.Parameters.AddWithValue("@codExemplar", entity.CodExemplar);

                linhas_afetadas = cmd.ExecuteNonQuery();

                conexao.Close();
            }

            return linhas_afetadas >= 1;
        }
        
        public bool Remover(Exemplar entity)
        {
            string sql = "DELETE FROM Exemplar WHERE CodExemplar = @CodExemplar";
            int linhas_afetadas = 0;
            conexao.Open();

            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@CodExemplar", entity.CodExemplar);
                linhas_afetadas = cmd.ExecuteNonQuery();
                conexao.Close();
            }

            return linhas_afetadas >= 1;
        }

        public Exemplar BuscarID(Exemplar entity)
        {
            string sql = "SELECT * FROM Exemplar WHERE CodExemplar = @CodExemplar";
            Exemplar exemplar = null;
            conexao.Open();

            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@CodExemplar", entity.CodExemplar);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int codExemplar = reader.GetInt32("codExemplar");
                        string anoPubli = reader.GetString("anoPubli");
                        string estadoFisico = reader.GetString("estadoFisico");
                        string editoraExemplar = reader.GetString("editoraExemplar");
                        int codTitulo = reader.GetInt32("codTitulo");
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
                        int codExemplar = reader.GetInt32("codExemplar");
                        string anoPubli = reader.GetString("anoPubli");
                        string estadoFisico = reader.GetString("estadoFisico");
                        string editoraExemplar = reader.GetString("editoraExemplar");
                        int codTitulo = reader.GetInt32("codTitulo");
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
