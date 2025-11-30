using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bibliotecla
{
    public partial class frm_EmprEDev : Form
    {
        public frm_EmprEDev()
        {
            InitializeComponent();
        }

        private void btn_Voltar_Click(object sender, EventArgs e)
        {
            // 1. Cria uma instância do novo formulário.
            frm_Menu_Principal novoFormulario = new frm_Menu_Principal();

            // 2. Exibe o novo formulário.
            novoFormulario.Show();

            // 3. Fecha o formulário atual.
            this.Hide();
        }

        private void btn_Cadas_Leitor_Click(object sender, EventArgs e)
        {
            // 1. Cria uma instância do novo formulário.
            frm_Cadastro_Leitores novoFormulario = new frm_Cadastro_Leitores();

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

        private void cmb_Titulo_Emp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
