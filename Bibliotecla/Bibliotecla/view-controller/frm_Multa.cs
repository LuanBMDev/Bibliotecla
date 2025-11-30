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

namespace Bibliotecla
{
    public partial class frm_Multa : Form
    {
        public frm_Multa()
        {
            InitializeComponent();
        }

        private void btn_Pago_Click(object sender, EventArgs e)
        {

        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            Navegacao.TrocarTela(this, new frm_Menu_Principal());
        }
    }
}
