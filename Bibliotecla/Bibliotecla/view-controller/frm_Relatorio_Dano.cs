using Bibliotecla.geral;
using System;
using System.IO;
using System.Windows.Forms;

namespace Bibliotecla
{
    public partial class frm_Relatorio_Dano : Form
    {
        public frm_Relatorio_Dano()
        {
            InitializeComponent();
        }

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

                // Atualiza JSONs antes de gerar
                try { CriacaoDJson.AtualizarTodosJson(); } catch (Exception exJson) { Console.WriteLine("Falha atualizar JSON: " + exJson.Message); }

                string filtroLimpo = selecionado.Trim();
                string pdfPath = FazerJsonemPDF.GerarPdfPorTipo("dano", filtroLimpo);

                if (string.IsNullOrEmpty(pdfPath) || !File.Exists(pdfPath))
                {
                    string relDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "relatorios");
                    string jsonName = filtroLimpo == "Geral" ? "EstadoGeral.json" :
                                      filtroLimpo == "Novo" ? "EstadoNovo.json" :
                                      filtroLimpo == "Uso Moderado" ? "EstadoUsoModerado.json" :
                                      filtroLimpo == "Danos Leves" ? "EstadoDanosLeves.json" :
                                      filtroLimpo == "Danos Graves" ? "EstadoDanosGraves.json" : "(desconhecido)";
                    bool jsonExiste = File.Exists(Path.Combine(relDir, jsonName));
                    MessageBox.Show("Nenhum dado disponível. JSON=" + jsonName + " existe=" + jsonExiste);
                    return;
                }

                MessageBox.Show("Relatório gerado com sucesso!\nArquivo: " + pdfPath, "Relatório Danos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar PDF: " + ex.Message);
            }
        }

        private void btn_Gerar_Relatorio_Click(object sender, EventArgs e)
        {
            GeneratePdfBySelection();
        }
    }
}
