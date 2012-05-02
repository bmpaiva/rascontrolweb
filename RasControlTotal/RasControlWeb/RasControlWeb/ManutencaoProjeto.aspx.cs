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
    public partial class ManutencaoProjeto : System.Web.UI.Page
    {

        string tipoTela = null;

        protected void Page_Load(object sender, EventArgs e)
        {


            tipoTela = (string)Session["TipoTela"];

            int idProjeto = 0;

            if (Session["IdProjeto"] != null)
            {
                idProjeto = (int)Session["IdProjeto"];
            }

            if (!IsPostBack)
            {
                lbErro.Text = string.Empty;
                tbNome.Text = "";
                tbDescricao.Text = "";
                tbDTInclusao.Text = "";                
                tbCodigo.Text = "";

                if (tipoTela == "Inclusao")
                {
                    ControleEnableDisable(true);
                }
                else if (tipoTela == "Alteracao")
                {
                    this.CarregarProjetoTela(idProjeto);
                    ControleEnableDisable(true);

                }
                else if (tipoTela == "Detalhamento")
                {
                    this.CarregarProjetoTela(idProjeto);
                    ControleEnableDisable(false);
                }
            }
        }

        private void ControleEnableDisable(Boolean status)
        {
            tbNome.ReadOnly = !status;         
            tbDescricao.ReadOnly = !status;
            tbDTInclusao.ReadOnly = !status;
            btGravar.Enabled = status;
        }

        private void CarregarProjetoTela(int idProjeto)
        {
            try
            {
                Projeto projeto = Fachada.Fachada.Instancia.ConsultarProjetoPorId(idProjeto);

                tbCodigo.Text = projeto.Codigo.ToString();
                tbNome.Text = projeto.Nome;                
                tbDescricao.Text = projeto.Descricao;
                tbDTInclusao.Text = projeto.DtInclusao.ToString();
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
                    Projeto projeto = new Projeto();                 
                    projeto.Nome = tbNome.Text;
                    projeto.Descricao = tbDescricao.Text;
                    projeto.DtInclusao = DateTime.Parse(tbDTInclusao.Text, new CultureInfo("pt-BR", false)); 
                   

                    Fachada.Fachada.Instancia.CadastrarProjeto(projeto);

                    Page.RegisterClientScriptBlock("Aviso",
                                                   "<script type= text/javascript>alert('Projeto cadastrado com sucesso!');</script>");
                    Response.Redirect("ListagemProjeto.aspx");

                }
                else if (tipoTela == "Alteracao")
                {
                    Projeto projeto = new Projeto();

                    projeto.Codigo = int.Parse(tbCodigo.Text);
                    projeto.Nome = tbNome.Text;
                    projeto.Descricao = tbDescricao.Text;
                    projeto.DtInclusao = DateTime.Parse(tbDTInclusao.Text, new CultureInfo("pt-BR", false)); 
                    

                    Fachada.Fachada.Instancia.AlterarProjeto(projeto);

                    Page.RegisterClientScriptBlock("Aviso",
                                                   "<script type= text/javascript>alert('Usuario alterado com sucesso!');</script>");
                    Response.Redirect("ListagemProjeto.aspx");
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