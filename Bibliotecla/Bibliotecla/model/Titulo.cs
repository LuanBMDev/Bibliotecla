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

        public Titulo() { }

        public Titulo(string nomeTitulo,
                      string generoTitulo,
                      string autorTitulo)
        {
            this.nomeTitulo = nomeTitulo;
            this.generoTitulo = generoTitulo;
            this.autorTitulo = autorTitulo;
        }

        public Titulo(int codTitulo,
                      string nomeTitulo,
                      string generoTitulo,
                      string autorTitulo)
        {
            this.codTitulo = codTitulo;
            this.nomeTitulo = nomeTitulo;
            this.generoTitulo = generoTitulo;
            this.autorTitulo = autorTitulo;
        }

        public int CodTitulo { get => codTitulo; set => codTitulo = value; }
        public string NomeTitulo { get => nomeTitulo; set => nomeTitulo = value; }
        public string GeneroTitulo { get => generoTitulo; set => generoTitulo = value; }
        public string AutorTitulo { get => autorTitulo; set => autorTitulo = value; }
    }
}