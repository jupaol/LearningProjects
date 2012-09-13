<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProtectedPage.aspx.cs" Inherits="ControllingInformation.Protected.ProtectedPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        secret page
        <br />
        using the following to hash the viewstate: 'this.ViewStateUserKey = 
        <%: this.ViewStateUserKey %>'
        <br />
        <asp:Button Text="Submit" runat="server" OnClick="Unnamed_Click" />
    </div>
    </form>
</body>
</html>
