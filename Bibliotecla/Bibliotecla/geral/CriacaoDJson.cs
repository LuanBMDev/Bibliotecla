using Bibliotecla.banco;
using Bibliotecla.DAO;
using Bibliotecla.model;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bibliotecla.geral
{
    internal class CriacaoDJson
    {
        /// <summary>
        /// Gera/atualiza arquivos JSON na pasta "relatorios" para os principais DAOs do projeto.
        /// Cria os arquivos: titulos.json, exemplares.json, emprestimos.json, leitores.json, multas.json
        /// </summary>
        public static void AtualizarTodosJson()
        {
            string diretorio = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "relatorios");
            if (!Directory.Exists(diretorio)) Directory.CreateDirectory(diretorio);

            string connectionString = null;
            try
            {
                // Abre temporariamente uma conexão apenas para obter a connection string
                using (var tmp = Conexao.Conectar())
                {
                    connectionString = tmp.ConnectionString;
                    Conexao.Desconectar(tmp);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Aviso: não foi possível obter connection string via Conexao.Conectar(): " + ex.Message);
                // connectionString permanece nulo; DAOs que abrem sua própria conexão continuarão funcionando
            }

            MySqlConnection sharedConn = null;
            if (!string.IsNullOrEmpty(connectionString))
            {
                sharedConn = new MySqlConnection(connectionString); // mantemos fechada; DAOs vão abrir/fechar
            }

            // Helper local para serializar e salvar
            Action<string, object> salvar = (fileName, data) =>
            {
                try
                {
                    string caminho = Path.Combine(diretorio, fileName);
                    string json = JsonConvert.SerializeObject(data, Formatting.Indented);
                    File.WriteAllText(caminho, json, Encoding.UTF8);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao salvar {fileName}: {ex.Message}");
                }
            };

            // Títulos
            try
            {
                if (sharedConn != null)
                {
                    var tituloDao = new TituloDAO(sharedConn);
                    List<Titulo> titulos = tituloDao.Listar(string.Empty).ConvertAll(x => (Titulo)x);
                    salvar("titulos.json", titulos);
                }
                else
                {
                    // Tenta instanciar sem passar conexão (algumas versões do DAO abrem a conexão internamente)
                    var tituloDao = (TituloDAO)Activator.CreateInstance(typeof(TituloDAO), new Titulo[] { null });
                    List<Titulo> titulos = tituloDao.Listar(string.Empty).ConvertAll(x => (Titulo)x);
                    salvar("titulos.json", titulos);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao gerar JSON de títulos: " + ex.Message);
            }

            // Exemplares
            try
            {
                if (sharedConn != null)
                {
                    var exemplarDao = new ExemplarDAO(sharedConn);
                    List<Exemplar> exemplares = exemplarDao.Listar(string.Empty).ConvertAll(x => (Exemplar)x);
                    salvar("exemplares.json", exemplares);
                }
                else
                {
                    var exemplarDao = (ExemplarDAO)Activator.CreateInstance(typeof(ExemplarDAO), new Exemplar[] { null });
                    List<Exemplar> exemplares = exemplarDao.Listar(string.Empty).ConvertAll(x => (Exemplar)x);
                    salvar("exemplares.json", exemplares);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao gerar JSON de exemplares: " + ex.Message);
            }

            // Empréstimos
            try
            {
                if (sharedConn != null)
                {
                    var emprestimoDao = new EmprestimoDAO(sharedConn);
                    List<Emprestimo> emprestimos = emprestimoDao.Listar(string.Empty).ConvertAll(x => (Emprestimo)x);
                    salvar("emprestimos.json", emprestimos);
                }
                else
                {
                    var emprestimoDao = (EmprestimoDAO)Activator.CreateInstance(typeof(EmprestimoDAO), new Emprestimo[] { null });
                    List<Emprestimo> emprestimos = emprestimoDao.Listar(string.Empty).ConvertAll(x => (Emprestimo)x);
                    salvar("emprestimos.json", emprestimos);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao gerar JSON de empréstimos: " + ex.Message);
            }

            // Multas
            try
            {
                if (sharedConn != null)
                {
                    var multaDao = new MultaDAO(sharedConn);
                    List<object> multas = multaDao.Listar(string.Empty).ConvertAll(x => (object)x);
                    salvar("multas.json", multas);
                }
                else
                {
                    var multaDao = (MultaDAO)Activator.CreateInstance(typeof(MultaDAO), new object[] { null });
                    List<object> multas = multaDao.Listar(string.Empty).ConvertAll(x => (object)x);
                    salvar("multas.json", multas);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao gerar JSON de multas: " + ex.Message);
            }

            // Leitores (LeitorFuncioDAO usa Conexao internamente)
            try
            {
                var leitorDao = new LeitorFuncioDAO();
                List<LeitorFuncio> leitores = leitorDao.Listar(string.Empty).ConvertAll(x => (LeitorFuncio)x);
                salvar("leitores.json", leitores);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao gerar JSON de leitores: " + ex.Message);
            }

            // Cleanup
            if (sharedConn != null)
            {
                try
                {
                    sharedConn.Dispose();
                }
                catch { }
            }
        }
    }
}
