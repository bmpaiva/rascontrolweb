using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassesBasicas
{
    public class Avaliacao360
    {
        private int codigo;
        private Sprint idSprint;
        private Usuario idAvaliador;
        private double nota;
        private Usuario idAvaliado;
        private string justificativa;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }


        public Sprint IdSprint
        {
            get { return idSprint; }
            set { idSprint = value; }
        }


        public Usuario IdAvaliador
        {
            get { return idAvaliador; }
            set { idAvaliador = value; }
        }


        public double Nota
        {
            get { return nota; }
            set { nota = value; }
        }


        public Usuario IdAvaliado
        {
            get { return idAvaliado; }
            set { idAvaliado = value; }
        }


        public string Justificativa
        {
            get { return justificativa; }
            set { justificativa = value; }
        }

        public Avaliacao360() { }

        public Avaliacao360(int codigo, Sprint idSprint, Usuario idAvaliador, double nota, Usuario idAvaliado, string justificativa)
        {
            this.Codigo = codigo;
            this.IdSprint = idSprint;
            this.IdAvaliador = idAvaliador;
            this.Nota = nota;
            this.IdAvaliado = IdAvaliado;
            this.Justificativa = justificativa;
        }

    }
}