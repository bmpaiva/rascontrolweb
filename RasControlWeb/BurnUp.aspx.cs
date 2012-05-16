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
    public partial class BurnUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private string FindTextoNo(XmlNode noPai, string campo)
        {
          return  (noPai[campo] == null || string.IsNullOrEmpty(noPai[campo].InnerText)) ? "..." : noPai[campo].InnerText;
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            WebService.refService.WebServiceRasControl service = new WebService.refService.WebServiceRasControl();
            service.Url = System.Configuration.ConfigurationSettings.AppSettings["ServiceURL"];
            service.Credentials = System.Net.CredentialCache.DefaultCredentials;

            service.XmlBurnDown(1, 1);

            XmlNode sprints = service.XmlBurnUp(Int32.Parse(TextBox1.Text), Int32.Parse(TextBox2.Text));

            string numeroProjeto = null;
            string numeroSprint = null;
            string qtdDias = null;

            string[] valoresx = null;
            double[] valoresyRealizado = null;
            double[] valoresyPlanejado = null;
            

            foreach (XmlNode sprint in sprints)
            {
                
                   numeroProjeto = FindTextoNo(sprint, "NumeroProjeto");
                   numeroSprint = FindTextoNo(sprint, "NumeroSprint");
                   qtdDias = FindTextoNo(sprint, "QtdDias");

                   valoresx = new String[Convert.ToInt32(qtdDias)];
                   valoresyRealizado = new double[Convert.ToInt32(qtdDias)];
                   valoresyPlanejado = new double[Convert.ToInt32(qtdDias)];
            

                    foreach (XmlNode no in sprint.ChildNodes)
                    {
                        if (no.Name == "Dias")
                        {
                            int cont = 0;
                            foreach (XmlNode noDet in no.ChildNodes)
                            {
                                if (noDet.Name == "Dia")
                                {
                                    valoresx[cont] = "Dia " + FindTextoNo(noDet, "Numero");
                                    valoresyPlanejado[cont] = Convert.ToDouble(FindTextoNo(noDet, "Previsto"));
                                    valoresyRealizado[cont] = Convert.ToDouble(FindTextoNo(noDet, "Realizado"));
                                    cont++;

                                }
                            }                      
                           
                        }
                    }
            }

            ChartBurnDown.Series.Add("Planejado");
            ChartBurnDown.Series.Add("Realizado");

            ChartBurnDown.Series["Planejado"].ChartType = SeriesChartType.Line;
            ChartBurnDown.Series["Realizado"].ChartType = SeriesChartType.Line;

            ChartBurnDown.Series["Planejado"].IsValueShownAsLabel = true;
            ChartBurnDown.Series["Realizado"].IsValueShownAsLabel = true;

            ChartBurnDown.Series["Planejado"].BorderWidth = 3;
            ChartBurnDown.Series["Realizado"].BorderWidth = 3;
                       
            ChartBurnDown.Series["Planejado"].Points.DataBindXY(valoresx, valoresyPlanejado);
            ChartBurnDown.Series["Realizado"].Points.DataBindXY(valoresx, valoresyRealizado);

            ChartBurnDown.Series["Planejado"]["PieLabelStyle"] = "inside";
            ChartBurnDown.Series["Realizado"]["PieLabelStyle"] = "inside";

            
        }
    }
}