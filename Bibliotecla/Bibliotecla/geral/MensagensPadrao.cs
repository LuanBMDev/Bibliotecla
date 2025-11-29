using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bibliotecla.geral
{
    internal class MensagensPadrao
    {
        public static void MsgCamposObrigatorios()
        {
            MessageBox.Show("Por favor, preencha todos os campos obrigatórios.",
                            "Campos Obrigatórios", 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
