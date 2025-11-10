using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotecla.model
{
    internal class Exemplar
    {
        private int codExemplar;
        private string anoPubli;
        private string estadoFisico;
        private string editoraExemplar;
        private Titulo titulo;

        public Exemplar(Titulo titulo) 
        {
            this.titulo = titulo;
        }

        public Exemplar(int codExemplar,
                        string anoPubli,
                        string estadoFisico,
                        string editoraExemplar,
                        Titulo titulo)
        {
            this.codExemplar = codExemplar;
            this.anoPubli = anoPubli;
            this.estadoFisico = estadoFisico;
            this.editoraExemplar = editoraExemplar;
            this.titulo = titulo;
        }

        public int CodExemplar { get => codExemplar; set => codExemplar = value; }
        public string AnoPubli { get => anoPubli; set => anoPubli = value; }
        public string EstadoFisico { get => estadoFisico; set => estadoFisico = value; }
        public string EditoraExemplar { get => editoraExemplar; set => editoraExemplar = value; }
        public Titulo Titulo { get => titulo; set => titulo = value; }
    }
}
