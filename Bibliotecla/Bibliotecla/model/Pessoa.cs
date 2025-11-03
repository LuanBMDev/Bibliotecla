using Bibliotecla.geral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotecla.model
{
    internal class Pessoa
    {
        private string cpfPessoa;
        private string nomePessoa;
        private Endereco enderecoPessoa;
        private string emailPessoa;
        private string telefonePessoa;

        public string Cpf { get => cpfPessoa; set => cpfPessoa = value; }
        public string Nome { get => nomePessoa; set => nomePessoa = value; }
        public Endereco Endereco { get => enderecoPessoa; set => enderecoPessoa = value; }
        public string Email { get => emailPessoa; set => emailPessoa = value; }
        public string Telefone { get => telefonePessoa; set => telefonePessoa = value; }
    }
}
