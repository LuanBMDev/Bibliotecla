using Bibliotecla.DAO;
using Bibliotecla.model;
using System;
using System.Windows.Forms;

namespace Bibliotecla
{
    public partial class frm_Cadastro_Leitores : Form
    {
        private readonly LeitorFuncioDAO leitorFuncioDAO = new LeitorFuncioDAO();
        private LeitorFuncio leitor = null;

        public frm_Cadastro_Leitores()
        {
            InitializeComponent();
            AlternarEstadoEdicao();
        }

        internal void CarregarLeitor(LeitorFuncio l)
        {
            leitor = l;
            if (l != null)
            {
                txt_Cpf.Text = l.CPF ?? string.Empty;
                txt_Nome.Text = l.Nome ?? string.Empty;
                txt_Email.Text = l.Email ?? string.Empty;
                txt_Telefone.Text = l.Telefone ?? string.Empty;
                txt_CEP.Text = l.CEP ?? string.Empty;
                txt_Endereco.Text = l.Rua ?? string.Empty;
                txt_Num.Text = l.NumRes ?? string.Empty;
                txt_Cidade.Text = l.Cidade ?? string.Empty;
                txt_Bairro.Text = l.Bairro ?? string.Empty;
            }
            AlternarEstadoEdicao();
        }

        private void AlternarEstadoEdicao()
        {
            bool editando = leitor != null;
            btn_Editar.Enabled = editando;
            btn_Cadastrar.Enabled = !editando;
        }

        public bool VerificaCampos()
        {
            if (txt_Nome.Text == "" || txt_Cpf.Text == "" || txt_Telefone.Text == "" || txt_Email.Text == "" || txt_Endereco.Text == "" || txt_CEP.Text == "" || txt_Num.Text == "" || txt_Cidade.Text == "" || txt_Bairro.Text == "" )
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios.", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btn_Voltar_Click(object sender, EventArgs e)
        {
            leitor = null;
            frm_Geren_Cadastro novoFormulario = new frm_Geren_Cadastro();
            novoFormulario.Show();
            this.Hide();
        }

        private void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            if (VerificaCampos()) { 
                string cpf = txt_Cpf.Text.Trim();
                string nome = txt_Nome.Text.Trim();
                string email = txt_Email.Text.Trim();
                string telefone = txt_Telefone.Text.Trim();
                string cep = txt_CEP.Text.Trim();
                string rua = txt_Endereco.Text.Trim();
                string numRes = txt_Num.Text.Trim();
                string cidade = txt_Cidade.Text.Trim();
                string bairro = txt_Bairro.Text.Trim();
                string cargo = "leitor";
                string usuario = "";
                string senha = "";

                try
                {
                    LeitorFuncio ObjLeitor = new LeitorFuncio(cargo, usuario, senha, cpf, telefone, email, nome, cep, rua, numRes, bairro, cidade);
                    leitorFuncioDAO.Inserir(ObjLeitor);

                    txt_Cpf.Clear();
                    txt_Nome.Clear();
                    txt_Endereco.Clear();
                    txt_Email.Clear();
                    txt_Telefone.Clear();
                    txt_CEP.Clear();
                    txt_Num.Clear();
                    txt_Cidade.Clear();
                    txt_Bairro.Clear();

                    MessageBox.Show("Cadastro feito com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                    MessageBox.Show("Erro ao cadastrar leitor: " + msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            if (leitor == null)
            {
                MessageBox.Show("Nenhum leitor carregado para edição.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!VerificaCampos()) return;

            string cpf = txt_Cpf.Text.Trim();
            string nome = txt_Nome.Text.Trim();
            string email = txt_Email.Text.Trim();
            string telefone = txt_Telefone.Text.Trim();
            string cep = txt_CEP.Text.Trim();
            string rua = txt_Endereco.Text.Trim();
            string numRes = txt_Num.Text.Trim();
            string cidade = txt_Cidade.Text.Trim();
            string bairro = txt_Bairro.Text.Trim();
            string cargo = "leitor";

            try
            {
                LeitorFuncio obj = new LeitorFuncio(cpf, telefone, cargo, email, nome, cep, rua, numRes, bairro, cidade);
                obj.CodPessoa = leitor.CodPessoa; // manter ID
                leitorFuncioDAO.Alterar(obj);
                MessageBox.Show("Edição feita com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
                leitor = null;
                AlternarEstadoEdicao();
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show("Erro ao editar leitor: " + msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            txt_Cpf.Clear();
            txt_Nome.Clear();
            txt_Endereco.Clear();
            txt_Email.Clear();
            txt_Telefone.Clear();
            txt_CEP.Clear();
            txt_Num.Clear();
            txt_Cidade.Clear();
            txt_Bairro.Clear();
        }
    }
}
