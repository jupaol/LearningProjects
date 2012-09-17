<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SimpleValidation.aspx.cs" Inherits="Msts.Topics.Chapter06.Lesson01___Input_Validation.SimpleValidation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager runat="server" ID="scriptManager" EnableCdn="false">
            <Scripts>
                <asp:ScriptReference Name="jquery" />
            </Scripts>
        </asp:ScriptManager>
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
        <asp:RequiredFieldValidator ErrorMessage="errormessage" ControlToValidate="txt" runat="server" Text="*" />
        <asp:Button Text="text" runat="server" />
    </div>
    </form>
</body>
</html>
