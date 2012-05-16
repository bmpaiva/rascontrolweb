using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebService;

namespace RasControlWeb
{
    public partial class ListagemAtividade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void BindGrid() 
        {
            int id_atividade;
            int id_tipo_atividade;
            int id_estoria_sprint;
            string descricao = null;
            double duracao_estimada;
            double duracao_realizada;

            try
            {
                id_atividade = int.Parse(tbCodigoAtividade.Text);
                id_tipo_atividade = 
                id_estoria_sprint = int.Parse(tbCodigoEstoriaSprint.Text);
                duracao_estimada = double.Parse(tbDuracaoEstimada.Text);
                duracao_realizada = double.Parse(tbDuracaoRealizada.Text);
                
            }
            catch (Exception ex) 
            {
                id_atividade = -1;
                id_tipo_atividade = -1;
                id_estoria_sprint = -1;
                duracao_estimada = -1;
                duracao_realizada = -1;
         
            }

            descricao = tbDescricao.Text;

            WebServiceRasControl service = new WebServiceRasControl();
            GridView1.DataSource = service.ConsultarAllAtividadeFiltros(id_atividade,id_tipo_atividade, id_estoria_sprint, descricao, duracao_estimada, duracao_realizada);
            GridView1.DataBind();
        }

        protected void btPesquisar_Click(object sender, EventArgs e)
        {
            this.BindGrid();
        }

        protected void btIncluir_Click(object sender, EventArgs e)
        {
            Session["TipoTela"] = "Inclusao";

            Session["PaginaOrigem"] = "ListagemAtividade.aspx";

            Response.Redirect("ManutencaoAtividade.aspx");
        }
            
       

        protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Detalhar")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridView1.Rows[index];

                int id = Int16.Parse(Server.HtmlDecode(row.Cells[0].Text));

                Session["TipoTela"] = "Detalhamento";

                Session["id_atividade"] = id;

           //     Session["id_tipo_atividade"] = id;

           //     Session["id_estoria_sprint"] = id;

                Session["PaginaOrigem"] = "ListagemAtividade.aspx";

                Response.Redirect("ManutencaoAtividade.aspx");
            }
            else if (e.CommandName == "Alterar")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridView1.Rows[index];

                int id = Int16.Parse(Server.HtmlDecode(row.Cells[0].Text));

                Session["TipoTela"] = "Alteracao";

                Session["id_atividade"] = id;

            //   Session["id_tipo_atividade"] = id;

            //     Session["id_estoria_sprint"] = id;

                Session["PaginaOrigem"] = "ListagemAtividade.aspx";

                Response.Redirect("ManutencaoAtividade.aspx");

            }
            else if (e.CommandName == "Remover")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridView1.Rows[index];

                int id = Int16.Parse(Server.HtmlDecode(row.Cells[0].Text));
                WebService.WebServiceRasControl delete = new WebServiceRasControl();
                delete.DeletarAtividade(id);
                Page.RegisterClientScriptBlock("Aviso",
                                               "<script type= text/javascript>alert('Atividade excluído com sucesso!');</script>");
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