using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotecla.model
{
    internal class Emprestimo
    {
        private int codEmprestimo;
        private Exemplar exemplar;
        private Leitor leitor;
        private string dataEmprestimo;
        private string dataDevol;
        private string prazoDevol;
        private int isAtrasado;

        public Emprestimo(Exemplar exemplar, Leitor leitor)
        {
            this.exemplar = exemplar;
            this.leitor = leitor;
        }

        public Emprestimo(int codEmprestimo,
                          Exemplar exemplar,
                          Leitor leitor,
                          string dataEmprestimo,
                          string dataDevol,
                          string prazoDevol,
                          int isAtrasado)
        {
            this.codEmprestimo = codEmprestimo;
            this.exemplar = exemplar;
            this.leitor = leitor;
            this.dataEmprestimo = dataEmprestimo;
            this.dataDevol = dataDevol;
            this.prazoDevol = prazoDevol;
            this.isAtrasado = isAtrasado;
        }

        public int CodEmprestimo { get => codEmprestimo; set => codEmprestimo = value; }
        public Exemplar Exemplar { get => exemplar; set => exemplar = value; }
        public Leitor Leitor { get => leitor; set => leitor = value; }
        public string DataEmprestimo { get => dataEmprestimo; set => dataEmprestimo = value; }
        public string DataDevol { get => dataDevol; set => dataDevol = value; }
        public string PrazoDevol { get => prazoDevol; set => prazoDevol = value; }
        public int IsAtrasado { get => isAtrasado; set => isAtrasado = value; }
    }
}
