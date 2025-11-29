using Bibliotecla.banco;
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
    public partial class frm_Cadastro_Titulos : Form, CadastroEdicao
    {
        public frm_Cadastro_Titulos()
        {
            InitializeComponent();
        }

        public bool VerificarCampos()
        {
            bool isPreenchido = false;
            if (!string.IsNullOrWhiteSpace(txt_Titulo.Text) &&
                !string.IsNullOrWhiteSpace(txt_Autor.Text) &&
                !string.IsNullOrWhiteSpace(txt_Genero.Text))
            {
                isPreenchido = true;
            }

            return isPreenchido;
        }

        private void btn_Voltar_Click(object sender, EventArgs e)
        {
            // 1. Cria uma instância do novo formulário.
            frm_Geren_Livros novoFormulario = new frm_Geren_Livros();

            // 2. Exibe o novo formulário.
            novoFormulario.Show();

            // 3. Fecha o formulário atual.
            this.Hide();
        }

        private void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            if (VerificarCampos())
            {
                string titulo = txt_Titulo.Text;
                string autor = txt_Autor.Text;
                string genero = txt_Genero.Text;

                Titulo objTitulo = new Titulo(titulo, autor, genero);

            }
            else
            {
                MensagensPadrao.MsgCamposObrigatorios();
            }
        }
    }
}
