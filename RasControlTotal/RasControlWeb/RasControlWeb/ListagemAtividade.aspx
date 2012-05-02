<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListagemAtividade.aspx.cs" Inherits="RasControlWeb.ListagemAtividade" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 138px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<table>
     <tr>
      <td align="center" class="style1" rowspan="1">
       
          Listagem de Atividades</td>
     <//tr>
     <tr>
    
    <td class="style1">Código:</td>
    <td><asp:TextBox ID="tbCodigoAtividade" runat="server"></asp:TextBox></td>
        </tr>
    <br /> 
        <tr>
    <td class="style1">Cod. Tipo Ativ:</td>
    <td><asp:TextBox ID="tbCodigoTipoAtividade" runat="server"></asp:TextBox></td>
        </tr>
    <br />
        <tr>
    <td class="style1">Código Estória Sprint:</td>
    <td><asp:TextBox ID="tbCodigoEstoriaSprint" runat="server"></asp:TextBox></td>
        </tr>
    <br />
        <tr>
    <td class="style1">Descrição:</td>
    <td><asp:TextBox ID="tbDescricao" runat="server" Width="380px"></asp:TextBox></td>
        </tr>
    <br />
        <tr>
    <td class="style1">Duração Estimada:</td>
    <td><asp:TextBox ID="tbDuracaoEstimada" runat="server"></asp:TextBox></td>
        </tr>
    <br />
        <tr>
    <td class="style1">Duração Realiada:</td>
    <td><asp:TextBox ID="tbDuracaoRealizada" runat="server"></asp:TextBox></td>
        </tr>
</table>
    <br />
    <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
        CellPadding="3" ForeColor="Black" GridLines="Vertical" 
        onrowcommand="GridView1_RowCommand1">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:BoundField DataField="id_atividade" HeaderText="Código" 
                    SortExpression="id_atividade" />
                <asp:BoundField DataField="id_tipo_atividade" HeaderText="Código Tipo Ativ." 
                    SortExpression="id_tipo_atividade" />
                <asp:BoundField DataField="id_estoria_sprint" HeaderText="Código Sprint" 
                    SortExpression="id_estoria_sprint" />
                <asp:BoundField DataField="descricao" HeaderText="Descrição" 
                    SortExpression="descricao" />
                <asp:BoundField DataField="duracao_estimada" HeaderText="Duração Estimada" 
                    SortExpression="duracao_estimada" />
                <asp:BoundField DataField="duracao_realizada" HeaderText="Duração Realizada" 
                    SortExpression="duracao_realizada" />
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
