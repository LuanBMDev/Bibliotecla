using Bibliotecla.geral;
using Bibliotecla.model;
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
            CarregarAcesso();
        }

        private void CarregarAcesso()
        {
            LeitorFuncio usuario = UsuarioLogado.GetUsuario();

            lbl_InfoAcesso.Text += usuario.Cargo.ToUpper();
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            Navegacao.TrocarTela(this, new frm_Menu_Principal());
        }

        private void btn_Pref_Click(object sender, EventArgs e)
        {
            Navegacao.TrocarTela(this, new frm_Relatorio_Pref());
        }

        private void btn_Danos_Click(object sender, EventArgs e)
        {
            Navegacao.TrocarTela(this, new frm_Relatorio_Dano());
        }

        private void btn_Atrasos_Click(object sender, EventArgs e)
        {
            Navegacao.TrocarTela(this, new frm_Relatorio_Atraso());
        }
    }
}
