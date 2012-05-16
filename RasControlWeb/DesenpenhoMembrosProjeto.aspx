<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DesenpenhoMembrosProjeto.aspx.cs" Inherits="RasControlWeb.DesenpenhoMembrosProjeto" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <br />
    Código Projeto&nbsp;
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <br />
    &nbsp;
    <br />
    <br />
    <asp:Button ID="BtGerar" runat="server" onclick="Button1_Click" Text="Gerar" />
    <br />
    <asp:Chart ID="ChartProjeto" runat="server" Width="711px">
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
            </asp:ChartArea>
        </ChartAreas>
        <Legends>
            <asp:Legend Name="Legend1" Title="Legenda">
            </asp:Legend>
        </Legends>
        <Titles>
            <asp:Title Font="Microsoft Sans Serif, 18pt, style=Bold" Name="Title1" 
                Text="Desempenho de Membro por Projeto">
            </asp:Title>
        </Titles>
    </asp:Chart>
    <br />
    </form>
</body>
</html>
