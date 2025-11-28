using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Bibliotecla
{
    public partial class frm_Menu_Principal : Form
    {
        public frm_Menu_Principal()
        {
            InitializeComponent();
        }

        private void btn_Emp_Dev_Click(object sender, EventArgs e)
        {
            // 1. Cria uma instância do novo formulário.
            frm_EmprEDev novoFormulario = new frm_EmprEDev();

            // 2. Exibe o novo formulário.
            novoFormulario.Show();

            // 3. Fecha o formulário atual.
            this.Hide();
        }

        private void btn_Livros_Click(object sender, EventArgs e)
        {
            // 1. Cria uma instância do novo formulário.
            frm_Geren_Livros novoFormulario = new frm_Geren_Livros();

            // 2. Exibe o novo formulário.
            novoFormulario.Show();

            // 3. Fecha o formulário atual.
            this.Hide();
        }

        private void btn_Multa_Click(object sender, EventArgs e)
        {
            // 1. Cria uma instância do novo formulário.
            frm_Multa novoFormulario = new frm_Multa();

            // 2. Exibe o novo formulário.
            novoFormulario.Show();

            // 3. Fecha o formulário atual.
            this.Hide();
        }

        private void btn_Geren_Cad_Click(object sender, EventArgs e)
        {
            // 1. Cria uma instância do novo formulário.
            frm_Geren_Cadastro novoFormulario = new frm_Geren_Cadastro();

            // 2. Exibe o novo formulário.
            novoFormulario.Show();

            // 3. Fecha o formulário atual.
            this.Hide();
        }

        private void btn_relatorio_Click(object sender, EventArgs e)
        {
            // 1. Cria uma instância do novo formulário.
            frm_Geren_Relatorios novoFormulario = new frm_Geren_Relatorios();

            // 2. Exibe o novo formulário.
            novoFormulario.Show();

            // 3. Fecha o formulário atual.
            this.Hide();
        }

        private void btn_Sair_Click(object sender, EventArgs e)
        {
            // 1. Cria uma instância do novo formulário.
            Login novoFormulario = new Login();

            // 2. Exibe o novo formulário.
            novoFormulario.Show();

            // 3. Fecha o formulário atual.
            this.Hide();
        }
    }
}
