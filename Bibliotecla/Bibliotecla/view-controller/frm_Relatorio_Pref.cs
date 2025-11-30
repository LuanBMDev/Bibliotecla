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

        private void GeneratePdfBySelection()
        {
            try
            {
                string selecionado = cmb_Filtro.SelectedItem as string;
                if (string.IsNullOrEmpty(selecionado))
                {
                    MessageBox.Show("Selecione um filtro.");
                    return;
                }

                string pdfPath = FazerJsonemPDF.GerarPdfPorTipo("preferencia", selecionado);

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

        private void btn_Gerar_Relatorio_Click(object sender, EventArgs e)
        {
            GeneratePdfBySelection();
        }

        // designer might wire another handler name; ensure it calls the same logic
        private void btn_Gerar_Relatorio_Click_1(object sender, EventArgs e)
        {
            GeneratePdfBySelection();
        }
    }
}
