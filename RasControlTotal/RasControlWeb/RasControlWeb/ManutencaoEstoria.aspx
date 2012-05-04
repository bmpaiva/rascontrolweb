<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManutencaoEstoria.aspx.cs" Inherits="RasControlWeb.ManutencaoEstoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

  <style type="text/css">
    #Select1
    {
      width: 132px;
    }
  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

 <table>
        <tr>
            <td style="font-weight: bold; color: #000000;">Cadastro de Estoria</td>       
        </tr>
        <tr>
            <td><asp:Label ID="Label1" runat="server" Text="Codigo:"></asp:Label></td>
            <td><asp:TextBox ID="tbCodigo" runat="server" ReadOnly="True" Width="320px"></asp:TextBox></td>
            <td><asp:Label ID="Label3" runat="server" Text="Descrição:"></asp:Label></td>
            <td><asp:TextBox ID="tbDescricao" runat="server" Width="320px"></asp:TextBox></td>
        </tr>
        <tr>           
            <td><asp:Label ID="Label2" runat="server" Text="SP:"></asp:Label></td>
            <td><asp:TextBox ID="tbSp" runat="server" Width="320px" Autopostback="true" 
                ontextchanged="tbSp_TextChanged"></asp:TextBox></td>
            <td><asp:Label ID="Label4" runat="server" Text="BV:"></asp:Label></td>
            <td><asp:TextBox ID="tbBv" runat="server" Width="320px"  Autopostback="true" 
                ontextchanged="tbBv_TextChanged"></asp:TextBox></td>
            
        </tr>
         <tr>          
            
            <td><asp:Label ID="Label5" runat="server" Text="ROI:"></asp:Label></td>
            <td><asp:TextBox ID="tbRoi" runat="server" Width="320px" 
                ontextchanged="tbRoi_TextChanged"></asp:TextBox></td>
            
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