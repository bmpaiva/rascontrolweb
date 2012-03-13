using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Genericas;
using ClassesBasicas;
using Fachada;

namespace Testes
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Permissao permissao = new Permissao();
            permissao.Codigo = 1;
            permissao.Descricao = "CADASTRARUSU";
            permissao.Observacao = "Cadastrar usuário";
            Fachada.Fachada.Instancia.CadastrarPermissao(permissao);

            
         

        }
    }
}
