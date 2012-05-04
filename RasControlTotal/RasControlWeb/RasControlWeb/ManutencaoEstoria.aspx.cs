using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebService;
using ClassesBasicas;
using System.Text.RegularExpressions;

namespace RasControlWeb
{
  public partial class ManutencaoEstoria : System.Web.UI.Page
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
          Projeto p = service.ConsultarProjetoPorId(Convert.ToInt32(Request.Params["idProjeto"]));
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
          Projeto p = service.ConsultarProjetoPorId(Convert.ToInt32(Request.Params["idProjeto"]));
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
        if (tbDescricao.Text == "")
        {
          Page.RegisterClientScriptBlock("Aviso",
                                          "<script type= text/javascript>alert('Campo Descrição em branco!');</script>");

          tbDescricao.Focus();


        }

        else if


          (tbSp.Text == "")
        {
          Page.RegisterClientScriptBlock("Aviso",
                                          "<script type= text/javascript>alert('Campo SP em branco!');</script>");

          tbSp.Focus();


        }

         //
        else if (!ValidaNumero(tbSp.Text.ToString()))
        {
          Page.RegisterClientScriptBlock("Aviso",
             "<script type= text/javascript>alert('Digite apenas numeros no campo SP!');</script>");
          tbSp.Focus();
        }
        //

        else if
        (tbBv.Text == "")
        {
          Page.RegisterClientScriptBlock("Aviso",
                                          "<script type= text/javascript>alert('Campo BV em branco!');</script>");

          tbBv.Focus();

        }

          //
        else if (!ValidaNumero(tbBv.Text.ToString()))
        {
          Page.RegisterClientScriptBlock("Aviso",
             "<script type= text/javascript>alert('Digite apenas numeros no campo BV!');</script>");
          tbSp.Focus();
        }
        //

        else if
        (tbRoi.Text == "")
        {
          Page.RegisterClientScriptBlock("Aviso",
                                          "<script type= text/javascript>alert('Campo Roi em branco!');</script>");

          tbRoi.Focus();

        }

           //
        else if (!ValidaNumero(tbRoi.Text.ToString()))
        {
          Page.RegisterClientScriptBlock("Aviso",
             "<script type= text/javascript>alert('Digite apenas numeros no campo ROI!');</script>");
          tbSp.Focus();
        }
        //

        else
        {
          lbErro.Text = ex.Message;

        }
      }
    }


    public void CalcularRoi()
    {

     /*if (tbSp.Text == "")
      {
        tbSp.Text = (0).ToString();
        tbRoi.Text = (0).ToString();
      }
      else
      {*/
        double roi = Convert.ToDouble(tbBv.Text) / Convert.ToDouble(tbSp.Text);
        string roi2 = roi.ToString();
        tbRoi.Text = roi2.Substring(0, 3);
        // double roi = Convert.ToDouble(tbBv.Text) / Convert.ToDouble(tbSp.Text);
        //tbRoi.Text = roi.ToString();
      //}
    }

    public bool ValidaNumero(string numero)
    {
      Regex rx = new Regex(@"^\d+$");
      return rx.IsMatch(numero);
    }

    

    protected void btVoltar_Click(object sender, EventArgs e)
    {
      if ((string)Session["PaginaOrigem"] == null)
      {
        Response.Redirect("Index.aspx");
        //Response.Redirect("ListagemEstoria.aspx");
        //ListagemEstoria.aspx
      }
      else
      {
        Response.Redirect((string)Session["PaginaOrigem"]);
      }
    }

    protected void tbRoi_TextChanged(object sender, EventArgs e)
    {
      
    }

    protected void tbBv_TextChanged(object sender, EventArgs e)
    {
      if ((tbSp.Text.Trim() != "" && tbSp.Text.Trim() != null) && (tbBv.Text.Trim() != "" && tbBv.Text.Trim() != null))
      {
        CalcularRoi();
      }
    }

    protected void tbSp_TextChanged(object sender, EventArgs e)
    {
      if ((tbSp.Text.Trim() != "" && tbSp.Text.Trim() != null) && (tbBv.Text.Trim() != "" && tbBv.Text.Trim() != null))
      {
        CalcularRoi();
      }
      // CalcularRoi();
    }

  }
}