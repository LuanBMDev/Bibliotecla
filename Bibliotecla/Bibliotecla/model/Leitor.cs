using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bibliotecla.geral;

namespace Bibliotecla.model
{
    internal class Leitor : Pessoa
    {
        public Leitor() { }

        public Leitor(string cpfPessoa,
                      string nomeLeitor,
                      Endereco enderecoLeitor,
                      string emailLeitor,
                      string telefoneLeitor)
             : base(cpfPessoa,
                    nomeLeitor,
                    enderecoLeitor,
                    emailLeitor,
                    telefoneLeitor)
        { }
    }
}
