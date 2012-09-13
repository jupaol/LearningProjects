<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MakeTransfer.aspx.cs" Inherits="CrossSiteRequestForgery.MakeTransfer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label runat="server" AssociatedControlID="account" Text="From:"></asp:Label>
        <asp:DropDownList runat="server" ID="account">
            <asp:ListItem Text="Account 1" />
            <asp:ListItem Text="Account 2" />
        </asp:DropDownList>
        <br />
        <asp:Label runat="server" Text="Amount" AssociatedControlID="ammount"></asp:Label>
        <asp:TextBox runat="server" ID="ammount"></asp:TextBox>
        <br />
        <asp:Label runat="server" Text="To:" AssociatedControlID="to"></asp:Label>
        <asp:TextBox runat="server" ID="to"></asp:TextBox>
        <br />
        <asp:Button Text="Make Transfer" runat="server" ID="make_transfer" OnClick="make_transfer_Click" />
        <br />
        <asp:Literal runat="server" ID="msg"></asp:Literal>
    </div>
    </form>
</body>
</html>
