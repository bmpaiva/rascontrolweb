<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListagemEstoria.aspx.cs" Inherits="RasControlWeb.ListagemEstoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <style type="text/css">
    #Select1
    {
      width: 122px;
    }
  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<table>
    <tr>
        <td style="font-weight: bold; color: #000000;">Estórias do Projeto</td>       
    </tr>
    </table>
    <br />

        <asp:GridView ID="GridView1" runat="server" BackColor="White" 
            BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
            GridLines="Vertical" 
            onrowcommand="GridView1_RowCommand" ForeColor="Black" Width="662px" 
    AutoGenerateColumns="False" >
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:BoundField DataField="Codigo" HeaderText="Código" 
                    SortExpression="Codigo" />

<asp:BoundField DataField="Descricao" HeaderText="Descricao" SortExpression="Descricao"></asp:BoundField>
<asp:BoundField DataField="Sp" HeaderText="Sp" SortExpression="Sp"></asp:BoundField>
<asp:BoundField DataField="Bv" HeaderText="Bv" SortExpression="Bv"></asp:BoundField>
<asp:BoundField DataField="Roi" HeaderText="Roi" SortExpression="Roi"></asp:BoundField>

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
        <asp:Button ID="btIncluir" runat="server" Text="Incluir" 
            onclick="btIncluir_Click" style="height: 26px" Width="130px" />
    
    &nbsp;

</asp:Content>
