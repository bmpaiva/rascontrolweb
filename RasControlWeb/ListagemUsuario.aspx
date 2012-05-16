<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListagemUsuario.aspx.cs" Inherits="RasControlWeb.ListagemUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
    <tr>
        <td style="font-weight: bold; color: #000000;">Pesquisa de Usuário</td>       
    </tr>
    <tr>
        <td> </td>       
    </tr>
    <tr>
        <td><asp:Label ID="Label1" runat="server" Text="Codigo:"></asp:Label></td>
        <td><asp:TextBox ID="tbCodigo" runat="server" Width="192px"></asp:TextBox></td>
    </tr>
    <tr>
        <td><asp:Label ID="Label2" runat="server" Text="Cpf:"></asp:Label>
            <br />
            <br />
        </td>
        <td><asp:TextBox ID="tbCpf" runat="server" Width="195px"></asp:TextBox></td>
    </tr>
        
    </table>

    <br />

    <asp:GridView ID="GridView1" runat="server" BackColor="White" 
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
        ForeColor="Black" GridLines="Vertical" Width="431px" 
        onrowcommand="GridView1_RowCommand" AutoGenerateColumns="False">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:BoundField DataField="Codigo" HeaderText="Codigo" 
                SortExpression="Codigo" />
            <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="Nome"  />
            <asp:BoundField DataField="Cpf" HeaderText="Cpf" SortExpression="Cpf" />
            <asp:ButtonField ButtonType="Button" CommandName="Detalhar" Text="Detalhar" />
            <asp:ButtonField ButtonType="Button" CommandName="Alterar" Text="Alterar" />
            <asp:ButtonField ButtonType="Button" CommandName="Deletar" Text="Deletar" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="Gray" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
    <br />
    <table style="width: 291px">
    <tr>
    <td><center>
        <asp:Button ID="btPesquisar" runat="server" Text="Pesquisar" 
            onclick="btPesquisar_Click" Width="130px" /></center></td>
    <td><center>
        <asp:Button ID="btIncluir" runat="server" Text="Incluir" 
            onclick="btIncluir_Click" Width="130px" /></center></td>
    <td><center>
        <asp:Button ID="btLimpar" runat="server" Text="Limpar" 
            onclick="btLimpar_Click" Width="130px" /></center></td>
    </tr>
    </table>
</asp:Content>
