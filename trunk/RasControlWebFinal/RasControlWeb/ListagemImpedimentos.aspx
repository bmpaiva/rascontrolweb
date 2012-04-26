<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListagemImpedimentos.aspx.cs" Inherits="RasControlWeb.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<table>
    <tr>            
        <td>Código:</td>
        <td><asp:TextBox ID="tbCodigo" runat="server"></asp:TextBox></td>        
    </tr>

    <tr>        
        <td>Código Sprint:</td>
        <td><asp:TextBox ID="tbCodigoSprint" runat="server"></asp:TextBox></td>        
    </tr>

    <tr>
        <td>Descrição:</td>
        <td><asp:TextBox ID="tbDescricao" runat="server" Width="333px"></asp:TextBox></td>
    </tr>

</table>

    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
            CellPadding="3" ForeColor="Black" GridLines="Vertical" 
            onrowcommand="GridView1_RowCommand">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:BoundField DataField="id_impedimento" HeaderText="Código" 
                    SortExpression="id_impedimento" />
                <asp:BoundField DataField="id_sprint" HeaderText="Código Sprint" 
                    SortExpression="id_sprint" />
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

     <asp:Button ID="btPesquisar" runat="server" onclick="btPesquisar_Click" 
            Text="Pesquisar" />
        <asp:Button ID="btIncluir" runat="server" Text="Incluir" 
            onclick="btIncluir_Click" style="height: 26px" />
        <asp:Button ID="btLimpar" runat="server" Text="Limpar" 
            onclick="btLimpar_Click" />
</asp:Content>
