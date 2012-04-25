using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassesBasicas
{
    public class Projeto
    {
        private int codigo;
        private string descricao;
        private string nome;
        private DateTime dtInclusao;
        private string status;


        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }


        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }


        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }


        public DateTime DtInclusao
        {
            get { return dtInclusao; }
            set { dtInclusao = value; }
        }


        public string Status
        {
            get { return status; }
            set { status = value; }
        }



        public Projeto() { }

        public Projeto(int codigo, string descricao, string nome, DateTime dtInclusao, string status)
        {
            this.Codigo = codigo;
            this.Descricao = descricao;
            this.Nome = nome;
            this.DtInclusao = dtInclusao;
            this.Status = status;
        }

    }
}
