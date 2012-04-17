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
    public partial class WebForm2 : System.Web.UI.Page
    {
        string tipoTela = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            tipoTela = (string)Session["TipoTela"];

            int idPermissao = 0;

            if (Session["IdPermissao"] != null)
            {
                idPermissao = (int)Session["IdPermissao"];
            }

            if (!IsPostBack)
            {
                lbErro.Text = string.Empty;
                tbDescricao.Text = "";
                tbCodigo.Text = "";
                tbObservacao.Text = "";

                if (tipoTela == "Inclusao")
                {
                    ControleEnableDisable(true);
                }
                else if (tipoTela == "Alteracao")
                {
                    this.CarregarPermissaoTela(idPermissao);
                    ControleEnableDisable(true);

                }
                else if (tipoTela == "Detalhamento")
                {
                    this.CarregarPermissaoTela(idPermissao);
                    ControleEnableDisable(false);
                }
            }



        }

        private void ControleEnableDisable(Boolean status)
        {
            tbDescricao.ReadOnly = !status;
            tbObservacao.ReadOnly = !status;
            btGravar.Enabled = status;
        }

        private void CarregarPermissaoTela(int idPermissao)
        {
            try
            {
                Permissao permissao = Fachada.Fachada.Instancia.ConsultarPermissaoPorId(idPermissao);

                tbCodigo.Text = permissao.Codigo.ToString();
                tbDescricao.Text = permissao.Descricao;
                tbObservacao.Text = permissao.Observacao;

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
                    Permissao permissao = new Permissao();
                    permissao.Descricao = tbDescricao.Text;
                    permissao.Observacao = tbObservacao.Text;

                    Fachada.Fachada.Instancia.CadastrarPermissao(permissao);

                    Page.RegisterClientScriptBlock("Aviso",
                                                   "<script type= text/javascript>alert('Permissão cadastrada com sucesso!');</script>");

                }
                else if (tipoTela == "Alteracao")
                {
                    Permissao permissao = new Permissao();

                    permissao.Codigo = int.Parse(tbCodigo.Text);
                    permissao.Descricao = tbDescricao.Text;
                    permissao.Observacao = tbObservacao.Text;

                    Fachada.Fachada.Instancia.AlterarPermissao(permissao);

                    Page.RegisterClientScriptBlock("Aviso",
                                                   "<script type= text/javascript>alert('Permissão alterada com sucesso!');</script>");

                }

            }
            catch (Exception ex)
            {
                lbErro.Text = ex.Message;

            }

        }




    }
}