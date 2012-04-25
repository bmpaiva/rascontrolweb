using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassesBasicas
{
    public class Estoria
    {
        private int codigo;
        private Projeto idProjeto;
        private string descricao;
        private double sp;
        private double bv;
        private double roi;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }



        public Projeto IdProjeto
        {
            get { return idProjeto; }
            set { idProjeto = value; }
        }


        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }


        public double Sp
        {
            get { return sp; }
            set { sp = value; }
        }


        public double Bv
        {
            get { return bv; }
            set { bv = value; }
        }


        public double Roi
        {
            get { return roi; }
            set { roi = value; }
        }

        public Estoria() { }

        public Estoria(int codigo, Projeto idProjeto, string descricao, double sp, double bv, double roi)
        {
            this.Codigo = codigo;
            this.IdProjeto = idProjeto;
            this.Descricao = descricao;
            this.Sp = sp;
            this.Bv = bv;
            this.Roi = roi;
        }

    }
}