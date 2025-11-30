using Bibliotecla.DAO;
using Bibliotecla.model;
using Bibliotecla.geral; // adiciona MensagensPadrao e CadastroEdicao
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Bibliotecla
{
    public partial class frm_Cadastro_Exemplares : Form, CadastroEdicao
    {
        private readonly ExemplarDAO exemplarDAO = new ExemplarDAO();
        private Exemplar exemplar = null;
        internal Exemplar Exemplar { get => exemplar; set => exemplar = value; }

        public frm_Cadastro_Exemplares()
        {
            InitializeComponent();
            CarregarTitulos();
            AlternarBtnEditar();
        }

        private void AlternarBtnEditar()
        {
            if (exemplar == null)
            {
                btn_Editar.Enabled = false;
                btn_Editar.Text = "Editar";
                lbl_Dica.Visible = true;
            }
            else
            {
                btn_Editar.Enabled = true;
                btn_Editar.Text = "Editar Exemplar N°" + this.exemplar.CodExemplar;
                lbl_Dica.Visible = false;
            }
        }

        private void CarregarTitulos()
        {
            TituloDAO tituloDAO = new TituloDAO();
            List<Titulo> listaTitulos = tituloDAO.Listar("");

            cmb_Titulos.Items.Clear();

            foreach (Titulo titulo in listaTitulos)
            {
                cmb_Titulos.Items.Add(titulo.CodTitulo + " - " + titulo.NomeTitulo);
            }
        }

        private void btn_Voltar_Click(object sender, EventArgs e)
        {
            this.exemplar = null;

            // 1. Cria uma instância do novo formulário.
            frm_Geren_Livros novoFormulario = new frm_Geren_Livros();

            // 2. Exibe o novo formulário.
            novoFormulario.Show();

            // 3. Fecha o formulário atual.
            this.Hide();
        }

        private void cmb_Titulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Titulo titulo = ExtrairIDComboBox();
            
            txt_Autor.Text = titulo.AutorTitulo;
            txt_Genero.Text = titulo.GeneroTitulo;
        }

        private Titulo ExtrairIDComboBox()
        {
            string[] tituloComID = cmb_Titulos.Text.Split();

            int id = int.Parse(tituloComID[0].Trim());

            TituloDAO tituloDAO = new TituloDAO();
            Titulo titulo = new Titulo(id, null, null, null);
            titulo = tituloDAO.BuscarID(titulo);

            return titulo;
        }

        public bool VerificarCampos()
        {
            bool isPreenchido = false;
            if (!string.IsNullOrWhiteSpace(cmb_Titulos.Text) &&
                !string.IsNullOrWhiteSpace(txt_Genero.Text) &&
                !string.IsNullOrWhiteSpace(txt_Autor.Text) &&
                !string.IsNullOrWhiteSpace(txt_Ano_Publi.Text) &&
                !string.IsNullOrWhiteSpace(txt_Editora.Text) &&
                !string.IsNullOrWhiteSpace(cmb_Estado.Text))
            {
                isPreenchido = true;
            }

            return isPreenchido;
        }

        private void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            if (VerificarCampos())
            {
                Titulo titulo = ExtrairIDComboBox();
                string anoPubli = txt_Ano_Publi.Text;
                string editora = txt_Editora.Text;
                string estadoFisico = cmb_Estado.Text;
                try
                {
                    Exemplar novo = new Exemplar(titulo, anoPubli, estadoFisico, editora);
                    exemplarDAO.Inserir(novo);
                    MensagensPadrao.MsgCadastroSucesso(MensagensPadrao.Entidade.Exemplar);
                    LimparCampos();
                }
                catch (MySqlException ex)
                {
                    MensagensPadrao.MsgFalhaCadastro(MensagensPadrao.Entidade.Exemplar, ex);
                }
            }
            else MensagensPadrao.MsgCamposObrigatorios();
        }

        public void LimparCampos()
        {
            cmb_Titulos.Text = "";
            txt_Autor.Clear();
            txt_Genero.Clear();
            txt_Ano_Publi.Clear();
            txt_Editora.Clear();
            cmb_Estado.SelectedIndex = 0;
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            if (VerificarCampos())
            {
                Titulo titulo = ExtrairIDComboBox();
                string anoPubli = txt_Ano_Publi.Text;
                string editora = txt_Editora.Text;
                string estadoFisico = cmb_Estado.Text;
                try
                {
                    Exemplar att = new Exemplar(this.exemplar.CodExemplar, anoPubli, estadoFisico, editora, titulo);
                    exemplarDAO.Alterar(att);
                    MensagensPadrao.MsgEdicaoSucesso(MensagensPadrao.Entidade.Exemplar);
                }
                catch (MySqlException ex)
                {
                    MensagensPadrao.MsgFalhaEdicao(MensagensPadrao.Entidade.Exemplar, ex);
                }
            }
            else MensagensPadrao.MsgCamposObrigatorios();
        }
    }
}
