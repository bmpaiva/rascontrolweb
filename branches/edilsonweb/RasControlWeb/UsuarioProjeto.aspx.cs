using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassesBasicas;
using WebService;

namespace RasControlWeb
{
  public partial class UsuarioProjeto : System.Web.UI.Page
  {

    WebServiceRasControl service = new WebServiceRasControl();
    private List<Usuario> usuarios = new List<Usuario>();

    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        this.BindGrid();
      }
    }

    private void BindGrid()
    {

      usuarios = service.ConsultarAllUsuarioProjeto(Convert.ToInt32(Request.Params["idProjeto"]));
      Session["Usuarios"] = usuarios;

      GridView1.DataSource = usuarios;
      GridView1.DataBind();

      dropboxUsuarios.DataSource = service.ConsultarAllUsuarioFiltros(-1, null);
    
      dropboxUsuarios.DataValueField = "codigo";
      dropboxUsuarios.DataTextField = "nome";
    
      dropboxUsuarios.DataBind();
    }

    protected void btAdicionar_Click(object sender, EventArgs e)
    {
      Usuario usuario = service.ConsultarUsuarioPorId(int.Parse(dropboxUsuarios.SelectedValue));

      bool existe = false;

      if (Session["Usuarios"] != null)
      {
        usuarios = (List<Usuario>)Session["Usuarios"];
      }

      foreach (Usuario objUsuario in usuarios)
      {
        if (objUsuario.Codigo == usuario.Codigo)
        {
          existe = true;
          break;
        }
      }
      if (!existe)
      {
        // service.CadastrarUsuarioProjeto(usuario, Convert.ToInt32(Request.Params["idProjeto"]));
        service.CadastrarUsuarioProjeto(Convert.ToInt32(Request.Params["idProjeto"]), usuario);
        usuarios.Add(usuario);
        Session["Usuarios"] = usuarios;
      }
      GridView1.DataSource = usuarios;
      GridView1.DataBind();
    }


    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      if (e.CommandName == "Remover")
      {
        int index = Convert.ToInt32(e.CommandArgument);

        GridViewRow row = GridView1.Rows[index];

        int idProjeto = Convert.ToInt32(Request.Params["idProjeto"]);
        int idUsuario = Int16.Parse(Server.HtmlDecode(row.Cells[0].Text));

        WebService.WebServiceRasControl service = new WebServiceRasControl();
        service.DeletarUsuarioProjeto(idUsuario, idProjeto);

        usuarios = service.ConsultarAllUsuarioProjeto(Convert.ToInt32(Request.Params["idProjeto"]));
        Session["Usuarios"] = usuarios;

        Page.RegisterClientScriptBlock("Aviso",
                                           "<script type= text/javascript>alert('Exclusão efetivada com sucesso!');</script>");
        
      }
      GridView1.DataSource = usuarios;
      GridView1.DataBind();
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