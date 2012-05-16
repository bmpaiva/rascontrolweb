<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManutencaoSprint.aspx.cs" Inherits="RasControlWeb.ManutencaoSprint" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <table>
        <tr>
            <td class="style1"><asp:Label ID="Label5" runat="server" Text="Codigo da Sprint"></asp:Label></td>
            <td class="style1"><asp:TextBox ID="tbCodigo" runat="server" Width="183px" 
                    ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label1" runat="server" Text="Descricao:"></asp:Label></td>
            <td><asp:TextBox ID="tbDescricao" runat="server" Width="183px"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label2" runat="server" Text="Data Inicio:"></asp:Label></td>
            <td><asp:TextBox ID="tbDInicio" runat="server" Width="81px"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label3" runat="server" Text="Data Fim:"></asp:Label></td>
            <td><asp:TextBox ID="tbDFim" runat="server" Width="78px"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label4" runat="server" Text="Quantidade Dias:"></asp:Label></td>
            <td><asp:TextBox ID="tbQTDDias" runat="server" Width="58px"></asp:TextBox></td>
        </tr>
    </table>

    <table style="width: 186px">
        <tr>
            <td><center><asp:Button ID="btGravar" runat="server" Text="Gravar" 
                    onclick="btGravar_Click" /></center></td>
            <td><center><asp:Button ID="btVoltar" runat="server" Text="Voltar" 
                    onclick="btVoltar_Click" /></center></td>
        </tr>
    </table>

    <asp:Label ID="lbErro" runat="server"></asp:Label>

</asp:Content>
