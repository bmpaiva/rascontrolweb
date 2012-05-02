using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebService;

namespace RasControlWeb
{
  public partial class ListagemEstoria : System.Web.UI.Page
  {   
    protected void Page_Load(object sender, EventArgs e)
    {       
        this.BindGrid();

    }


    private void BindGrid()
    {   
      WebServiceRasControl service = new WebServiceRasControl();
      GridView1.DataSource = service.ConsultarAllEstoriaFiltros(Convert.ToInt32(Request.Params["idProjeto"]), null);
      GridView1.DataBind();
    }
      

    

    protected void btIncluir_Click(object sender, EventArgs e)
    {
      Session["TipoTela"] = "Inclusao";

      Session["PaginaOrigem"] = "ListagemEstoria.aspx?idProjeto=" + Request.Params["idProjeto"];

      Response.Redirect("ManutencaoEstoria.aspx?idProjeto=" + Request.Params["idProjeto"]); 
    }

    

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      if (e.CommandName == "Detalhar")
      {
        int index = Convert.ToInt32(e.CommandArgument);

        GridViewRow row = GridView1.Rows[index];

        int id = Int16.Parse(Server.HtmlDecode(row.Cells[0].Text));

        Session["TipoTela"] = "Detalhamento";

        Session["IdEstoria"] = id;

        Session["PaginaOrigem"] = "ListagemEstoria.aspx?idProjeto=" + Request.Params["idProjeto"];

        Response.Redirect("ManutencaoEstoria.aspx?idProjeto=" + Request.Params["idProjeto"]); 


      }
      else if (e.CommandName == "Alterar")
      {
        int index = Convert.ToInt32(e.CommandArgument);

        GridViewRow row = GridView1.Rows[index];

        int id = Int16.Parse(Server.HtmlDecode(row.Cells[0].Text));

        Session["TipoTela"] = "Alteracao";

        Session["IdEstoria"] = id;

        Session["PaginaOrigem"] = "ListagemEstoria.aspx?idProjeto=" + Request.Params["idProjeto"];

        Response.Redirect("ManutencaoEstoria.aspx?idProjeto=" + Request.Params["idProjeto"]); 
      }
      else if (e.CommandName == "Remover")
      {
        int index = Convert.ToInt32(e.CommandArgument);

        GridViewRow row = GridView1.Rows[index];

        int id = Int16.Parse(Server.HtmlDecode(row.Cells[0].Text));
        WebService.WebServiceRasControl service = new WebServiceRasControl();
        service.DeletarEstoria(id);
        Page.RegisterClientScriptBlock("Aviso",
                                       "<script type= text/javascript>alert('Estória excluída com sucesso!');</script>");

      }
      GridView1.DataBind();
    }

  
  }
}