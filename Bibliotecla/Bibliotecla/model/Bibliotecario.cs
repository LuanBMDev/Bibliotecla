using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bibliotecla.geral;

namespace Bibliotecla.model
{
    internal class Bibliotecario : Funcionario
    {
        public Bibliotecario() { }

        public Bibliotecario(int codFuncionario,
                             string cpfFuncionario,
                             string nomeFuncionario,
                             Endereco enderecoFuncionario,
                             string emailFuncionario,
                             string telefoneFuncionario,
                             string usuario,
                             string senha,
                             string cargo)
              : base(codFuncionario,
                     usuario,
                     senha,
                     cargo,
                     cpfFuncionario,
                     nomeFuncionario,
                     enderecoFuncionario,
                     emailFuncionario,
                     telefoneFuncionario)
        { }
    }
}
