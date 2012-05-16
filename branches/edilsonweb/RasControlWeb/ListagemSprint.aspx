<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListagemSprint.aspx.cs" Inherits="RasControlWeb.ListagemSprint" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 11px;
        }
        .style2
        {
            height: 21px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <table>
    <tr>
        <td style="font-weight: bold; color: #000000;">Sprints do Projeto</td>       
    </tr>
    <tr>
    <td></td>
    </tr>
    <tr>
       <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
            CellPadding="3" ForeColor="Black" GridLines="Vertical" onrowcommand="GridView1_RowCommand">
           <AlternatingRowStyle BackColor="#CCCCCC" />
           <Columns>
               <asp:BoundField DataField="id_Srint" HeaderText="Codigo Sprint" 
                   SortExpression="Codigo Sprint" />
               <asp:BoundField DataField="codigo" HeaderText="Codigo Projeto" 
                   SortExpression="Codigo Projeto" />
               <asp:BoundField DataField="descricao" HeaderText="Descricao" 
                   SortExpression="Descricao" />
               <asp:ButtonField ButtonType="Button" CommandName="Detalhar" Text="Detalhar" />
               <asp:ButtonField ButtonType="Button" CommandName="Alterar" Text="Alterar" />
               <asp:ButtonField ButtonType="Button" CommandName="Remover" Text="Remover" />
               <asp:ButtonField CommandName="Estorias" Text="Estorias" />
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
        </tr>
    </table>
     <table style="width: 291px">
        <tr>
            <td>
                <asp:Button ID="btIncluir" runat="server" Text="Incluir" 
                    onclick="btIncluir_Click" Width="130px" /></td>
            <td class="style1">&nbsp;</td>
            <td><center>
                </center></td>
        </tr>
    </table>
</asp:Content>
