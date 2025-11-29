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
            // 1. Cria uma instância do novo formulário.
            frm_Menu_Principal novoFormulario = new frm_Menu_Principal();

            // 2. Exibe o novo formulário.
            novoFormulario.Show();

            // 3. Fecha o formulário atual.
            this.Hide();
        }

        private void btn_Titulos_Click(object sender, EventArgs e)
        {
            // 1. Cria uma instância do novo formulário.
            frm_Cadastro_Titulos novoFormulario = new frm_Cadastro_Titulos();

            // 2. Exibe o novo formulário.
            novoFormulario.Show();

            // 3. Fecha o formulário atual.
            this.Hide();
        }

        private void btn_Consul_Titulo_Click(object sender, EventArgs e)
        {
            // 1. Cria uma instância do novo formulário.
            frm_Colsul_Titulos novoFormulario = new frm_Colsul_Titulos();

            // 2. Exibe o novo formulário.
            novoFormulario.Show();

            // 3. Fecha o formulário atual.
            this.Hide();
        }

        private void btn_Exemplar_Click(object sender, EventArgs e)
        {
            // 1. Cria uma instância do novo formulário.
            frm_Cadastro_Exemplares novoFormulario = new frm_Cadastro_Exemplares();

            // 2. Exibe o novo formulário.
            novoFormulario.Show();

            // 3. Fecha o formulário atual.
            this.Hide();
        }

        private void btn_Consul_Exemplar_Click(object sender, EventArgs e)
        {
            // 1. Cria uma instância do novo formulário.
            frm_Consul_Exemplares novoFormulario = new frm_Consul_Exemplares();

            // 2. Exibe o novo formulário.
            novoFormulario.Show();

            // 3. Fecha o formulário atual.
            this.Hide();
        }
    }
}
