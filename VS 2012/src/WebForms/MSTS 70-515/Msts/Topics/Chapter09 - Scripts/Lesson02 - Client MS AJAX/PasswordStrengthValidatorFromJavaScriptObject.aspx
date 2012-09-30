<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="PasswordStrengthValidatorFromJavaScriptObject.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson02___Client_MS_AJAX.PasswordStrengthValidatorFromJavaScriptObject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManagerProxy runat="server" ID="smp">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/Chapter09/PasswordLengthValidator.js" />
        </Scripts>
    </asp:ScriptManagerProxy>
    <h1>
        Testing a custom JavaScript control created with the MS AJAX framework
    </h1>
    <script>
        $(function () {
            var $text = $("input:password[id$=password]");
            var $btn = $("input:submit[id$=btn]");
            var $msg = $("#msg");
            var v = new Msts.UI.Client.Controls.Validators.passwordStrengthValidator(true, 8);

            $btn.click(function (e) {
                if (!v.isValid($text.val())) {
                    e.preventDefault();
                    alert("Password invalid");
                }
            });

            $text.keyup(function (e) {
                var val = $(this).val();

                $msg.text('');

                if (val.length > 0) {
                    var strength = v.getPasswordStrength(val);

                    switch (strength) {
                        case Msts.UI.Client.Controls.Validators.passwordStrength.Weak:
                            $msg.text("Weak");
                            break;
                        case Msts.UI.Client.Controls.Validators.passwordStrength.Medium:
                            $msg.text("Medium");
                            break;
                        case Msts.UI.Client.Controls.Validators.passwordStrength.Strong:
                            $msg.text("Strong");
                            break;
                    }
                }
            });
        });
    </script>
    <h3>
        Validate password
    </h3>
    <div>
        <asp:Label Text="Password" runat="server" AssociatedControlID="password" ID="passwordMessage" />
    </div>
    <div>
        <asp:TextBox runat="server" TextMode="Password" ID="password" />
        <div id="msg">

        </div>
    </div>
    <div>
        <asp:Button Text="Validate" runat="server" ID="btn" />
    </div>
</asp:Content>
