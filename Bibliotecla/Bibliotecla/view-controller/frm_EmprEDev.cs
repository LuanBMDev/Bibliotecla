using Bibliotecla.geral;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
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
    public partial class frm_EmprEDev : Form
    {
        public frm_EmprEDev()
        {
            InitializeComponent();
            btn_Emprestimo.Click += btn_Emprestimo_Click; // associa handler
            // Desabilitar botão Multa nesta tela
            btn_Multa.Enabled = false;
        }

        private void btn_Voltar_Click(object sender, EventArgs e)
        {
            // 1. Cria uma instância do novo formulário.
            Navegacao.TrocarTela(this, new frm_Menu_Principal());
        }

        private void btn_Cadas_Leitor_Click(object sender, EventArgs e)
        {
            // 1. Cria uma instância do novo formulário.
            Navegacao.TrocarTela(this, new frm_Cadastro_Leitores());
        }

        private void btn_Multa_Click(object sender, EventArgs e)
        {
            // 1. Cria uma instância do novo formulário.
            Navegacao.TrocarTela(this, new frm_Multa());
        }

        private void cmb_Titulo_Emp_SelectedIndexChanged(object sender, EventArgs e)
        {
            // não utilizado; deixado para compatibilidade
        }

        private void frm_EmprEDev_Load(object sender, EventArgs e)
        {
            PopularLeitoresEmp();
            PopularTitulos();
            PopularLeitoresDevolucao();
            PopularExemplaresDevolucao();
            this.comboBox_titulo_livro.SelectedIndexChanged += ComboBox_titulo_livro_SelectedIndexChanged;
            // Define o prazo para 6 dias a partir de hoje
            txt_Prazo.Text = DateTime.Today.AddDays(6).ToString("dd/MM/yyyy");
        }

        private void ComboBox_titulo_livro_SelectedIndexChanged(object sender, EventArgs e)
        {
            int? codTitulo = ObterCodTituloSelecionado();
            if (codTitulo.HasValue)
            {
                PopularExemplaresParaTitulo(codTitulo.Value);
            }
            else
            {
                cmb_Exem_Emp.Items.Clear();
            }
        }

        private int? ObterCodTituloSelecionado()
        {
            if (string.IsNullOrWhiteSpace(comboBox_titulo_livro.Text)) return null;
            // Espera formato: "<id> - <nome>"
            var texto = comboBox_titulo_livro.Text.Trim();
            int sep = texto.IndexOf('-');
            string idStr = sep > 0 ? texto.Substring(0, sep).Trim() : texto;
            int id;
            if (int.TryParse(idStr, out id)) return id;
            return null;
        }

        private void PopularExemplaresParaTitulo(int codTitulo)
        {
            try
            {
                var dao = new ExemplarDAO();
                var exemplares = dao.Listar($"CodTitulo = {codTitulo}");
                cmb_Exem_Emp.Items.Clear();
                if (exemplares != null)
                {
                    foreach (var ex in exemplares)
                    {
                        // apenas o ID do exemplar, conforme solicitado
                        cmb_Exem_Emp.Items.Add(ex.CodExemplar.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao carregar exemplares do título: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopularLeitoresEmp()
        {
            try
            {
                var dao = new LeitorFuncioDAO();
                // apenas leitores
                List<LeitorFuncio> leitores = dao.Listar("cargo = 'leitor'");
                combo_leitor_emp.Items.Clear();
                foreach (var l in leitores)
                {
                    combo_leitor_emp.Items.Add(string.Format("{0} - {1}", l.CodPessoa, l.Nome ?? string.Empty));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao carregar leitores: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Popula combo de leitores para devolução apenas com leitores que aparecem na tabela Emprestimo
        private void PopularLeitoresDevolucao()
        {
            try
            {
                // usa EmprestimoDAO.Listar para obter empréstimos e extrair leitores distintos
                using (MySqlConnection conn = Conexao.Conectar())
                {
                    // EmprestimoDAO espera abrir a conexão internamente; fechamos se estiver aberta
                    if (conn.State == ConnectionState.Open)
                        Conexao.Desconectar(conn);

                    var emprestimoDao = new EmprestimoDAO(conn);
                    var emprestimos = emprestimoDao.Listar("");

                    combo_leitor_devl.Items.Clear();
                    if (emprestimos != null)
                    {
                        var leitores = emprestimos
                            .Where(e => e.Leitor != null)
                            .Select(e => e.Leitor)
                            .GroupBy(l => l.CodPessoa)
                            .Select(g => g.First())
                            .OrderBy(l => l.Nome);

                        foreach (var l in leitores)
                        {
                            combo_leitor_devl.Items.Add(string.Format("{0} - {1}", l.CodPessoa, l.Nome ?? string.Empty));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao carregar leitores para devolução: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Popula combo de exemplares para devolução apenas com exemplares que aparecem na tabela Emprestimo
        private void PopularExemplaresDevolucao()
        {
            try
            {
                using (MySqlConnection conn = Conexao.Conectar())
                {
                    if (conn.State == ConnectionState.Open)
                        Conexao.Desconectar(conn);

                    var emprestimoDao = new EmprestimoDAO(conn);
                    var emprestimos = emprestimoDao.Listar("");

                    cmb_EstExem_Dev.Items.Clear();
                    if (emprestimos != null)
                    {
                        var exemplares = emprestimos
                            .Where(e => e.Exemplar != null)
                            .Select(e => e.Exemplar)
                            .GroupBy(x => x.CodExemplar)
                            .Select(g => g.First())
                            .OrderBy(x => x.CodExemplar);

                        foreach (var ex in exemplares)
                        {
                            // exibir id e, se possível, o título
                            string titulo = ex.Titulo != null ? ex.Titulo.NomeTitulo : null;
                            if (!string.IsNullOrEmpty(titulo))
                                cmb_EstExem_Dev.Items.Add(string.Format("{0} - {1}", ex.CodExemplar, titulo));
                            else
                                cmb_EstExem_Dev.Items.Add(ex.CodExemplar.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao carregar exemplares para devolução: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopularTitulos()
        {
            try
            {
                var dao = new TituloDAO();
                var titulos = dao.Listar("");
                comboBox_titulo_livro.Items.Clear();
                foreach (var t in titulos)
                {
                    comboBox_titulo_livro.Items.Add(string.Format("{0} - {1}", t.CodTitulo, t.NomeTitulo ?? string.Empty));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao carregar títulos: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Emprestimo_Click(object sender, EventArgs e)
        {
            // Validar seleção
            if (string.IsNullOrWhiteSpace(combo_leitor_emp.Text) || string.IsNullOrWhiteSpace(cmb_Exem_Emp.Text) || string.IsNullOrWhiteSpace(txt_Prazo.Text))
            {
                MessageBox.Show("Selecione leitor, exemplar e prazo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int codLeitor;
            // formato "id - nome"
            var leitorTexto = combo_leitor_emp.Text.Trim();
            int sep = leitorTexto.IndexOf('-');
            string leitorIdStr = sep > 0 ? leitorTexto.Substring(0, sep).Trim() : leitorTexto;
            if (!int.TryParse(leitorIdStr, out codLeitor))
            {
                MessageBox.Show("Leitor inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int codExemplar;
            if (!int.TryParse(cmb_Exem_Emp.Text.Trim(), out codExemplar))
            {
                MessageBox.Show("Exemplar inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Datas
            string dataEmprestimo = DateTime.Today.ToString("yyyy-MM-dd");
            string prazoDevol;
            DateTime prazoDt;
            if (!DateTime.TryParseExact(txt_Prazo.Text.Trim(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out prazoDt))
            {
                MessageBox.Show("Prazo em formato inválido (use dd/MM/yyyy).", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            prazoDevol = prazoDt.ToString("yyyy-MM-dd");

            try
            {
                // Carregar objetos necessários
                var exDAO = new ExemplarDAO();
                var exemplar = exDAO.BuscarID(new Exemplar(null) { CodExemplar = codExemplar });
                var leitorDAO = new LeitorFuncioDAO();
                var leitor = leitorDAO.BuscarID(new LeitorFuncio { CodPessoa = codLeitor });
                if (exemplar == null || leitor == null)
                {
                    MessageBox.Show("Falha ao localizar exemplar ou leitor.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Montar empréstimo
                var emp = new Emprestimo(exemplar, leitor)
                {
                    DataEmprestimo = dataEmprestimo,
                    PrazoDevol = prazoDevol,
                    DataDevol = "0",
                    IsAtrasado = 0
                };
                using (MySqlConnection conn = Conexao.Conectar())
                {
                    // Se a conexão vier aberta (Conexao.Conectar abre), fechamos aqui para que o DAO possa abrir quando precisar.
                    if (conn.State == ConnectionState.Open)
                    {
                        Conexao.Desconectar(conn);
                    }

                    var empDAO = new EmprestimoDAO(conn);
                    bool ok = empDAO.Inserir(emp);
                    if (ok)
                    {
                        MessageBox.Show("Empréstimo registrado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // atualizar combos de devolução
                        PopularLeitoresDevolucao();
                        PopularExemplaresDevolucao();
                    }
                    else
                    {
                        MessageBox.Show("Falha ao registrar empréstimo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao registrar empréstimo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Devolucao_Click(object sender, EventArgs e)
        {
            // Validar seleção
            if (string.IsNullOrWhiteSpace(combo_leitor_devl.Text) || string.IsNullOrWhiteSpace(cmb_EstExem_Dev.Text))
            {
                MessageBox.Show("Selecione leitor e exemplar para devolução.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // extrair ids
            int codLeitor;
            var leitorTexto = combo_leitor_devl.Text.Trim();
            int sep = leitorTexto.IndexOf('-');
            string leitorIdStr = sep > 0 ? leitorTexto.Substring(0, sep).Trim() : leitorTexto;
            if (!int.TryParse(leitorIdStr, out codLeitor))
            {
                MessageBox.Show("Leitor inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int codExemplar;
            var exTexto = cmb_EstExem_Dev.Text.Trim();
            sep = exTexto.IndexOf('-');
            string exIdStr = sep > 0 ? exTexto.Substring(0, sep).Trim() : exTexto;
            if (!int.TryParse(exIdStr, out codExemplar))
            {
                MessageBox.Show("Exemplar inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (MySqlConnection conn = Conexao.Conectar())
                {
                    if (conn.State == ConnectionState.Open)
                        Conexao.Desconectar(conn);

                    var emprestimoDao = new EmprestimoDAO(conn);
                    // procura empréstimos em aberto (DataDevol = '0') para o leitor e exemplar selecionados
                    var lista = emprestimoDao.Listar($"CodExemplar = {codExemplar} AND CodLeitor = {codLeitor} AND DataDevol = '0'");

                    if (lista == null || lista.Count == 0)
                    {
                        MessageBox.Show("Nenhum empréstimo em aberto encontrado para o leitor/exemplar selecionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // escolher o empréstimo mais recente (maior id) - sem lambda
                    Emprestimo emprestimo = null;
                    int maxCod = int.MinValue;
                    foreach (var item in lista)
                    {
                        if (item != null && item.CodEmprestimo > maxCod)
                        {
                            maxCod = item.CodEmprestimo;
                            emprestimo = item;
                        }
                    }

                    if (emprestimo == null)
                    {
                        MessageBox.Show("Nenhum empréstimo válido encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // definir DataDevol como data atual e verificar atraso
                    string dataDevolAtual = DateTime.Today.ToString("yyyy-MM-dd");
                    emprestimo.DataDevol = dataDevolAtual;

                    int isAtrasado = 0;
                    DateTime prazo;
                    if (!string.IsNullOrWhiteSpace(emprestimo.PrazoDevol) && DateTime.TryParseExact(emprestimo.PrazoDevol, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out prazo))
                    {
                        if (DateTime.Today > prazo) isAtrasado = 1;
                    }
                    emprestimo.IsAtrasado = isAtrasado;

                    bool ok = emprestimoDao.Alterar(emprestimo);
                    if (ok)
                    {
                        MessageBox.Show("Devolução registrada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        PopularLeitoresDevolucao();
                        PopularExemplaresDevolucao();
                    }
                    else
                    {
                        MessageBox.Show("Falha ao registrar devolução.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                // Mostrar stacktrace completo para diagnosticar o erro
                MessageBox.Show("Erro ao registrar devolução: " + ex.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
