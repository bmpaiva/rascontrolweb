<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListagemPermissao.aspx.cs" Inherits="RasControlWeb.ListagemPermissao" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Código:
        <asp:TextBox ID="TbCodigo" runat="server"></asp:TextBox>
        <br />
        Descrição:&nbsp;
        <asp:TextBox ID="TbDescricao" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" BackColor="White" 
            BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
            GridLines="Horizontal">
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <SortedAscendingCellStyle BackColor="#F4F4FD" />
            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
            <SortedDescendingCellStyle BackColor="#D8D8F0" />
            <SortedDescendingHeaderStyle BackColor="#3E3277" />
        </asp:GridView>
        <br />
        <br />
        <br />
        <asp:Button ID="btPesquisar" runat="server" onclick="btPesquisar_Click" 
            Text="Pesquisar" />
&nbsp;
        <asp:Button ID="btIncluir" runat="server" Text="Incluir" />
&nbsp;
        <asp:Button ID="btLimpar" runat="server" Text="Limpar" />
    
    </div>
    </form>
</body>
</html>
