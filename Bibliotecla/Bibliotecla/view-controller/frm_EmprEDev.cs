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
            Navegacao.TrocarTela(this, new frm_Menu_Principal());
        }

        private void btn_Cadas_Leitor_Click(object sender, EventArgs e)
        {
            // 1. Cria uma instância do novo formulário.
            Navegacao.TrocarTela(this, new frm_Cadastro_Leitores());
        }

        private void btn_Multa_Click(object sender, EventArgs e)
        {
            // 1. Cria uma instância do novo formulário.
            Navegacao.TrocarTela(this, new frm_Multa());
        }

        private void cmb_Titulo_Emp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
