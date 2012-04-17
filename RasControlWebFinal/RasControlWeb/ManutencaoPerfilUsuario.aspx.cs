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
  public partial class WebForm3 : System.Web.UI.Page
  {
    string tipoTela = null;

    protected void Page_Load(object sender, EventArgs e)
    {

      tipoTela = (string)Session["TipoTela"];

      int idPerfilUsuario = 0;

      if (Session["IdPerfilUsuario"] != null)
      {
        idPerfilUsuario = (int)Session["IdPerfilUsuario"];
      }

      if (!IsPostBack)
      {
        lbErro.Text = string.Empty;
        tbDescricao.Text = "";
        tbCodigo.Text = "";
        

        if (tipoTela == "Inclusao")
        {
          ControleEnableDisable(true);
        }
        else if (tipoTela == "Alteracao")
        {
          this.CarregarPerfilUsuarioTela(idPerfilUsuario);
          ControleEnableDisable(true);

        }
        else if (tipoTela == "Detalhamento")
        {
          this.CarregarPerfilUsuarioTela(idPerfilUsuario);
          ControleEnableDisable(false);
        }
      }
    }

    private void ControleEnableDisable(Boolean status)
    {
      tbDescricao.ReadOnly = !status;
      
      btGravar.Enabled = status;
    }

    private void CarregarPerfilUsuarioTela(int idPerfilUsuario)
    {
      try
      {

        WebServiceRasControl service = new WebServiceRasControl();
        PerfilUsuario perfilUsuario = service.ConsultarPerfilUsuarioPorId(idPerfilUsuario);
        tbCodigo.Text = perfilUsuario.Codigo.ToString();
        tbDescricao.Text = perfilUsuario.Descricao;

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

    protected void btGravar_Click(object sender, EventArgs e)
    {
      lbErro.Text = string.Empty;

      try
      {
        if (tipoTela == "Inclusao")
        {

          PerfilUsuario perfilUsuario = new PerfilUsuario();
          perfilUsuario.Descricao = tbDescricao.Text;

          WebServiceRasControl service = new WebServiceRasControl();
          service.CadastrarPerfilUsuario(perfilUsuario);
          

          Page.RegisterClientScriptBlock("Aviso",
                                         "<script type= text/javascript>alert('Perfil de Usuário cadastrado com sucesso!');</script>");

        }
        else if (tipoTela == "Alteracao")
        {
          PerfilUsuario perfilUsuario = new PerfilUsuario();

          perfilUsuario.Codigo = int.Parse(tbCodigo.Text);
          perfilUsuario.Descricao = tbDescricao.Text;

          WebServiceRasControl service = new WebServiceRasControl();
          service.AlterarPerfilUsuario(perfilUsuario);
         

          Page.RegisterClientScriptBlock("Aviso",
                                         "<script type= text/javascript>alert('Perfil de Usuário alterado com sucesso!');</script>");

        }

      }
      catch (Exception ex)
      {
        lbErro.Text = ex.Message;

      }

    }

  }
}