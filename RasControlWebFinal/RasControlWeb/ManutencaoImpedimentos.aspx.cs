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
    public partial class WebForm8 : System.Web.UI.Page
    {
        string tipoTela = null;

        protected void Page_Load(object sender, EventArgs e)
        {

            tipoTela = (string)Session["TipoTela"];

            int id_impedimento = 0;

            if (Session["id_impedimento"] != null)             
            {
                id_impedimento = (int)Session["id_impedimento"];
            }

            if (!IsPostBack) 
            {
                lbErro.Text = string.Empty;
                tbCodigo.Text = "";
                tbCodigoSprint.Text = "";
                tbDescricao.Text = "";


                if (tipoTela == "Inclusao") 
                {
                    ControleEnableDisable(true);
                }
                else if (tipoTela == "Alteracao") 
                {
                    this.CarregarImpedimentoTela(id_impedimento);
                    ControleEnableDisable(true);
                }
                else if (tipoTela == "Detalhamento") 
                {
                    this.CarregarImpedimentoTela(id_impedimento);
                    ControleEnableDisable(false);
                }
            }
        }

        private void ControleEnableDisable(Boolean status) 
        {
            tbCodigo.ReadOnly = !status;
            tbCodigoSprint.ReadOnly = !status;
            tbDescricao.ReadOnly = !status;

            btGravar.Enabled = status;
        }

        private void CarregarImpedimentoTela(int id_impedimento) 
        {
            try
            {
                WebServiceRasControl service = new WebServiceRasControl();

                Impedimentos impedimentos = service.ConsultarImpedimentoPorId(id_impedimento);

                tbCodigo.Text = impedimentos.Id_Impedimento.ToString();
                tbCodigoSprint.Text = impedimentos.Id_Sprint.ToString();
                tbDescricao.Text = impedimentos.Descricao;

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

                       Impedimentos impedimentos = new Impedimentos();

                       impedimentos.Id_Sprint = int.Parse(tbCodigoSprint.Text) ;
                       impedimentos.Descricao = tbDescricao.Text;
                       
                       WebServiceRasControl service = new WebServiceRasControl();
                       service.CadastrarImpedimento(impedimentos);


                       Page.RegisterClientScriptBlock("Aviso",
                                                      "<script type= text/javascript>alert('Impedimento cadastrado com sucesso!');</script>");

                   }
                   else if (tipoTela == "Alteracao")
                   {
                       Impedimentos impedimentos = new Impedimentos();

                       impedimentos.Id_Impedimento = int.Parse(tbCodigo.Text);
                       impedimentos.Id_Sprint = int.Parse(tbCodigoSprint.Text);
                       impedimentos.Descricao = tbDescricao.Text;

                       WebServiceRasControl service = new WebServiceRasControl();
                       service.AlterarImpedimento(impedimentos);

                       Page.RegisterClientScriptBlock("Aviso",
                                                      "<script type= text/javascript>alert('Impedimentos alterado com sucesso!');</script>");

                   }

               }
               catch (Exception ex)
               {
                   lbErro.Text = ex.Message;

               }
          }
    }
}