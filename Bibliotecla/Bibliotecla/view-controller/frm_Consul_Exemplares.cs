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
    public partial class frm_Consul_Exemplares : Form
    {

        private readonly ExemplarDAO exemplarDAO = new ExemplarDAO();

        public frm_Consul_Exemplares()
        {
            InitializeComponent();
            cmb_EstExemplar.SelectedIndex = 4;
            popularTabela(listaInicial());
        }

        private void btn_Voltar_Click(object sender, EventArgs e)
        {
            // 1. Cria uma instância do novo formulário.
            frm_Geren_Livros novoFormulario = new frm_Geren_Livros();

            // 2. Exibe o novo formulário.
            novoFormulario.Show();

            // 3. Fecha o formulário atual.
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
            // Atualiza o DataGridView
            //Dgv_Consul_Exemplar.DataSource = null;
            //Dgv_Consul_Exemplar.DataSource = resultados;
            //Dgv_Consul_Exemplar.Refresh();
            foreach (var ex in resultados)
            {
                int rowIndex = Dgv_Consul_Exemplar.Rows.Add();
                var row = Dgv_Consul_Exemplar.Rows[rowIndex];

                // Col_Titulo vem de ex.Titulo.NomeTitulo (Titulo carregado pelo DAO)
                row.Cells["Col_Titulo"].Value = (ex.Titulo != null) ? (ex.Titulo.NomeTitulo ?? string.Empty) : string.Empty;
                row.Cells["Col_Ano_Publicado"].Value = ex.AnoPubli ?? string.Empty;
                row.Cells["Col_Estado_Fisico"].Value = ex.EstadoFisico ?? string.Empty;
                row.Cells["Col_Editora"].Value = ex.EditoraExemplar ?? string.Empty;
                row.Cells["Col_Cod_Exemplar"].Value = ex.CodExemplar;
            }

            // Seleciona primeira linha, se houver
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
                    // escape simples para evitar quebras no SQL gerado (se o DAO usar concatenação)
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
                            // Busca por título: como o título está em outra tabela, mantenha critério por CodTitulo
                            // porém como não sabemos o CodTitulo aqui, deixamos fallback por JOIN na DAO.
                            // Para funcionar com a implementação atual, busca pelos exemplares cujo título contenha texto
                            // (a DAO atual faz SELECT * FROM Exemplar, então esse critério busca por Titulo via CodTitulo - não aplicável)
                            // Melhor comportamento: buscar títulos primeiro (TítuloDAO) e montar critério por CodTitulo.
                            // Implementação simples: buscar títulos correspondentes e montar lista de CodTitulo.
                            List<Titulo> titulosEncontrados = new TituloDAO().Listar($"NomeTitulo LIKE '%{escaped}%'");
                            if (titulosEncontrados == null || titulosEncontrados.Count == 0)
                            {
                                // nenhum título encontrado -> resultado vazio
                                Dgv_Consul_Exemplar.Rows.Clear();
                                MessageBox.Show("Nenhum resultado encontrado.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            // monta critério CodTitulo IN (..)
                            string inList = string.Join(",", titulosEncontrados.Select(t => t.CodTitulo.ToString()).ToArray());
                            parametroParaDAO = $"CodTitulo IN ({inList})";
                            break;
                    }

                    // Instancia DAO e obtém exemplares
                    //ExemplarDAO exemplarDAO = new ExemplarDAO();
                    List<Exemplar> resultados = exemplarDAO.Listar(parametroParaDAO);

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
