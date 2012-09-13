<%@ Page ViewStateEncryptionMode="Always" EnableEventValidation="false" ValidateRequest="false" Language="C#" AutoEventWireup="true" CodeBehind="TestingTheIsPostBackProperty.aspx.cs" Inherits="QueryAndFormParameters.TestingTheIsPostBackProperty" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" method="get">
    <div>
        <p>
            Click the submit button and check how ASP.Net thinks that the page has been posted
            even when the form methos is <b>GET</b>
        </p>
        <div>
            <%: this.Request.HttpMethod %>
        </div>
        <div>
            <b>IsPostBack property:</b> <%: this.IsPostBack %>
        </div>
        <div>
            <b>EnableViewStateMac enabled:</b> <%: this.EnableViewStateMac.ToString() %>
        </div>
        <asp:TextBox runat="server" ID="txt" />
        <asp:Button Text="Submit" runat="server" />
    </div>
    </form>
</body>
</html>
