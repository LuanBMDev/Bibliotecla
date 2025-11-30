using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
// Removido iTextSharp

namespace Bibliotecla.geral
{
    internal static class FazerJsonemPDF
    {
        private static string GetDesktopPath() => Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        /// <summary>
        /// Converte um arquivo JSON em PDF simples (texto) multi-página. Se for array de objetos padronizados, mostra em tabela (colunas).
        /// </summary>
        public static bool GerarPdfDeJson(string jsonFilePath, string pdfOutputPath)
        {
            try
            {
                if (string.IsNullOrEmpty(jsonFilePath) || !File.Exists(jsonFilePath))
                    throw new FileNotFoundException("Arquivo JSON não encontrado.", jsonFilePath);

                string json = File.ReadAllText(jsonFilePath, Encoding.UTF8);
                JToken token = JToken.Parse(json); // valida estrutura
                string formatted = token.ToString(Newtonsoft.Json.Formatting.Indented);

                string[] tableLines = TryRenderTable(token);
                string[] lines;
                if (tableLines != null && tableLines.Length > 0)
                {
                    lines = tableLines;
                }
                else
                {
                    lines = formatted.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                }

                WriteSimplePdf(pdfOutputPath, Path.GetFileName(jsonFilePath), lines);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao gerar PDF do JSON: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Tenta renderizar o JSON como tabela monoespaçada. Retorna null se não aplicável.
        /// Critérios: token é JArray; elementos são JObject; todos compartilham ao menos uma chave.
        /// </summary>
        private static string[] TryRenderTable(JToken token)
        {
            if (token == null || token.Type != JTokenType.Array) return null;
            var arr = (JArray)token;
            if (arr.Count == 0) return new[] { "(Array vazio)" };
            // filtra apenas objetos
            var objetos = arr.OfType<JObject>().ToList();
            if (objetos.Count != arr.Count) return null; // mistura tipos
            // Coleta conjunto de chaves comum (interseção); se vazio, usar união.
            IEnumerable<string> allKeys = objetos.Select(o => o.Properties().Select(p => p.Name)).Aggregate((prev, next) => prev.Intersect(next));
            var keysList = allKeys.ToList();
            if (keysList.Count == 0)
            {
                keysList = objetos.SelectMany(o => o.Properties().Select(p => p.Name)).Distinct().ToList();
            }
            if (keysList.Count == 0) return null;

            // Determina largura disponível para conteúdo
            const int availableWidth = 595 - 40 - 20; // pageWidth - leftMargin - rightMargin aproximado
            int colCount = keysList.Count;
            // Calcula largura máxima de cada coluna
            var colWidths = new int[colCount];
            for (int i = 0; i < colCount; i++)
            {
                string key = keysList[i];
                int maxLen = key.Length;
                foreach (var obj in objetos)
                {
                    JToken valToken = obj[key];
                    string valStr = FormatValue(valToken);
                    if (valStr.Length > maxLen) maxLen = valStr.Length;
                }
                // padding + limites
                colWidths[i] = Math.Min(Math.Max(maxLen, 4) + 2, 30); // cap em 30
            }
            int totalWidth = colWidths.Sum() + colCount + 1; // separadores '|'
            if (totalWidth > availableWidth)
            {
                // Reduz proporcionalmente
                double ratio = (double)availableWidth / totalWidth;
                for (int i = 0; i < colWidths.Length; i++)
                {
                    colWidths[i] = Math.Max(5, (int)(colWidths[i] * ratio));
                }
            }

            var lines = new List<string>();
            // Header
            lines.Add(BuildRow(keysList.ToArray(), colWidths, true));
            // Separator
            lines.Add(BuildSeparator(colWidths));
            // Rows
            foreach (var obj in objetos)
            {
                var vals = new string[colCount];
                for (int i = 0; i < colCount; i++)
                {
                    JToken v = obj[keysList[i]];
                    vals[i] = Truncate(FormatValue(v), colWidths[i] - 2); // -2 for padding
                }
                lines.Add(BuildRow(vals, colWidths, false));
            }
            return lines.ToArray();
        }

        private static string FormatValue(JToken token)
        {
            if (token == null) return string.Empty;
            if (token.Type == JTokenType.Array) return "[" + token.Count() + "]";
            if (token.Type == JTokenType.Object) return "{obj}";
            string s = token.ToString();
            // Remove quebras internas para manter tabela
            s = s.Replace('\r', ' ').Replace('\n', ' ');
            return s;
        }

        private static string Truncate(string s, int max)
        {
            if (s == null) return string.Empty;
            if (s.Length <= max) return s;
            if (max <= 3) return s.Substring(0, max);
            return s.Substring(0, max - 3) + "...";
        }

        private static string BuildRow(string[] cells, int[] widths, bool isHeader)
        {
            var sb = new StringBuilder();
            sb.Append('|');
            for (int i = 0; i < cells.Length; i++)
            {
                string text = cells[i] ?? string.Empty;
                // pad
                if (text.Length > widths[i] - 2) text = Truncate(text, widths[i] - 2);
                sb.Append(' ');
                sb.Append(text.PadRight(widths[i] - 2));
                sb.Append(' ');
                sb.Append('|');
            }
            return sb.ToString();
        }

        private static string BuildSeparator(int[] widths)
        {
            var sb = new StringBuilder();
            sb.Append('+');
            foreach (var w in widths)
            {
                sb.Append(new string('-', w));
                sb.Append('+');
            }
            return sb.ToString();
        }

        /// <summary>
        /// Gera PDF mínimo em texto monoespaçado com suporte a múltiplas páginas e quebra de linha simples.
        /// Implementação manual do formato PDF (objetos, xref). Base genérica (não copia conteúdo de vídeo).
        /// </summary>
        private static void WriteSimplePdf(string path, string title, string[] lines)
        {
            const int pageWidth = 595;      // A4
            const int pageHeight = 842;     // A4
            const int leftMargin = 40;
            const int topStart = 800;
            const int fontSize = 9;
            const int leading = 12;         // espaço entre linhas
            const int bottomMargin = 40;

            string Escape(string s)
            {
                if (string.IsNullOrEmpty(s)) return string.Empty;
                return s.Replace("\\", "\\\\").Replace("(", "\\(").Replace(")", "\\)");
            }

            int linesPerPage = (topStart - bottomMargin) / leading - 2; // -2 título/data
            if (linesPerPage < 1) linesPerPage = 1;

            var pages = new List<List<string>>();
            int idx = 0;
            while (idx < lines.Length)
            {
                var page = new List<string>();
                int c = 0;
                while (c < linesPerPage && idx < lines.Length)
                {
                    page.Add(lines[idx]);
                    idx++; c++;
                }
                pages.Add(page);
            }
            if (pages.Count == 0) pages.Add(new List<string>());
            int pageCount = pages.Count;

            var contentStreams = new List<byte[]>();
            for (int p = 0; p < pages.Count; p++)
            {
                var sb = new StringBuilder();
                sb.AppendLine("BT");
                sb.AppendLine($"/F1 {fontSize} Tf");
                sb.AppendLine($"{leading} TL");
                sb.AppendLine($"{leftMargin} {topStart} Td");
                if (p == 0)
                {
                    sb.AppendLine($"({Escape(title)}) Tj T*");
                    sb.AppendLine($"(Gerado: {Escape(DateTime.Now.ToString("g"))}) Tj T*");
                }
                foreach (var l in pages[p])
                {
                    sb.AppendLine($"({Escape(l)}) Tj T*");
                }
                // número da página
                sb.AppendLine($"(Pag {p + 1}/{pageCount}) Tj T*");
                sb.AppendLine("ET");
                contentStreams.Add(Encoding.UTF8.GetBytes(sb.ToString()));
            }

            int totalObjects = 2 + (2 * pageCount) + 1;
            long[] offsets = new long[totalObjects + 1];
            using (var ms = new MemoryStream())
            using (var writer = new BinaryWriter(ms, Encoding.ASCII))
            {
                void W(string s) => writer.Write(Encoding.ASCII.GetBytes(s + "\n"));
                W("%PDF-1.4");
                offsets[1] = ms.Position; W("1 0 obj << /Type /Catalog /Pages 2 0 R >> endobj");
                var kids = new StringBuilder();
                for (int i = 0; i < pageCount; i++) kids.AppendFormat(" {0} 0 R", 3 + i);
                offsets[2] = ms.Position; W($"2 0 obj << /Type /Pages /Count {pageCount} /Kids[{kids.ToString().Trim()}] >> endobj");
                for (int i = 0; i < pageCount; i++)
                {
                    int pageObjId = 3 + i;
                    int contentObjId = 3 + pageCount + i;
                    offsets[pageObjId] = ms.Position;
                    W($"{pageObjId} 0 obj << /Type /Page /Parent 2 0 R /MediaBox [0 0 {pageWidth} {pageHeight}] /Resources << /Font << /F1 {3 + 2 * pageCount} 0 R >> >> /Contents {contentObjId} 0 R >> endobj");
                }
                for (int i = 0; i < pageCount; i++)
                {
                    int contentObjId = 3 + pageCount + i;
                    byte[] bytes = contentStreams[i];
                    offsets[contentObjId] = ms.Position;
                    W($"{contentObjId} 0 obj << /Length {bytes.Length} >> stream");
                    writer.Write(bytes);
                    W("endstream");
                    W("endobj");
                }
                int fontObjId2 = 3 + 2 * pageCount;
                offsets[fontObjId2] = ms.Position; W($"{fontObjId2} 0 obj << /Type /Font /Subtype /Type1 /BaseFont /Courier >> endobj");
                long xrefPos = ms.Position;
                W("xref");
                W($"0 {totalObjects + 1}");
                W("0000000000 65535 f ");
                for (int i = 1; i <= totalObjects; i++) W(offsets[i].ToString("0000000000") + " 00000 n ");
                W($"trailer << /Size {totalObjects + 1} /Root 1 0 R >>");
                W("startxref");
                W(xrefPos.ToString());
                W("%%EOF");
                File.WriteAllBytes(path, ms.ToArray());
            }
        }

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
                        string pdfFileName = Path.ChangeExtension(Path.GetFileName(file), ".pdf");
                        string pdfPath = Path.Combine(GetDesktopPath(), pdfFileName);
                        GerarPdfDeJson(file, pdfPath);
                    }
                    catch (Exception ex) { Console.WriteLine("Falha ao converter " + file + ": " + ex.Message); }
                }
            }
            catch (Exception ex) { Console.WriteLine("Erro ao gerar PDFs: " + ex.Message); }
        }

        private static string BuildDefaultPdfPath(string jsonPath, string outputPdfPath)
        {
            string fileName = Path.ChangeExtension(Path.GetFileName(jsonPath), ".pdf");
            return outputPdfPath ?? Path.Combine(GetDesktopPath(), fileName);
        }

        private static string GerarRelatorioGenerico(string jsonName, string outputPdfPath)
        {
            try
            {
                CriacaoDJson.AtualizarTodosJson();
                string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "relatorios");
                string json = Path.Combine(dir, jsonName);
                if (!File.Exists(json))
                {
                    Console.WriteLine($"JSON não encontrado: {json}");
                    return null;
                }
                string pdf = BuildDefaultPdfPath(json, outputPdfPath);
                return GerarPdfDeJson(json, pdf) ? pdf : null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro em GerarRelatorioGenerico({jsonName}): {ex.Message}");
                return null;
            }
        }

        public static string GerarRelatorioTitulosPdf(string outputPdfPath = null) => GerarRelatorioGenerico("titulos.json", outputPdfPath);
        public static string GerarRelatorioExemplaresPdf(string outputPdfPath = null) => GerarRelatorioGenerico("exemplares.json", outputPdfPath);
        public static string GerarRelatorioEmprestimosPdf(string outputPdfPath = null) => GerarRelatorioGenerico("emprestimos.json", outputPdfPath);
        public static string GerarRelatorioLeitoresPdf(string outputPdfPath = null) => GerarRelatorioGenerico("leitores.json", outputPdfPath);
        public static string GerarRelatorioMultasPdf(string outputPdfPath = null) => GerarRelatorioGenerico("multas.json", outputPdfPath);
        public static string GerarPreferenciaGeralPdf(string outputPdfPath = null) => GerarRelatorioGenerico("PreferenciaGeral.json", outputPdfPath);
        public static string GerarPreferenciaMaisEscolhidoPdf(string outputPdfPath = null) => GerarRelatorioGenerico("PreferenciaMaisEscolido.json", outputPdfPath);
        public static string GerarPreferenciaMaisEsperadoPdf(string outputPdfPath = null) => GerarRelatorioGenerico("PreferenciaMaisEsperado.json", outputPdfPath);
        public static string GerarAtrasoGeralPdf(string outputPdfPath = null) => GerarRelatorioGenerico("AtrasosGeral.json", outputPdfPath);
        public static string GerarAtrasoNaoQuitadosPdf(string outputPdfPath = null) => GerarRelatorioGenerico("AtrasosNaoQuitados.json", outputPdfPath);
        public static string GerarAtrasoQuitadoPdf(string outputPdfPath = null) => GerarRelatorioGenerico("AtrasoQuitados.json", outputPdfPath);
        public static string GerarDanosGeralPdf(string outputPdfPath = null) => GerarRelatorioGenerico("EstadoGeral.json", outputPdfPath);
        public static string GerarDanosNovosPdf(string outputPdfPath = null) => GerarRelatorioGenerico("EstadoNovo.json", outputPdfPath);
        public static string GerarUsoModeradoPdf(string outputPdfPath = null) => GerarRelatorioGenerico("EstadoUsoModerado.json", outputPdfPath);
        public static string GerarDanoLevesPdf(string outputPdfPath = null) => GerarRelatorioGenerico("EstadoDanosLeves.json", outputPdfPath);
        public static string GerarDanoGravesPdf(string outputPdfPath = null) => GerarRelatorioGenerico("EstadoDanosGraves.json", outputPdfPath);

        // Helper central para gerar PDF por categoria + filtro
        public static string GerarPdfPorTipo(string categoria, string filtro)
        {
            if (string.IsNullOrEmpty(categoria) || string.IsNullOrEmpty(filtro)) return null;
            categoria = categoria.Trim().ToLowerInvariant();
            filtro = filtro.Trim();

            Console.WriteLine($"GerarPdfPorTipo: categoria={categoria}, filtro={filtro}");

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
