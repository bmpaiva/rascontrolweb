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
    public partial class ManutencaoAtividade : System.Web.UI.Page
    {
        WebServiceRasControl service = new WebServiceRasControl();

        string tipoTela = null;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                this.BindGrid();
            }

            tipoTela = (string)Session["TipoTela"];

            int id_atividade = 0;

            if (Session["id_atividade"] != null)
            {
                id_atividade = (int)Session["id_atividade"];
            }

            if (!IsPostBack)
            {
                lbErro.Text = string.Empty;
                tbCodigoAtividade.Text = "";
                //   tbCodigoTipoAtividade.Text = "";
                dropboxTipoAtividade.Text = "";
                tbCodigoEstoriaSprint.Text = "";
                tbDescricao.Text = "";
                tbDuracaoEstimada.Text = "";
                tbDuracaoRealizada.Text = "";



                if (tipoTela == "Inclusao")
                {
                    ControleEnableDisable(true);
                }
                else if (tipoTela == "Alteracao")
                {
                    this.CarregarAtividadeTela(id_atividade);
                    ControleEnableDisable(true);

                }
                else if (tipoTela == "Detalhamento")
                {
                    this.CarregarAtividadeTela(id_atividade);
                    ControleEnableDisable(false);
                }
                            
            }
        }

        private void BindGrid()
        {
            dropboxTipoAtividade.DataSource = service.ConsultarAllTipoAtividadeFiltros(-1, null);
            dropboxTipoAtividade.DataTextField = "descricao";
            dropboxTipoAtividade.DataValueField = "codigo";
            dropboxTipoAtividade.DataBind();
        }

        private void ControleEnableDisable(Boolean status)
        {
          //  tbCodigoTipoAtividade.ReadOnly = !status;
            tbCodigoEstoriaSprint.ReadOnly = !status;
            tbDescricao.ReadOnly = !status;
            tbDuracaoEstimada.ReadOnly = !status;
            tbDuracaoRealizada.ReadOnly = !status;

            btGravar.Enabled = status;
        }

        private void CarregarAtividadeTela(int id_atividade)
        {
            try
            {

                WebServiceRasControl service = new WebServiceRasControl();

                Atividade atividade = service.ConsultarAtividadePorId(id_atividade);

              //  Atividade atividade = Fachada.Fachada.Instancia.ConsultarAtividadePorId(id_atividade);

                tbCodigoAtividade.Text = atividade.Id_Atividade.ToString();
                tbDescricao.Text = atividade.Descricao;
                dropboxTipoAtividade.Text = atividade.Id_Tipo_Atividade.ToString();
            //    tbCodigoTipoAtividade.Text = atividade.Id_Tipo_Atividade.ToString();
                tbCodigoEstoriaSprint.Text = atividade.Id_Estoria_Sprint.ToString();
                tbDuracaoEstimada.Text = atividade.Duracao_Estimada.ToString();
                tbDuracaoRealizada.Text = atividade.Duracao_Realizada.ToString();

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

                    Atividade atividade = new Atividade();

                    atividade.Descricao = tbDescricao.Text;

                  //  atividade.Id_Tipo_Atividade = int.Parse(tbCodigoTipoAtividade.Text);
                    atividade.Id_Tipo_Atividade = int.Parse(dropboxTipoAtividade.Text);
                    atividade.Id_Estoria_Sprint = int.Parse(tbCodigoEstoriaSprint.Text);
                    atividade.Duracao_Estimada = float.Parse(tbDuracaoEstimada.Text);
                    atividade.Duracao_Realizada = float.Parse(tbDuracaoRealizada.Text);

                    WebServiceRasControl service = new WebServiceRasControl();
                    service.CadastrarAtividade(atividade);


                    Page.RegisterClientScriptBlock("Aviso",
                                                   "<script type= text/javascript>alert('Atividade cadastrado com sucesso!');</script>");

                }
                else if (tipoTela == "Alteracao")
                {
                    Atividade atividade = new Atividade();

                    atividade.Id_Atividade = int.Parse(tbCodigoAtividade.Text);
                    atividade.Descricao = tbDescricao.Text;

                 //   atividade.Id_Tipo_Atividade = int.Parse(tbCodigoTipoAtividade.Text);
                    atividade.Id_Estoria_Sprint = int.Parse(tbCodigoEstoriaSprint.Text);
                    atividade.Duracao_Estimada = double.Parse(tbDuracaoEstimada.Text);
                    atividade.Duracao_Realizada = double.Parse(tbDuracaoRealizada.Text);

                    WebServiceRasControl service = new WebServiceRasControl();
                    service.AlterarAtividade(atividade);

               //     Fachada.Fachada.Instancia.AlterarAtividade(atividade);

                    Page.RegisterClientScriptBlock("Aviso",
                                                   "<script type= text/javascript>alert('Atividade alterado com sucesso!');</script>");

                }

            }
            catch (Exception ex)
            {
                lbErro.Text = ex.Message;

            }

        }

    }
}