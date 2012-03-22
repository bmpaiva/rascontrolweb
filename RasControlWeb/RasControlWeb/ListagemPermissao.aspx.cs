using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebService;

namespace RasControlWeb
{
    public partial class ListagemPermissao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btPesquisar_Click(object sender, EventArgs e)
        {
            WebServiceRasControl service = new WebServiceRasControl();
            GridView1.DataSource = service.ListarPermissoes();
            GridView1.DataBind();
        }
    }
}