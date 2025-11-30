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
    public partial class frm_Relatorio_Atraso : Form
    {
        public frm_Relatorio_Atraso()
        {
            InitializeComponent();
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
                // Para relatório de atrasos usamos o relatório de empréstimos (contém campo isAtrasado)
                string pdfPath = FazerJsonemPDF.GerarRelatorioEmprestimosPdf();

                if (!string.IsNullOrEmpty(pdfPath) && File.Exists(pdfPath))
                {
                    MessageBox.Show("PDF gerado em: " + pdfPath);
                }
                else
                {
                    MessageBox.Show("Falha ao gerar o PDF de atrasos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar PDFs: " + ex.Message);
            }
        }
    }
}
