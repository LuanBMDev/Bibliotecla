using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bibliotecla.geral
{
    internal class MensagensPadrao
    {
        public enum Entidade
        {
            Leitor,
            Bibliotecario,
            Gerente,
            Diretora,
            Titulo,
            Exemplar,
            Emprestimo,
            Multa
        }

        public static void MsgCamposObrigatorios()
        {
            MessageBox.Show("Por favor, preencha todos os campos obrigatórios.",
                            "Campos Obrigatórios", 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void MsgCadastroSucesso(Entidade entidade)
        {
            MessageBox.Show(entidade.ToString() + " cadastrado(a) com sucesso!",
                            "Sucesso no Cadastro",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void MsgFalhaCadastro(Entidade entidade, Exception ex)
        {
            MessageBox.Show("Falha durante o cadastro de " + entidade.ToString() + "! \n" +
                            ex.Message,
                            "Falha de Cadastro",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
