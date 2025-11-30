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
    public partial class frm_Geren_Cadastro : Form
    {
        public frm_Geren_Cadastro()
        {
            InitializeComponent();
            CarregarAcesso();
        }

        private void CarregarAcesso()
        {
            LeitorFuncio usuario = UsuarioLogado.GetUsuario();

            lbl_InfoAcesso.Text += usuario.Cargo.ToUpper();

            switch (usuario.Cargo.ToUpper())
            {
                case "BIBLIOTECARIO":
                    btn_Consul_Funcionario.Enabled = false;
                    btn_Funcionario.Enabled = false;
                    break;

                case "GERENTE":
                    btn_Consul_Funcionario.Enabled = false;
                    btn_Funcionario.Enabled = false;
                    break;

                case "DIRETORA":
                    btn_Consul_Funcionario.Enabled = true;
                    btn_Funcionario.Enabled = true;
                    break;

                default:
                    btn_Consul_Funcionario.Enabled = false;
                    btn_Funcionario.Enabled = false;
                    btn_Leitor.Enabled = false;
                    btn_Consul_Leitores.Enabled = false;
                    btn_Voltar.Enabled = true;
                    break;
            }
        }

        private void btn_Voltar_Click(object sender, EventArgs e)
        {
            Navegacao.TrocarTela(this, new frm_Menu_Principal());
        }

        private void btn_Funcionario_Click(object sender, EventArgs e)
        {
            Navegacao.TrocarTela(this, new frm_Cadastro_Funcionarios());
        }

        private void btn_Consul_Funcionario_Click(object sender, EventArgs e)
        {
            Navegacao.TrocarTela(this, new frm_Consul_Funcionario());
        }

        private void btn_Leitor_Click(object sender, EventArgs e)
        {
            Navegacao.TrocarTela(this, new frm_Cadastro_Leitores());
        }

        private void btn_Consul_Leitores_Click(object sender, EventArgs e)
        {
            Navegacao.TrocarTela(this, new frm_Consulta_Leitor());
        }
    }
}
