<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ControllingInformation.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Username:
        <asp:TextBox runat="server" ID="userName"></asp:TextBox>
        <br />
        password
        <asp:TextBox runat="server" ID="password"></asp:TextBox>
        <br />
        <asp:Button Text="Login" runat="server" ID="logon" OnClick="login_Click" />
    </div>
    </form>
</body>
</html>
