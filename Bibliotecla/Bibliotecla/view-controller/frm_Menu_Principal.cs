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
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Bibliotecla
{
    public partial class frm_Menu_Principal : Form
    {
        public frm_Menu_Principal()
        {
            InitializeComponent();
            CarregarAcesso();
        }

        private void CarregarAcesso()
        {
            LeitorFuncio usuario = UsuarioLogado.GetUsuario();

            lbl_InfoAcesso.Text += usuario.Cargo.ToUpper();

            // Desabilitar botão Multa por padrão
            btn_Multa.Enabled = false;

            switch (usuario.Cargo.ToUpper())
            {
                case "BIBLIOTECARIO":
                    btn_relatorio.Enabled = false; 
                    break;

                case "GERENTE":
                    btn_relatorio.Enabled = true;
                    break;

                case "DIRETORA":
                    btn_relatorio.Enabled = true;
                    break;

                default:
                    btn_relatorio.Enabled = false;
                    btn_Livros.Enabled = false;
                    btn_Emp_Dev.Enabled = false;
                    btn_Geren_Cad.Enabled = false;
                    // btn_Multa already desabilitado acima
                    btn_Sair.Enabled = true;
                    break;
            }
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
