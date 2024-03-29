﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebService;
using ClassesBasicas;

namespace RasControlWeb
{
  public partial class WebForm5 : System.Web.UI.Page
  {

    string tipoTela = null;

    protected void Page_Load(object sender, EventArgs e)
    {

      tipoTela = (string)Session["TipoTela"];

      int idEstoria = 0;

      if (Session["IdEstoria"] != null)
      {
        idEstoria = (int)Session["IdEstoria"];
      }

      if (!IsPostBack)
      {
        lbErro.Text = string.Empty;
       
        tbCodigo.Text = "";
        tbIdProjeto.Text = "";
        tbDescricao.Text = "";
        tbSp.Text = "";
        tbBv.Text = "";
        tbRoi.Text = "";


        if (tipoTela == "Inclusao")
        {
          ControleEnableDisable(true);
        }
        else if (tipoTela == "Alteracao")
        {
          this.CarregarEstoriaTela(idEstoria);
          ControleEnableDisable(true);

        }
        else if (tipoTela == "Detalhamento")
        {
          this.CarregarEstoriaTela(idEstoria);
          ControleEnableDisable(false);
        }
      }
    }

    private void ControleEnableDisable(Boolean status)
    {
      
      tbIdProjeto.ReadOnly = !status;
      tbDescricao.ReadOnly = !status;
      tbSp.ReadOnly = !status;
     tbBv.ReadOnly = !status;
     tbRoi.ReadOnly = !status;

      btGravar.Enabled = status;
    }

    private void CarregarEstoriaTela(int idEstoria)
    {
      try
      {

        WebServiceRasControl service = new WebServiceRasControl();       

        Estoria estoria = service.ConsultarEstoriaPorId(idEstoria);
        tbCodigo.Text = estoria.Codigo.ToString();
        
        Projeto p = service.ConsultarProjetoPorId(estoria.IdProjeto.Codigo);
        tbIdProjeto.Text = p.Codigo.ToString();
        
        //tbIdProjeto.Text = estoria.IdProjeto.Codigo.ToString();

        tbDescricao.Text = estoria.Descricao;
        tbSp.Text = estoria.Sp.ToString();
        tbBv.Text = estoria.Bv.ToString();
        tbRoi.Text = estoria.Roi.ToString();

       
      }
      catch (Exception ex)
      {
        lbErro.Text = ex.Message;

      }
      
    }

    protected void btGravar_Click(object sender, EventArgs e)
    {

      lbErro.Text = string.Empty;

      try
      {
        if (tipoTela == "Inclusao")
        {
          WebServiceRasControl service = new WebServiceRasControl();
          Projeto p = service.ConsultarProjetoPorId(int.Parse(tbIdProjeto.Text));
          Estoria estoria = new Estoria();
  
          estoria.IdProjeto = service.ConsultarProjetoPorId(p.Codigo);
          estoria.Descricao = tbDescricao.Text;
          estoria.Sp = double.Parse(tbSp.Text);
          estoria.Bv = double.Parse(tbBv.Text);
          estoria.Roi = double.Parse(tbRoi.Text);
          
          service.CadastrarEstoria(estoria);

          Page.RegisterClientScriptBlock("Aviso",
                                         "<script type= text/javascript>alert('Estória cadastrada com sucesso!');</script>");

        }
        else if (tipoTela == "Alteracao")
        {
          WebServiceRasControl service = new WebServiceRasControl();
          Projeto p = service.ConsultarProjetoPorId(int.Parse(tbIdProjeto.Text));
          Estoria estoria = new Estoria();
          estoria.Codigo = int.Parse(tbCodigo.Text);
          estoria.IdProjeto = service.ConsultarProjetoPorId(p.Codigo);
          estoria.Descricao = tbDescricao.Text;
          estoria.Sp = double.Parse(tbSp.Text);
          estoria.Bv = double.Parse(tbBv.Text);
          estoria.Roi = double.Parse(tbRoi.Text);
          
         
          service.AlterarEstoria(estoria);


          Page.RegisterClientScriptBlock("Aviso",
                                         "<script type= text/javascript>alert('Estória alterada com sucesso!');</script>");

        }

      }
      catch (Exception ex)
      {
        lbErro.Text = ex.Message;

      }

    }

    protected void btVoltar_Click(object sender, EventArgs e)
    {
      if ((string)Session["PaginaOrigem"] == null)
      {
        Response.Redirect("Index.aspx");
      }
      else
      {
        Response.Redirect((string)Session["PaginaOrigem"]);
      }
    }

  }
}