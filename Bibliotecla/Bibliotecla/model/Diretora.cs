using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bibliotecla.geral;

namespace Bibliotecla.model
{
    internal class Diretora : Gerente
    {
        public Diretora() { }

        public Diretora(int codFuncionario,
                        string usuario,
                        string senha,
                        string cargo,
                        string cpfPessoa,
                        string nomeFuncionario,
                        Endereco enderecoFuncionario,
                        string emailFuncionario,
                        string telefoneFuncionario)
            : base(codFuncionario,
                   cpfPessoa,
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
