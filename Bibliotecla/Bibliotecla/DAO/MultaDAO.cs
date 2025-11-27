using Bibliotecla.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotecla.DAO
{
    internal class MultaDAO : DAO<Bibliotecla.model.Multa>
    {
        private readonly MySqlConnection conexao;

        public MultaDAO(MySqlConnection conexao)
        {
            this.conexao = conexao;
        }

        public bool Inserir(Bibliotecla.model.Multa entity)
        {
            string sql = "INSERT INTO Multa (CodLeitor, PrecoMulta, CodEmpres) " +
                         "VALUES (@CodLeitor, @PrecoMulta, @CodEmpres)";
            int linhas_afetadas = 0;

            conexao.Open();

            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@CodLeitor", entity.Leitor.CodPessoa);
                cmd.Parameters.AddWithValue("@PrecoMulta", entity.PrecoMulta);
                cmd.Parameters.AddWithValue("@CodEmpres", entity.Emprestimo.CodEmprestimo);

                linhas_afetadas = cmd.ExecuteNonQuery();

                conexao.Close();
            }
            return linhas_afetadas >= 1;
        }

        public bool Alterar(Bibliotecla.model.Multa entity)
        {
            string sql = "UPDATE Multa SET " +
                         "CodLeitor = @CodLeitor, " +
                         "PrecoMulta = @PrecoMulta, " +
                         "CodEmpres = @CodEmpres " +
                         "WHERE CodMulta = @CodMulta";

            int linhas_afetadas = 0;

            conexao.Open();

            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@CodLeitor", entity.Leitor.CodPessoa);
                cmd.Parameters.AddWithValue("@PrecoMulta", entity.PrecoMulta);
                cmd.Parameters.AddWithValue("@CodEmpres", entity.Emprestimo);
                cmd.Parameters.AddWithValue("@CodMulta", entity.CodMulta);

                linhas_afetadas = cmd.ExecuteNonQuery();
                conexao.Close();
            }
            return linhas_afetadas >= 1;
        }

        public bool Remover(Bibliotecla.model.Multa entity)
        {
            string sql = "DELETE FROM Multa WHERE CodMulta = @CodMulta";
            int linhas_afetadas = 0;

            conexao.Open();

            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@CodMulta", entity.CodMulta);

                linhas_afetadas = cmd.ExecuteNonQuery();
                conexao.Close();
            }
            return linhas_afetadas >= 1;
        }

        public Bibliotecla.model.Multa BuscarID(Bibliotecla.model.Multa entity)
        {
            string sql = "SELECT * FROM Multa WHERE CodMulta = @CodMulta";
            Bibliotecla.model.Multa multa = null;
            conexao.Open();

            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@CodMulta", entity.CodMulta);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int codMulta = reader.GetInt32("@CodMulta");
                        int codLeitor = reader.GetInt32("@CodLeitor");
                        LeitorFuncioDAO leitorDAO = new LeitorFuncioDAO(conexao);
                        LeitorFuncio leitor = leitorDAO.BuscarID(new LeitorFuncio { CodPessoa = codLeitor });
                        double precoMulta = reader.GetDouble("@PrecoMulta");
                        int codEmpres = reader.GetInt32("@CodEmpres");
                        EmprestimoDAO empresDAO = new EmprestimoDAO(conexao);
                        Emprestimo emprestimo = empresDAO.BuscarID(new Emprestimo(null, null) { CodEmprestimo = codEmpres });
                        multa = new Bibliotecla.model.Multa(codMulta, leitor, precoMulta, emprestimo);
                    }
                }
                conexao.Close();
            }
            return multa;
        }

        public List<Bibliotecla.model.Multa> Listar(string critério)
        {
            string sql = "SELECT * FROM Multa";
            if (!string.IsNullOrEmpty(critério))
            {
                sql += " WHERE " + critério;
            }

            List<Bibliotecla.model.Multa> multas = new List<Bibliotecla.model.Multa>();

            conexao.Open();

            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int codMulta = reader.GetInt32("CodMulta");
                        int codLeitor = reader.GetInt32("CodLeitor");
                        LeitorFuncioDAO leitorDAO = new LeitorFuncioDAO(conexao);
                        LeitorFuncio leitor = leitorDAO.BuscarID(new LeitorFuncio { CodPessoa = codLeitor });
                        double precoMulta = reader.GetDouble("PrecoMulta");
                        int codEmpres = reader.GetInt32("CodEmpres");
                        EmprestimoDAO empresDAO = new EmprestimoDAO(conexao);
                        Emprestimo emprestimo = empresDAO.BuscarID(new Emprestimo(null, null) { CodEmprestimo = codEmpres });
                        Bibliotecla.model.Multa multa = new Bibliotecla.model.Multa(codMulta, leitor, precoMulta, emprestimo);
                        multas.Add(multa);
                    }
                }
                conexao.Close();
            }

            return multas;
        }
    }
}
