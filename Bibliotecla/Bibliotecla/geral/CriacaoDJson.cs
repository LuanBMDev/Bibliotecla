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
<<<<<<< Updated upstream
        /// Também cria os relatórios de preferência solicitados.
=======
>>>>>>> Stashed changes
        /// </summary>
        public static void AtualizarTodosJson()
        {
            string diretorio = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "relatorios");
            if (!Directory.Exists(diretorio)) Directory.CreateDirectory(diretorio);

            string connectionString = null;
            try
            {
<<<<<<< Updated upstream
=======
                // Abre temporariamente uma conexão apenas para obter a connection string
>>>>>>> Stashed changes
                using (var tmp = Conexao.Conectar())
                {
                    connectionString = tmp.ConnectionString;
                    Conexao.Desconectar(tmp);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Aviso: não foi possível obter connection string via Conexao.Conectar(): " + ex.Message);
<<<<<<< Updated upstream
=======
                // connectionString permanece nulo; DAOs que abrem sua própria conexão continuarão funcionando
>>>>>>> Stashed changes
            }

            MySqlConnection sharedConn = null;
            if (!string.IsNullOrEmpty(connectionString))
            {
<<<<<<< Updated upstream
                sharedConn = new MySqlConnection(connectionString);
            }

=======
                sharedConn = new MySqlConnection(connectionString); // mantemos fechada; DAOs vão abrir/fechar
            }

            // Helper local para serializar e salvar
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
                var tituloDao = new TituloDAO();
                List<Titulo> titulos = tituloDao.Listar(string.Empty);
                salvar("titulos.json", titulos);
=======
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
>>>>>>> Stashed changes
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao gerar JSON de títulos: " + ex.Message);
            }

            // Exemplares
            try
            {
<<<<<<< Updated upstream
                var exemplarDao = new ExemplarDAO();
                List<Exemplar> exemplares = exemplarDao.Listar(string.Empty);
                salvar("exemplares.json", exemplares);
=======
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
>>>>>>> Stashed changes
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao gerar JSON de exemplares: " + ex.Message);
            }

            // Empréstimos
            try
            {
<<<<<<< Updated upstream
                var emprestimoDao = sharedConn != null ? new EmprestimoDAO(sharedConn) : new EmprestimoDAO(null);
                List<Emprestimo> emprestimos = emprestimoDao.Listar(string.Empty);
                salvar("emprestimos.json", emprestimos);
=======
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
>>>>>>> Stashed changes
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao gerar JSON de empréstimos: " + ex.Message);
            }

            // Multas
            try
            {
<<<<<<< Updated upstream
                var multaDao = sharedConn != null ? new MultaDAO(sharedConn) : new MultaDAO(null);
                var multas = multaDao.Listar(string.Empty);
                salvar("multas.json", multas);
=======
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
>>>>>>> Stashed changes
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao gerar JSON de multas: " + ex.Message);
            }

