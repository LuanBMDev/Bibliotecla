using Bibliotecla.geral;
using System;
using System.IO;
using System.Windows.Forms;

namespace Bibliotecla
{
    public partial class frm_Relatorio_Pref : Form
    {
        public frm_Relatorio_Pref()
        {
            InitializeComponent();
        }

        private void gunaLabel2_Click(object sender, EventArgs e) { }

        private void btn_Voltar_Click(object sender, EventArgs e)
        {
            frm_Geren_Relatorios novoFormulario = new frm_Geren_Relatorios();
            novoFormulario.Show();
            this.Hide();
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

                // Garante atualização dos JSON antes de gerar
                try { CriacaoDJson.AtualizarTodosJson(); } catch (Exception exJson) { Console.WriteLine("Falha atualizar JSON: " + exJson.Message); }

                string pdfPath = FazerJsonemPDF.GerarPdfPorTipo("preferencia", selecionado.Trim());

                if (string.IsNullOrEmpty(pdfPath) || !File.Exists(pdfPath))
                {
                    // Mostra diagnóstico básico
                    string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                    string relDir = Path.Combine(baseDir, "relatorios");
                    string jsonName = selecionado.Trim() == "Geral" ? "PreferenciaGeral.json" :
                                      selecionado.Trim() == "Mais Escolhido" ? "PreferenciaMaisEscolido.json" :
                                      selecionado.Trim() == "Mais Esperado" ? "PreferenciaMaisEsperado.json" : "(desconhecido)";
                    string jsonPath = Path.Combine(relDir, jsonName);
                    bool jsonExiste = File.Exists(jsonPath);
                    MessageBox.Show("Nenhum dado disponível. JSON=" + jsonName + " existe=" + jsonExiste);
                    return;
                }

                MessageBox.Show("Relatório gerado com sucesso!\nArquivo: " + pdfPath, "Relatório Preferência", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar PDF: " + ex.Message);
            }
        }

        private void btn_Gerar_Relatorio_Click(object sender, EventArgs e) => GeneratePdfBySelection();
        private void btn_Gerar_Relatorio_Click_1(object sender, EventArgs e) => GeneratePdfBySelection();
    }
}
