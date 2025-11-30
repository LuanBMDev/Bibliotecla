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
using Bibliotecla.model;

namespace Bibliotecla
{
    public partial class frm_Consul_Exemplares : Form
    {
        private readonly ExemplarDAO exemplarDAO = new ExemplarDAO();
        public frm_Consul_Exemplares()
        {
            InitializeComponent();
            cmb_EstExemplar.SelectedIndex = 4;
            // associa eventos dos botões
            btn_Editar.Click += btn_Editar_Click;
            btn_Excluir.Click += btn_Excluir_Click;
            btn_Pesquisar.Click += btn_Pesquisar_Click;
            popularTabela(listaInicial());
        }

        private void btn_Voltar_Click(object sender, EventArgs e)
        {
            frm_Geren_Livros novoFormulario = new frm_Geren_Livros();
            novoFormulario.Show();
            this.Hide();
        }

        public bool verificarCampos()
        {
            if (string.IsNullOrWhiteSpace(txt_Titulo.Text))
            {
                MessageBox.Show("O campo de pesquisa não pode estar vazio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private List<Exemplar> listaInicial()
        {
            try
            {
                List<Exemplar> resultados = exemplarDAO.Listar("");
                return resultados;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar lista inicial: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Exemplar>();
            }
        }

        private void popularTabela(List<Exemplar> resultados)
        {
            Dgv_Consul_Exemplar.Rows.Clear();
            foreach (var ex in resultados)
            {
                int rowIndex = Dgv_Consul_Exemplar.Rows.Add();
                var row = Dgv_Consul_Exemplar.Rows[rowIndex];
                // guardar ID para edição/remoção
                row.Tag = ex.CodExemplar;
                // preencher colunas existentes
                row.Cells["Col_Titulo"].Value = (ex.Titulo != null) ? (ex.Titulo.NomeTitulo ?? string.Empty) : string.Empty;
                row.Cells["Col_Ano_Publicado"].Value = ex.AnoPubli ?? string.Empty;
                row.Cells["Col_Estado_Fisico"].Value = ex.EstadoFisico ?? string.Empty;
                row.Cells["Col_Editora"].Value = ex.EditoraExemplar ?? string.Empty;
                row.Cells["Col_Cod_Exemplar"].Value = ex.CodExemplar;
            }
            if (Dgv_Consul_Exemplar.Rows.Count > 0)
                Dgv_Consul_Exemplar.CurrentCell = Dgv_Consul_Exemplar.Rows[0].Cells[0];
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            if(verificarCampos())
            {
                string pesquisa = txt_Titulo.Text.Trim();
                string criterio = cmb_EstExemplar.Text;
                try
                {
                    string escaped = pesquisa;
                    string parametroParaDAO;
                    switch (criterio)
                    {
                        case "codExemplar":
                            parametroParaDAO = $"CodExemplar = '{escaped}'";
                            break;
                        case "anopubli":
                            parametroParaDAO = $"AnoPubli LIKE '%{escaped}%'";
                            break;
                        case "estadofisc":
                            parametroParaDAO = $"EstadoFisc LIKE '%{escaped}%'";
                            break;
                        case "editora":
                            parametroParaDAO = $"Editora LIKE '%{escaped}%'";

                            break;
                        case "titulo":
                        default:
                            List<Titulo> titulosEncontrados = new TituloDAO().Listar($"NomeTitulo LIKE '%{escaped}%'");
                            if (titulosEncontrados == null || titulosEncontrados.Count == 0)
                            {
                                Dgv_Consul_Exemplar.Rows.Clear();
                                MessageBox.Show("Nenhum resultado encontrado.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            string inList = string.Join(",", titulosEncontrados.Select(t => t.CodTitulo.ToString()).ToArray());
                            parametroParaDAO = $"CodTitulo IN ({inList})";
                            break;
                    }
                    List<Exemplar> resultados = exemplarDAO.Listar(parametroParaDAO);
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
            if (Dgv_Consul_Exemplar.SelectedRows.Count != 1)
            {
                MessageBox.Show("Selecione um único exemplar para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var row = Dgv_Consul_Exemplar.SelectedRows[0];
            if (!(row.Tag is int cod) || cod <= 0)
            {
                MessageBox.Show("Registro inválido selecionado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Busca exemplar completo para obter Titulo
            Exemplar exCompleto = null;
            try
            {
                exCompleto = exemplarDAO.BuscarID(new Exemplar { CodExemplar = cod });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao carregar exemplar para edição: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (exCompleto == null)
            {
                MessageBox.Show("Exemplar não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var frm = new frm_Cadastro_Exemplares();
            frm.CarregarExemplar(exCompleto);
            frm.Show();
            this.Hide();
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            if (Dgv_Consul_Exemplar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione ao menos um exemplar para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Confirma exclusão dos registros selecionados?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            int sucesso = 0; int falha = 0;
            foreach (DataGridViewRow row in Dgv_Consul_Exemplar.SelectedRows)
            {
                if (row.Tag is int cod && cod > 0)
                {
                    try
                    {
                        if (exemplarDAO.Remover(new Exemplar { CodExemplar = cod })) sucesso++; else falha++;
                    }
                    catch (Exception ex)
                    {
                        falha++;
                        MessageBox.Show("Erro ao excluir exemplar Cod=" + cod + ": " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else falha++;
            }
            MessageBox.Show($"Excluídos: {sucesso}\nFalhas: {falha}", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            try { popularTabela(exemplarDAO.Listar("")); } catch { }
        }
    }
}
