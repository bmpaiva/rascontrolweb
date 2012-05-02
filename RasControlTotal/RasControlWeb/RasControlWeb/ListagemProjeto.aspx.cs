using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebService;

namespace RasControlWeb
{
    public partial class ListagemProjeto : System.Web.UI.Page
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
            GridView1.DataSource = service.ConsultarAllProjetoFiltros(codigo, descricao);
            GridView1.DataBind();

        }

        protected void tbPesquisar_Click(object sender, EventArgs e)
        {
            this.BindGrid();
        }

        protected void tbIncluir_Click(object sender, EventArgs e)
        {
            Session["TipoTela"] = "Inclusao";

            Session["PaginaOrigem"] = "ListagemProjeto.aspx";

            Response.Redirect("Manutencaoprojeto.aspx");
        }

        protected void tbLimpar_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
        }

       
        protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Detalhar")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridView1.Rows[index];

                int id = Int16.Parse(Server.HtmlDecode(row.Cells[0].Text));

                Session["TipoTela"] = "Detalhamento";

                Session["IdProjeto"] = id;

                Session["PaginaOrigem"] = "ListagemProjeto.aspx";

                Response.Redirect("ManutencaoProjeto.aspx");


            }
            else if (e.CommandName == "Alterar")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridView1.Rows[index];

                int id = Int16.Parse(Server.HtmlDecode(row.Cells[0].Text));

                Session["TipoTela"] = "Alteracao";

                Session["IdProjeto"] = id;

                Session["PaginaOrigem"] = "ListagemProjeto.aspx";

                Response.Redirect("ManutencaoProjeto.aspx");
            }
            else if (e.CommandName == "Remover")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridView1.Rows[index];

                int id = Int16.Parse(Server.HtmlDecode(row.Cells[0].Text));
                WebService.WebServiceRasControl teste = new WebServiceRasControl();
                teste.DeletarUsuario(id);
                Page.RegisterClientScriptBlock("Aviso",
                                               "<script type= text/javascript>alert('Projeto excluido com sucesso!');</script>");

            }
            else if (e.CommandName == "Estorias")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridView1.Rows[index];

                int id = Int16.Parse(Server.HtmlDecode(row.Cells[0].Text));
               
                Session["PaginaOrigem"] = "ListagemProjeto.aspx";

                Response.Redirect("ListagemEstoria.aspx?idProjeto=" + id.ToString());
                
            }
            else if (e.CommandName == "Sprints")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridView1.Rows[index];

                int id = Int16.Parse(Server.HtmlDecode(row.Cells[0].Text));

                Session["PaginaOrigem"] = "ListagemSprint.aspx";

                Response.Redirect("ListagemSprint.aspx?idProjeto=" + id.ToString());

            }
            GridView1.DataBind();

        }

    }
}