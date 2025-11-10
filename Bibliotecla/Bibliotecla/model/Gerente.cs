using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bibliotecla.geral;

namespace Bibliotecla.model
{
    internal class Gerente : Bibliotecario
    {
        public Gerente() { }

        public Gerente(int codFuncionario,
                       string cpfFuncionario,
                       string nomeFuncionario,
                       Endereco enderecoFuncionario,
                       string emailFuncionario,
                       string telefoneFuncionario,
                       string usuario,
                       string senha,
                       string cargo)
              : base(codFuncionario,
                     cpfFuncionario,
                     nomeFuncionario,
                     enderecoFuncionario,
                     emailFuncionario,
                     telefoneFuncionario,
                     usuario,
                     senha,
                     cargo)
        { }
    }
}
