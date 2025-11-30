using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Bibliotecla.model;
using System.Runtime.InteropServices;

namespace Bibliotecla.DAO
{
    internal class EmprestimoDAO : DAO<Emprestimo>
    {
        private readonly MySqlConnection conexao;

        public EmprestimoDAO(MySqlConnection conexao)
        {
            this.conexao = conexao;
        }

        public bool Inserir(Emprestimo entity)
        {
            string sql = "INSERT INTO Emprestimo (CodExemplar, CodLeitor, DataEmpres, PrazoDevol, isAtrasado) " +
                         "VALUES (@CodExemplar, @CodLeitor, @DataEmprestimo, @PrazoDevol, @isAtrasado)";

            int linhas_afetadas = 0;

            conexao.Open();

            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@CodExemplar", entity.Exemplar.CodExemplar);
                cmd.Parameters.AddWithValue("@CodLeitor", entity.Leitor.CodPessoa);
                cmd.Parameters.AddWithValue("@DataEmpres", entity.DataEmprestimo);
                cmd.Parameters.AddWithValue("@PrazoDevol", entity.PrazoDevol);
                cmd.Parameters.AddWithValue("@isAtrasado", entity.IsAtrasado);

                linhas_afetadas = cmd.ExecuteNonQuery();
                conexao.Close();
            }
            return linhas_afetadas >= 1;
        }

        public bool Alterar(Emprestimo entity)
        {
            string sql = "UPDATE Emprestimo SET " +
                         "CodExemplar = @CodExemplar, " +
                         "CodLeitor = @CodLeitor, " +
                         "DataEmpres = @DataEmpres" +
                         "DataDevol = @DataDevol" +
                         "PrazoDevol = @PrazoDevol" +
                         "isAtrasado = @isAtrasado" +
                         "WHERE CodEmpres = @CodEmpres";
            int linhas_afetadas = 0;

            conexao.Open();

            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@CodExemplar", entity.Exemplar.CodExemplar);
                cmd.Parameters.AddWithValue("@CodLeitor", entity.Leitor.CodPessoa);
                cmd.Parameters.AddWithValue("@DataEmpres", entity.DataEmprestimo);
                cmd.Parameters.AddWithValue("@DataDevol", entity.DataDevol);
                cmd.Parameters.AddWithValue("@PrazoDevol", entity.PrazoDevol);
                cmd.Parameters.AddWithValue("@isAtrasado", entity.IsAtrasado);
                cmd.Parameters.AddWithValue("@CodEmpres", entity.CodEmprestimo);

                linhas_afetadas = cmd.ExecuteNonQuery();
                conexao.Close();
            }
            return linhas_afetadas >= 1;
        }

        public bool Remover(Emprestimo entity)
        {
            string sql = "DELETE FROM Emprestimo WHERE CodEmpres = @CodEmpres";
            int linhas_afetadas = 0;
            conexao.Open();

            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@CodEmpres", entity.CodEmprestimo);

                linhas_afetadas = cmd.ExecuteNonQuery();
                conexao.Close();
            }
            return linhas_afetadas >= 1;
        }

        public Emprestimo BuscarID(Emprestimo entity)
        {
            string sql = "SELECT * FROM Emprestimo WHERE CodEmpres = @CodEmpres";
            Emprestimo emprestimo = null;
            conexao.Open();

            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@CodEmpres", entity.CodEmprestimo);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int codEmpres = reader.GetInt32("CodEmpres");
                        int codExemplar = reader.GetInt32("CodExemplar");
                        ExemplarDAO exDAO = new ExemplarDAO();
                        Exemplar exemplar = exDAO.BuscarID(new Exemplar(null) { CodExemplar = codExemplar });
                        int codLeitor = reader.GetInt32("CodLeitor");
                        LeitorFuncioDAO leitorDAO = new LeitorFuncioDAO();
                        LeitorFuncio leitor = leitorDAO.BuscarID(new LeitorFuncio { CodPessoa = codLeitor });
                        string dataEmpres = reader.GetString("DataEmpres");
                        string dataDevol = reader.GetString("DataDevol");
                        string prazoDevol = reader.GetString("PrazoDevol");
                        int isAtrasado = reader.GetInt32("isAtrasado");
                        emprestimo = new Emprestimo(codEmpres, exemplar, leitor, dataEmpres, dataDevol, prazoDevol, isAtrasado);
                    }
                }
                conexao.Close();
            }
            return emprestimo;
        }

        public List<Emprestimo> Listar(string critério)
        {
            string sql = "SELECT * FROM Emprestimo";
            if (!string.IsNullOrEmpty(critério))
            {
                sql += " WHERE " + critério;
            }

            List<Emprestimo> emprestimos = new List<Emprestimo>();

            conexao.Open();

            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int codEmpres = reader.GetInt32("CodEmpres");
                        int codExemplar = reader.GetInt32("CodExemplar");
                        ExemplarDAO exDAO = new ExemplarDAO();
                        Exemplar exemplar = exDAO.BuscarID(new Exemplar(null) { CodExemplar = codExemplar });
                        int codLeitor = reader.GetInt32("CodLeitor");
                        LeitorFuncioDAO leitorDAO = new LeitorFuncioDAO();
                        LeitorFuncio leitor = leitorDAO.BuscarID(new LeitorFuncio { CodPessoa = codLeitor });
                        string dataEmpres = reader.GetString("DataEmpres");
                        string dataDevol = reader.GetString("DataDevol");
                        string prazoDevol = reader.GetString("PrazoDevol");
                        int isAtrasado = reader.GetInt32("isAtrasado");
                        Emprestimo emprestimo = new Emprestimo(codEmpres, exemplar, leitor, dataEmpres, dataDevol, prazoDevol, isAtrasado);
                        emprestimos.Add(emprestimo);
                    }
                }
                conexao.Close();
            }
            return emprestimos;
        }
    }
}
