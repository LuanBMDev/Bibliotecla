using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotecla.model
{
    internal class Multa
    {
        private int codMulta;
        private Leitor leitor;
        private double precoMulta;
        private Emprestimo emprestimo;

        

        public Multa(int CodMulta, Leitor leitor, double PrecoMulta, Emprestimo Emprestimo)
        {
            this.codMulta = CodMulta;
            this.leitor = leitor;
            this.precoMulta = PrecoMulta;
            this.emprestimo = Emprestimo;
        }

        public int CodMulta { get => codMulta; set => codMulta = value; }
        public Leitor Leitor { get => leitor; set => leitor = value; }
        public double PrecoMulta { get => precoMulta; set => precoMulta = value; }
        public Emprestimo Emprestimo { get => emprestimo; set => emprestimo = value; }
    }
}
