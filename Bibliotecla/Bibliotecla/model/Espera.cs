using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotecla.model
{
    internal class Espera
    {
        private int codEspera;
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
    }
}
