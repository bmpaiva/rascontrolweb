<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SprintEstoria.aspx.cs" Inherits="RasControlWeb.SprintEstoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<table>
    <tr>
        <td>Sprint</td><td>
        <asp:DropDownList ID="dropBoxSprint" runat="server" 
            onselectedindexchanged="dropboxSprints_SelectedIndexChanged" 
            Height="18px" Width="351px">
        </asp:DropDownList>
        </td><td>
            <asp:Button ID="btAdicionar" runat="server" Text="Adicionar" 
                onclick="btAdicionar_Click" Width="77px" />
        </td>
    </tr>
</table>


<br />

Estorias Associadas:
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
        CellPadding="3" ForeColor="Black" GridLines="Vertical" Height="141px" 
        onrowcommand="GridView1_RowCommand" Width="511px">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:BoundField DataField="Descricao" HeaderText="Descricao" />
            <asp:BoundField DataField="Roi" HeaderText="Roi" SortExpression="Roi" />
            <asp:BoundField DataField="BV" HeaderText="BV" SortExpression="BV" />
            <asp:BoundField DataField="SP" HeaderText="SP" SortExpression="SP" />
            <asp:ButtonField CommandName="Remover" Text="Remover" />
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

    <asp:Button ID="btVoltar" runat="server" Text="Voltar" onclick="btVoltar_Click" 
        Width="130px" />



</asp:Content>
