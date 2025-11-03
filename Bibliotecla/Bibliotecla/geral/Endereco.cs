using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotecla.geral
{
    internal class Endereco
    {
        private int codEndereco;
        private string cep;
        private string rua;
        private string numero;
        private string bairro;
        private string cidade;
        private string estado;

        // CUIDADO: Pra ser "Brasil" (descoberto, durrr)
        public int CodEndereco { get => codEndereco; set => codEndereco = value; }
        public string Cep { get => cep; set => cep = value; }
        public string Rua { get => rua; set => rua = value; }
        public string Numero { get => numero; set => numero = value; }
        public string Bairro { get => bairro; set => bairro = value; }
        public string Cidade { get => cidade; set => cidade = value; }
        public string Estado { get => estado; set => estado = value; }
    }
}
