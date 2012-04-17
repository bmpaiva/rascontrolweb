<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListagemPermissoes.aspx.cs" Inherits="RasControlWeb.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lbCodigo" runat="server" Text="Código:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="tbCodigo" runat="server"></asp:TextBox>
    <br />
    Descrição:&nbsp;
    <asp:TextBox ID="tbDescricao" runat="server" Width="380px"></asp:TextBox>
    <br />
    <br />
        <asp:GridView ID="GridView1" runat="server" BackColor="White" 
            BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
            GridLines="Vertical" AutoGenerateColumns="False" 
            onrowcommand="GridView1_RowCommand" ForeColor="Black" Width="662px">
          <AlternatingRowStyle BackColor="#CCCCCC" />
          <Columns>
            <asp:BoundField DataField="Codigo" HeaderText="Código" 
                    SortExpression="Codigo" />
            <asp:BoundField DataField="Descricao" HeaderText="Descricao" SortExpression="Descricao">
            </asp:BoundField>
            <asp:BoundField DataField="Observacao" HeaderText="Observacao" SortExpression="Observacao">
            </asp:BoundField>
            <asp:ButtonField Text="Detalhar" ButtonType="Button" CommandName="Detalhar" />
            <asp:ButtonField Text="Alterar" ButtonType="Button" CommandName="Alterar" />
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
        <br />
    <br />
        <asp:Button ID="btPesquisar" runat="server" onclick="btPesquisar_Click" 
            Text="Pesquisar" />
        <asp:Button ID="btIncluir" runat="server" Text="Incluir" 
            onclick="btIncluir_Click" style="height: 26px" />
        <asp:Button ID="btLimpar" runat="server" Text="Limpar" 
            onclick="btLimpar_Click" />
    
    &nbsp;
</asp:Content>
