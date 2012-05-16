<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManutencaoAtividade.aspx.cs" Inherits="RasControlWeb.ManutencaoAtividade" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<table>
   <tr>
    
        <td>Cadastro de Atividade:</td>                 
    
    </tr> 
    <tr>
    
        <td>Código:</td>
        <td><asp:TextBox ID="tbCodigoAtividade" runat="server" ReadOnly="True" ></asp:TextBox></td>          
    
    </tr> 

    <tr>
    
        <td>Cod. Tipo Ativ:</td>
        <td>
            <asp:DropDownList ID="dropboxTipoAtividade" runat="server" Height="24px"                
                Width="110px">
            </asp:DropDownList>
        </td>    
    
    </tr>

    <tr>
    <p>
        <td>Código Estória Sprint:</td>
        <td><asp:TextBox ID="tbCodigoEstoriaSprint" runat="server"></asp:TextBox></td>
    </tr>   

    <tr>
         <td>Descrição:</td> 
         <td><asp:TextBox ID="tbDescricao" runat="server" Height="22px" Width="355px"></asp:TextBox></td>
    </tr>  
    </p>

    <tr>
    <p>
        <td>Duração Estimada:</td>
        <td><asp:TextBox ID="tbDuracaoEstimada" runat="server"></asp:TextBox></td>       
    </p>
    </tr>

    <tr>
    <p>
        <td>Duração Realizada:</td>
        <td><asp:TextBox ID="tbDuracaoRealizada" runat="server"></asp:TextBox></td>       
    </p>
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
