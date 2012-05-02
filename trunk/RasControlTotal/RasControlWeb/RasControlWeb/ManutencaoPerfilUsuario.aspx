<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManutencaoPerfilUsuario.aspx.cs" Inherits="RasControlWeb.ManutencaoPerfilUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

 <table>
        <tr>
            <td style="font-weight: bold; color: #000000;">Cadastro de Usuário</td>       
        </tr>
        <tr>
            <td><asp:Label ID="Label1" runat="server" Text="Codigo:"></asp:Label></td>
            <td><asp:TextBox ID="tbCodigo" runat="server" ReadOnly="True" Width="320px"></asp:TextBox></td>
     
        </tr>
        <tr>           
            <td><asp:Label ID="Label3" runat="server" Text="Celular:"></asp:Label></td>
            <td><asp:TextBox ID="tbDescricao" runat="server" Width="320px"></asp:TextBox></td>
            
        </tr>
 </table>
    
  <table style="width: 186px">
        <tr>
            
            <td><center>
                <br />
                <asp:Button ID="btGravar" runat="server" Text="Gravar" 
                    onclick="btGravar_Click" Width="130px" /></center></td>
            <td><center style="width: 112px">
                <br />
                <asp:Button ID="btVoltar" runat="server" Text="Voltar" 
                    onclick="btVoltar_Click" Width="130px" /></center></td>
        </tr>
    </table>

       
        <asp:Label ID="lbErro" runat="server"></asp:Label>
    </p>

</asp:Content>
