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

namespace Bibliotecla
{
    public partial class frm_Cadastro_Leitores : Form
    {
        public frm_Cadastro_Leitores()
        {
            InitializeComponent();
        }

        public bool VerificaCampos()
        {
            if (txt_Nome.Text == "" || txt_Cpf.Text == "" || txt_Telefone.Text == "" || txt_Email.Text == "" || txt_Endereco.Text == "")
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
            VerificaCampos();

            string cpf = txt_Cpf.Text.Trim;
            string nome = txt_Nome.Text.Trim;
            string endereco = txt_Endereco.Text.Trim;
            string email = txt_Email.Text.Trim;
            string telefone = txt_Telefone.Text.Trim;
            string cargo = "Leitor";
            string usuario = "";
            string senha = "";
            string cep = "";
            string rua = "";
            string numRes = "";
            string cidade = "";
            string bairro = "";
            int isDevedor = 0;

            try
            {
                LeitorFuncio ObjLeitor = new LeitorFuncio(cpf, telefone, nome, cargo, usuario, senha, cep, endereco, email);
                LeitorFuncioDAO.Inserir(ObjLeitor);

                MensagensPadrao.msgCadastroSucesso(MensagensPadrao.Entidade.Leitor);

                txt_Cpf.Clear();
                txt_Nome.Clear();   
                txt_Endereco.Clear();
                txt_Email.Clear();
                txt_Telefone.Clear();
            }
            catch (Exception ex)
            {
                MensagensPadrao.msgFalhaCadastro(MensagensPadrao.Entidade.Leitor, ex);
            }

        }
    }
}
