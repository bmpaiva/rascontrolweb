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

            int id_tipoatividade = 0;

            if (Session["id_tipoatividade"] != null) 
            {
                id_tipoatividade = (int)Session["id_tipoatividade"];
            }

            if (!IsPostBack) 
            {
                lbErro.Text = string.Empty;
                tbCodigo.Text = "";
                tbDescricao.Text = "";

                if (tipoTela == "Inclusao") 
                {
                    this.CarregarTipoAtividadeTela(id_tipoatividade);
                    ControleEnableDisable(true);
                }
                else if (tipoTela == "Alteracao") 
                {
                    this.CarregarTipoAtividadeTela(id_tipoatividade);
                    ControleEnableDisable(true);
                }
                else if (tipoTela == "Detalhamento") 
                {
                    this.CarregarTipoAtividadeTela(id_tipoatividade);
                    ControleEnableDisable(false);
                }
            }
        }

        private void ControleEnableDisable(Boolean status) 
        {
            tbCodigo.ReadOnly = !status;
            tbDescricao.ReadOnly = !status;

            btGravar.Enabled = status;
        }

        //verificar
        private void CarregarTipoAtividadeTela(int id_tipoatividade) 
        {
            try
            {
                WebServiceRasControl service = new WebServiceRasControl();

                TipoAtividade tipoAtividade = service.ConsultarTipoAtividadePorId(id_tipoatividade);
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
                    TipoAtividade tipoAtividade = new TipoAtividade();

                    tipoAtividade.Descricao = tbDescricao.Text;

                    WebServiceRasControl service = new WebServiceRasControl();
                    service.CadastrarTipoAtividade(tipoAtividade);

                    Page.RegisterClientScriptBlock("Aviso",
                                                   "<script type= text/javascript>alert('Tipo atividade cadastrado com sucesso!');</script>");

                }
                else if (tipoTela == "Alteracao")
                {
                    TipoAtividade tipoAtividade = new TipoAtividade();

                    tipoAtividade.Codigo = int.Parse(tbCodigo.Text);
                    tipoAtividade.Descricao = tbDescricao.Text;

                    WebServiceRasControl service = new WebServiceRasControl();
                    service.AlterarTipoAtividade(tipoAtividade);

                    Page.RegisterClientScriptBlock("Aviso",
                                                  "<script type= text/javascript>alert('Tipo atividade alterado com sucesso!');</script>");

                }
            }
            catch (Exception ex) 
            {
                lbErro.Text = ex.Message;
            }
        }


    }
}