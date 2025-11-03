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
        private string cpf;
        private string nome;
        private Endereco endereco;
        private string email;
        private string telefone;

        public string Cpf { get => cpf; set => cpf = value; }
        public string Nome { get => nome; set => nome = value; }
        public Endereco Endereco { get => endereco; set => endereco = value; }
        public string Email { get => email; set => email = value; }
        public string Telefone { get => telefone; set => telefone = value; }
    }
}
