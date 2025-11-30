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

namespace Bibliotecla
{
    public partial class frm_EmprEDev : Form
    {
        public frm_EmprEDev()
        {
            InitializeComponent();
            btn_Emprestimo.Click += btn_Emprestimo_Click; // associa handler
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
                    DataDevol = string.Empty,
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
    }
}
