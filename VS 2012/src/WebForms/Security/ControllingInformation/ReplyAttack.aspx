﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReplyAttack.aspx.cs" Inherits="ControllingInformation.ReplyAttack" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%: this.Session["d"] %>
        <br />
        <%: DateTime.Now %>
        <br />
        <asp:Button Text="Submit" runat="server" />
    </div>
    </form>
</body>
</html>
