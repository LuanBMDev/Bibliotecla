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
    public partial class frm_Geren_Cadastro : Form
    {
        public frm_Geren_Cadastro()
        {
            InitializeComponent();
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
