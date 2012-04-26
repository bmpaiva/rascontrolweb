using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassesBasicas
{
  public class TipoAtividade
  {
    private int codigo;
    private string descricao;
    private string erro;

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
    

    public string Erro
    {
      get { return erro; }
      set { erro = value; }
    }

    public TipoAtividade() { }

    public TipoAtividade(int codigo, string descricao, string erro) 
    {
      this.Codigo = codigo;
      this.Descricao = descricao;
      this.Erro = erro;
    }

  }
}