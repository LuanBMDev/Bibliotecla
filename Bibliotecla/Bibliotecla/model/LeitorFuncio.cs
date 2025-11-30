using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotecla.model
{
    internal class LeitorFuncio
    {
        private int codPessoa;
        private string cpf;
        private string telefone;
        private string email;
        private string nome;
        private string cargo;
        private string usuario;
        private string senha;
        private string cep;
        private string rua;
        private string numRes;
        private string bairro;
        private string cidade;
        private int isDevedor;

        public LeitorFuncio()
        {
            
        }

        public LeitorFuncio(int codPessoa, string cpf, string telefone, 
                            string email, string nome, string cargo,
                            string usuario, string senha, string cep, 
                            string rua, string numRes, string bairro, string cidade,
                            int isDevedor)
        {
            this.codPessoa = codPessoa;
            this.cpf = cpf;
            this.telefone = telefone;
            this.email = email;
            this.nome = nome;
            this.cargo = cargo;
            this.usuario = usuario;
            this.senha = senha;
            this.cep = cep;
            this.rua = rua;
            this.numRes = numRes;
            this.bairro = bairro;
            this.cidade = cidade;
            this.isDevedor = isDevedor;
        }

        public LeitorFuncio(string cpf, string telefone, string cargo,
                            string email, string nome, string cep,
                            string rua, string numRes, string bairro, string cidade)
        {
            this.cpf = cpf;
            this.telefone = telefone;
            this.email = email;
            this.nome = nome;
            this.cep = cep;
            this.rua = rua;
            this.numRes = numRes;
            this.bairro = bairro;
            this.cidade = cidade;
            this.cargo = cargo;
        }

        public LeitorFuncio(string cargo, string usuario, string senha)
        {
            this.cargo = cargo;
            this.usuario = usuario;
            this.senha = senha;
        }

        public int CodPessoa { get => codPessoa; set => codPessoa = value; }
        public string CPF { get => cpf; set => cpf = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string Email { get => email; set => email = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Cargo { get => cargo; set => cargo = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Senha { get => senha; set => senha = value; }
        public string CEP { get => cep; set => cep = value; }
        public string Rua { get => rua; set => rua = value; }
        public string NumRes { get => numRes; set => numRes = value; }
        public string Bairro { get => bairro; set => bairro = value; }
        public string Cidade { get => cidade; set => cidade = value; }
        public int IsDevedor { get => isDevedor; set => isDevedor = value; }
    }
}
