using System;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Bibliotecla.geral
{
    internal static class FazerJsonemPDF
    {
        /// <summary>
        /// Gera um PDF a partir de um arquivo JSON. Suporta objetos (key/value) e arrays de objetos.
        /// Retorna true se o PDF foi gerado com sucesso.
        /// </summary>
        public static bool GerarPdfDeJson(string jsonFilePath, string pdfOutputPath)
        {
            try
            {
                if (string.IsNullOrEmpty(jsonFilePath) || !File.Exists(jsonFilePath))
                    throw new FileNotFoundException("Arquivo JSON não encontrado.", jsonFilePath);

                string json = File.ReadAllText(jsonFilePath, Encoding.UTF8);
                JToken token = JToken.Parse(json);

                using (FileStream fs = new FileStream(pdfOutputPath, FileMode.Create, FileAccess.Write))
                {
                    Document doc = new Document(PageSize.A4, 36, 36, 36, 36);
                    PdfWriter.GetInstance(doc, fs);
                    doc.Open();

                    // Título
                    var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14);
                    var normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);

                    Paragraph title = new Paragraph(Path.GetFileName(jsonFilePath), titleFont);
                    title.Alignment = Element.ALIGN_CENTER;
                    doc.Add(title);
                    doc.Add(new Paragraph("Generated: " + DateTime.Now.ToString("g"), normalFont));
                    doc.Add(Chunk.NEWLINE);

                    if (token.Type == JTokenType.Array)
                    {
                        // Array de objetos
                        var arr = (JArray)token;
                        // Determina colunas: união de todas as chaves dos objetos
                        var columnNames = new System.Collections.Generic.List<string>();
                        foreach (var item in arr)
                        {
                            if (item.Type == JTokenType.Object)
                            {
                                foreach (var prop in ((JObject)item).Properties())
                                {
                                    if (!columnNames.Contains(prop.Name)) columnNames.Add(prop.Name);
                                }
                            }
                        }

                        if (columnNames.Count == 0)
                        {
                            // Array de primitivos
                            foreach (var item in arr)
                            {
                                doc.Add(new Paragraph(item.ToString(), normalFont));
                            }
                        }
                        else
                        {
                            PdfPTable table = new PdfPTable(columnNames.Count);
                            table.WidthPercentage = 100f;

                            // Cabeçalho
                            foreach (var col in columnNames)
                            {
                                var cell = new PdfPCell(new Phrase(col, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)));
                                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                                table.AddCell(cell);
                            }

                            // Linhas
                            foreach (var item in arr)
                            {
                                if (item.Type == JTokenType.Object)
                                {
                                    var obj = (JObject)item;
                                    foreach (var col in columnNames)
                                    {
                                        var v = obj.ContainsKey(col) ? obj[col].ToString() : string.Empty;
                                        table.AddCell(new Phrase(v, normalFont));
                                    }
                                }
                                else
                                {
                                    // item não é objeto -> coloca em primeira coluna e as demais vazias
                                    table.AddCell(new Phrase(item.ToString(), normalFont));
                                    for (int i = 1; i < columnNames.Count; i++) table.AddCell(string.Empty);
                                }
                            }

                            doc.Add(table);
                        }
                    }
                    else if (token.Type == JTokenType.Object)
                    {
                        // Objeto simples: tabela key/value
                        var obj = (JObject)token;
                        PdfPTable table = new PdfPTable(2) { WidthPercentage = 100f };
                        table.SetWidths(new float[] { 30f, 70f });

                        foreach (var prop in obj.Properties())
                        {
                            var cellKey = new PdfPCell(new Phrase(prop.Name, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)));
                            cellKey.BackgroundColor = BaseColor.LIGHT_GRAY;
                            table.AddCell(cellKey);

                            var valueText = prop.Value.Type == JTokenType.Array || prop.Value.Type == JTokenType.Object
                                            ? prop.Value.ToString(Newtonsoft.Json.Formatting.None)
                                            : prop.Value.ToString();
                            table.AddCell(new Phrase(valueText, normalFont));
                        }

                        doc.Add(table);
                    }
                    else
                    {
                        // Primitive
                        doc.Add(new Paragraph(token.ToString(), normalFont));
                    }

                    doc.Close();
                    fs.Flush();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao gerar PDF do JSON: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Gera PDF para todos os arquivos .json na pasta relatorios (cria arquivos .pdf com mesmo nome).
        /// </summary>
        public static void GerarPdfsDeTodosRelatorios()
        {
            try
            {
                string diretorio = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "relatorios");
                if (!Directory.Exists(diretorio)) return;

                var files = Directory.GetFiles(diretorio, "*.json");
                foreach (var file in files)
                {
                    try
                    {
                        string pdfPath = Path.ChangeExtension(file, ".pdf");
                        GerarPdfDeJson(file, pdfPath);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Falha ao converter " + file + ": " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao gerar PDFs: " + ex.Message);
            }
        }

        // --- Relatórios específicos padrão ---
        public static string GerarRelatorioTitulosPdf(string outputPdfPath = null)
        {
            try
            {
                CriacaoDJson.AtualizarTodosJson();
                string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "relatorios");
                string json = Path.Combine(dir, "titulos.json");
                if (!File.Exists(json)) return null;
                string pdf = outputPdfPath ?? Path.ChangeExtension(json, ".pdf");
                return GerarPdfDeJson(json, pdf) ? pdf : null;
            }
            catch { return null; }
        }

        public static string GerarRelatorioExemplaresPdf(string outputPdfPath = null)
        {
            try
            {
                CriacaoDJson.AtualizarTodosJson();
                string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "relatorios");
                string json = Path.Combine(dir, "exemplares.json");
                if (!File.Exists(json)) return null;
                string pdf = outputPdfPath ?? Path.ChangeExtension(json, ".pdf");
                return GerarPdfDeJson(json, pdf) ? pdf : null;
            }
            catch { return null; }
        }

        public static string GerarRelatorioEmprestimosPdf(string outputPdfPath = null)
        {
            try
            {
                CriacaoDJson.AtualizarTodosJson();
                string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "relatorios");
                string json = Path.Combine(dir, "emprestimos.json");
                if (!File.Exists(json)) return null;
                string pdf = outputPdfPath ?? Path.ChangeExtension(json, ".pdf");
                return GerarPdfDeJson(json, pdf) ? pdf : null;
            }
            catch { return null; }
        }

        public static string GerarRelatorioLeitoresPdf(string outputPdfPath = null)
        {
            try
            {
                CriacaoDJson.AtualizarTodosJson();
                string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "relatorios");
                string json = Path.Combine(dir, "leitores.json");
                if (!File.Exists(json)) return null;
                string pdf = outputPdfPath ?? Path.ChangeExtension(json, ".pdf");
                return GerarPdfDeJson(json, pdf) ? pdf : null;
            }
            catch { return null; }
        }

        public static string GerarRelatorioMultasPdf(string outputPdfPath = null)
        {
            try
            {
                CriacaoDJson.AtualizarTodosJson();
                string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "relatorios");
                string json = Path.Combine(dir, "multas.json");
                if (!File.Exists(json)) return null;
                string pdf = outputPdfPath ?? Path.ChangeExtension(json, ".pdf");
                return GerarPdfDeJson(json, pdf) ? pdf : null;
            }
            catch { return null; }
        }

        // --- Relatórios específicos novos (preferências) ---
        public static string GerarPreferenciaGeralPdf(string outputPdfPath = null)
        {
            try
            {
                CriacaoDJson.AtualizarTodosJson();
                string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "relatorios");
                string json = Path.Combine(dir, "preferenciaGeral.json");
                if (!File.Exists(json)) return null;
                string pdf = outputPdfPath ?? Path.ChangeExtension(json, ".pdf");
                return GerarPdfDeJson(json, pdf) ? pdf : null;
            }
            catch { return null; }
        }

        public static string GerarPreferenciaMaisEscolhidoPdf(string outputPdfPath = null)
        {
            try
            {
                CriacaoDJson.AtualizarTodosJson();
                string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "relatorios");
                string json = Path.Combine(dir, "preferenciaMaisEscolhido.json");
                if (!File.Exists(json)) return null;
                string pdf = outputPdfPath ?? Path.ChangeExtension(json, ".pdf");
                return GerarPdfDeJson(json, pdf) ? pdf : null;
            }
            catch { return null; }
        }

        public static string GerarPreferenciaMaisEsperadoPdf(string outputPdfPath = null)
        {
            try
            {
                CriacaoDJson.AtualizarTodosJson();
                string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "relatorios");
                string json = Path.Combine(dir, "preferenciaMaisEsperado.json");
                if (!File.Exists(json)) return null;
                string pdf = outputPdfPath ?? Path.ChangeExtension(json, ".pdf");
                return GerarPdfDeJson(json, pdf) ? pdf : null;
            }
            catch { return null; }
        }

        // --- Relatórios de Atrasos ---
        public static string GerarAtrasoGeralPdf(string outputPdfPath = null)
        {
            try
            {
                CriacaoDJson.AtualizarTodosJson();
                string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "relatorios");
                string json = Path.Combine(dir, "AtrasoGeral.json");
                if (!File.Exists(json)) return null;
                string pdf = outputPdfPath ?? Path.ChangeExtension(json, ".pdf");
                return GerarPdfDeJson(json, pdf) ? pdf : null;
            }
            catch { return null; }
        }

        public static string GerarAtrasoNaoQuitadosPdf(string outputPdfPath = null)
        {
            try
            {
                CriacaoDJson.AtualizarTodosJson();
                string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "relatorios");
                string json = Path.Combine(dir, "AtrasoNaoQuitados.json");
                if (!File.Exists(json)) return null;
                string pdf = outputPdfPath ?? Path.ChangeExtension(json, ".pdf");
                return GerarPdfDeJson(json, pdf) ? pdf : null;
            }
            catch { return null; }
        }

        public static string GerarAtrasoQuitadoPdf(string outputPdfPath = null)
        {
            try
            {
                CriacaoDJson.AtualizarTodosJson();
                string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "relatorios");
                string json = Path.Combine(dir, "AtrasoQuitado.json");
                if (!File.Exists(json)) return null;
                string pdf = outputPdfPath ?? Path.ChangeExtension(json, ".pdf");
                return GerarPdfDeJson(json, pdf) ? pdf : null;
            }
            catch { return null; }
        }

        // --- Relatórios de Danos ---
        public static string GerarDanosGeralPdf(string outputPdfPath = null)
        {
            try
            {
                CriacaoDJson.AtualizarTodosJson();
                string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "relatorios");
                string json = Path.Combine(dir, "DanosGeral.json");
                if (!File.Exists(json)) return null;
                string pdf = outputPdfPath ?? Path.ChangeExtension(json, ".pdf");
                return GerarPdfDeJson(json, pdf) ? pdf : null;
            }
            catch { return null; }
        }

        public static string GerarDanosNovosPdf(string outputPdfPath = null)
        {
            try
            {
                CriacaoDJson.AtualizarTodosJson();
                string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "relatorios");
                string json = Path.Combine(dir, "DanosNovos.json");
                if (!File.Exists(json)) return null;
                string pdf = outputPdfPath ?? Path.ChangeExtension(json, ".pdf");
                return GerarPdfDeJson(json, pdf) ? pdf : null;
            }
            catch { return null; }
        }

        public static string GerarUsoModeradoPdf(string outputPdfPath = null)
        {
            try
            {
                CriacaoDJson.AtualizarTodosJson();
                string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "relatorios");
                string json = Path.Combine(dir, "UsoModerado.json");
                if (!File.Exists(json)) return null;
                string pdf = outputPdfPath ?? Path.ChangeExtension(json, ".pdf");
                return GerarPdfDeJson(json, pdf) ? pdf : null;
            }
            catch { return null; }
        }

        public static string GerarDanoLevesPdf(string outputPdfPath = null)
        {
            try
            {
                CriacaoDJson.AtualizarTodosJson();
                string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "relatorios");
                string json = Path.Combine(dir, "DanoLeves.json");
                if (!File.Exists(json)) return null;
                string pdf = outputPdfPath ?? Path.ChangeExtension(json, ".pdf");
                return GerarPdfDeJson(json, pdf) ? pdf : null;
            }
            catch { return null; }
        }

        public static string GerarDanoGravesPdf(string outputPdfPath = null)
        {
            try
            {
                CriacaoDJson.AtualizarTodosJson();
                string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "relatorios");
                string json = Path.Combine(dir, "DanoGraves.json");
                if (!File.Exists(json)) return null;
                string pdf = outputPdfPath ?? Path.ChangeExtension(json, ".pdf");
                return GerarPdfDeJson(json, pdf) ? pdf : null;
            }
            catch { return null; }
        }

        // Helper central para gerar PDF por categoria + filtro
        public static string GerarPdfPorTipo(string categoria, string filtro)
        {
            if (string.IsNullOrEmpty(categoria) || string.IsNullOrEmpty(filtro)) return null;
            categoria = categoria.Trim().ToLowerInvariant();
            filtro = filtro.Trim();

            switch (categoria)
            {
                case "dano":
                case "danos":
                    switch (filtro)
                    {
                        case "Geral": return GerarDanosGeralPdf();
                        case "Novo": return GerarDanosNovosPdf();
                        case "Uso Moderado": return GerarUsoModeradoPdf();
                        case "Danos Leves": return GerarDanoLevesPdf();
                        case "Danos Graves": return GerarDanoGravesPdf();
                        default: return null;
                    }
                case "atraso":
                case "atrasos":
                    switch (filtro)
                    {
                        case "Geral": return GerarAtrasoGeralPdf();
                        case "Atrasos Não Quitados": return GerarAtrasoNaoQuitadosPdf();
                        case "Atrasos Quitados": return GerarAtrasoQuitadoPdf();
                        default: return null;
                    }
                case "preferencia":
                case "pref":
                case "preferências":
                    switch (filtro)
                    {
                        case "Geral": return GerarPreferenciaGeralPdf();
                        case "Mais Escolhido": return GerarPreferenciaMaisEscolhidoPdf();
                        case "Mais Esperado": return GerarPreferenciaMaisEsperadoPdf();
                        default: return null;
                    }
                default:
                    return null;
            }
        }
    }
}
