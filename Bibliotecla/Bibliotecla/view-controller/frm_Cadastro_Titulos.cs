using Bibliotecla.banco;
using Bibliotecla.DAO;
using Bibliotecla.geral;
using Bibliotecla.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;

namespace Bibliotecla
{
    public partial class frm_Cadastro_Titulos : Form, CadastroEdicao
    {
        private readonly TituloDAO tituloDAO = new TituloDAO();

        // Objeto que só recebe valor por meio da tela de Consulta de Titulos
        private Titulo titulo = null;
        internal Titulo Titulo { get => titulo; set => titulo = value; }

        public frm_Cadastro_Titulos()
        {
            InitializeComponent();
            AlternarBtnEditar();
        }

        private void AlternarBtnEditar()
        {
            if (titulo == null)
            {
                btn_Editar.Enabled = false;
                btn_Editar.Text = "Editar";
                lbl_Dica.Visible = true;
            }
            else
            {
                btn_Editar.Enabled = true;
                btn_Editar.Text = "Editar Titulo N°" + this.titulo.CodTitulo;
                lbl_Dica.Visible = false;
            }
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
            this.titulo = null;

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
                string titulo = txt_Titulo.Text.Trim();
                string autor = txt_Autor.Text.Trim();
                string genero = txt_Genero.Text.Trim();

                try
                {
                    Titulo objTitulo = new Titulo(titulo, genero, autor);
                    tituloDAO.Inserir(objTitulo);

                    MensagensPadrao.MsgCadastroSucesso(MensagensPadrao.Entidade.Titulo);

                    LimparCampos();
                }
                catch (MySqlException ex)
                {
                    MensagensPadrao.MsgFalhaCadastro(MensagensPadrao.Entidade.Titulo, ex);
                }
            }
            else
            {
                MensagensPadrao.MsgCamposObrigatorios();
            }
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            if (VerificarCampos())
            {
                string titulo = txt_Titulo.Text.Trim();
                string autor = txt_Autor.Text.Trim();
                string genero = txt_Genero.Text.Trim();

                try
                {
                    Titulo objTitulo = new Titulo(this.titulo.CodTitulo, titulo, genero, autor);
                    tituloDAO.Alterar(objTitulo);

                    MensagensPadrao.MsgEdicaoSucesso(MensagensPadrao.Entidade.Titulo);
                }
                catch (MySqlException ex)
                {
                    MensagensPadrao.MsgFalhaEdicao(MensagensPadrao.Entidade.Titulo, ex);
                }
            }
            else
            {
                MensagensPadrao.MsgCamposObrigatorios();
            }
        }

        public void LimparCampos()
        {
            txt_Titulo.Clear();
            txt_Autor.Clear();
            txt_Genero.Clear();
        }
    }
}
