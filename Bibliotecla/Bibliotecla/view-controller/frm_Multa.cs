using Bibliotecla.geral;
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
using Bibliotecla.banco;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace Bibliotecla
{
    public partial class frm_Multa : Form
    {
        public frm_Multa()
        {
            InitializeComponent();
            this.Load += frm_Multa_Load;
            // wire events for live search
            this.txt_Pesquisa.TextChanged += Txt_Pesquisa_TextChanged;
            this.cmb_Filtro.SelectedIndexChanged += Cmb_Filtro_SelectedIndexChanged;
        }

        private void frm_Multa_Load(object sender, EventArgs e)
        {
            // popular filtros
            cmb_Filtro.Items.Clear();
            cmb_Filtro.Items.Add("Todos");
            cmb_Filtro.Items.Add("Leitor");
            cmb_Filtro.Items.Add("CodLeitor");
            cmb_Filtro.Items.Add("Exemplar");
            cmb_Filtro.SelectedIndex = 0;

            // carregar automaticamente
            CarregarMultas();
        }

        private void Txt_Pesquisa_TextChanged(object sender, EventArgs e)
        {
            CarregarMultas();
        }

        private void Cmb_Filtro_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarMultas();
        }

        private void btn_Pago_Click(object sender, EventArgs e)
        {

        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            Navegacao.TrocarTela(this, new frm_Menu_Principal());
        }

        private void Dgv_Consul_multa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_Pesquisar_multa_Click(object sender, EventArgs e)
        {
            CarregarMultas();
        }

        private void CarregarMultas()
        {
            try
            {
                Dgv_Consul_multa.Rows.Clear();

                using (MySqlConnection conn = Conexao.Conectar())
                {
                    if (conn.State == ConnectionState.Open)
                        Conexao.Desconectar(conn);

                    var emprestimoDao = new EmprestimoDAO(conn);
                    List<Emprestimo> lista = emprestimoDao.Listar("isAtrasado = 1");

                    if (lista == null || lista.Count == 0)
                        return;

                    string pesquisa = txt_Pesquisa.Text?.Trim();
                    string filtro = cmb_Filtro.Text?.Trim();

                    // Aplicar filtro em memória
                    IEnumerable<Emprestimo> resultados = lista;

                    if (!string.IsNullOrWhiteSpace(pesquisa) && !string.IsNullOrWhiteSpace(filtro) && filtro != "Todos")
                    {
                        switch (filtro)
                        {
                            case "Leitor":
                                resultados = resultados.Where(e => e.Leitor != null && !string.IsNullOrEmpty(e.Leitor.Nome) && e.Leitor.Nome.IndexOf(pesquisa, StringComparison.CurrentCultureIgnoreCase) >= 0);
                                break;
                            case "CodLeitor":
                                if (int.TryParse(pesquisa, out int codL))
                                    resultados = resultados.Where(e => e.Leitor != null && e.Leitor.CodPessoa == codL);
                                else
                                    resultados = Enumerable.Empty<Emprestimo>();
                                break;
                            case "Exemplar":
                                // pesquisar por código do exemplar ou título
                                if (int.TryParse(pesquisa, out int codEx))
                                {
                                    resultados = resultados.Where(e => e.Exemplar != null && e.Exemplar.CodExemplar == codEx);
                                }
                                else
                                {
                                    resultados = resultados.Where(e => e.Exemplar != null && e.Exemplar.Titulo != null && !string.IsNullOrEmpty(e.Exemplar.Titulo.NomeTitulo) && e.Exemplar.Titulo.NomeTitulo.IndexOf(pesquisa, StringComparison.CurrentCultureIgnoreCase) >= 0);
                                }
                                break;
                            default:
                                break;
                        }
                    }

                    foreach (var emprestimo in resultados)
                    {
                        string nomeLeitor = emprestimo.Leitor != null ? emprestimo.Leitor.Nome ?? string.Empty : string.Empty;
                        string codLeitor = emprestimo.Leitor != null ? emprestimo.Leitor.CodPessoa.ToString() : string.Empty;
                        string nomeExemplar = (emprestimo.Exemplar != null && emprestimo.Exemplar.Titulo != null) ? emprestimo.Exemplar.Titulo.NomeTitulo ?? string.Empty : string.Empty;
                        string codExemplar = emprestimo.Exemplar != null ? emprestimo.Exemplar.CodExemplar.ToString() : string.Empty;
                        string dataEmp = emprestimo.DataEmprestimo ?? string.Empty;
                        string prazo = emprestimo.PrazoDevol ?? string.Empty;
                        string dataDevol = emprestimo.DataDevol ?? string.Empty;

                        // Calcular valor da multa: R$1 por dia de atraso
                        decimal valorMulta = 0m;
                        try
                        {
                            if (!string.IsNullOrWhiteSpace(prazo) && prazo != "0")
                            {
                                DateTime dtPrazo;
                                if (DateTime.TryParseExact(prazo, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dtPrazo))
                                {
                                    DateTime dtFim;
                                    if (string.IsNullOrWhiteSpace(dataDevol) || dataDevol == "0")
                                    {
                                        dtFim = DateTime.Today;
                                    }
                                    else if (!DateTime.TryParseExact(dataDevol, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dtFim))
                                    {
                                        dtFim = DateTime.Today;
                                    }

                                    var dias = (dtFim - dtPrazo).TotalDays;
                                    if (dias > 0) valorMulta = (decimal)Math.Floor(dias) * 1m; // R$1 por dia
                                }
                            }
                        }
                        catch
                        {
                            valorMulta = 0m;
                        }

                        string valor = valorMulta.ToString("N2", CultureInfo.GetCultureInfo("pt-BR"));

                        Dgv_Consul_multa.Rows.Add(nomeLeitor, codLeitor, nomeExemplar, codExemplar, dataEmp, prazo, dataDevol, valor);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar multas: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
