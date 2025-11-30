using Bibliotecla.DAO;
using Bibliotecla.model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bibliotecla
{
    public partial class frm_Colsul_Titulos : Form
    {
        private readonly TituloDAO tituloDAO = new TituloDAO();

        public frm_Colsul_Titulos()
        {
            InitializeComponent();
            btn_Excluir.Click += btn_Excluir_Click; // associa evento excluir
            btn_Editar.Click += btn_Editar_Click; // evento editar
            try { PopularTabela(tituloDAO.Listar("")); } catch { }
            if (cmb_EstExemplar.Items.Count > 0) cmb_EstExemplar.SelectedIndex = 0;
        }

        public bool verificaCampos()
        {
            if (string.IsNullOrWhiteSpace(txt_Titulo.Text))
            {
                MessageBox.Show("O campo de pesquisa não pode estar vazio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btn_Voltar_Click(object sender, EventArgs e)
        {
            frm_Geren_Livros novoFormulario = new frm_Geren_Livros();
            novoFormulario.Show();
            this.Hide();
        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            if (!verificaCampos()) return;

            string pesquisa = txt_Titulo.Text.Trim().Replace("'", "''");
            string criterio = (cmb_EstExemplar.Text ?? string.Empty).Trim().ToLowerInvariant();
            string where;
            switch (criterio)
            {
                case "nome titulo":
                case "titulo":
                    where = $"NomeTitulo LIKE '%{pesquisa}%'";
                    break;
                case "autor":
                    where = $"Autor LIKE '%{pesquisa}%'";
                    break;
                case "genero":
                    where = $"Genero LIKE '%{pesquisa}%'";
                    break;
                default:
                    where = $"NomeTitulo LIKE '%{pesquisa}%'";
                    break;
            }
            try
            {
                var resultados = tituloDAO.Listar(where);
                PopularTabela(resultados);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao pesquisar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            if (Dgv_Consul_Titulo.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione ao menos um título para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Confirma exclusão dos registros selecionados?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            int sucesso = 0; int falha = 0;
            foreach (DataGridViewRow row in Dgv_Consul_Titulo.SelectedRows)
            {
                if (row.Tag is int cod && cod > 0)
                {
                    try
                    {
                        if (tituloDAO.Remover(new Titulo { CodTitulo = cod })) sucesso++; else falha++;
                    }
                    catch (Exception ex)
                    {
                        falha++;
                        string msg = ex.Message.ToLowerInvariant();
                        if (msg.Contains("foreign key") && msg.Contains("exemplar"))
                        {
                            MessageBox.Show("existem exemplares desse titulo nao é possiveu deleta-lo", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Erro ao excluir título Cod=" + cod + ": " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else falha++;
            }
            MessageBox.Show($"Excluídos: {sucesso}\nFalhas: {falha}", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            try { PopularTabela(tituloDAO.Listar("")); } catch { }
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            if (Dgv_Consul_Titulo.SelectedRows.Count != 1)
            {
                MessageBox.Show("Selecione um único título para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var row = Dgv_Consul_Titulo.SelectedRows[0];
            if (!(row.Tag is int cod) || cod <= 0)
            {
                MessageBox.Show("Registro inválido selecionado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Busca dados completos (caso precise futuro) - aqui já temos nome/autor/genero nas células
            Titulo titulo = new Titulo
            {
                CodTitulo = cod,
                NomeTitulo = Convert.ToString(row.Cells["Col_Titulo_Titulo"].Value),
                AutorTitulo = Convert.ToString(row.Cells["Col_Autor_Titulo"].Value),
                GeneroTitulo = Convert.ToString(row.Cells["Col_Genero_Titulo"].Value)
            };
            frm_Cadastro_Titulos frmCad = new frm_Cadastro_Titulos();
            frmCad.CarregarTitulo(titulo);
            frmCad.Show();
            this.Hide();
        }

        private void PopularTabela(List<Titulo> lista)
        {
            Dgv_Consul_Titulo.Rows.Clear();
            Dgv_Consul_Titulo.DataSource = null;
            if (lista == null || lista.Count == 0)
            {
                MessageBox.Show("Nenhum resultado encontrado.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            foreach (var t in lista)
            {
                int i = Dgv_Consul_Titulo.Rows.Add();
                var r = Dgv_Consul_Titulo.Rows[i];
                r.Tag = t.CodTitulo; // guarda ID para exclusão e edição
                r.Cells["Col_Titulo_Titulo"].Value = t.NomeTitulo ?? string.Empty;
                r.Cells["Col_Autor_Titulo"].Value = t.AutorTitulo ?? string.Empty;
                r.Cells["Col_Genero_Titulo"].Value = t.GeneroTitulo ?? string.Empty;
            }
            if (Dgv_Consul_Titulo.Rows.Count > 0)
                Dgv_Consul_Titulo.CurrentCell = Dgv_Consul_Titulo.Rows[0].Cells[0];
        }

        private void Dgv_Consul_Titulo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
