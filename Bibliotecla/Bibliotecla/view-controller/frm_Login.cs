using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bibliotecla.DAO;
using Bibliotecla.geral;
using Bibliotecla.model;
using MySql.Data.MySqlClient;
using Mysqlx;

namespace Bibliotecla
{
    public partial class Form1 : Form, CadastroEdicao
    {
        public Form1()
        {
            InitializeComponent();
            UsuarioLogado.SetUsuario(null);
        }

        public void LimparCampos()
        {
            txt_cadastro.Clear();
            txt_senha.Clear();
        }

        public bool VerificarCampos()
        {
            bool isPreenchido = false;
            if (!string.IsNullOrWhiteSpace(txt_cadastro.Text) ||
                !string.IsNullOrWhiteSpace(txt_senha.Text))
            {
                isPreenchido = true;
            }

            return isPreenchido;
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (VerificarCampos())
            {
                try
                {
                    LeitorFuncioDAO funcioDAO = new LeitorFuncioDAO();

                    List<LeitorFuncio> funcionario = 
                        funcioDAO.ListarFuncionario(
                            "USUARIO = '" + txt_cadastro.Text + "'" +
                            " AND SENHA = '" + txt_senha.Text + "'");

                    if (funcionario.Count > 0)
                    {
                        UsuarioLogado.SetUsuario(funcionario[0]);

                        MessageBox.Show("BEM VINDO(A) - " + UsuarioLogado.GetUsuario().Nome,
                            "Boas Vindas",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Navegacao.TrocarTela(this, new frm_Menu_Principal());
                    }
                    else
                    {
                        MessageBox.Show("Credenciais Inválidas.",
                                    "Erro de Login",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Ocorreu um erro durante a validação dos dados.\n" + ex,
                                    "Erro de Login",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MensagensPadrao.MsgCamposObrigatorios();
            }
        }

        private void chk_MostrarSenha_CheckedChanged(object sender, EventArgs e)
        {
            if (!chk_MostrarSenha.Checked)
            {
                txt_senha.PasswordChar = '●';
            }
            else
            {
                txt_senha.PasswordChar = '\0';
            }
        }
    }
}
