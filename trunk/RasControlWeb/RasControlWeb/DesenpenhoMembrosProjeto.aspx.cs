using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fachada;
using WebService;
using System.Xml;
using System.Web.UI.DataVisualization.Charting;
namespace RasControlWeb
{
    public partial class DesenpenhoMembrosProjeto : System.Web.UI.Page
    {
      

        private string FindTextoNo(XmlNode noPai, string campo)
        {
          return  (noPai[campo] == null || string.IsNullOrEmpty(noPai[campo].InnerText)) ? "..." : noPai[campo].InnerText;
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            WebServiceRasControl webService = new WebServiceRasControl();
            
            XmlDocument xml = webService.XmlDesempenhoMembrosProjeto(1);

            XmlNodeList projetos = xml.GetElementsByTagName("Projeto");

            string qtdTotalSprints = null;
            string qtdTotalMembros = null;
            string[] valoresx = null;
            double[] medias;

            foreach (XmlNode projeto in projetos)
            {
                if (projeto.Name == "Projeto")
                {
                    qtdTotalSprints = FindTextoNo(projeto, "QtdSprints");
                    valoresx = new string[Convert.ToInt16(qtdTotalSprints)];

                    for (int i = 1; i <= Convert.ToInt16(qtdTotalSprints); i++)
                    {
                        valoresx[i-1] = "Sprint " + i.ToString();
                    }

                        foreach (XmlNode membros in projeto)
                        {
                            if (membros.Name == "Membros")
                            {
                                qtdTotalMembros = FindTextoNo(membros, "QtdMembros");
                                int i = 0;
                                foreach (XmlNode membro in membros)
                                {

                                    if (membro.Name == "Membro")
                                    {
                                        string nome = FindTextoNo(membro, "Nome");
                                        medias = new double[Convert.ToInt16(qtdTotalSprints)];

                                        foreach (XmlNode sprints in membro)
                                        {

                                            if (sprints.Name == "Sprints")
                                            {
                                                int x = 0;
                                                foreach (XmlNode sprint in sprints)
                                                {
                                                    if (sprint.Name == "Sprint")
                                                    {
                                                        string codigo = FindTextoNo(sprint, "Codigo");
                                                        string media = FindTextoNo(sprint, "Media");
                                                        medias[x] = Convert.ToDouble(media);
                                                        x++;
                                                    }
                                                }
                                            }
                                        }

                                        ChartProjeto.Series.Add((i+1).ToString() + " " + nome);                                      
                                        ChartProjeto.Series[(i + 1).ToString() + " " + nome].Points.DataBindXY(valoresx, medias);
                                        ChartProjeto.Series[(i + 1).ToString() + " " + nome]["PieLabelStyle"] = "inside";
                                        ChartProjeto.Series[(i + 1).ToString() + " " + nome].ChartType = SeriesChartType.Line;
                                        ChartProjeto.Series[(i + 1).ToString() + " " + nome].BorderWidth = 3;
                                  
                                        i++;

                                    }
                                }

                            }
                        }
                }               
            }            
        }
    }
}