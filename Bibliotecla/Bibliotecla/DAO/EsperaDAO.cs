using Bibliotecla.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using Bibliotecla.geral;

namespace Bibliotecla.DAO
{
    internal class EsperaDAO : DAO<Espera>
    {
        private readonly MySqlConnection conexao;

        public EsperaDAO(MySqlConnection conexao)
        {
            this.conexao = conexao;
        }

        public bool Inserir(Espera entity)
        {
            string sql = "INSERT INTO Espera (DataEspera, DataLimite, DataDevol, CodPessoa, CodEmpres, CodExemplar) " +
                         "VALUES (@DataEspera, @DataLimite, @DataDevol, @CodPessoa, @CodEmpres, @CodExemplar)";
            int linhas_afetadas = 0;

            conexao.Open();
            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@DataEspera", entity.DataEspera ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DataLimite", entity.DataLimite ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DataDevol", entity.DataDevol ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@CodPessoa", entity.Pessoa?.CodPessoa ?? 0);
                cmd.Parameters.AddWithValue("@CodEmpres", entity.Emprestimo?.CodEmprestimo ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@CodExemplar", entity.Exemplar?.CodExemplar ?? (object)DBNull.Value);

                linhas_afetadas = cmd.ExecuteNonQuery();
            }
            conexao.Close();

            bool ok = linhas_afetadas >= 1;
            if (ok) { try { CriacaoDJson.AtualizarTodosJson(); } catch { } }
            return ok;
        }

        public bool Alterar(Espera entity)
        {
            string sql = "UPDATE Espera SET DataEspera = @DataEspera, DataLimite = @DataLimite, DataDevol = @DataDevol, " +
                         "CodPessoa = @CodPessoa, CodEmpres = @CodEmpres, CodExemplar = @CodExemplar WHERE CodEspera = @CodEspera";
            int linhas_afetadas = 0;

            conexao.Open();
            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@DataEspera", entity.DataEspera ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DataLimite", entity.DataLimite ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DataDevol", entity.DataDevol ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@CodPessoa", entity.Pessoa?.CodPessoa ?? 0);
                cmd.Parameters.AddWithValue("@CodEmpres", entity.Emprestimo?.CodEmprestimo ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@CodExemplar", entity.Exemplar?.CodExemplar ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@CodEspera", entity.CodEspera);

