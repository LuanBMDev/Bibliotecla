using Bibliotecla.DAO;
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
        public frm_Cadastro_Funcionarios()
        {
            InitializeComponent();
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
                leitorFuncioDAO.Inserir(ObjFuncio);

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

                MessageBox.Show("Cadastro feito com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar funcionário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            VerificaCampos();

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
                leitorFuncioDAO.Alterar(ObjFuncio);

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

                MessageBox.Show("Edição feita com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar funcionário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
