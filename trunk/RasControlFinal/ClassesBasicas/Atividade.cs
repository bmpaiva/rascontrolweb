using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassesBasicas
{
  public class Atividade
  {
    private int codigo;
    private TipoAtividade idTipoAtividade;
    private string descricao;
    private string observacao;
    private double duracaoEstimada;
    private double duracaoRealizada;
    private string status;
    private int idEstoriaSprint;

    public int Codigo
    {
      get { return codigo; }
      set { codigo = value; }
    }
    

    public TipoAtividade IdTipoAtividade
    {
      get { return idTipoAtividade; }
      set { idTipoAtividade = value; }
    }
    

    public string Descricao
    {
      get { return descricao; }
      set { descricao = value; }
    }
   

    public string Observacao
    {
      get { return observacao; }
      set { observacao = value; }
    }
    

    public double DuracaoEstimada
    {
      get { return duracaoEstimada; }
      set { duracaoEstimada = value; }
    }
    

    public double DuracaoRealizada
    {
      get { return duracaoRealizada; }
      set { duracaoRealizada = value; }
    }
    

    public string Status
    {
      get { return status; }
      set { status = value; }
    }
   

    public int IdEstoriaSprint
    {
      get { return idEstoriaSprint; }
      set { idEstoriaSprint = value; }
    }

    public Atividade() { }

    public Atividade(int codigo, TipoAtividade idTipoAtividade, int idEstoriaSprint, string descricao, string observacao, double duracaoEstimada, double duracaoRealizada, string status) 
    {
      this.Codigo = codigo;
      this.IdTipoAtividade = idTipoAtividade;
      this.IdEstoriaSprint = idEstoriaSprint;
      this.Descricao = descricao;
      this.Observacao = observacao;
      this.DuracaoEstimada = duracaoEstimada;
      this.DuracaoRealizada = duracaoEstimada;
      this.Status = status;
     
    
    }

  }
}