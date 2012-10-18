<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SimpleValidation.aspx.cs" Inherits="Msts.Topics.Chapter05.Lesson01___Input_Validation.SimpleValidation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePageMethods="true">
            <Scripts>
                <%--Framework Scripts--%>
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="jquery.ui.combined" />
                <asp:ScriptReference Name="WebForms.js"  Path="~/Scripts/WebForms/WebForms.js" />
                <asp:ScriptReference Name="WebUIValidation.js"  Path="~/Scripts/WebForms/WebUIValidation.js" />
                <asp:ScriptReference Name="MenuStandards.js"  Path="~/Scripts/WebForms/MenuStandards.js" />
                <asp:ScriptReference Name="GridView.js"  Path="~/Scripts/WebForms/GridView.js" />
                <asp:ScriptReference Name="DetailsView.js"  Path="~/Scripts/WebForms/DetailsView.js" />
                <asp:ScriptReference Name="TreeView.js"  Path="~/Scripts/WebForms/TreeView.js" />
                <asp:ScriptReference Name="WebParts.js"  Path="~/Scripts/WebForms/WebParts.js" />
                <asp:ScriptReference Name="Focus.js"  Path="~/Scripts/WebForms/Focus.js" />
                <asp:ScriptReference Name="WebFormsBundle" />
                <%--Site Scripts--%>

            </Scripts>
        </ajaxToolkit:ToolkitScriptManager>
        <h1>
            Scroll down to test valdiation
        </h1>
        <script type="text/javascript">
            $(function () {
                alert("jquery okok");
            });
        </script>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:TextBox runat="server" ID="txt" />
        <asp:RequiredFieldValidator ErrorMessage="Txt required" ControlToValidate="txt" runat="server" Text="*" />
        <asp:DropDownList runat="server" CausesValidation="true" AutoPostBack="true" ID="ddl">
            <asp:ListItem Text="Please select" Value="-1" Selected="True" />
            <asp:ListItem Text="text1" />
            <asp:ListItem Text="text2" />
            <asp:ListItem Text="text3" />
        </asp:DropDownList>
        <asp:RequiredFieldValidator ErrorMessage="Ddl required" ControlToValidate="ddl" runat="server" InitialValue="-1" Text="*" />
        <asp:Button Text="text" runat="server" />
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:Timer runat="server" Interval="1000" OnLoad="Unnamed_Load" OnTick="Unnamed_Tick"></asp:Timer>
                <asp:Literal Text="text" runat="server" ID="msg" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
