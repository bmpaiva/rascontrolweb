using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassesBasicas
{
    public class TipoAtividade
    {
        private int id_tipoatividade;
        private string decricao;

        public TipoAtividade()
        {
        
        }

        public int Codigo 
        {
            get { return this.id_tipoatividade; }
            set { this.id_tipoatividade = value;}
        }

        public string Descricao 
        {
            get { return this.decricao; }
            set { this.decricao = value; }
        }
    }
}