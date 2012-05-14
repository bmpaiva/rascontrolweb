<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListagemProjeto.aspx.cs" Inherits="RasControlWeb.ListagemProjeto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <table>
    <tr>
        <td style="font-weight: bold; color: #000000;">Pesquisa de Projeto</td>       
    </tr>
    <tr>
        <td> </td>       
    </tr>
    <tr>
        <td><asp:Label ID="Label3" runat="server" Text="Codigo:"></asp:Label></td>
        <td><asp:TextBox ID="tbCodigo" runat="server" Width="264px"></asp:TextBox></td>
    </tr>
    <tr>
        <td><asp:Label ID="Label4" runat="server" Text="Descrição:"></asp:Label>
            <br />
            <br />
        </td>
        <td><asp:TextBox ID="tbDescricao" runat="server" Width="262px"></asp:TextBox></td>
    </tr>        
  </table>

  <br />
   

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
        CellPadding="3" ForeColor="Black" GridLines="Vertical" 
        onrowcommand="GridView1_RowCommand1">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:BoundField DataField="codigo" HeaderText="Codigo" 
                SortExpression="codigo" />
            <asp:BoundField DataField="descricao" HeaderText="Descriçao" 
                SortExpression="descricao" />
            <asp:ButtonField ButtonType="Button" CommandName="Detalhar" Text="Detalhar" />
            <asp:ButtonField ButtonType="Button" CommandName="Alterar" Text="Alterar" />
            <asp:ButtonField ButtonType="Button" CommandName="Remover" Text="Remover" />
            <asp:ButtonField CommandName="Sprints" Text="Sprints" />
            <asp:ButtonField CommandName="Estorias" Text="Estorias" />
             <asp:ButtonField CommandName="Usuarios" Text="Usuarios" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>

         <br />
    <br />
    
     <asp:Button ID="tbPesquisar" runat="server" onclick="tbPesquisar_Click" 
            Text="Pesquisar" Width="130px" />
        &nbsp;<asp:Button ID="tbIncluir" runat="server" Text="Incluir" 
            onclick="tbIncluir_Click" Width="130px" />
        &nbsp;<asp:Button ID="tbLimpar" runat="server" Text="Limpar" 
            onclick="tbLimpar_Click" Width="130px" />
    
    
   
</asp:Content>
