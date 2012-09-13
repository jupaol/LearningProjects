<%@ Page ViewStateEncryptionMode="Always" Language="C#" AutoEventWireup="true" CodeBehind="SessionPageState.aspx.cs" Inherits="ControllingInformation.SessionPageState" %>
<%@ OutputCache Location="None" VaryByParam="none" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox runat="server" />
        <asp:Button Text="submit" runat="server" />
        <asp:BulletedList runat="server" ID="bl" DisplayMode="Text" BulletStyle="Disc"></asp:BulletedList>
    </div>
    </form>
</body>
</html>
