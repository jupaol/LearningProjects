<%@ Page Trace="true" TraceMode="SortByTime" Language="C#" AutoEventWireup="true" CodeBehind="CachingMembershipUsers.aspx.cs" Inherits="WebSecurity.Topics.Caching.CachingMembershipUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>
            Caching the list of users returned by the SqlMembershipProvider
        </h1>
        <asp:ObjectDataSource runat="server" ID="ods" 
            SelectMethod="GetDomainUsers" 
            TypeName="WebSecurity.DataAccess.DomainUsersObjectSource" />
        <asp:GridView runat="server" DataSourceID="ods">

        </asp:GridView>
    </div>
    </form>
</body>
</html>
