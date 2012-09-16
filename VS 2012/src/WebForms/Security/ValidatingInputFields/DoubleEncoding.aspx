<%@ Page ValidateRequest="false" Language="C#" AutoEventWireup="true" CodeBehind="DoubleEncoding.aspx.cs" Inherits="ValidatingInputFields.DoubleEncoding" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox runat="server" ID="txt" />
        </div>
        <hr />
        <div>
            Without encoding
            <br />
            <asp:Literal ID="msg" runat="server" />
        </div>
        <hr />
        <div>
            Server.HtmlEncode
            <br />
            <asp:Literal ID="msg2" runat="server" />
        </div>
        <hr />
        <div>
            Server.HtmlEncode x 2
            <br />
            <asp:Literal ID="msg3" runat="server" />
        </div>
        <hr />
        <div>
            Server.HtmlEncode x 3
            <br />
            <asp:Literal ID="msg4" runat="server" />
        </div>
        <hr />
        <div>
            (AntiXss) - Encoder.HtmlEncode
            <br />
            <asp:Literal ID="msg5" runat="server" />
        </div>
        <hr />
        <div>
            (AntiXss) - Encoder.HtmlEncode x 2
            <br />
            <asp:Literal ID="msg6" runat="server" />
        </div>
        <hr />
        <div>
            (AntiXss) - Encoder.HtmlEncode x 3
            <br />
            <asp:Literal ID="msg7" runat="server" />
        </div>
        <hr />
        <div>
            <asp:Button Text="Submit me" runat="server" OnLoad="Unnamed_Load" />
        </div>
    </form>
</body>
</html>
