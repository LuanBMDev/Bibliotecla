using Bibliotecla.DAO;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Bibliotecla
{
    public partial class frm_Cadastro_Leitores : Form
    {

        private readonly LeitorFuncioDAO leitorFuncioDAO = new LeitorFuncioDAO();

        public frm_Cadastro_Leitores()
        {
            InitializeComponent();
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
            // 1. Cria uma instância do novo formulário.
            frm_Geren_Cadastro novoFormulario = new frm_Geren_Cadastro();

            // 2. Exibe o novo formulário.
            novoFormulario.Show();

            // 3. Fecha o formulário atual.
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

                    //MensagensPadrao.msgCadastroSucesso(MensagensPadrao.Entidade.Leitor);

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
                    //MensagensPadrao.msgFalhaCadastro(MensagensPadrao.Entidade.Leitor, ex);
                    MessageBox.Show("Erro ao cadastrar leitor: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            VerificaCampos();

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
                LeitorFuncio ObjLeitor = new LeitorFuncio(cpf, telefone, cargo, email, nome, cep, rua, numRes, bairro, cidade);
                leitorFuncioDAO.Alterar(ObjLeitor);

                MessageBox.Show("Edição feita com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar leitor: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
