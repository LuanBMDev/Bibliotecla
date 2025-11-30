using Bibliotecla.DAO;
using Bibliotecla.geral;
using Bibliotecla.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Bibliotecla
{
    public partial class frm_Consulta_Leitor : Form
    {
        private readonly LeitorFuncioDAO leitorFuncioDAO = new LeitorFuncioDAO();
        public frm_Consulta_Leitor()
        {
            InitializeComponent();
            cmb_Filtro.SelectedIndex = 3;
            btn_Editar.Click += btn_Editar_Click;
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
            Navegacao.TrocarTela(this, new frm_Geren_Cadastro());
        }

        private void popularTabela(List<LeitorFuncio> resultados)
        {

            Dgv_Consul_Leitor.Rows.Clear();

            // Atualiza o DataGridView
            Dgv_Consul_Leitor.DataSource = null;

            if (resultados == null || resultados.Count == 0)
            {
                //MessageBox.Show("Nenhum resultado encontrado.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // preenche linhas usando colunas já criadas (mapeamento por nome)
            foreach (var r in resultados)
            {
                int rowIndex = Dgv_Consul_Leitor.Rows.Add();
                var row = Dgv_Consul_Leitor.Rows[rowIndex];

                row.Tag = r.CodPessoa;
                row.Cells["Col_Nome"].Value = r.Nome ?? string.Empty;
                row.Cells["Col_Cpf"].Value = r.CPF ?? string.Empty;
                row.Cells["Col_Email"].Value = r.Email ?? string.Empty;
                row.Cells["Col_Telefone"].Value = r.Telefone ?? string.Empty;
                row.Cells["Col_Cep"].Value = r.CEP ?? string.Empty;
                row.Cells["Col_Rua"].Value = r.Rua ?? string.Empty;
                row.Cells["Col_NumRes"].Value = r.NumRes ?? string.Empty;
                row.Cells["Col_Cidade"].Value = r.Cidade ?? string.Empty;
                row.Cells["Col_Bairro"].Value = r.Bairro ?? string.Empty;
                row.Cells["Col_Devendo"].Value = r.IsDevedor == 1 ? "Sim" : "Não";
            }

            // Ajustes finais opcionais: selecionar primeira linha
            if (Dgv_Consul_Leitor.Rows.Count > 0)
                Dgv_Consul_Leitor.CurrentCell = Dgv_Consul_Leitor.Rows[0].Cells[0];
        }

        private List<LeitorFuncio> listaInicial()
        {
            List<LeitorFuncio> resultados = leitorFuncioDAO.Listar("Cargo IN ('Leitor')");

            return resultados;
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            if (verificaCampos()) {
                
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

                        case "devedor":
                            // espera 1/0 ou "sim"/"nao" do usuário; qualquer coisa que não seja positivo vira 0
                            var low = pesquisa.ToLowerInvariant();
                            bool positivo = low == "sim" || low == "s" || low == "true" || low == "yes" || low == "y";
                            parametroParaDAO = $"IsDevedor = {(positivo ? 1 : 0)}";
                            break;

                        default:
                            // fallback para nome
                            parametroParaDAO = $"Nome LIKE '%{escaped}%'";
                            break;
                    }
                    parametroParaDAO += " AND Cargo IN ('Leitor')";

                    // Chama o DAO

                    List<LeitorFuncio> resultados = leitorFuncioDAO.Listar(parametroParaDAO);

                    popularTabela(resultados);
                

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao pesquisar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            if (Dgv_Consul_Leitor.SelectedRows.Count != 1)
            {
                MessageBox.Show("Selecione um único leitor para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var row = Dgv_Consul_Leitor.SelectedRows[0];
            if (!(row.Tag is int cod) || cod <= 0)
            {
                MessageBox.Show("Registro inválido selecionado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LeitorFuncio leitor = new LeitorFuncio
            {
                CodPessoa = cod,
                Nome = Convert.ToString(row.Cells["Col_Nome"].Value),
                CPF = Convert.ToString(row.Cells["Col_Cpf"].Value),
                Email = Convert.ToString(row.Cells["Col_Email"].Value),
                Telefone = Convert.ToString(row.Cells["Col_Telefone"].Value),
                CEP = Convert.ToString(row.Cells["Col_Cep"].Value),
                Rua = Convert.ToString(row.Cells["Col_Rua"].Value),
                NumRes = Convert.ToString(row.Cells["Col_NumRes"].Value),
                Cidade = Convert.ToString(row.Cells["Col_Cidade"].Value),
                Bairro = Convert.ToString(row.Cells["Col_Bairro"].Value)
            };
            var frm = new frm_Cadastro_Leitores();
            frm.CarregarLeitor(leitor);
            frm.Show();
            this.Hide();
        }

        private void Dgv_Consul_Leitor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
