using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebService;

namespace RasControlWeb
{
  public partial class WebForm6 : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    private void BindGrid()
    {
      int codigo;
      string descricao = null;

      
      try
      {
        codigo = int.Parse(tbCodigo.Text);

      }
      catch (Exception ex)
      {
        codigo = -1;
      }

      descricao = tbDescricao.Text;

      WebServiceRasControl service = new WebServiceRasControl();
      GridView1.DataSource = service.ConsultarAllEstoriaFiltros(codigo, descricao);
      GridView1.DataBind();

    }



    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btLimpar_Click(object sender, EventArgs e)
    {
      GridView1.DataSource = null;
      GridView1.DataBind();
    }

    protected void btIncluir_Click(object sender, EventArgs e)
    {
      Session["TipoTela"] = "Inclusao";

      Session["PaginaOrigem"] = "ListagemEstoria.aspx";

      Response.Redirect("ManutencaoEstoria.aspx");
    }

    protected void btPesquisar_Click(object sender, EventArgs e)
    {
      this.BindGrid();
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

        Session["PaginaOrigem"] = "ListagemEstoria.aspx";

        Response.Redirect("ManutencaoEstoria.aspx");


      }
      else if (e.CommandName == "Alterar")
      {
        int index = Convert.ToInt32(e.CommandArgument);

        GridViewRow row = GridView1.Rows[index];

        int id = Int16.Parse(Server.HtmlDecode(row.Cells[0].Text));

        Session["TipoTela"] = "Alteracao";

        Session["IdEstoria"] = id;

        Session["PaginaOrigem"] = "ListagemEstoria.aspx";

        Response.Redirect("ManutencaoEstoria.aspx");
      }
      else if (e.CommandName == "Remover")
      {
        int index = Convert.ToInt32(e.CommandArgument);

        GridViewRow row = GridView1.Rows[index];

        int id = Int16.Parse(Server.HtmlDecode(row.Cells[0].Text));
        WebService.WebServiceRasControl delete = new WebServiceRasControl();
        delete.DeletarEstoria(id);
        Page.RegisterClientScriptBlock("Aviso",
                                       "<script type= text/javascript>alert('Estória excluída com sucesso!');</script>");

      }
      GridView1.DataBind();
    }
  }
}