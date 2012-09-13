<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestingGetMethod.aspx.cs" Inherits="GetAndPostRequests.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" method="get">
    <div>
        <h1><%: Server.HtmlEncode("Testing GET method") %></h1>
        <h2><%: this.Request.HttpMethod %></h2>
        <asp:Label runat="server" ID="lbl" AssociatedControlID="txt">Text example:</asp:Label>
        <asp:TextBox runat="server" ID="txt"></asp:TextBox>
        <div>
            <asp:Button Text="Submit form" runat="server" />
        </div>
        <h3>Querystring parameters</h3>
        <div>
            <ul>
                <% foreach (var key in this.Request.QueryString.Keys.OfType<string>())
                   {
                %>
                        <li>
                            <b><%: key + " = " %></b><%: this.Request.QueryString[key] %>
                        </li>
                <%
                   } 
                %>
            </ul>
        </div>
    </div>
    </form>
</body>
</html>
