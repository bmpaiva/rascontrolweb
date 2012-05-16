using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebService;
using ClassesBasicas;

namespace RasControlWeb
{
    public partial class SprintEstoria : System.Web.UI.Page
    {
        WebServiceRasControl service = new WebServiceRasControl();
        private List<Sprint> sprints = new List<Sprint>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindGrid();
            }
        }

        private void BindGrid()
        {

            sprints = service.ConsultarAllSprintEstoria(Convert.ToInt32(Request.Params["idSprint"]));
            Session["Sprints"] = sprints;

            GridView1.DataSource = sprints;
            GridView1.DataBind();

            dropBoxSprint.DataSource = service.ConsultarAllEstoriaFiltros(-1, null);
            dropBoxSprint.DataTextField = "descricao";
            dropBoxSprint.DataValueField = "codigo";
            dropBoxSprint.DataBind();
        }

        protected void dropboxSprints_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Remover")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridView1.Rows[index];

                int idSprint = Convert.ToInt32(Request.Params["idSprint"]);
                int idEstoria = Int16.Parse(Server.HtmlDecode(row.Cells[0].Text));

                WebService.WebServiceRasControl service = new WebServiceRasControl();
                service.DeletarSprintEstoria(idSprint, idEstoria);

                sprints = service.ConsultarAllSprintEstoria(Convert.ToInt32(Request.Params["idSprint"]));
                Session["Sprint"] = sprints;

                Page.RegisterClientScriptBlock("Aviso",
                                                   "<script type= text/javascript>alert('Exclusão efetivada com sucesso!');</script>");

            }
            GridView1.DataSource = sprints;
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

        protected void btAdicionar_Click(object sender, EventArgs e)
        {

        }
    }
}