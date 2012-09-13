<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestingPostMethod.aspx.cs" Inherits="GetAndPostRequests.TestingPostMethod" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" method="post">
    <div>
        <h1>Testing the POST method</h1>
        <h2><%: this.Request.HttpMethod %></h2>
        <asp:Panel runat="server" GroupingText="Form data">
            <div>
                <asp:Label Text="Some data" runat="server" AssociatedControlID="txt" />
                <asp:TextBox runat="server" ID="txt" />
            </div>
            <div>
                <asp:Button Text="Submit" runat="server" />
            </div>
        </asp:Panel>
        <div>
            <h3>Request parameters</h3>
            <asp:BulletedList runat="server" ID="reqParams" DisplayMode="Text" BulletStyle="Circle"></asp:BulletedList>
        </div>
        <div>
            <h3>Get parameters</h3>
            <asp:BulletedList runat="server" ID="getParams" DisplayMode="Text" BulletStyle="Circle"></asp:BulletedList>
        </div>
        <div>
            <h3>Post parameters</h3>
            <asp:BulletedList runat="server" ID="postParams" DisplayMode="Text" BulletStyle="Circle"></asp:BulletedList>
        </div>
        <div>
            <h4>Header parameters</h4>
            <asp:BulletedList runat="server" ID="headerParams" DisplayMode="Text" BulletStyle="Circle"></asp:BulletedList>
        </div>
    </div>
    </form>
</body>
</html>
