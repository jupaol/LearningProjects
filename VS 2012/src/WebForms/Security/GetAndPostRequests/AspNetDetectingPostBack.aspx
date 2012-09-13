<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AspNetDetectingPostBack.aspx.cs" Inherits="GetAndPostRequests.AspNetDetectingPostBack" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Detecting ASP.Net - postbacks</h1>
        <div>
            <b>Method:</b> <%: this.Request.HttpMethod %>
        </div>
        <div>
            <b>Is Post Back property:</b> <%: this.IsPostBack %>
        </div>
        <div>
            <h3>POST parameters</h3>
            <asp:BulletedList runat="server" ID="postParams"></asp:BulletedList>
        </div>
        <div>
            <asp:Literal runat="server" ID="msg"></asp:Literal>
        </div>
        <div>
            <asp:LinkButton runat="server" ID="btn" Text="Submit" OnClick="btn_Click" />
        </div>
    </div>
    </form>
</body>
</html>
