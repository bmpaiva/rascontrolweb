using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebService;

namespace RasControlWeb
{
    public partial class ListagemUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void BindGrid()
        {
            int codigo;
            string cpf = null;

            try
            {
                codigo = int.Parse(tbCodigo.Text);

            }
            catch (Exception ex)
            {
                codigo = -1;
            }

            cpf = tbCpf.Text;

            WebServiceRasControl service = new WebServiceRasControl();
            GridView1.DataSource = service.ConsultarAllUsuarioFiltros(codigo, cpf);
            GridView1.DataBind();

        }

        

        protected void btPesquisar_Click(object sender, EventArgs e)
        {
            this.BindGrid();
        }

        protected void btIncluir_Click(object sender, EventArgs e)
        {
            Session["TipoTela"] = "Inclusao";

            Session["PaginaOrigem"] = "ListagemUsuario.aspx";

            Response.Redirect("ManutencaoUsuario.aspx");
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

                Session["IdUsuario"] = id;

                Session["PaginaOrigem"] = "ListagemUsuario.aspx";

                Response.Redirect("ManutencaoUsuario.aspx");


            }
            else if (e.CommandName == "Alterar")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridView1.Rows[index];

                int id = Int16.Parse(Server.HtmlDecode(row.Cells[0].Text));

                Session["TipoTela"] = "Alteracao";

                Session["IdUsuario"] = id;

                Session["PaginaOrigem"] = "ListagemUsuario.aspx";

                Response.Redirect("ManutencaoUsuario.aspx");
            }
            else if (e.CommandName == "Deletar")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridView1.Rows[index];

                int id = Int16.Parse(Server.HtmlDecode(row.Cells[0].Text));
                WebService.WebServiceRasControl teste = new WebServiceRasControl();
                teste.DeletarUsuario(id);
                Page.RegisterClientScriptBlock("Aviso",
                                               "<script type= text/javascript>alert('Usuario excluido com sucesso!');</script>");

            }
            GridView1.DataBind();

        }
    }
}