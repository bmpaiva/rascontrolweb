<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListagemTipoAtividade.aspx.cs" Inherits="RasControlWeb.WebForm1" %>
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
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
            CellPadding="3" ForeColor="Black" GridLines="Vertical" 
            onrowcommand="GridView1_RowCommand">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:BoundField DataField="Codigo" HeaderText="Codigo" 
                    SortExpression="Codigo" />
                <asp:BoundField DataField="descricao" HeaderText="Descrição" 
                    SortExpression="descricao" />
                <asp:ButtonField ButtonType="Button" CommandName="Detalhar" Text="Detalhar" />
                <asp:ButtonField ButtonType="Button" CommandName="Alterar" Text="Alterar" />
                <asp:ButtonField ButtonType="Button" CommandName="Remover" Text="Remover" />
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
    </p>
    <p>
        <asp:Button ID="btPesquisar" runat="server" onclick="btPesquisar_Click" 
            Text="Pesquisar" />
        <asp:Button ID="btIncluir" runat="server" onclick="btIncluir_Click" 
            style="height: 26px" Text="Incluir" />
        <asp:Button ID="btLimpar" runat="server" onclick="btLimpar_Click" 
            Text="Limpar" />
    </p>
</asp:Content>
