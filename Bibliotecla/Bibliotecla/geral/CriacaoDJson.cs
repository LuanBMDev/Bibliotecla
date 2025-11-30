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
        private static bool _gerando; // evita reentrância quando chamado a partir de geração de PDF

        public static void AtualizarTodosJson()
        {
            if (_gerando) return;
            _gerando = true;
            try
            {
                string diretorio = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "relatorios");
                if (!Directory.Exists(diretorio)) Directory.CreateDirectory(diretorio);

                // Básicos usando extensão
                try { new TituloDAO().Listar(string.Empty).SalvarJson(diretorio, "titulos.json"); } catch (Exception ex) { Console.WriteLine("Erro titulos: " + ex.Message); }
                try { new ExemplarDAO().Listar(string.Empty).SalvarJson(diretorio, "exemplares.json"); } catch (Exception ex) { Console.WriteLine("Erro exemplares: " + ex.Message); }
                try { using (var conn = Conexao.Conectar()) { new EmprestimoDAO(conn).Listar(string.Empty).SalvarJson(diretorio, "emprestimos.json"); } } catch (Exception ex) { Console.WriteLine("Erro emprestimos: " + ex.Message); }
                try { using (var conn = Conexao.Conectar()) { new MultaDAO(conn).Listar(string.Empty).SalvarJson(diretorio, "multas.json"); } } catch (Exception ex) { Console.WriteLine("Erro multas: " + ex.Message); }
                try { new LeitorFuncioDAO().Listar(string.Empty).SalvarJson(diretorio, "leitores.json"); } catch (Exception ex) { Console.WriteLine("Erro leitores: " + ex.Message); }
                try { new LeitorFuncioDAO().Listar("IsDevedor = 1").SalvarJson(diretorio, "leitoresDevedores.json"); } catch (Exception ex) { Console.WriteLine("Erro leitoresDevedores: " + ex.Message); }
                try { new EsperaDAO().Listar(string.Empty).SalvarJson(diretorio, "esperas.json"); } catch (Exception ex) { Console.WriteLine("Erro esperas: " + ex.Message); }

                // Preferências
                try { GerarPreferenciaGeral(diretorio); } catch (Exception ex) { Console.WriteLine("Erro PreferenciaGeral: " + ex.Message); }
                try { GerarPreferenciaMaisEscolido(diretorio); } catch (Exception ex) { Console.WriteLine("Erro PreferenciaMaisEscolido: " + ex.Message); }
                try { GerarPreferenciaMaisEsperado(diretorio); } catch (Exception ex) { Console.WriteLine("Erro PreferenciaMaisEsperado: " + ex.Message); }

                // Atrasos
                try { GerarAtrasos(diretorio); } catch (Exception ex) { Console.WriteLine("Erro atrasos: " + ex.Message); }

                // Danos
                try { GerarDanos(diretorio); } catch (Exception ex) { Console.WriteLine("Erro danos: " + ex.Message); }
            }
            finally { _gerando = false; }
        }

        private static void GerarPreferenciaGeral(string diretorio)
        {
            var tituloDAO = new TituloDAO();
            var exemplarDAO = new ExemplarDAO();
            using (var connEmp = Conexao.Conectar())
            {
                var emprestimoDAO = new EmprestimoDAO(connEmp);
                var resultado = new List<object>();
                var titulosList = tituloDAO.Listar(string.Empty);
                foreach (var t in titulosList)
                {
                    var emprestimosList = new List<object>();
                    var exemplares = exemplarDAO.Listar($"CodTitulo = {t.CodTitulo}");
                    foreach (var ex in exemplares)
                    {
                        var emprestimos = emprestimoDAO.Listar($"CodExemplar = {ex.CodExemplar}");
                        foreach (var emp in emprestimos)
                        {
                            emprestimosList.Add(new { emp.CodEmprestimo, Exemplar = ex.CodExemplar, Leitor = emp.Leitor?.CodPessoa, emp.DataEmprestimo, emp.DataDevol, emp.PrazoDevol, emp.IsAtrasado });
                        }
                    }
                    resultado.Add(new { t.CodTitulo, t.NomeTitulo, t.GeneroTitulo, t.AutorTitulo, Emprestimos = emprestimosList });
                }
                resultado.SalvarJson(diretorio, "PreferenciaGeral.json");
            }
        }

        private static void GerarPreferenciaMaisEscolido(string diretorio)
        {
            var resultado = new List<object>();
            string sql = "SELECT e.CodExempl, e.CodTitulo, COUNT(emp.CodEmpres) AS TotalEmprestimos FROM Exemplar e LEFT JOIN Emprestimo emp ON emp.CodExemplar = e.CodExempl GROUP BY e.CodExempl, e.CodTitulo ORDER BY TotalEmprestimos DESC";
            using (var conn = Conexao.Conectar())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                var exemplarDao = new ExemplarDAO();
                var tituloDao = new TituloDAO();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int codEx = reader.GetInt32("CodExempl");
                        int codTitulo = reader.GetInt32("CodTitulo");
                        long total = reader.IsDBNull(reader.GetOrdinal("TotalEmprestimos")) ? 0 : reader.GetInt64("TotalEmprestimos");
                        var exemplar = exemplarDao.BuscarID(new Exemplar(null) { CodExemplar = codEx });
                        var titulo = tituloDao.BuscarID(new Titulo { CodTitulo = codTitulo });
                        resultado.Add(new { Exemplar = exemplar?.CodExemplar, Titulo = titulo?.CodTitulo, TotalEmprestimos = total });
                    }
                }
            }
            resultado.SalvarJson(diretorio, "PreferenciaMaisEscolido.json");
        }

        private static void GerarPreferenciaMaisEsperado(string diretorio)
        {
            var resultado = new List<object>();
            string sql = "SELECT e.CodExempl, COUNT(esp.CodEspera) AS TotalEspera, e.CodTitulo FROM Exemplar e LEFT JOIN Espera esp ON esp.CodTitulo = e.CodTitulo GROUP BY e.CodExempl, e.CodTitulo ORDER BY TotalEspera DESC";
            using (var conn = Conexao.Conectar())
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                var exemplarDao = new ExemplarDAO();
                var tituloDao = new TituloDAO();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int codEx = reader.GetInt32("CodExempl");
                        long total = reader.IsDBNull(reader.GetOrdinal("TotalEspera")) ? 0 : reader.GetInt64("TotalEspera");
                        int codTitulo = reader.IsDBNull(reader.GetOrdinal("CodTitulo")) ? 0 : reader.GetInt32("CodTitulo");
                        var exemplar = exemplarDao.BuscarID(new Exemplar(null) { CodExemplar = codEx });
                        var titulo = codTitulo != 0 ? tituloDao.BuscarID(new Titulo { CodTitulo = codTitulo }) : null;
                        resultado.Add(new { Exemplar = exemplar?.CodExemplar, Titulo = titulo?.CodTitulo, TotalEspera = total });
                    }
                }
            }
            resultado.SalvarJson(diretorio, "PreferenciaMaisEsperado.json");
        }

        private static void GerarAtrasos(string diretorio)
        {
            var atrasosGeral = new List<object>();
            var atrasosNaoQuitados = new List<object>();
            var atrasoQuitados = new List<object>();
            using (var connEmp = Conexao.Conectar())
            using (var connMulta = Conexao.Conectar())
            {
                var emprestimoDAO = new EmprestimoDAO(connEmp);
                var multaDAO = new MultaDAO(connMulta);
                var atrasados = emprestimoDAO.Listar("isAtrasado = 1");
                foreach (var emp in atrasados)
                {
                    atrasosGeral.Add(new { emp.CodEmprestimo, Exemplar = emp.Exemplar?.CodExemplar, Leitor = emp.Leitor?.CodPessoa, emp.DataEmprestimo, emp.DataDevol, emp.PrazoDevol });
                    var multas = multaDAO.Listar($"CodEmpres = {emp.CodEmprestimo}");
                    if (multas == null || multas.Count == 0)
                        atrasosNaoQuitados.Add(new { emp.CodEmprestimo, Exemplar = emp.Exemplar?.CodExemplar, Leitor = emp.Leitor?.CodPessoa, emp.DataEmprestimo, emp.DataDevol, emp.PrazoDevol });
                    else
                        atrasoQuitados.Add(new { emp.CodEmprestimo, Exemplar = emp.Exemplar?.CodExemplar, Leitor = emp.Leitor?.CodPessoa, emp.DataEmprestimo, emp.DataDevol, emp.PrazoDevol, Multas = multas });
                }
            }
            atrasosGeral.SalvarJson(diretorio, "AtrasosGeral.json");
            atrasosNaoQuitados.SalvarJson(diretorio, "AtrasosNaoQuitados.json");
            atrasoQuitados.SalvarJson(diretorio, "AtrasoQuitados.json");
        }

        private static void GerarDanos(string diretorio)
        {
            string Classificar(string estado)
            {
                if (string.IsNullOrWhiteSpace(estado)) return "Indefinido";
                estado = estado.Trim();
                if (estado.Equals("Novo", StringComparison.OrdinalIgnoreCase)) return "Novo";
                if (estado.Equals("UsoModerado", StringComparison.OrdinalIgnoreCase) || estado.Equals("Uso Moderado", StringComparison.OrdinalIgnoreCase)) return "Uso Moderado";
                if (estado.Equals("Leve", StringComparison.OrdinalIgnoreCase) || estado.Equals("DanoLeve", StringComparison.OrdinalIgnoreCase) || estado.Equals("Leves", StringComparison.OrdinalIgnoreCase) || estado.Equals("Danos Leves", StringComparison.OrdinalIgnoreCase)) return "Danos Leves";
                if (estado.Equals("Grave", StringComparison.OrdinalIgnoreCase) || estado.Equals("DanoGrave", StringComparison.OrdinalIgnoreCase) || estado.Equals("Graves", StringComparison.OrdinalIgnoreCase) || estado.Equals("Danos Graves", StringComparison.OrdinalIgnoreCase)) return "Danos Graves";
                return estado; // mantém valor original se diferente
            }

            var estadoGeral = new List<object>();
            var estadoNovo = new List<object>();
            var estadoUsoModerado = new List<object>();
            var estadoDanosLeves = new List<object>();
            var estadoDanosGraves = new List<object>();
            var exemplarDAO = new ExemplarDAO();
            var todos = exemplarDAO.Listar(string.Empty);
            foreach (var ex in todos)
            {
                string tipo = Classificar(ex.EstadoFisico);
                var obj = new { ex.CodExemplar, ex.EstadoFisico, TipoDano = tipo, ex.EditoraExemplar, ex.AnoPubli, Titulo = ex.Titulo?.CodTitulo };
                estadoGeral.Add(obj);
                switch (tipo)
                {
                    case "Novo": estadoNovo.Add(obj); break;
                    case "Uso Moderado": estadoUsoModerado.Add(obj); break;
                    case "Danos Leves": estadoDanosLeves.Add(obj); break;
                    case "Danos Graves": estadoDanosGraves.Add(obj); break;
                }
            }
            estadoGeral.SalvarJson(diretorio, "EstadoGeral.json");
            estadoNovo.SalvarJson(diretorio, "EstadoNovo.json");
            estadoUsoModerado.SalvarJson(diretorio, "EstadoUsoModerado.json");
            estadoDanosLeves.SalvarJson(diretorio, "EstadoDanosLeves.json");
            estadoDanosGraves.SalvarJson(diretorio, "EstadoDanosGraves.json");
        }
    }

    internal static class JsonRelatorioExtensions
    {
        public static void SalvarJson(this object data, string diretorio, string fileName)
        {
            try
            {
                string caminho = Path.Combine(diretorio, fileName);
                string json = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText(caminho, json, Encoding.UTF8);
                try
                {
                    string pdfPath = Path.ChangeExtension(caminho, ".pdf");
                    FazerJsonemPDF.GerarPdfDeJson(caminho, pdfPath);
                }
                catch (Exception exPdf)
                {
                    Console.WriteLine("Erro ao gerar PDF de " + fileName + ": " + exPdf.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao salvar " + fileName + ": " + ex.Message);
            }
        }
    }
}
