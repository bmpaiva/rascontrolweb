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
    public partial class ListagemImpedimentos : System.Web.UI.Page
    {    

        protected void Page_Load(object sender, EventArgs e)
        {


        }

        public void BindGrid() 
        {
            int id_impedimento;
            int id_sprint;
            string descricao = null;

            try
            {
                id_impedimento = int.Parse(tbCodigo.Text);
                id_sprint = int.Parse(tbCodigoSprint.Text);
            }
            catch (Exception ex)
            {
                id_impedimento = -1;
                id_sprint = -1;
            }

            descricao = tbDescricao.Text;

            WebServiceRasControl service = new WebServiceRasControl();
            GridView1.DataSource = service.ConsultarAllImpedimentoFiltros(id_impedimento,id_sprint, descricao);
            GridView1.DataBind(); 
        }

        protected void btPesquisar_Click(object sender, EventArgs e)
        {
            this.BindGrid();
        }

        protected void btIncluir_Click(object sender, EventArgs e)
        {
            Session["TipoTela"] = "Inclusao";

            Session["PaginaOrigem"] = "ListagemImpedimentos.aspx";

            Response.Redirect("ManutencaoImpedimentos.aspx");
        }

      

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Detalhar")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridView1.Rows[index];

                int id = Int16.Parse(Server.HtmlDecode(row.Cells[0].Text));

                Session["TipoTela"] = "Detalhamento";

                Session["id_impedimento"] = id;

                //

                //

                Session["PaginaOrigem"] = "ListagemImpedimentos.aspx";

                Response.Redirect("ManutencaoImpedimentos.aspx");
            }
            else if (e.CommandName == "Alterar")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridView1.Rows[index];

                int id = Int16.Parse(Server.HtmlDecode(row.Cells[0].Text));

                Session["TipoTela"] = "Alteracao";

                Session["id_impedimento"] = id;

                Session["PaginaOrigem"] = "ListagemImpedimentos.aspx";

                Response.Redirect("ManutencaoImpedimentos.aspx");

            }
            else if (e.CommandName == "Remover")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridView1.Rows[index];

                int id = Int16.Parse(Server.HtmlDecode(row.Cells[0].Text));
                WebService.WebServiceRasControl delete = new WebServiceRasControl();
                delete.DeletarImpedimento(id);
                Page.RegisterClientScriptBlock("Aviso",
                                               "<script type= text/javascript>alert('Impedimento excluído com sucesso!');</script>");
            }
            GridView1.DataBind();

        }

        protected void btLimpar_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
        }

    }
}