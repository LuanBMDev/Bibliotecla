<<<<<<< Updated upstream
﻿using Bibliotecla.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using Bibliotecla.geral;
=======
﻿using Bibliotecla.banco;
using Bibliotecla.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
>>>>>>> Stashed changes

namespace Bibliotecla.DAO
{
    internal class EsperaDAO : DAO<Espera>
    {
<<<<<<< Updated upstream
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
=======
        private MySqlConnection conexao;

        public bool Inserir(Espera entity)
        {
            string sql = "INSERT INTO Espera (CodLeitor, CodTitulo, DataSolicitacao) VALUES (@CodLeitor, @CodTitulo, @DataSolicitacao)";
            int linhas_afetadas = 0;

            conexao = Conexao.Conectar();

            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@CodLeitor", entity.Leitor?.CodPessoa ?? 0);
                cmd.Parameters.AddWithValue("@CodTitulo", entity.Titulo?.CodTitulo ?? 0);
                cmd.Parameters.AddWithValue("@DataSolicitacao", entity.DataSolicitacao ?? DateTime.Now.ToString("yyyy-MM-dd"));

                linhas_afetadas = cmd.ExecuteNonQuery();
            }

            Conexao.Desconectar(conexao);

            bool ok = linhas_afetadas >= 1;
            if (ok) { try { Bibliotecla.geral.CriacaoDJson.AtualizarTodosJson(); } catch { } }
>>>>>>> Stashed changes
            return ok;
        }

        public bool Alterar(Espera entity)
        {
<<<<<<< Updated upstream
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
=======
            string sql = "UPDATE Espera SET CodLeitor = @CodLeitor, CodTitulo = @CodTitulo, DataSolicitacao = @DataSolicitacao WHERE CodEspera = @CodEspera";
            int linhas_afetadas = 0;

            conexao = Conexao.Conectar();
            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@CodLeitor", entity.Leitor?.CodPessoa ?? 0);
                cmd.Parameters.AddWithValue("@CodTitulo", entity.Titulo?.CodTitulo ?? 0);
                cmd.Parameters.AddWithValue("@DataSolicitacao", entity.DataSolicitacao ?? DateTime.Now.ToString("yyyy-MM-dd"));
>>>>>>> Stashed changes
                cmd.Parameters.AddWithValue("@CodEspera", entity.CodEspera);

                linhas_afetadas = cmd.ExecuteNonQuery();
            }
<<<<<<< Updated upstream
            conexao.Close();

            bool ok = linhas_afetadas >= 1;
            if (ok) { try { CriacaoDJson.AtualizarTodosJson(); } catch { } }
=======
            Conexao.Desconectar(conexao);

            bool ok = linhas_afetadas >= 1;
            if (ok) { try { Bibliotecla.geral.CriacaoDJson.AtualizarTodosJson(); } catch { } }
>>>>>>> Stashed changes
            return ok;
        }

        public bool Remover(Espera entity)
        {
            string sql = "DELETE FROM Espera WHERE CodEspera = @CodEspera";
            int linhas_afetadas = 0;

<<<<<<< Updated upstream
            conexao.Open();
=======
            conexao = Conexao.Conectar();
>>>>>>> Stashed changes
            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@CodEspera", entity.CodEspera);
                linhas_afetadas = cmd.ExecuteNonQuery();
            }
<<<<<<< Updated upstream
            conexao.Close();

            bool ok = linhas_afetadas >= 1;
            if (ok) { try { CriacaoDJson.AtualizarTodosJson(); } catch { } }
=======
            Conexao.Desconectar(conexao);

            bool ok = linhas_afetadas >= 1;
            if (ok) { try { Bibliotecla.geral.CriacaoDJson.AtualizarTodosJson(); } catch { } }
>>>>>>> Stashed changes
            return ok;
        }

        public Espera BuscarID(Espera entity)
        {
            string sql = "SELECT * FROM Espera WHERE CodEspera = @CodEspera";
            Espera espera = null;

<<<<<<< Updated upstream
            conexao.Open();
            int cod = 0;
            string dataEspera = null;
            string dataLimite = null;
            string dataDevol = null;
            int codPessoa = 0;
            int codEmpres = 0;
            int codExemplar = 0;

=======
            conexao = Conexao.Conectar();
>>>>>>> Stashed changes
            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@CodEspera", entity.CodEspera);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
<<<<<<< Updated upstream
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
=======
                        int cod = reader.GetInt32("CodEspera");
                        int codLeitor = reader.GetInt32("CodLeitor");
                        int codTitulo = reader.GetInt32("CodTitulo");
                        string data = reader.IsDBNull(reader.GetOrdinal("DataSolicitacao")) ? null : reader.GetString("DataSolicitacao");

                        var leitorDAO = new LeitorFuncioDAO();
                        var tituloDAO = new TituloDAO(null);
                        var leitor = leitorDAO.BuscarID(new LeitorFuncio { CodPessoa = codLeitor });
                        var titulo = tituloDAO.BuscarID(new Titulo { CodTitulo = codTitulo });

                        espera = new Espera(cod, leitor, titulo, data);
                    }
                }
            }
            Conexao.Desconectar(conexao);
>>>>>>> Stashed changes

            return espera;
        }

        public List<Espera> Listar(string critério)
        {
            string sql = "SELECT * FROM Espera";
            if (!string.IsNullOrEmpty(critério)) sql += " WHERE " + critério;

<<<<<<< Updated upstream
            var dados = new List<(int Cod, string DataEspera, string DataLimite, string DataDevol, int CodPessoa, int CodEmpres, int CodExemplar)>();
            var lista = new List<Espera>();

            conexao.Open();
=======
            var lista = new List<Espera>();
            conexao = Conexao.Conectar();
>>>>>>> Stashed changes
            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int cod = reader.GetInt32("CodEspera");
<<<<<<< Updated upstream
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
=======
                        int codLeitor = reader.GetInt32("CodLeitor");
                        int codTitulo = reader.GetInt32("CodTitulo");
                        string data = reader.IsDBNull(reader.GetOrdinal("DataSolicitacao")) ? null : reader.GetString("DataSolicitacao");

                        var leitorDAO = new LeitorFuncioDAO();
                        var tituloDAO = new TituloDAO(null);
                        var leitor = leitorDAO.BuscarID(new LeitorFuncio { CodPessoa = codLeitor });
                        var titulo = tituloDAO.BuscarID(new Titulo { CodTitulo = codTitulo });

                        lista.Add(new Espera(cod, leitor, titulo, data));
                    }
                }
            }
            Conexao.Desconectar(conexao);
>>>>>>> Stashed changes

            return lista;
        }
    }
}
