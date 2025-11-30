using System;
<<<<<<< Updated upstream
=======
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
>>>>>>> Stashed changes

namespace Bibliotecla.model
{
    internal class Espera
    {
        private int codEspera;
<<<<<<< Updated upstream
        private string dataEspera;
        private string dataLimite;
        private string dataDevol;
        private LeitorFuncio pessoa;
        private Emprestimo emprestimo;
        private Exemplar exemplar;

        public Espera()
        {
        }

        public Espera(LeitorFuncio pessoa, Emprestimo emprestimo, Exemplar exemplar)
        {
            this.pessoa = pessoa;
            this.emprestimo = emprestimo;
            this.exemplar = exemplar;
        }

        public Espera(int codEspera,
                       string dataEspera,
                       string dataLimite,
                       string dataDevol,
                       LeitorFuncio pessoa,
                       Emprestimo emprestimo,
                       Exemplar exemplar)
        {
            this.codEspera = codEspera;
            this.dataEspera = dataEspera;
            this.dataLimite = dataLimite;
            this.dataDevol = dataDevol;
            this.pessoa = pessoa;
            this.emprestimo = emprestimo;
            this.exemplar = exemplar;
        }

        public int CodEspera { get => codEspera; set => codEspera = value; }
        public string DataEspera { get => dataEspera; set => dataEspera = value; }
        public string DataLimite { get => dataLimite; set => dataLimite = value; }
        public string DataDevol { get => dataDevol; set => dataDevol = value; }
        public LeitorFuncio Pessoa { get => pessoa; set => pessoa = value; }
        public Emprestimo Emprestimo { get => emprestimo; set => emprestimo = value; }
        public Exemplar Exemplar { get => exemplar; set => exemplar = value; }
=======
        private LeitorFuncio leitor;
        private Titulo titulo;
        private string dataSolicitacao;

        public Espera() { }

        public Espera(LeitorFuncio leitor, Titulo titulo, string dataSolicitacao)
        {
            this.leitor = leitor;
            this.titulo = titulo;
            this.dataSolicitacao = dataSolicitacao;
        }

        public Espera(int codEspera, LeitorFuncio leitor, Titulo titulo, string dataSolicitacao)
        {
            this.codEspera = codEspera;
            this.leitor = leitor;
            this.titulo = titulo;
            this.dataSolicitacao = dataSolicitacao;
        }

        public int CodEspera { get => codEspera; set => codEspera = value; }
        public LeitorFuncio Leitor { get => leitor; set => leitor = value; }
        public Titulo Titulo { get => titulo; set => titulo = value; }
        public string DataSolicitacao { get => dataSolicitacao; set => dataSolicitacao = value; }
>>>>>>> Stashed changes
    }
}
