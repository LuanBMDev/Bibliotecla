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
    public partial class frm_Cadastro_Exemplares : Form
    {
        private readonly ExemplarDAO exemplarDAO = new ExemplarDAO();
        public frm_Cadastro_Exemplares()
        {
            InitializeComponent();
            CarregarTitulos();
        }

        private void CarregarTitulos()
        {
            TituloDAO tituloDAO = new TituloDAO();
            List<Titulo> listaTitulos = tituloDAO.Listar("");

            cmb_Titulos.Items.Clear();

            foreach (Titulo titulo in listaTitulos)
            {
                cmb_Titulos.Items.Add(titulo.CodTitulo + " - " + titulo.NomeTitulo);
            }
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
    }
}
