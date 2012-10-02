<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="DefaultErrorPage.aspx.cs" Inherits="Msts.Topics.Chapter08___Debugging_and_Deploying.Lesson01___Debugging.DefaultErrorPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/themes/base/css" /> 
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                An error occurred with your request. This is the default redirection page when
                an error occurs in the application
            </div>
            <asp:Panel runat="server" ID="errorPanel" Visible="false">
                <div>
                    Error message:
                </div>
                <div>
                    <asp:Literal ID="errorMessage" runat="server" />
                </div>
                <div>
                    Error trace
                </div>
                <div>
                    <asp:Literal ID="errorTrace" runat="server" />
                </div>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