<<<<<<< Updated upstream
            // Leitores (usa Conexao internamente)
            try
            {
                var leitorDao = new LeitorFuncioDAO();
                List<LeitorFuncio> leitores = leitorDao.Listar(string.Empty);
=======
            // Leitores (LeitorFuncioDAO usa Conexao internamente)
            try
            {
                var leitorDao = new LeitorFuncioDAO();
                List<LeitorFuncio> leitores = leitorDao.Listar(string.Empty).ConvertAll(x => (LeitorFuncio)x);
>>>>>>> Stashed changes
                salvar("leitores.json", leitores);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao gerar JSON de leitores: " + ex.Message);
            }

<<<<<<< Updated upstream
            // Novos relatórios de preferência
            try { GerarPreferenciaGeral(sharedConn, diretorio, salvar); }
            catch (Exception ex) { Console.WriteLine("Erro ao gerar preferenciaGeral: " + ex.Message); }
            try { GerarPreferenciaMaisEscolhido(sharedConn, diretorio, salvar); }
            catch (Exception ex) { Console.WriteLine("Erro ao gerar preferenciaMaisEscolhido: " + ex.Message); }
            try { GerarPreferenciaMaisEsperado(sharedConn, diretorio, salvar); }
            catch (Exception ex) { Console.WriteLine("Erro ao gerar preferenciaMaisEsperado: " + ex.Message); }

            // Relatórios de atraso
            try { GerarAtrasos(sharedConn, diretorio, salvar); }
            catch (Exception ex) { Console.WriteLine("Erro ao gerar relatórios de atrasos: " + ex.Message); }

            // Relatórios de danos
            try { GerarDanos(sharedConn, diretorio, salvar); }
            catch (Exception ex) { Console.WriteLine("Erro ao gerar relatórios de danos: " + ex.Message); }

            if (sharedConn != null)
            {
                try { sharedConn.Dispose(); } catch { }
            }
        }

        private static void GerarPreferenciaGeral(MySqlConnection sharedConn, string diretorio, Action<string, object> salvar)
        {
            var tituloDAO = new TituloDAO();
            var exemplarDAO = new ExemplarDAO();
            var emprestimoDAO = sharedConn != null ? new EmprestimoDAO(sharedConn) : new EmprestimoDAO(null);
            var esperaDAO = sharedConn != null ? new EsperaDAO(sharedConn) : new EsperaDAO(null);

            var resultado = new List<object>();
            var titulosList = tituloDAO.Listar(string.Empty);
            foreach (var t in titulosList)
            {
                var emprestimosList = new List<object>();
                var esperasList = new List<object>();

                var exemplares = exemplarDAO.Listar($"CodTitulo = {t.CodTitulo}");
                foreach (var ex in exemplares)
                {
                    var emprestimos = emprestimoDAO.Listar($"CodExemplar = {ex.CodExemplar}");
                    foreach (var emp in emprestimos)
                    {
                        emprestimosList.Add(new
                        {
                            emp.CodEmprestimo,
                            Exemplar = ex,
                            Leitor = emp.Leitor,
                            emp.DataEmprestimo,
                            emp.DataDevol,
                            emp.PrazoDevol,
                            emp.IsAtrasado
                        });
                    }

                    var esperas = esperaDAO.Listar($"CodExemplar = {ex.CodExemplar}");
                    foreach (var esp in esperas)
                    {
                        esperasList.Add(new
                        {
                            esp.CodEspera,
                            esp.DataEspera,
                            esp.DataLimite,
                            esp.DataDevol,
                            Pessoa = esp.Pessoa,
                            Emprestimo = esp.Emprestimo,
                            Exemplar = esp.Exemplar
                        });
                    }
                }

                resultado.Add(new
                {
                    t.CodTitulo,
                    t.NomeTitulo,
                    t.GeneroTitulo,
                    t.AutorTitulo,
                    Emprestimos = emprestimosList,
                    Esperas = esperasList
                });
            }

            salvar("preferenciaGeral.json", resultado);
        }

        private static void GerarPreferenciaMaisEscolhido(MySqlConnection sharedConn, string diretorio, Action<string, object> salvar)
        {
            var resultado = new List<object>();

            if (sharedConn == null)
            {
                salvar("preferenciaMaisEscolhido.json", resultado);
                return;
            }

            string sql = "SELECT e.CodExempl, e.CodTitulo, COUNT(emp.CodEmpres) AS TotalEmprestimos FROM Exemplar e LEFT JOIN Emprestimo emp ON emp.CodExemplar = e.CodExempl GROUP BY e.CodExempl ORDER BY TotalEmprestimos DESC";

            using (MySqlCommand cmd = new MySqlCommand(sql, sharedConn))
            {
                var exemplarDao = new ExemplarDAO();
                var tituloDao = new TituloDAO();
                try
                {
                    sharedConn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int codEx = reader.GetInt32("CodExempl");
                            int codTitulo = reader.GetInt32("CodTitulo");
                            long total = reader.IsDBNull(reader.GetOrdinal("TotalEmprestimos")) ? 0 : reader.GetInt64("TotalEmprestimos");

                            var exemplar = exemplarDao.BuscarID(new Exemplar(null) { CodExemplar = codEx });
                            var titulo = tituloDao.BuscarID(new Titulo { CodTitulo = codTitulo });

                            resultado.Add(new { Exemplar = exemplar, Titulo = titulo, TotalEmprestimos = total });
                        }
                    }
                }
                finally
                {
                    try { sharedConn.Close(); } catch { }
                }
            }

            salvar("preferenciaMaisEscolhido.json", resultado);
        }

        private static void GerarPreferenciaMaisEsperado(MySqlConnection sharedConn, string diretorio, Action<string, object> salvar)
        {
            var resultado = new List<object>();

            if (sharedConn == null)
            {
                salvar("preferenciaMaisEsperado.json", resultado);
                return;
            }

            string sql = "SELECT e.CodExempl, COUNT(esp.CodEspera) AS TotalEspera, e.CodTitulo FROM Exemplar e LEFT JOIN Espera esp ON esp.CodExemplar = e.CodExempl GROUP BY e.CodExempl ORDER BY TotalEspera DESC";

            using (MySqlCommand cmd = new MySqlCommand(sql, sharedConn))
            {
                var exemplarDao = new ExemplarDAO();
                var tituloDao = new TituloDAO();
                try
                {
                    sharedConn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int codEx = reader.GetInt32("CodExempl");
                            long total = reader.IsDBNull(reader.GetOrdinal("TotalEspera")) ? 0 : reader.GetInt64("TotalEspera");
                            int codTitulo = reader.IsDBNull(reader.GetOrdinal("CodTitulo")) ? 0 : reader.GetInt32("CodTitulo");

                            var exemplar = exemplarDao.BuscarID(new Exemplar(null) { CodExemplar = codEx });
                            var titulo = codTitulo != 0 ? tituloDao.BuscarID(new Titulo { CodTitulo = codTitulo }) : null;

                            resultado.Add(new { Exemplar = exemplar, Titulo = titulo, TotalEspera = total });
                        }
                    }
                }
                finally
                {
                    try { sharedConn.Close(); } catch { }
                }
            }

            salvar("preferenciaMaisEsperado.json", resultado);
        }

        private static void GerarAtrasos(MySqlConnection sharedConn, string diretorio, Action<string, object> salvar)
        {
            var atrasoGeral = new List<object>();
            var atrasoNaoQuitado = new List<object>();
            var atrasoQuitado = new List<object>();

            var emprestimoDAO = sharedConn != null ? new EmprestimoDAO(sharedConn) : new EmprestimoDAO(null);
            var multaDAO = sharedConn != null ? new MultaDAO(sharedConn) : new MultaDAO(null);

            var atrasados = emprestimoDAO.Listar("isAtrasado = 1");
            foreach (var emp in atrasados)
            {
                atrasoGeral.Add(new { emp.CodEmprestimo, Exemplar = emp.Exemplar, Leitor = emp.Leitor, emp.DataEmprestimo, emp.DataDevol, emp.PrazoDevol });

                var multas = multaDAO.Listar($"CodEmpres = {emp.CodEmprestimo}");
                if (multas == null || multas.Count == 0)
                {
                    atrasoNaoQuitado.Add(new { emp.CodEmprestimo, emp.Exemplar, emp.Leitor, emp.DataEmprestimo, emp.DataDevol, emp.PrazoDevol });
                }
                else
                {
                    atrasoQuitado.Add(new { emp.CodEmprestimo, emp.Exemplar, emp.Leitor, emp.DataEmprestimo, emp.DataDevol, emp.PrazoDevol, Multas = multas });
                }
            }

            salvar("AtrasoGeral.json", atrasoGeral);
            salvar("AtrasoNaoQuitados.json", atrasoNaoQuitado);
            salvar("AtrasoQuitado.json", atrasoQuitado);
        }

        private static void GerarDanos(MySqlConnection sharedConn, string diretorio, Action<string, object> salvar)
        {
            var danosGeral = new List<object>();
            var danosNovos = new List<object>();
            var usoModerado = new List<object>();
            var danoLeves = new List<object>();
            var danoGraves = new List<object>();

            var exemplarDAO = new ExemplarDAO();
            var todos = exemplarDAO.Listar(string.Empty);
            foreach (var ex in todos)
            {
                danosGeral.Add(ex);
                if (!string.IsNullOrEmpty(ex.EstadoFisico))
                {
                    var estado = ex.EstadoFisico.Trim();
                    if (string.Equals(estado, "Novo", StringComparison.OrdinalIgnoreCase)) danosNovos.Add(ex);
                    else if (string.Equals(estado, "UsoModerado", StringComparison.OrdinalIgnoreCase) || string.Equals(estado, "Uso Moderado", StringComparison.OrdinalIgnoreCase)) usoModerado.Add(ex);
                    else if (string.Equals(estado, "Leve", StringComparison.OrdinalIgnoreCase) || string.Equals(estado, "DanoLeve", StringComparison.OrdinalIgnoreCase) || string.Equals(estado, "Leves", StringComparison.OrdinalIgnoreCase)) danoLeves.Add(ex);
                    else if (string.Equals(estado, "Grave", StringComparison.OrdinalIgnoreCase) || string.Equals(estado, "DanoGrave", StringComparison.OrdinalIgnoreCase) || string.Equals(estado, "Graves", StringComparison.OrdinalIgnoreCase)) danoGraves.Add(ex);
                }
            }

            salvar("DanosGeral.json", danosGeral);
            salvar("DanosNovos.json", danosNovos);
            salvar("UsoModerado.json", usoModerado);
            salvar("DanoLeves.json", danoLeves);
            salvar("DanoGraves.json", danoGraves);
=======
            // Cleanup
            if (sharedConn != null)
            {
                try
                {
                    sharedConn.Dispose();
                }
                catch { }
            }
>>>>>>> Stashed changes
        }
    }
}
