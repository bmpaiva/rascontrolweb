using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Text;
using Fachada;

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

        [WebMethod]
        public XmlDocument XmlBurnDown(int idProjeto, int idSprint)
        {
            XmlDocument xmlDocumento = new XmlDocument();
            StringBuilder xmlString = new StringBuilder();

             int quantidadeDiasSprint = Fachada.Fachada.Instancia.SelectQtdDiasSprint(1, 1);
             double quantidadeHorasPlanejadaSprint = Fachada.Fachada.Instancia.SelectQtdHorasPlanejadaSprint(1, 1);
             double quantidadeHorasPorDia = 1;

             if (quantidadeDiasSprint > 0 && quantidadeHorasPlanejadaSprint > 0)
             {
                 quantidadeHorasPorDia = quantidadeHorasPlanejadaSprint / quantidadeDiasSprint;
             }

             xmlString.Append("<?xml version=\"1.0\" encoding=\"iso-8859-1\"?><?xml-stylesheet type='text/xsl' version='1.0'?>");
             xmlString.Append("<Burndown xmlns=\"http://www.w3.org/2001/XMLSchema\">");
             xmlString.Append("<Sprint>");
             xmlString.Append("<NumeroProjeto> "+ idProjeto.ToString() + " </NumeroProjeto>");
             xmlString.Append("<NumeroSprint> " + idSprint.ToString() + " </NumeroSprint>");
             xmlString.Append("<QtdDias> " + quantidadeDiasSprint.ToString() + " </QtdDias>");
             xmlString.Append("<Dias>");


             double qtdPlanejadoRestante = 0;
             for (int i = 1; i <= quantidadeDiasSprint; i++)
             {
                 qtdPlanejadoRestante = qtdPlanejadoRestante + quantidadeHorasPorDia;
                 double qtdHorasRalizadaDia = Fachada.Fachada.Instancia.SelectTamanhoRealizadoDia(idProjeto, idSprint, i);
                 
                 xmlString.Append("<Dia>");
                 xmlString.Append("<Numero> 1 </Numero>");
                 xmlString.Append("<Previsto> " + qtdPlanejadoRestante.ToString() + " </Previsto>");
                 xmlString.Append("<Realizado> " + qtdHorasRalizadaDia.ToString() + " </Realizado>");
                 xmlString.Append("</Dia>");
             }

            xmlString.Append("</Dias>");
            xmlString.Append("</Sprint>");
            xmlString.Append("</Burndown>");

             xmlDocumento.LoadXml(xmlString.ToString());
            return xmlDocumento;


            /*
            xmlString.Append("<?xml version=\"1.0\" encoding=\"iso-8859-1\"?><?xml-stylesheet type='text/xsl' version='1.0'?>");
            xmlString.Append("<Burndown xmlns=\"http://www.w3.org/2001/XMLSchema\">");
            xmlString.Append("<Sprint>");
            xmlString.Append("<NumeroProjeto> 1 </NumeroProjeto>");
            xmlString.Append("<NumeroSprint> 2 </NumeroSprint>");
            xmlString.Append("<QtdDias> 5 </QtdDias>");
            xmlString.Append("<Dias>");
            xmlString.Append("<Dia>");
            xmlString.Append("<Numero> 1 </Numero>");
            xmlString.Append("<Previsto> 100 </Previsto>");
            xmlString.Append("<Realizado> 100 </Realizado>");           
            xmlString.Append("</Dia>");
            xmlString.Append("<Dia>");
            xmlString.Append("<Numero> 2 </Numero>");
            xmlString.Append("<Previsto> 75 </Previsto>");
            xmlString.Append("<Realizado> 90 </Realizado>");
            xmlString.Append("</Dia>");
            xmlString.Append("<Dia>");
            xmlString.Append("<Numero> 3 </Numero>");
            xmlString.Append("<Previsto> 50 </Previsto>");
            xmlString.Append("<Realizado> 60 </Realizado>");
            xmlString.Append("</Dia>");
            xmlString.Append("<Dia>");
            xmlString.Append("<Numero> 4 </Numero>");
            xmlString.Append("<Previsto> 25 </Previsto>");
            xmlString.Append("<Realizado> 60 </Realizado>");
            xmlString.Append("</Dia>");
            xmlString.Append("<Dia>");
            xmlString.Append("<Numero> 5 </Numero>");
            xmlString.Append("<Previsto> 0 </Previsto>");
            xmlString.Append("<Realizado> 20 </Realizado>");
            xmlString.Append("</Dia>");
            xmlString.Append("</Dias>");
            xmlString.Append("</Sprint>");
            xmlString.Append("</Burndown>");
            
            xmlDocumento.LoadXml(xmlString.ToString());
            return xmlDocumento;
            */

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
    }
}
