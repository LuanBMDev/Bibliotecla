using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bibliotecla.geral
{
    internal class Navegacao
    {
        public static void TrocarTela(Form frmAtual, Form frmProximo)
        {
            frmProximo.Show();
            frmAtual.Hide();
            frmProximo.FormClosed += (s, args) => frmAtual.Close();
        }
    }
}
