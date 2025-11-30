using Bibliotecla.DAO;
using Bibliotecla.geral;
using Bibliotecla.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bibliotecla
{
    public partial class frm_Cadastro_Funcionarios : Form
    {
        private readonly LeitorFuncioDAO leitorFuncioDAO = new LeitorFuncioDAO();
        private LeitorFuncio funcionario = null;

        public frm_Cadastro_Funcionarios()
        {
            InitializeComponent();
            AlternarEstadoEdicao();
        }

        internal void CarregarFuncionario(LeitorFuncio f)
        {
            funcionario = f;
            if (f != null)
            {
                txt_Cpf.Text = f.CPF ?? string.Empty;
                txt_Nome.Text = f.Nome ?? string.Empty;
                txt_Endereco.Text = f.Rua ?? string.Empty;
                txt_Num.Text = f.NumRes ?? string.Empty;
                txt_CEP.Text = f.CEP ?? string.Empty;
                txt_Cidade.Text = f.Cidade ?? string.Empty;
                txt_Bairro.Text = f.Bairro ?? string.Empty;
                txt_Email.Text = f.Email ?? string.Empty;
                txt_Telefone.Text = f.Telefone ?? string.Empty;
                cmb_Cargo.Text = f.Cargo ?? string.Empty;
                txt_Usuario.Text = f.Usuario ?? string.Empty;
                txt_Senha.Text = f.Senha ?? string.Empty;
            }
            AlternarEstadoEdicao();
        }

        private void AlternarEstadoEdicao()
        {
            bool editando = funcionario != null;
            btn_Editar.Enabled = editando;
            btn_Cadastrar.Enabled = !editando;
        }

        public bool VerificaCampos()
        {
            if (txt_Cpf.Text == "" || txt_Nome.Text == "" || txt_Endereco.Text == "" || txt_Num.Text == "" || txt_CEP.Text == "" || txt_Cidade.Text == "" || txt_Bairro.Text == "" || txt_Email.Text == "" || txt_Telefone.Text == "" || cmb_Cargo.Text == "" || txt_Usuario.Text == "" || txt_Senha.Text == "" )
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios.", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btn_Voltar_Click(object sender, EventArgs e)
        {
            funcionario = null;
            Navegacao.TrocarTela(this, new frm_Geren_Cadastro());
        }

        private void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            if (VerificaCampos())
            {
                string cpf = txt_Cpf.Text.Trim();
                string nome = txt_Nome.Text.Trim();
                string rua = txt_Endereco.Text.Trim();
                string numRes = txt_Num.Text.Trim();
                string cep = txt_CEP.Text.Trim();
                string cidade = txt_Cidade.Text.Trim();
                string bairro = txt_Bairro.Text.Trim();
                string email = txt_Email.Text.Trim();
                string telefone = txt_Telefone.Text.Trim();
                string cargo = cmb_Cargo.Text;
                string usuario = txt_Usuario.Text.Trim();
                string senha = txt_Senha.Text.Trim();
                int isDevedor = 0;

                try
                {
                    LeitorFuncio ObjFuncio = new LeitorFuncio(cpf, telefone, email, nome, cargo, usuario, senha, cep, rua, numRes, bairro, cidade, isDevedor);
                    leitorFuncioDAO.Inserir(ObjFuncio);

                    LimparCampos();
                    MessageBox.Show("Cadastro feito com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                    MessageBox.Show("Erro ao cadastrar funcionário: " + msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            if (funcionario == null)
            {
                MessageBox.Show("Nenhum funcionário carregado para edição.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!VerificaCampos()) return;

            string cpf = txt_Cpf.Text.Trim();
            string nome = txt_Nome.Text.Trim();
            string rua = txt_Endereco.Text.Trim();
            string numRes = txt_Num.Text.Trim();
            string cep = txt_CEP.Text.Trim();
            string cidade = txt_Cidade.Text.Trim();
            string bairro = txt_Bairro.Text.Trim();
            string email = txt_Email.Text.Trim();
            string telefone = txt_Telefone.Text.Trim();
            string cargo = cmb_Cargo.Text;
            string usuario = txt_Usuario.Text.Trim();
            string senha = txt_Senha.Text.Trim();

            try
            {
                LeitorFuncio ObjFuncio = new LeitorFuncio(cargo, usuario, senha, cpf, telefone, email, nome, cep, rua, numRes, bairro, cidade);
                ObjFuncio.CodPessoa = funcionario.CodPessoa;
                leitorFuncioDAO.Alterar(ObjFuncio);

                LimparCampos();
                funcionario = null;
                AlternarEstadoEdicao();
                MessageBox.Show("Edição feita com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show("Erro ao editar funcionário: " + msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            txt_Cpf.Clear();
            txt_Nome.Clear();
            txt_Endereco.Clear();
            txt_Num.Clear();
            txt_CEP.Clear();
            txt_Cidade.Clear();
            txt_Bairro.Clear();
            txt_Email.Clear();
            txt_Telefone.Clear();
            cmb_Cargo.SelectedIndex = -1;
            txt_Usuario.Clear();
            txt_Senha.Clear();
        }
    }
}
