using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Text;
using Fachada;
using ClassesBasicas;

namespace WebService
{
    /// <summary>
    /// Summary description for WebServiceRasControl
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceRasControl : System.Web.Services.WebService
    {
        #region Graficos

        [WebMethod]
        public XmlDocument XmlBurnDown(int idProjeto, int idSprint)
        {
            XmlDocument xmlDocumento = new XmlDocument();
            StringBuilder xmlString = new StringBuilder();

             int quantidadeDiasSprint = Fachada.Fachada.Instancia.SelectQtdDiasSprint(1, 1);
             double quantidadeHorasPlanejadaSprint = Fachada.Fachada.Instancia.SelectQtdHorasPlanejadaSprint(1, 1);
             double quantidadeHorasPorDia = 1;

             if (quantidadeDiasSprint > 1 && quantidadeHorasPlanejadaSprint > 0)
             {
                 quantidadeHorasPorDia = Math.Truncate(quantidadeHorasPlanejadaSprint / (quantidadeDiasSprint - 1));
             }

             xmlString.Append("<?xml version=\"1.0\" encoding=\"iso-8859-1\"?><?xml-stylesheet type='text/xsl' version='1.0'?>");
             xmlString.Append("<Burndown xmlns=\"http://www.w3.org/2001/XMLSchema\">");
             xmlString.Append("<Sprint>");
             xmlString.Append("<NumeroProjeto> "+ idProjeto.ToString() + " </NumeroProjeto>");
             xmlString.Append("<NumeroSprint> " + idSprint.ToString() + " </NumeroSprint>");
             xmlString.Append("<QtdDias> " + quantidadeDiasSprint.ToString() + " </QtdDias>");
             xmlString.Append("<Dias>");


             double qtdPlanejadoRestante = quantidadeHorasPlanejadaSprint;
             double valorRealizado = qtdPlanejadoRestante;
             for (int i = 1; i <= quantidadeDiasSprint; i++)
             {   
                 double qtdHorasRalizadaDia = Fachada.Fachada.Instancia.SelectTamanhoRealizadoDia(idProjeto, idSprint, i);
                 if (qtdHorasRalizadaDia > 0)
                 {
                     valorRealizado = valorRealizado - qtdHorasRalizadaDia;  
                 }
                 
                 xmlString.Append("<Dia>");
                 xmlString.Append("<Numero> " + i.ToString() + " </Numero>");
                 xmlString.Append("<Previsto> " + qtdPlanejadoRestante.ToString() + " </Previsto>");
                 xmlString.Append("<Realizado> " + valorRealizado.ToString() + " </Realizado>");
                 xmlString.Append("</Dia>");

                 qtdPlanejadoRestante = qtdPlanejadoRestante - quantidadeHorasPorDia;
             }

            xmlString.Append("</Dias>");
            xmlString.Append("</Sprint>");
            xmlString.Append("</Burndown>");

             xmlDocumento.LoadXml(xmlString.ToString());
            return xmlDocumento;

        }

        [WebMethod]
        public XmlDocument XmlDesempenhoMembrosProjeto (int idProjeto)
        {
            XmlDocument xmlDocumento = new XmlDocument();
            StringBuilder xmlString = new StringBuilder();

            xmlString.Append("<?xml version=\"1.0\" encoding=\"iso-8859-1\"?><?xml-stylesheet type='text/xsl' version='1.0'?>");
            xmlString.Append("<Avaliacao xmlns=\"http://www.w3.org/2001/XMLSchema\">");
            xmlString.Append("<Projetos>");
            xmlString.Append("<Projeto>");
            xmlString.Append("<QtdSprints> 5 </QtdSprints>");
            xmlString.Append("<Membros>");
            xmlString.Append("<QtdMembros> 5 </QtdMembros>");
            
            xmlString.Append("<Membro>");
            xmlString.Append("<Nome> Nilson </Nome>");
            xmlString.Append("<Sprints>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 1 </Codigo>");
            xmlString.Append("<Media> 8 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 2 </Codigo>");
            xmlString.Append("<Media> 4 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 3 </Codigo>");
            xmlString.Append("<Media> 6 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 4 </Codigo>");
            xmlString.Append("<Media> 9 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 5 </Codigo>");
            xmlString.Append("<Media> 10 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("</Sprints>");
            xmlString.Append("</Membro>");

            xmlString.Append("<Membro>");
            xmlString.Append("<Nome> Gisele </Nome>");
            xmlString.Append("<Sprints>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 1 </Codigo>");
            xmlString.Append("<Media> 2 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 2 </Codigo>");
            xmlString.Append("<Media> 4 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 3 </Codigo>");
            xmlString.Append("<Media> 5 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 4 </Codigo>");
            xmlString.Append("<Media> 5 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 5 </Codigo>");
            xmlString.Append("<Media> 8 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("</Sprints>");
            xmlString.Append("</Membro>");


            xmlString.Append("<Membro>");
            xmlString.Append("<Nome> Igor </Nome>");
            xmlString.Append("<Sprints>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 1 </Codigo>");
            xmlString.Append("<Media> 5 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 2 </Codigo>");
            xmlString.Append("<Media> 4 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 3 </Codigo>");
            xmlString.Append("<Media> 3 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 4 </Codigo>");
            xmlString.Append("<Media> 2 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 5 </Codigo>");
            xmlString.Append("<Media> 1 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("</Sprints>");
            xmlString.Append("</Membro>");


            xmlString.Append("<Membro>");
            xmlString.Append("<Nome> Pedro </Nome>");
            xmlString.Append("<Sprints>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 1 </Codigo>");
            xmlString.Append("<Media> 1 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 2 </Codigo>");
            xmlString.Append("<Media> 2 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 3 </Codigo>");
            xmlString.Append("<Media> 3 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 4 </Codigo>");
            xmlString.Append("<Media> 4 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 5 </Codigo>");
            xmlString.Append("<Media> 5 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("</Sprints>");
            xmlString.Append("</Membro>");


            xmlString.Append("<Membro>");
            xmlString.Append("<Nome> Bruno </Nome>");
            xmlString.Append("<Sprints>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 1 </Codigo>");
            xmlString.Append("<Media> 8 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 2 </Codigo>");
            xmlString.Append("<Media> 8 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 3 </Codigo>");
            xmlString.Append("<Media> 8 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 4 </Codigo>");
            xmlString.Append("<Media> 8 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("<Sprint>");
            xmlString.Append("<Codigo> 5 </Codigo>");
            xmlString.Append("<Media> 7 </Media>");
            xmlString.Append("</Sprint>");
            xmlString.Append("</Sprints>");
            xmlString.Append("</Membro>");
            

            xmlString.Append("</Membros>");
            xmlString.Append("</Projeto>");
            xmlString.Append("</Projetos>");
            xmlString.Append("</Avaliacao>");

            xmlDocumento.LoadXml(xmlString.ToString());
            return xmlDocumento;


        }

        [WebMethod]
        public XmlDocument XmlBurnUp(int idProjeto, int idSprint)
        {
            XmlDocument xmlDocumento = new XmlDocument();
            StringBuilder xmlString = new StringBuilder();

            int quantidadeDiasSprint = Fachada.Fachada.Instancia.SelectQtdDiasSprint(1, 1);
            double quantidadeHorasPlanejadaSprint = Fachada.Fachada.Instancia.SelectQtdHorasPlanejadaSprint(1, 1);
            double quantidadeHorasPorDia = 1;

            if (quantidadeDiasSprint > 1 && quantidadeHorasPlanejadaSprint > 0)
            {
                quantidadeHorasPorDia = Math.Truncate(quantidadeHorasPlanejadaSprint / (quantidadeDiasSprint - 1));
            }

            xmlString.Append("<?xml version=\"1.0\" encoding=\"iso-8859-1\"?><?xml-stylesheet type='text/xsl' version='1.0'?>");
            xmlString.Append("<Burndown xmlns=\"http://www.w3.org/2001/XMLSchema\">");
            xmlString.Append("<Sprint>");
            xmlString.Append("<NumeroProjeto> " + idProjeto.ToString() + " </NumeroProjeto>");
            xmlString.Append("<NumeroSprint> " + idSprint.ToString() + " </NumeroSprint>");
            xmlString.Append("<QtdDias> " + quantidadeDiasSprint.ToString() + " </QtdDias>");
            xmlString.Append("<Dias>");


            double qtdPlanejado = 0;//quantidadeHorasPlanejadaSprint;
            double valorRealizado = 0;//qtdPlanejadoRestante;
            for (int i = 1; i <= quantidadeDiasSprint; i++)
            {
                double qtdHorasRalizadaDia = Fachada.Fachada.Instancia.SelectTamanhoRealizadoDia(idProjeto, idSprint, i);
                if (qtdHorasRalizadaDia > 0)
                {
                    valorRealizado = valorRealizado + qtdHorasRalizadaDia;
                }

                xmlString.Append("<Dia>");
                xmlString.Append("<Numero> " + i.ToString() + " </Numero>");
                xmlString.Append("<Previsto> " + qtdPlanejado.ToString() + " </Previsto>");
                xmlString.Append("<Realizado> " + valorRealizado.ToString() + " </Realizado>");
                xmlString.Append("</Dia>");

                qtdPlanejado = qtdPlanejado + quantidadeHorasPorDia;
            }

            xmlString.Append("</Dias>");
            xmlString.Append("</Sprint>");
            xmlString.Append("</Burndown>");

            xmlDocumento.LoadXml(xmlString.ToString());
            return xmlDocumento;

        }

        #endregion

        #region Permissao

        [WebMethod]
        public void CadastrarPermissao(Permissao permissao)
        {
            try
            {
                Fachada.Fachada.Instancia.CadastrarPermissao(permissao);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public void AlterarPermissao(Permissao permissao)
        {
            try
            {
                Fachada.Fachada.Instancia.AlterarPermissao(permissao);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public void DeletarPermissao(int idPermissao)
        {
            try
            {
                Fachada.Fachada.Instancia.DeletarPermissao(idPermissao);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public Permissao ConsultarPermissaoPorId(int idPermissao)
        {
            try
            {

                return Fachada.Fachada.Instancia.ConsultarPermissaoPorId(idPermissao);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public List<Permissao> ConsultarAllPermissaoFiltros(int codigo, string descricao)
        {
            try
            {
                return Fachada.Fachada.Instancia.ConsultarAllPermissaoFiltros(codigo,descricao);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
               
        [WebMethod]
        public List<Permissao> ListarPermissoes()
        {
            try
            {
                return Fachada.Fachada.Instancia.ListarPermissoes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion


      #region PerfilUsuario

        [WebMethod]
        public void CadastrarPerfilUsuario(PerfilUsuario perfilUsuario)
        {
          try
          {
            Fachada.Fachada.Instancia.CadastrarPerfilUsuario(perfilUsuario);

          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

        [WebMethod]
        public void AlterarPerfilUsuario(PerfilUsuario perfilUsuario)
        {
          try
          {
            Fachada.Fachada.Instancia.AlterarPerfilUsuario(perfilUsuario);

          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

        [WebMethod]
        public void DeletarPerfilUsuario(int idPerfilUsuario)
        {
          try
          {
            Fachada.Fachada.Instancia.DeletarPerfilUsuario(idPerfilUsuario);
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

        [WebMethod]
        public PerfilUsuario ConsultarPerfilUsuarioPorId(int idPerfilUsuario)
        {
          try
          {

            return Fachada.Fachada.Instancia.ConsultarPerfilUsuarioPorId(idPerfilUsuario);
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

        [WebMethod]
        public List<PerfilUsuario> ConsultarAllPerfilUsuarioFiltros(int codigo, string descricao)
        {
          try
          {
            return Fachada.Fachada.Instancia.ConsultarAllPerfilUsuarioFiltros(codigo, descricao);
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

        [WebMethod]
        public List<PerfilUsuario> ListarPerfilUsuario()
        {
          try
          {
            return Fachada.Fachada.Instancia.ListarPerfilUsuario();
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }

      #endregion




    }
}
