using Bibliotecla.geral;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Bibliotecla
{
    public partial class frm_Relatorio_Pref : Form
    {
        public frm_Relatorio_Pref()
        {
            InitializeComponent();
        }

        private void gunaLabel2_Click(object sender, EventArgs e)
        {
        }

        private void btn_Voltar_Click(object sender, EventArgs e)
        {
            // 1. Cria uma instância do novo formulário.
            frm_Geren_Relatorios novoFormulario = new frm_Geren_Relatorios();

            // 2. Exibe o novo formulário.
            novoFormulario.Show();

            // 3. Fecha o formulário atual.
            this.Hide();
        }

        private void btn_Gerar_Relatorio_Click(object sender, EventArgs e)
        {
            try
            {
                string selecionado = cmb_Filtro.SelectedItem as string;
                if (string.IsNullOrEmpty(selecionado))
                {
                    MessageBox.Show("Selecione um filtro.");
                    return;
                }

                string pdfPath = null;
                switch (selecionado)
                {
                    case "Geral":
                        pdfPath = FazerJsonemPDF.GerarPreferenciaGeralPdf();
                        break;
                    case "Mais Escolhido":
                        pdfPath = FazerJsonemPDF.GerarPreferenciaMaisEscolhidoPdf();
                        break;
                    case "Mais Esperado":
                        pdfPath = FazerJsonemPDF.GerarPreferenciaMaisEsperadoPdf();
                        break;
                    default:
                        MessageBox.Show("Filtro desconhecido.");
                        return;
                }

                if (string.IsNullOrEmpty(pdfPath) || !File.Exists(pdfPath))
                {
                    MessageBox.Show("Sem informação");
                    return;
                }

                MessageBox.Show("PDF gerado em: " + pdfPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar PDFs: " + ex.Message);
            }
        }
    }
}
