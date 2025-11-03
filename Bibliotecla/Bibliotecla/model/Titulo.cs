using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotecla.model
{
    internal class Titulo
    {
        private int codTitulo;
        private string nomeTitulo;
        private string generoTitulo;
        private string autorTitulo;

        public int CodTitulo { get => codTitulo; set => codTitulo = value; }
        public string NomeTitulo { get => nomeTitulo; set => nomeTitulo = value; }
        public string GeneroTitulo { get => generoTitulo; set => generoTitulo = value; }
        public string AutorTitulo { get => autorTitulo; set => autorTitulo = value; }
    }
}
