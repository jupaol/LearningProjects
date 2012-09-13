<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MakeTransferSecure.aspx.cs" Inherits="CrossSiteRequestForgery.MakeTransferSecure" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" AssociatedControlID="account" Text="From:"></asp:Label>
        <asp:DropDownList runat="server" ID="account">
            <asp:ListItem Text="Account 1" />
            <asp:ListItem Text="Account 2" />
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Amount" AssociatedControlID="ammount"></asp:Label>
        <asp:TextBox runat="server" ID="ammount"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="To:" AssociatedControlID="to"></asp:Label>
        <asp:TextBox runat="server" ID="to"></asp:TextBox>
        <br />
        <asp:Button Text="Make Transfer" runat="server" ID="make_transfer" OnClick="make_transfer_Click" />
        <br />
        <asp:Literal runat="server" ID="msg"></asp:Literal>
    </div>
    </form>
</body>
</html>
