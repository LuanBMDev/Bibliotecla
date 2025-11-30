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
    public partial class frm_Geren_Relatorios : Form
    {
        public frm_Geren_Relatorios()
        {
            InitializeComponent();
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            // 1. Cria uma instância do novo formulário.
            frm_Menu_Principal novoFormulario = new frm_Menu_Principal();

            // 2. Exibe o novo formulário.
            novoFormulario.Show();

            // 3. Fecha o formulário atual.
            this.Hide();
        }

        private void btn_Pref_Click(object sender, EventArgs e)
        {
            // 1. Cria uma instância do novo formulário.
            frm_Relatorio_Pref novoFormulario = new frm_Relatorio_Pref();

            // 2. Exibe o novo formulário.
            novoFormulario.Show();

            // 3. Fecha o formulário atual.
            this.Hide();
        }

        private void btn_Danos_Click(object sender, EventArgs e)
        {
            // 1. Cria uma instância do novo formulário.
            frm_Relatorio_Dano novoFormulario = new frm_Relatorio_Dano();

            // 2. Exibe o novo formulário.
            novoFormulario.Show();

            // 3. Fecha o formulário atual.
            this.Hide();
        }

        private void btn_Atrasos_Click(object sender, EventArgs e)
        {
            // 1. Cria uma instância do novo formulário.
            frm_Relatorio_Atraso novoFormulario = new frm_Relatorio_Atraso();

            // 2. Exibe o novo formulário.
            novoFormulario.Show();

            // 3. Fecha o formulário atual.
            this.Hide();
        }
    }
}
