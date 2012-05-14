using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassesBasicas;
using System.Text.RegularExpressions;

namespace RasControlWeb
{
    public partial class ManutencaoUsuario : System.Web.UI.Page
    {
        string tipoTela = null;

        protected void Page_Load(object sender, EventArgs e)
        {

            tipoTela = (string)Session["TipoTela"];

            int idUsuario = 0;

            if (Session["IdUsuario"] != null)
            {
                idUsuario = (int)Session["IdUsuario"];
            }

            if (!IsPostBack)
            {
                lbErro.Text = string.Empty;
                tbNome.Text = "";
                tbCodigo.Text = "";
                tbCelular.Text = "";
                tbCpf.Text = "";
                tbEmail.Text = "";
                tbLogin.Text = "";
                tbObservacao.Text = "";
                tbRg.Text = "";
                tbSenha.Text = "";
                tbTelefone.Text = "";

                if (tipoTela == "Inclusao")
                {
                    ControleEnableDisable(true);
                }
                else if (tipoTela == "Alteracao")
                {
                    this.CarregarUsuarioTela(idUsuario);
                    ControleEnableDisable(true);

                }
                else if (tipoTela == "Detalhamento")
                {
                    this.CarregarUsuarioTela(idUsuario);
                    ControleEnableDisable(false);
                }

                dpTipoUsuario.DataSource =  Fachada.Fachada.Instancia.ConsultarAllPerfilUsuarioFiltros(-1, null);
                dpTipoUsuario.DataTextField = "descricao";
                dpTipoUsuario.DataValueField = "codigo";
                dpTipoUsuario.DataBind();      
            }

        }

        private void ControleEnableDisable(Boolean status)
        {
            tbNome.ReadOnly = !status;
            tbObservacao.ReadOnly = !status;
            tbCodigo.ReadOnly = !status;
            tbCelular.ReadOnly = !status;
            tbCpf.ReadOnly = !status;
            tbEmail.ReadOnly = !status;
            tbLogin.ReadOnly = !status;
            tbRg.ReadOnly = !status;
            tbSenha.ReadOnly = !status;
            tbTelefone.ReadOnly = !status;
            dpTipoUsuario.Enabled = status;
            btGravar.Enabled = status;
        }

        private void CarregarUsuarioTela(int idUsuario)
        {
            try
            {
                Usuario usuario = Fachada.Fachada.Instancia.ConsultarUsuarioPorId(idUsuario);

                tbCodigo.Text = usuario.Codigo.ToString();
                tbNome.Text = usuario.Nome;
                tbObservacao.Text = usuario.Observacao;
                tbCelular.Text = usuario.Celular;
                tbCpf.Text = usuario.Cpf;
                tbEmail.Text = usuario.Email;
                tbLogin.Text = usuario.Login;
                tbRg.Text = usuario.Rg;
                tbSenha.Text = usuario.Senha;
                tbTelefone.Text = usuario.Telefone;
                dpTipoUsuario.SelectedValue = usuario.PerfilUsuario.Codigo.ToString();
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

        public bool ValidaNumero(string numero)
        {
            Regex rx = new Regex(@"^\d+$");
            return rx.IsMatch(numero);
        }

        public bool ValidaCPF(string cpf)
        {
            Regex rx = new Regex(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$");
            return rx.IsMatch(cpf);
        }

        public bool ValidaEmail(string email)
        {
            Regex rx = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
            return rx.IsMatch(email);
        }

        protected void btGravar_Click(object sender, EventArgs e)
        {
            lbErro.Text = string.Empty;

            try
            {
                if (tipoTela == "Inclusao")
                {
                    Usuario usuario = new Usuario();
                    usuario.Nome = tbNome.Text;
                    usuario.Celular = tbCelular.Text;
                    usuario.Telefone = tbTelefone.Text;
                    usuario.Cpf = tbCpf.Text;
                    usuario.Email = tbEmail.Text;
                    usuario.Login = tbLogin.Text;
                    usuario.Rg = tbRg.Text;
                    usuario.Senha = tbSenha.Text;
                    usuario.Observacao = tbObservacao.Text;
                    usuario.PerfilUsuario = Fachada.Fachada.Instancia.ConsultarPerfilUsuarioPorId(int.Parse(dpTipoUsuario.SelectedValue));

                    Fachada.Fachada.Instancia.CadastrarUsuario(usuario);

                    Page.RegisterClientScriptBlock("Aviso",
                                                   "<script type= text/javascript>alert('Usuario cadastrado com sucesso!');</script>");
                    Response.Redirect("ListagemUsuario.aspx");

                }
                else if (tipoTela == "Alteracao")
                {
                    Usuario usuario = new Usuario();

                    usuario.Codigo = int.Parse(tbCodigo.Text);
                    usuario.Nome = tbNome.Text;
                    usuario.Celular = tbCelular.Text;
                    usuario.Telefone = tbTelefone.Text;
                    usuario.Cpf = tbCpf.Text;
                    usuario.Email = tbEmail.Text;
                    usuario.Login = tbLogin.Text;
                    usuario.Rg = tbRg.Text;
                    usuario.Senha = tbSenha.Text;
                    usuario.Observacao = tbObservacao.Text;
                    usuario.PerfilUsuario = Fachada.Fachada.Instancia.ConsultarPerfilUsuarioPorId(int.Parse(dpTipoUsuario.SelectedValue));

                    Fachada.Fachada.Instancia.AlterarUsuario(usuario);

                    Page.RegisterClientScriptBlock("Aviso",
                                                   "<script type= text/javascript>alert('Usuario alterado com sucesso!');</script>");

                }

            }
            catch (Exception ex)
            {
                if (!ValidaCPF(tbCpf.Text.ToString()))
                {
                    lbErro.Text = ex.Message;
                }
                else if (!ValidaEmail(tbEmail.Text.ToString()))
                {
                    lbErro.Text = ex.Message;
                }
                else
                {
                lbErro.Text = ex.Message;

                }

            }
        }
    }
}