                linhas_afetadas = cmd.ExecuteNonQuery();
            }
            conexao.Close();

            bool ok = linhas_afetadas >= 1;
            if (ok) { try { CriacaoDJson.AtualizarTodosJson(); } catch { } }
            return ok;
        }

        public bool Remover(Espera entity)
        {
            string sql = "DELETE FROM Espera WHERE CodEspera = @CodEspera";
            int linhas_afetadas = 0;

            conexao.Open();
            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@CodEspera", entity.CodEspera);
                linhas_afetadas = cmd.ExecuteNonQuery();
            }
            conexao.Close();

            bool ok = linhas_afetadas >= 1;
            if (ok) { try { CriacaoDJson.AtualizarTodosJson(); } catch { } }
            return ok;
        }

        public Espera BuscarID(Espera entity)
        {
            string sql = "SELECT * FROM Espera WHERE CodEspera = @CodEspera";
            Espera espera = null;

            conexao.Open();
            int cod = 0;
            string dataEspera = null;
            string dataLimite = null;
            string dataDevol = null;
            int codPessoa = 0;
            int codEmpres = 0;
            int codExemplar = 0;

            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@CodEspera", entity.CodEspera);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        cod = reader.GetInt32("CodEspera");
                        dataEspera = reader.IsDBNull(reader.GetOrdinal("DataEspera")) ? null : reader.GetString("DataEspera");
                        dataLimite = reader.IsDBNull(reader.GetOrdinal("DataLimite")) ? null : reader.GetString("DataLimite");
                        dataDevol = reader.IsDBNull(reader.GetOrdinal("DataDevol")) ? null : reader.GetString("DataDevol");
                        codPessoa = reader.IsDBNull(reader.GetOrdinal("CodPessoa")) ? 0 : reader.GetInt32("CodPessoa");
                        codEmpres = reader.IsDBNull(reader.GetOrdinal("CodEmpres")) ? 0 : reader.GetInt32("CodEmpres");
                        codExemplar = reader.IsDBNull(reader.GetOrdinal("CodExemplar")) ? 0 : reader.GetInt32("CodExemplar");
                    }
                }
            }
            conexao.Close();

            if (cod != 0)
            {
                LeitorFuncio pessoa = null;
                Emprestimo emprestimo = null;
                Exemplar exemplar = null;

                var leitorDAO = new LeitorFuncioDAO();
                if (codPessoa != 0) pessoa = leitorDAO.BuscarID(new LeitorFuncio { CodPessoa = codPessoa });

                conexao.Open();
                try
                {
                    var emprestimoDAO = new EmprestimoDAO(conexao);
                    var exemplarDAO = new ExemplarDAO();
                    if (codEmpres != 0) emprestimo = emprestimoDAO.BuscarID(new Emprestimo(null, null) { CodEmprestimo = codEmpres });
                    if (codExemplar != 0) exemplar = exemplarDAO.BuscarID(new Exemplar(null) { CodExemplar = codExemplar });
                }
                finally
                {
                    conexao.Close();
                }

                espera = new Espera(cod, dataEspera, dataLimite, dataDevol, pessoa, emprestimo, exemplar);
            }

            return espera;
        }

        public List<Espera> Listar(string critério)
        {
            string sql = "SELECT * FROM Espera";
            if (!string.IsNullOrEmpty(critério)) sql += " WHERE " + critério;

            var dados = new List<(int Cod, string DataEspera, string DataLimite, string DataDevol, int CodPessoa, int CodEmpres, int CodExemplar)>();
            var lista = new List<Espera>();

            conexao.Open();
            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int cod = reader.GetInt32("CodEspera");
                        string dataEspera = reader.IsDBNull(reader.GetOrdinal("DataEspera")) ? null : reader.GetString("DataEspera");
                        string dataLimite = reader.IsDBNull(reader.GetOrdinal("DataLimite")) ? null : reader.GetString("DataLimite");
                        string dataDevol = reader.IsDBNull(reader.GetOrdinal("DataDevol")) ? null : reader.GetString("DataDevol");
                        int codPessoa = reader.IsDBNull(reader.GetOrdinal("CodPessoa")) ? 0 : reader.GetInt32("CodPessoa");
                        int codEmpres = reader.IsDBNull(reader.GetOrdinal("CodEmpres")) ? 0 : reader.GetInt32("CodEmpres");
                        int codExemplar = reader.IsDBNull(reader.GetOrdinal("CodExemplar")) ? 0 : reader.GetInt32("CodExemplar");
                        dados.Add((cod, dataEspera, dataLimite, dataDevol, codPessoa, codEmpres, codExemplar));
                    }
                }
            }
            conexao.Close();

            foreach (var d in dados)
            {
                LeitorFuncio pessoa = null;
                Emprestimo emprestimo = null;
                Exemplar exemplar = null;

                var leitorDAO = new LeitorFuncioDAO();
                if (d.CodPessoa != 0) pessoa = leitorDAO.BuscarID(new LeitorFuncio { CodPessoa = d.CodPessoa });

                conexao.Open();
                try
                {
                    var emprestimoDAO = new EmprestimoDAO(conexao);
                    var exemplarDAO = new ExemplarDAO();
                    if (d.CodEmpres != 0) emprestimo = emprestimoDAO.BuscarID(new Emprestimo(null, null) { CodEmprestimo = d.CodEmpres });
                    if (d.CodExemplar != 0) exemplar = exemplarDAO.BuscarID(new Exemplar(null) { CodExemplar = d.CodExemplar });
                }
                finally
                {
                    conexao.Close();
                }

                lista.Add(new Espera(d.Cod, d.DataEspera, d.DataLimite, d.DataDevol, pessoa, emprestimo, exemplar));
            }

            return lista;
        }
    }
}
