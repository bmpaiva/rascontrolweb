<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManutencaoUsuario.aspx.cs" Inherits="RasControlWeb.ManutencaoUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
<script src="http://cloud.github.com/downloads/digitalBush/jquery.maskedinput/jquery.maskedinput-1.3.min.js">
</script>
    
    <asp:ScriptManager ID="smMaster" runat="server" EnablePartialRendering="true" EnableCdn="true" />
    <script>
        function AtribuirMascaras() {
            $(".formCel").unmask();
            $(".formCel").mask("9999-9999");

            $(".formRg").unmask();
            $(".formRg").mask("9.999.999");

            $(".formCpf").unmask();
            $(".formCpf").mask("999.999.999-99");
        }

    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            AtribuirMascaras();
        });
    </script>

    <table>
        <tr>
            <td style="font-weight: bold; color: #000000;">Cadastro de Usuário</td>       
        </tr>
        <tr>
            <td><asp:Label ID="Label1" runat="server" Text="Codigo:"></asp:Label></td>
            <td><asp:TextBox ID="tbCodigo" runat="server" ReadOnly="False" Width="320px"></asp:TextBox></td>
             <td><asp:Label ID="Label2" runat="server" Text="Nome:"></asp:Label></td>
            <td><asp:TextBox ID="tbNome" runat="server" Width="320px"></asp:TextBox></td>
        </tr>
        <tr>           
            <td><asp:Label ID="Label3" runat="server" Text="Celular:"></asp:Label></td>
            <td><asp:TextBox ID="tbCelular" runat="server" CssClass="formCel" Width="320px"></asp:TextBox></td>
            <td><asp:Label ID="Label4" runat="server" Text="Telefone:"></asp:Label></td>
            <td><asp:TextBox ID="tbTelefone" runat="server" CssClass="formCel" Width="320px"></asp:TextBox></td>
        </tr>
        <tr>            
            <td><asp:Label ID="Label5" runat="server" Text="Cpf:"></asp:Label></td>
            <td><asp:TextBox ID="tbCpf" runat="server" CssClass="formCpf" Width="320px"></asp:TextBox></td>    
            <td><asp:Label ID="Label6" runat="server" Text="Rg:"></asp:Label></td>
            <td><asp:TextBox ID="tbRg" runat="server" CssClass="formRg" Width="320px"></asp:TextBox></td>       
        </tr>
      
        <tr>            
            <td><asp:Label ID="Label7" runat="server" Text="Email:"></asp:Label></td>
            <td><asp:TextBox ID="tbEmail" runat="server" Width="320px"></asp:TextBox></td>
            <td><asp:Label ID="Label8" runat="server" Text="Login:"></asp:Label></td>
            <td><asp:TextBox ID="tbLogin" runat="server" Width="320px"></asp:TextBox></td>
        </tr>       
        <tr>            
            <td><asp:Label ID="Label9" runat="server" Text="Senha:"></asp:Label></td>
            <td><asp:TextBox ID="tbSenha" runat="server" Width="320px"></asp:TextBox></td>
             <td><asp:Label ID="Label10" runat="server" Text="Observação:"></asp:Label></td>
            <td><asp:TextBox ID="tbObservacao" runat="server" Width="320px"></asp:TextBox></td>
        </tr>
               
    </table>

    <table style="width: 186px">
        <tr>
            
            <td><center>
                <br />
                <asp:Button ID="btGravar" runat="server" Text="Gravar" 
                    onclick="btGravar_Click" Width="130px" /></center></td>
            <td><center style="width: 112px">
                <br />
                <asp:Button ID="btVoltar" runat="server" Text="Voltar" 
                    onclick="btVoltar_Click" Width="130px" /></center></td>
        </tr>
    </table>

    <asp:Label ID="lbErro" runat="server"></asp:Label>

</asp:Content>
