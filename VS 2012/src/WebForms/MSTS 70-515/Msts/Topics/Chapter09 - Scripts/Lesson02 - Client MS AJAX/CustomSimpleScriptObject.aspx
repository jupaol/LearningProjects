<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="CustomSimpleScriptObject.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson02___Client_MS_AJAX.CustomSimpleScriptObject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        This page will test a custom script control created with the MS AJAX library
    </h1>
    <asp:ScriptManagerProxy runat="server" ID="smp">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/Chapter09/SimpleValidator.js" />
        </Scripts>
    </asp:ScriptManagerProxy>
    <script>
        $(function () {
            var $register = $("input:submit[id$=registerUser]");
            var $user = $("input:text[id$=username]");

            $register.click(function (e) {
                e.preventDefault();

                var o = new Msts.UI.Client.Controls.Validators.RequiredFieldValidator($user.val());

                alert(o.FieldValue);
                alert(o.get_FieldValue());
                alert(o.get_ShouldValidate());
                alert(o.isValid());
            });
        });
    </script>
    <div>
        Username:
    </div>
    <div>
        <asp:TextBox runat="server" ID="username" />
    </div>
    <div>
        <asp:Button Text="Register user" runat="server" ID="registerUser" OnClick="registerUser_Click" />
    </div>
</asp:Content>
