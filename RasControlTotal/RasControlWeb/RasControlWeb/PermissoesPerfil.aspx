<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PermissoesPerfil.aspx.cs" Inherits="RasControlWeb.PermissoesPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <table>
        <tr>
            <td style="font-weight: bold; color: #000000;">Permissões do Perfil</td>       
        </tr>
        </table>
    
    <br />
    Permissão:&nbsp;
    <asp:DropDownList ID="dropboxPermissoes" runat="server" Height="18px" 
        style="margin-left: 0px" Width="351px">
    </asp:DropDownList>
&nbsp;
    <asp:Button ID="btAdicionar" runat="server" onclick="btAdicionar_Click" 
        Text="Adicionar" Width="77px" />
    <br />
    <br />
    Permissões associadas: 
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        Height="141px" Width="511px" BackColor="White" BorderColor="#999999" 
        BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" 
        GridLines="Vertical" onrowcommand="GridView1_RowCommand">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:BoundField DataField="Codigo" HeaderText="Código" />
            <asp:BoundField DataField="Descricao" HeaderText="Descrição" />
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
&nbsp;
    <asp:Button ID="btVoltar" runat="server" Text="Voltar" Width="130px" 
        onclick="btVoltar_Click" />
    <br />
&nbsp;
</asp:Content>
