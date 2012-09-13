<%@ Page ValidateRequest="false" Language="C#" AutoEventWireup="true" CodeBehind="XssVulnerablePage.aspx.cs" Inherits="ValidatingInput.XssVulnerablePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel runat="server" ID="comment">
                <asp:Label Text="Comments" runat="server" ID="lbl" AssociatedControlID="txt" />
                <asp:TextBox runat="server" ID="txt" TextMode="MultiLine" Rows="10" Columns="100" />
                <div>
                    <asp:Button Text="Submit without encoding" runat="server" OnClick="Unnamed_Click" />
                </div>
                <div>
                    <asp:Button Text="Submit with encoding" runat="server" ID="withEncoding" OnClick="withEncoding_Click" />
                </div>
                <div>
                    <asp:Button Text="Submit with special encoding" runat="server" ID="withSpecialEncoding" OnClick="withSpecialEncoding_Click" />
                </div>
            </asp:Panel>
            <asp:Panel runat="server" ID="display">
            </asp:Panel>
            <asp:Literal runat="server" ID="msg"></asp:Literal>
        </div>
    </form>
</body>
</html>
