using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebService;

namespace RasControlWeb
{
  public partial class ListagemPerfilUsuario : System.Web.UI.Page
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
      GridView1.DataSource = service.ConsultarAllPerfilUsuarioFiltros(codigo, descricao);
      GridView1.DataBind();

    }

    protected void btPesquisar_Click(object sender, EventArgs e)
    {
      this.BindGrid();
    }

    protected void btIncluir_Click(object sender, EventArgs e)
    {
      Session["TipoTela"] = "Inclusao";

      Session["PaginaOrigem"] = "ListagemPerfilUsuario.aspx";

      Response.Redirect("ManutencaoPerfilUsuario.aspx");
    }

    protected void btLimpar_Click(object sender, EventArgs e)
    {
      GridView1.DataSource = null;
      GridView1.DataBind();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      if (e.CommandName == "Detalhar")
      {
        int index = Convert.ToInt32(e.CommandArgument);

        GridViewRow row = GridView1.Rows[index];

        int id = Int16.Parse(Server.HtmlDecode(row.Cells[0].Text));

        Session["TipoTela"] = "Detalhamento";

        Session["IdPerfilUsuario"] = id;

        Session["PaginaOrigem"] = "ListagemPerfilUsuario.aspx";

        Response.Redirect("ManutencaoPerfilUsuario.aspx");


      }
      else if (e.CommandName == "Alterar")
      {
        int index = Convert.ToInt32(e.CommandArgument);

        GridViewRow row = GridView1.Rows[index];

        int id = Int16.Parse(Server.HtmlDecode(row.Cells[0].Text));

        Session["TipoTela"] = "Alteracao";

        Session["IdPerfilUsuario"] = id;

        Session["PaginaOrigem"] = "ListagemPerfilUsuario.aspx";

        Response.Redirect("ManutencaoPerfilUsuario.aspx");
      }
      else if (e.CommandName == "Remover")
      {
        int index = Convert.ToInt32(e.CommandArgument);

        GridViewRow row = GridView1.Rows[index];

        int id = Int16.Parse(Server.HtmlDecode(row.Cells[0].Text));
        WebService.WebServiceRasControl delete = new WebServiceRasControl();
        delete.DeletarPerfilUsuario(id);
        Page.RegisterClientScriptBlock("Aviso",
                                       "<script type= text/javascript>alert('Perfil de usuário excluído com sucesso!');</script>");

      }
      else if (e.CommandName == "Permissoes")
      {
          int index = Convert.ToInt32(e.CommandArgument);

          GridViewRow row = GridView1.Rows[index];

          int id = Int16.Parse(Server.HtmlDecode(row.Cells[0].Text));

          Session["PaginaOrigem"] = "ListagemPerfilUsuario.aspx";

          Response.Redirect("PermissoesPerfil.aspx?idPerfil=" + id.ToString());
      }
          
      GridView1.DataBind();

    }

   



  }
}