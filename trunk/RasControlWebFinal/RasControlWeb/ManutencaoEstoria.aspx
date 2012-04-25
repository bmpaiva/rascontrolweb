<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManutencaoEstoria.aspx.cs" Inherits="RasControlWeb.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <style type="text/css">
    #Select1
    {
      width: 132px;
    }
  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


 <p>
        Código: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbCodigo" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
        IdProjeto: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbIdProjeto" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
        Descrição: &nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:TextBox ID="tbDescricao" runat="server" Height="22px" Width="355px"></asp:TextBox>
         <br />
        SP: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <asp:TextBox ID="tbSp" runat="server" Height="22px" Width="355px"></asp:TextBox>
        <br />
        BV: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbBv" runat="server" Height="22px" Width="355px"></asp:TextBox>
        <br />
        ROI: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbRoi" runat="server" Height="22px" Width="355px"></asp:TextBox>
       
    </p>
    <p>
        <asp:Button ID="btGravar" runat="server" onclick="btGravar_Click" 
            Text="Gravar" />
        <asp:Button ID="btVoltar" runat="server" onclick="btVoltar_Click" 
            Text="Voltar" />
    </p>
    <p>
        <asp:Label ID="lbErro" runat="server"></asp:Label>
    </p>

</asp:Content>
