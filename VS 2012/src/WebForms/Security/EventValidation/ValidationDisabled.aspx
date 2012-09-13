<%@ Page EnableEventValidation="false" Language="C#" AutoEventWireup="true" CodeBehind="ValidationDisabled.aspx.cs" Inherits="EventValidation.ValidationDisabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList runat="server" ID="ddl" AutoPostBack="true">
            <asp:ListItem Text="text1" />
            <asp:ListItem Text="text2" />
        </asp:DropDownList>
        <br />
        <asp:Label ID="msg" runat="server" />
        <br />
        <asp:Button Text="Delete" runat="server" ID="delete" OnClick="delete_Click" Visible="false" />
        <br />
        <asp:Button Text="Insert" runat="server" ID="insert" OnClick="insert_Click" />
        <p>
            To test the problem, copy and paste the following javascript code in the 
            browser URL (There is a button named 'delete') but it is hidden
        </p>
        <p>
            <%= Server.HtmlEncode("javascript:__doPostBack('delete', '');") %>
        </p>
        <p>
            To solve the problem set the 'EnableEventValidation = true'
        </p>
        <p>
            <%: "<%@ Page EnableEventValidation=\"true\""  %>
        </p>
    </div>
    </form>
</body>
</html>
