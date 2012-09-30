<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="AjaxClientControl.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson02___Client_MS_AJAX.AjaxClientControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .weak {
            background-color:red;
        }
        .medium {
            background-color:yellow;
        }
        .strong {
            background-color:green;
        }
    </style>
    <asp:ScriptManagerProxy runat="server" ID="smp">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/Chapter09/PasswordLengthValidator.js" />
            <asp:ScriptReference Path="~/Scripts/Chapter09/PasswordLengthControl.js" />
        </Scripts>
    </asp:ScriptManagerProxy>
    <h1>
        Creating an AJAX client control
    </h1>
    <h3>
        This is a client UI control created with MS AJAX
    </h3>
    <div>
        <asp:Label Text="Password:" runat="server" ID="passwordMessage" AssociatedControlID="password" />
    </div>
    <div>
        <asp:TextBox runat="server" ID="password" TextMode="Password" />
    </div>
    <script>
        Sys.Application.add_init(function (s, e) {
            $create(
                Msts.UI.Client.Controls.passwordLengthControl,
                { "weakCss": "weak", "mediumCss": "medium", "strongCss": "strong" },
                null,
                null,
                $get("<%: this.password.ClientID%>")
            );
        });
    </script>
</asp:Content>
