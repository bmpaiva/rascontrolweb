using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassesBasicas
{
    /// <summary>
    /// Classe basica para o Manter Sprint
    /// </summary>
  public class Sprint
  {
      //Declara os atributos
      private int id_sprint;
      private int id_projeto;
      private string descricao;
      private DateTime data_inicio;
      private DateTime data_fim;
      private int qtd_dias;
      private char ind_ativo;

      //Declara um construtor Default
      public Sprint()
      {

      }

      //Declara todos os Get´s & Set´s
      public int Id_Sprint
      {
          get { return this.id_sprint; }
          set { this.id_sprint = value; }
      }

      public int Id_Projeto
      {
          get { return this.id_projeto; }
          set { this.id_projeto = value; }
      }

      public string Descricao
      {
          get { return this.descricao; }
          set { this.descricao = value; }
      }

      public DateTime Data_Inicio
      {
          get { return this.data_inicio; }
          set { this.data_inicio = value; }
      }

      public DateTime Data_Fim
      {
          get { return this.data_fim; }
          set { this.data_fim = value; }
      }

      public int Qtd_Dias
      {
          get { return this.qtd_dias; }
          set { this.qtd_dias = value; }
      }

      public char Ind_Ativo
      {
          get { return this.ind_ativo; }
          set { this.ind_ativo = value; }
      }
  }
}
