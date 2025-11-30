using Bibliotecla.geral;
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
            Navegacao.TrocarTela(this, new frm_EmprEDev());
        }

        private void btn_Livros_Click(object sender, EventArgs e)
        {
            Navegacao.TrocarTela(this, new frm_Geren_Livros());
        }

        private void btn_Multa_Click(object sender, EventArgs e)
        {
            Navegacao.TrocarTela(this, new frm_Multa());
        }

        private void btn_Geren_Cad_Click(object sender, EventArgs e)
        {
            Navegacao.TrocarTela(this, new frm_Geren_Cadastro());
        }

        private void btn_relatorio_Click(object sender, EventArgs e)
        {
            Navegacao.TrocarTela(this, new frm_Geren_Relatorios());
        }

        private void btn_Sair_Click(object sender, EventArgs e)
        {
            Navegacao.TrocarTela(this, new Form1());
        }
    }
}
