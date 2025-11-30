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
    public partial class frm_Geren_Livros : Form
    {
        public frm_Geren_Livros()
        {
            InitializeComponent();
        }

        private void btn_Voltar_Click(object sender, EventArgs e)
        {
            Navegacao.TrocarTela(this, new frm_Menu_Principal());
        }

        private void btn_Titulos_Click(object sender, EventArgs e)
        {
            Navegacao.TrocarTela(this, new frm_Cadastro_Titulos());     
        }

        private void btn_Consul_Titulo_Click(object sender, EventArgs e)
        {
            Navegacao.TrocarTela(this, new frm_Colsul_Titulos());
        }

        private void btn_Exemplar_Click(object sender, EventArgs e)
        {
            Navegacao.TrocarTela(this, new frm_Cadastro_Exemplares());
        }

        private void btn_Consul_Exemplar_Click(object sender, EventArgs e)
        {
            Navegacao.TrocarTela(this, new frm_Consul_Exemplares());
        }
    }
}
