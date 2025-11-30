using Bibliotecla.banco;
using Bibliotecla.DAO;
using Bibliotecla.geral;
using Bibliotecla.model;
using MySql.Data.MySqlClient;
using System;
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

        // Tornar internal para manter consistência de acessibilidade com a classe Titulo (internal)
        internal void CarregarTitulo(Titulo t)
        {
            this.titulo = t;
            if (t != null)
            {
                txt_Titulo.Text = t.NomeTitulo ?? string.Empty;
                txt_Autor.Text = t.AutorTitulo ?? string.Empty;
                txt_Genero.Text = t.GeneroTitulo ?? string.Empty;
            }
            AlternarBtnEditar();
        }

        private void AlternarBtnEditar()
        {
            if (titulo == null)
            {
                btn_Editar.Enabled = false;
                btn_Cadastrar.Enabled = true;
                btn_Editar.Text = "Editar";
                lbl_Dica.Visible = true;
            }
            else
            {
                btn_Editar.Enabled = true;
                btn_Cadastrar.Enabled = false;
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
            Navegacao.TrocarTela(this, new frm_Geren_Livros());
        }

        private void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            if (VerificarCampos())
            {
                string t = txt_Titulo.Text.Trim();
                string a = txt_Autor.Text.Trim();
                string g = txt_Genero.Text.Trim();
                try
                {
                    Titulo objTitulo = new Titulo(t, g, a);
                    tituloDAO.Inserir(objTitulo);
                    MensagensPadrao.MsgCadastroSucesso(MensagensPadrao.Entidade.Titulo);
                    LimparCampos();
                }
                catch (MySqlException ex)
                {
                    MensagensPadrao.MsgFalhaCadastro(MensagensPadrao.Entidade.Titulo, ex);
                }
            }
            else MensagensPadrao.MsgCamposObrigatorios();
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            if (titulo == null)
            {
                MessageBox.Show("Nenhum título carregado para edição.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (VerificarCampos())
            {
                string t = txt_Titulo.Text.Trim();
                string a = txt_Autor.Text.Trim();
                string g = txt_Genero.Text.Trim();
                try
                {
                    Titulo objTitulo = new Titulo(this.titulo.CodTitulo, t, g, a);
                    tituloDAO.Alterar(objTitulo);
                    MensagensPadrao.MsgEdicaoSucesso(MensagensPadrao.Entidade.Titulo);
                    // Após editar, limpar e voltar ao estado de cadastro sem o título da consulta
                    LimparCampos();
                    this.titulo = null;
                    AlternarBtnEditar();
                }
                catch (MySqlException ex)
                {
                    MensagensPadrao.MsgFalhaEdicao(MensagensPadrao.Entidade.Titulo, ex);
                }
            }
            else MensagensPadrao.MsgCamposObrigatorios();
        }

        public void LimparCampos()
        {
            txt_Titulo.Clear();
            txt_Autor.Clear();
            txt_Genero.Clear();
        }
    }
}
