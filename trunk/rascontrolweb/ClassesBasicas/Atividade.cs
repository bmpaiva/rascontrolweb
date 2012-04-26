using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassesBasicas
{
  public class Atividade
  {
     private int id_atividade;
        private int id_tipo_atividade;
        private int id_estoria_sprint;
        private string descricao;
        private string observacao;
        private double duracao_estimada;
        private double duracao_realizada;
        private string status;
        private string ind_ativo;

        public Atividade()
        {

        }

        public int Id_Atividade
        {
            get { return this.id_atividade; }
            set { this.id_atividade = value; }
        }

        public int Id_Tipo_Atividade
        {
            get { return this.id_tipo_atividade; }
            set { this.id_tipo_atividade = value; }
        }

        public int Id_Estoria_Sprint
        {
            get { return this.id_estoria_sprint; }
            set { this.id_estoria_sprint = value; }
        }

        public string Descricao
        {
            get { return this.descricao; }
            set { this.descricao = value; }
        }

        public string Observacao
        {
            get { return this.observacao; }
            set { this.observacao = value; }
        }

        public double Duracao_Estimada
        {
            get { return this.duracao_estimada; }
            set { this.duracao_estimada = value; }
        }

        public double Duracao_Realizada
        {
            get { return this.duracao_realizada; }
            set { this.duracao_realizada = value; }
        }

        public string Status
        {
            get { return this.status; }
            set { this.status = value; }
        }

        public string Ind_Ativo
        {
            get { return this.ind_ativo; }
            set { this.ind_ativo = value; }
        }

    

  }
}