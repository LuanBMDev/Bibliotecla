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
    public partial class frm_Consul_Funcionario : Form
    {
        private readonly LeitorFuncioDAO leitorFuncioDAO = new LeitorFuncioDAO();
        public frm_Consul_Funcionario()
        {
            InitializeComponent();
            cmb_Filtro.SelectedIndex = 3;
            popularTabela(listaInicial());
        }

        public bool verificaCampos()
        {
            if (string.IsNullOrWhiteSpace(txt_Leitor.Text))
            {
                MessageBox.Show("O campo de pesquisa não pode estar vazio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void popularTabela(List<LeitorFuncio> resultados)
        {

            Dgv_Consul_Funcionario.Rows.Clear();

            // Atualiza o DataGridView
            Dgv_Consul_Funcionario.DataSource = null;

            if (resultados == null || resultados.Count == 0)
            {
                MessageBox.Show("Nenhum resultado encontrado.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // preenche linhas usando colunas já criadas (mapeamento por nome)
            foreach (var r in resultados)
            {
                int rowIndex = Dgv_Consul_Funcionario.Rows.Add();
                var row = Dgv_Consul_Funcionario.Rows[rowIndex];

                row.Cells["Col_Nome"].Value = r.Nome ?? string.Empty;
                row.Cells["Col_Cpf"].Value = r.CPF ?? string.Empty;
                row.Cells["Col_Email"].Value = r.Email ?? string.Empty;
                row.Cells["Col_Telefone"].Value = r.Telefone ?? string.Empty;
                row.Cells["Col_Cep"].Value = r.CEP ?? string.Empty;
                row.Cells["Col_Rua"].Value = r.Rua ?? string.Empty;
                row.Cells["Col_NumRes"].Value = r.NumRes ?? string.Empty;
                row.Cells["Col_Cidade"].Value = r.Cidade ?? string.Empty;
                row.Cells["Col_Bairro"].Value = r.Bairro ?? string.Empty;
                row.Cells["Col_Usuario"].Value = r.Usuario ?? string.Empty;
                row.Cells["Col_Senha"].Value = r.Senha ?? string.Empty;
            }

            // Ajustes finais opcionais: selecionar primeira linha
            if (Dgv_Consul_Funcionario.Rows.Count > 0)
                Dgv_Consul_Funcionario.CurrentCell = Dgv_Consul_Funcionario.Rows[0].Cells[0];
        }
        private List<LeitorFuncio> listaInicial()
        {
            List<LeitorFuncio> resultados = leitorFuncioDAO.ListarFuncionario("cargo IN ('bibliotecario', 'gerente', 'diretora')");

            return resultados;
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            if (verificaCampos())
            {

                string pesquisa = txt_Leitor.Text.Trim();
                string criterio = cmb_Filtro.Text;

                try
                {
                    // escape simples para evitar quebras no SQL gerado (se o DAO usar concatenação)
                    string escaped = pesquisa;

                    string parametroParaDAO;

                    switch (criterio)
                    {
                        case "cpf":
                            // CPF costuma ser comparação exata
                            parametroParaDAO = $"CPF = '{escaped}'";
                            break;

                        case "telefone":
                            parametroParaDAO = $"Telefone LIKE '%{escaped}%'";
                            break;

                        case "email":
                            parametroParaDAO = $"Email LIKE '%{escaped}%'";
                            break;

                        case "nome":
                            parametroParaDAO = $"Nome LIKE '%{escaped}%'";
                            break;

                        case "cep":
                            parametroParaDAO = $"CEP LIKE '%{escaped}%'";
                            break;

                        case "rua":
                            parametroParaDAO = $"Rua LIKE '%{escaped}%'";
                            break;

                        case "numRes":
                            parametroParaDAO = $"NumRes LIKE '%{escaped}%'";
                            break;

                        case "bairro":
                            parametroParaDAO = $"Bairro LIKE '%{escaped}%'";
                            break;

                        case "cidade":
                            parametroParaDAO = $"Cidade LIKE '%{escaped}%'";
                            break;

                        case "usuario":
                            parametroParaDAO = $"Usuario LIKE '%{escaped}%'";
                            break;

                        case "senha":
                            parametroParaDAO = $"Senha LIKE '%{escaped}%'";
                            break;

                        default:
                            // fallback para nome
                            parametroParaDAO = $"Nome LIKE '%{escaped}%'";
                            break;
                    }

                    parametroParaDAO += " AND cargo IN ('bibliotecario', 'gerente', 'diretora')";

                    // Chama o DAO
                    List<LeitorFuncio> resultados = leitorFuncioDAO.ListarFuncionario(parametroParaDAO);

                    popularTabela(resultados);


                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao pesquisar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
