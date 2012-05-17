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
    public partial class Login : System.Web.UI.Page
    {
        WebServiceRasControl service = new WebServiceRasControl();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbErro.Text = null;
                tbLogin.Text = null;
                tbSenha.Text = null;
            }
        }

        protected void btLogar_Click(object sender, EventArgs e)
        {
            try
            {
                lbErro.Text = null;
                Usuario usuario = service.ValidarLogin(tbLogin.Text, tbSenha.Text);
                Response.Redirect("Index.aspx");

            }
            catch (Exception ex)
            {
                lbErro.Text = ex.Message;
            }
            
        }
    }
}