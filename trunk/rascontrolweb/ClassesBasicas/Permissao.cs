using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassesBasicas
{
    public class Permissao
    {
        private int codigo;
        private string descricao;
        private string observacao;
        private string erro;
        

        public Permissao()
        {
            // vazio
        }

        public int Codigo
        {
            get { return this.codigo; }
            set { this.codigo = Codigo; }
        }

        public string Descricao
        {
            get { return this.descricao; }
            set { this.descricao = Descricao; }
        }

        public string Observacao
        {
            get { return this.observacao; }
            set { this.observacao = Observacao; }
        }

        public string Erro
        {
            get { return erro; }
            set { erro = value; }
        }
   

    }


}