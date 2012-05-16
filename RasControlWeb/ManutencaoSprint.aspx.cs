using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassesBasicas;
using System.Globalization;

namespace RasControlWeb
{
    public partial class ManutencaoSprint : System.Web.UI.Page
    {
        string tipoTela = null;

        protected void Page_Load(object sender, EventArgs e)
        {

            tipoTela = (string)Session["TipoTela"];

            int idSprint = 0;            

            if (Session["IdSprint"] != null)
            {
                idSprint = (int)Session["IdSprint"];
            }
           
            if (!IsPostBack)
            {
                lbErro.Text = string.Empty;
                tbDescricao.Text = "";

                if (tipoTela == "Inclusao")
                {
                    ControleEnableDisable(true);
                }
                else if (tipoTela == "Alteracao")
                {
                    this.CarregarSprintTela(idSprint);
                    ControleEnableDisable(true);

                }
                else if (tipoTela == "Detalhamento")
                {
                    this.CarregarSprintTela(idSprint);
                    ControleEnableDisable(false);
                }
            }

        }

        private void ControleEnableDisable(Boolean status)
        {
            tbCodigo.ReadOnly = !status;
            tbDescricao.ReadOnly = !status;
            tbDInicio.ReadOnly = !status;
            tbDFim.ReadOnly = !status;
            tbQTDDias.ReadOnly = !status;
        }

        private void CarregarSprintTela(int idSprint)
        {
            try
            {
                Sprint sprint = Fachada.Fachada.Instancia.ConsultarSprintPorId(idSprint);

                tbCodigo.Text = sprint.Id_Sprint.ToString();
                tbDescricao.Text = sprint.Descricao;
                tbDInicio.Text = sprint.Data_Inicio.ToString();
                tbDFim.Text = sprint.Data_Fim.ToString();
                tbQTDDias.Text = sprint.Qtd_Dias.ToString();
                
            }
            catch (Exception ex)
            {
                lbErro.Text = ex.Message;

            }
        }

        protected void btGravar_Click(object sender, EventArgs e)
        {
            lbErro.Text = string.Empty;

            try
            {
                if (tipoTela == "Inclusao")
                {
                    Sprint sprint = new Sprint();
                    sprint.Id_Projeto = Convert.ToInt32(Request.Params["idProjeto"]);
                    sprint.Descricao = tbDescricao.Text;
                    sprint.Data_Inicio = DateTime.Parse(tbDInicio.Text, new CultureInfo("pt-BR", false));

                    sprint.Data_Fim = DateTime.Parse(tbDFim.Text, new CultureInfo("pt-BR", false));
                    
                    sprint.Qtd_Dias = int.Parse(tbQTDDias.Text);

                    Fachada.Fachada.Instancia.CadastrarSprint(sprint);

                    Page.RegisterClientScriptBlock("Aviso",
                                                   "<script type= text/javascript>alert('Sprint cadastrado com sucesso!');</script>");
                    
                }
                else if (tipoTela == "Alteracao")
                {
                    Sprint sprint = new Sprint();
                    sprint.Id_Sprint = Convert.ToInt32(tbCodigo.Text);
                    sprint.Id_Projeto = Convert.ToInt32(Request.Params["idProjeto"]);
                    sprint.Descricao = tbDescricao.Text;
                    sprint.Data_Inicio = DateTime.Parse(tbDInicio.Text, new CultureInfo("pt-BR", false));
                    sprint.Data_Fim = DateTime.Parse(tbDFim.Text, new CultureInfo("pt-BR", false));
                    sprint.Qtd_Dias = int.Parse(tbQTDDias.Text);

                    Fachada.Fachada.Instancia.AlterarSprint(sprint);

                    Page.RegisterClientScriptBlock("Aviso",
                                                   "<script type= text/javascript>alert('Sprint alterado com sucesso!');</script>");
                    Response.Redirect("ListagemSprint.aspx");
                }

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
    }
}