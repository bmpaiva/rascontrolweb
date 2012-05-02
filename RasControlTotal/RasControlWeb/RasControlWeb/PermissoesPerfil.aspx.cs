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
    public partial class PermissoesPerfil : System.Web.UI.Page
    {
        WebServiceRasControl service = new WebServiceRasControl();
        private List<Permissao> permissoes = new List<Permissao>();

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {                
                this.BindGrid();
            }
            
        }

        private void BindGrid()
        {

            permissoes = service.ConsultarAllPermissaoPerfil(Convert.ToInt32(Request.Params["idPerfil"]));
            Session["Permissoes"] = permissoes;

            GridView1.DataSource = permissoes;
            GridView1.DataBind();

            dropboxPermissoes.DataSource = service.ConsultarAllPermissaoFiltros(-1, null);
            dropboxPermissoes.DataTextField = "descricao";
            dropboxPermissoes.DataValueField = "codigo";
            dropboxPermissoes.DataBind();           
        }

        protected void btAdicionar_Click(object sender, EventArgs e)
        {
            Permissao permissao = service.ConsultarPermissaoPorId(int.Parse(dropboxPermissoes.SelectedValue));
            
            bool existe = false;

            if (Session["Permissoes"] != null)
            {
                permissoes = (List<Permissao>)Session["Permissoes"];
            }

            foreach (Permissao objPermissao in permissoes)
            {
                if (objPermissao.Codigo == permissao.Codigo)
                {
                    existe = true;
                    break;
                }
            }
            if (!existe)
            {
                service.CadastrarPermissaoPerfil(Convert.ToInt32(Request.Params["idPerfil"]), permissao);
                permissoes.Add(permissao);
                Session["Permissoes"] = permissoes;
            }
            GridView1.DataSource = permissoes;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Remover")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridView1.Rows[index];

                int idPerfil = Convert.ToInt32(Request.Params["idPerfil"]);
                int idPermissao = Int16.Parse(Server.HtmlDecode(row.Cells[0].Text));
              
                WebService.WebServiceRasControl service = new WebServiceRasControl();
                service.DeletarPerfilPermissao(idPerfil, idPermissao);

                permissoes = service.ConsultarAllPermissaoPerfil(Convert.ToInt32(Request.Params["idPerfil"]));
                Session["Permissoes"] = permissoes;

                Page.RegisterClientScriptBlock("Aviso",
                                                   "<script type= text/javascript>alert('Exclusão efetivada com sucesso!');</script>");
                             
            }
            GridView1.DataSource = permissoes;
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