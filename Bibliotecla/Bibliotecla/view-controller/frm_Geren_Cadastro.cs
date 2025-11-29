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
            // 1. Cria uma instância do novo formulário.
            frm_Menu_Principal novoFormulario = new frm_Menu_Principal();

            // 2. Exibe o novo formulário.
            novoFormulario.Show();

            // 3. Fecha o formulário atual.
            this.Hide();
        }

        private void btn_Funcionario_Click(object sender, EventArgs e)
        {
            // 1. Cria uma instância do novo formulário.
            frm_Cadastro_Funcionarios novoFormulario = new frm_Cadastro_Funcionarios();

            // 2. Exibe o novo formulário.
            novoFormulario.Show();

            // 3. Fecha o formulário atual.
            this.Hide();
        }

        private void btn_Consul_Funcionario_Click(object sender, EventArgs e)
        {
            // 1. Cria uma instância do novo formulário.
            frm_Consul_Funcionario novoFormulario = new frm_Consul_Funcionario();

            // 2. Exibe o novo formulário.
            novoFormulario.Show();

            // 3. Fecha o formulário atual.
            this.Hide();
        }

        private void btn_Leitor_Click(object sender, EventArgs e)
        {
            // 1. Cria uma instância do novo formulário.
            frm_Cadastro_Leitores novoFormulario = new frm_Cadastro_Leitores();

            // 2. Exibe o novo formulário.
            novoFormulario.Show();

            // 3. Fecha o formulário atual.
            this.Hide();
        }

        private void btn_Consul_Leitores_Click(object sender, EventArgs e)
        {
            // 1. Cria uma instância do novo formulário.
            frm_Consulta_Leitor novoFormulario = new frm_Consulta_Leitor();

            // 2. Exibe o novo formulário.
            novoFormulario.Show();

            // 3. Fecha o formulário atual.
            this.Hide();
        }
    }
}
