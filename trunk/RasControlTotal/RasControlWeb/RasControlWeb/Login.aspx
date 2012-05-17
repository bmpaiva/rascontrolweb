<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RasControlWeb.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Login<br />
        <br />
        Usuário<br />
        <asp:TextBox ID="tbLogin" runat="server"></asp:TextBox>
        <br />
        Senha<br />
        <asp:TextBox ID="tbSenha" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btLogar" runat="server" onclick="btLogar_Click" Text="Logar" />
    
        <br />
        <br />
        <asp:Label ID="lbErro" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
