using Bibliotecla.geral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotecla.model
{
    internal class Funcionario : Pessoa
    {
        private int codFuncionario;
        private string usuario;
        private string senha;
        private string cargo;

        public int CodFuncionario { get => codFuncionario; set => codFuncionario = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Senha { get => senha; set => senha = value; }
        public string Cargo { get => cargo; set => cargo = value; }
    }
}
