using Bibliotecla.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotecla.geral
{
    internal class UsuarioLogado
    {
        private static LeitorFuncio usuario;

        public static LeitorFuncio GetUsuario()
        {
            return usuario;
        }

        public static void SetUsuario(LeitorFuncio usuario)
        {
            UsuarioLogado.usuario = usuario;
        }
    }
}
