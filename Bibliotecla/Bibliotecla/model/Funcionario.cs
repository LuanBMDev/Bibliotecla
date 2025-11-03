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

        public Funcionario() { }

        public Funcionario(int codFuncionario,
                           string cpfFuncionario,
                           string nomeFuncionario,
                           Endereco enderecoFuncionario,
                           string emailFuncionario,
                           string telefoneFuncionario,
                           string usuario, 
                           string senha, 
                           string cargo)
        {
            this.codFuncionario = codFuncionario;
            this.Cpf = cpfFuncionario;
            this.Nome = nomeFuncionario;
            this.Endereco = enderecoFuncionario;
            this.Email = emailFuncionario;
            this.Telefone = telefoneFuncionario;
            this.usuario = usuario;
            this.senha = senha;
            this.cargo = cargo;
        }

        public int CodFuncionario { get => codFuncionario; set => codFuncionario = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Senha { get => senha; set => senha = value; }
        public string Cargo { get => cargo; set => cargo = value; }
    }
}
