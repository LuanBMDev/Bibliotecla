using Bibliotecla.banco;
using Bibliotecla.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;


namespace Bibliotecla.DAO
{
    internal class EsperaDAO : DAO<Espera>
    {

        private MySqlConnection conexao;

        public bool Inserir(Espera entity)
        {
            string sql = "INSERT INTO Espera (CodLeitor, CodTitulo, DataSolicitacao) VALUES (@CodLeitor, @CodTitulo, @DataSolicitacao)";
            int linhas_afetadas = 0;

            conexao = Conexao.Conectar();

            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@CodLeitor", entity.Pessoa?.CodPessoa ?? 0);
                // if model doesn't have Titulo, try to get from exemplar -> titulo
                int codTitulo = 0;
                if (entity.Exemplar != null && entity.Exemplar.Titulo != null) codTitulo = entity.Exemplar.Titulo.CodTitulo;
                cmd.Parameters.AddWithValue("@CodTitulo", entity.Exemplar == null ? 0 : codTitulo);
                cmd.Parameters.AddWithValue("@DataSolicitacao", entity.DataEspera ?? DateTime.Now.ToString("yyyy-MM-dd"));

                linhas_afetadas = cmd.ExecuteNonQuery();
            }

            Conexao.Desconectar(conexao);

            bool ok = linhas_afetadas >= 1;
            if (ok) { try { Bibliotecla.geral.CriacaoDJson.AtualizarTodosJson(); } catch { } }
            return ok;
        }

        public bool Alterar(Espera entity)
        {

            string sql = "UPDATE Espera SET CodLeitor = @CodLeitor, CodTitulo = @CodTitulo, DataSolicitacao = @DataSolicitacao WHERE CodEspera = @CodEspera";
            int linhas_afetadas = 0;

            conexao = Conexao.Conectar();
            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@CodLeitor", entity.Pessoa?.CodPessoa ?? 0);
                int codTitulo = 0;
                if (entity.Exemplar != null && entity.Exemplar.Titulo != null) codTitulo = entity.Exemplar.Titulo.CodTitulo;
                cmd.Parameters.AddWithValue("@CodTitulo", codTitulo);
                cmd.Parameters.AddWithValue("@DataSolicitacao", entity.DataEspera ?? DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@CodEspera", entity.CodEspera);

                linhas_afetadas = cmd.ExecuteNonQuery();
            }

            Conexao.Desconectar(conexao);

            bool ok = linhas_afetadas >= 1;
            if (ok) { try { Bibliotecla.geral.CriacaoDJson.AtualizarTodosJson(); } catch { } }
            return ok;
        }

        public bool Remover(Espera entity)
        {
            string sql = "DELETE FROM Espera WHERE CodEspera = @CodEspera";
            int linhas_afetadas = 0;

            conexao = Conexao.Conectar();
            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@CodEspera", entity.CodEspera);
                linhas_afetadas = cmd.ExecuteNonQuery();
            }

            Conexao.Desconectar(conexao);

            bool ok = linhas_afetadas >= 1;
            if (ok) { try { Bibliotecla.geral.CriacaoDJson.AtualizarTodosJson(); } catch { } }
            return ok;
        }

        public Espera BuscarID(Espera entity)
        {
            string sql = "SELECT * FROM Espera WHERE CodEspera = @CodEspera";
            Espera espera = null;

            conexao = Conexao.Conectar();
            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                cmd.Parameters.AddWithValue("@CodEspera", entity.CodEspera);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int cod = reader.GetInt32("CodEspera");
                        int codLeitor = reader.IsDBNull(reader.GetOrdinal("CodLeitor")) ? 0 : reader.GetInt32("CodLeitor");
                        int codTitulo = reader.IsDBNull(reader.GetOrdinal("CodTitulo")) ? 0 : reader.GetInt32("CodTitulo");
                        string data = reader.IsDBNull(reader.GetOrdinal("DataSolicitacao")) ? null : reader.GetString("DataSolicitacao");

                        var leitorDAO = new LeitorFuncioDAO();
                        var tituloDAO = new TituloDAO();
                        var leitor = codLeitor != 0 ? leitorDAO.BuscarID(new LeitorFuncio { CodPessoa = codLeitor }) : null;
                        var titulo = codTitulo != 0 ? tituloDAO.BuscarID(new Titulo { CodTitulo = codTitulo }) : null;

                        // Map to current Espera model: set DataEspera=data, Pessoa=leitor, Emprestimo=null, Exemplar=null
                        espera = new Espera(cod, data ?? "Sem informação", null, null, leitor, null, null);
                    }
                }
            }
            Conexao.Desconectar(conexao);

            return espera;
        }

        public List<Espera> Listar(string critério)
        {
            string sql = "SELECT * FROM Espera";
            if (!string.IsNullOrEmpty(critério)) sql += " WHERE " + critério;

            var lista = new List<Espera>();
            conexao = Conexao.Conectar();
            using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int cod = reader.GetInt32("CodEspera");
                        int codLeitor = reader.IsDBNull(reader.GetOrdinal("CodLeitor")) ? 0 : reader.GetInt32("CodLeitor");
                        int codTitulo = reader.IsDBNull(reader.GetOrdinal("CodTitulo")) ? 0 : reader.GetInt32("CodTitulo");
                        string data = reader.IsDBNull(reader.GetOrdinal("DataSolicitacao")) ? null : reader.GetString("DataSolicitacao");

                        var leitorDAO = new LeitorFuncioDAO();
                        var tituloDAO = new TituloDAO();
                        var leitor = codLeitor != 0 ? leitorDAO.BuscarID(new LeitorFuncio { CodPessoa = codLeitor }) : null;
                        var titulo = codTitulo != 0 ? tituloDAO.BuscarID(new Titulo { CodTitulo = codTitulo }) : null;

                        lista.Add(new Espera(cod, data ?? "Sem informação", null, null, leitor, null, null));
                    }
                }
            }
            Conexao.Desconectar(conexao);

            return lista;
        }
    }
}
