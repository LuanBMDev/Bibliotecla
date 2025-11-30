using Bibliotecla.geral;
using System;
using System.IO;
using System.Windows.Forms;

namespace Bibliotecla
{
    public partial class frm_Relatorio_Atraso : Form
    {
        public frm_Relatorio_Atraso()
        {
            InitializeComponent();
        }

        private void btn_Voltar_Click(object sender, EventArgs e)
        {
            frm_Geren_Relatorios novoFormulario = new frm_Geren_Relatorios();
            novoFormulario.Show();
            this.Hide();
        }

        private bool JsonTemConteudo(string jsonFileName)
        {
            if (string.IsNullOrWhiteSpace(jsonFileName)) return false;
            string relDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "relatorios");
            string caminho = Path.Combine(relDir, jsonFileName);
            if (!File.Exists(caminho)) return false;
            string texto = File.ReadAllText(caminho).Trim();
            if (string.IsNullOrWhiteSpace(texto)) return false;
            if (texto == "[]" || texto == "{}") return false;
            return true;
        }

        private void GeneratePdfBySelection()
        {
            try
            {
                string selecionado = cmb_Filtro.SelectedItem as string;
                if (string.IsNullOrWhiteSpace(selecionado))
                {
                    MessageBox.Show("Selecione um filtro.");
                    return;
                }

                try { CriacaoDJson.AtualizarTodosJson(); } catch (Exception exJson) { Console.WriteLine("Falha atualizar JSON: " + exJson.Message); }

                string filtroLimpo = selecionado.Trim();
                string jsonName = filtroLimpo == "Geral" ? "AtrasosGeral.json" :
                                   filtroLimpo == "Atrasos Não Quitados" ? "AtrasosNaoQuitados.json" :
                                   filtroLimpo == "Atrasos Quitados" ? "AtrasoQuitados.json" : null;

                if (jsonName == null)
                {
                    MessageBox.Show("Filtro desconhecido.");
                    return;
                }

                if (!JsonTemConteudo(jsonName))
                {
                    MessageBox.Show("Nenhum dado disponível para o filtro selecionado. JSON=" + jsonName, "Sem dados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string pdfPath = FazerJsonemPDF.GerarPdfPorTipo("atraso", filtroLimpo);

                if (string.IsNullOrEmpty(pdfPath) || !File.Exists(pdfPath))
                {
                    MessageBox.Show("Falha ao gerar PDF (arquivo não encontrado).", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show("Relatório gerado com sucesso!\nArquivo: " + pdfPath, "Relatório Atrasos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar PDF: " + ex.Message);
            }
        }

        private void btn_Gerar_Relatorio_Click(object sender, EventArgs e) => GeneratePdfBySelection();
    }
}
