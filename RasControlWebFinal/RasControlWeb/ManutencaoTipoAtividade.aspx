<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManutencaoTipoAtividade.aspx.cs" Inherits="RasControlWeb.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<table>    
    <tr>
        <td>Código:</td>
        <td><asp:TextBox ID="tbCodigo" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Descrição:</td>
        <td><asp:TextBox ID="tbDescricao" runat="server"></asp:TextBox></td>
    </tr>
</table>
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
