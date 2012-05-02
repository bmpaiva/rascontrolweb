using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassesBasicas
{
    public class Impedimentos
    {
        private int id_impedimento;
        private int id_sprint;
        private string descricao;
        private string ind_ativo;

        public Impedimentos()
        {

        }

        public int Id_Impedimento
        {
            get { return this.id_impedimento; }
            set { this.id_impedimento = value; }
        }

        public int Id_Sprint
        {
            get { return this.id_sprint; }
            set { this.id_sprint = value; }
        }

        public string Descricao
        {
            get { return this.descricao; }
            set { this.descricao = value; }
        }

        public string Ind_Ativo
        {
            get { return this.ind_ativo; }
            set { this.ind_ativo = value; }
        }
    }
}