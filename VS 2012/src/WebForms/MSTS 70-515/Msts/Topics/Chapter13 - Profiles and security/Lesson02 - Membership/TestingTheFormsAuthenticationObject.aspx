<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="TestingTheFormsAuthenticationObject.aspx.cs" Inherits="Msts.Topics.Chapter13___Profiles_and_security.Lesson02___Membership.TestingTheFormsAuthenticationObject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        $(function () {
            var viewModel = ko.validatedObservable({
                username: ko.observable("specialuser").extend({
                    required: true,
                    minLength: 2,
                    maxLength: 15
                }),
                password: ko.observable("password!").extend({
                    required: true,
                    minLength: 1,
                    maxLength: 11
                }),
                redirectUrl: ko.observable(),
                editMode: ko.observable(false),
                authenticated: ko.observable(Sys.Services.AuthenticationService.get_isLoggedIn())
            });
            var $login = $("input:submit[id$=login]");
            var hiddenValue = "";
            var $username = $("input:text[id$=username]");
            var $password = $("input:password[id$=password]");

            $("form").tooltip();

            $("#commit").click(function (e) {
                e.preventDefault();

                viewModel().commit();
                viewModel().editMode(false);
            });

            $("#edit").click(function (e) {
                e.preventDefault();

                viewModel().editMode(true);
                viewModel().beginEdit();
            });

            $("#cancelEdit").click(function (e) {
                e.preventDefault();

                viewModel().rollback();
                viewModel().editMode(false);
            });

            Sys.Application.add_load(function (a, e) {
                var $hidden = $("input:hidden[id$=redirectUrl]");

                hiddenValue = $hidden.val();

                ko.validation.init();
                ko.editable(viewModel());
                ko.applyBindings(viewModel);

                $("#commit").click(function (e) {
                    e.preventDefault();

                    viewModel().commit();
                    viewModel().editMode(false);
                });

                $("#edit").click(function (e) {
                    e.preventDefault();

                    viewModel().editMode(true);
                    viewModel().beginEdit();
                });

                $("#cancelEdit").click(function (e) {
                    e.preventDefault();

                    viewModel().rollback();
                    viewModel().editMode(false);
                });
            });

            Sys.WebForms.PageRequestManager.getInstance().add_initializeRequest(function (a, e) {
                $.blockUI({
                    title: "Processing",
                    message: "Authenticating..."
                });
            });

            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function (a, e) {
                $.unblockUI();

                viewModel().redirectUrl(hiddenValue);

                if (viewModel().redirectUrl().length > 0) {
                    $.growlUI("", "OK... " + viewModel().redirectUrl());
                    viewModel().redirectUrl("");
                }

                var error = e.get_error();

                if (error !== undefined && error !== null) {
                    var errorMessage = error.message;
                    $.blockUI({
                        fadeIn: 1000,
                        theme: true,
                        title: "Error",
                        message: errorMessage,
                        timeout: 8000
                    });
                    e.set_errorHandled(true);
                }
            });

            ko.validation.init();
            ko.editable(viewModel());
            ko.applyBindings(viewModel);

            $login.click(function (e) {
                if(!viewModel.isValid())
                {
                    e.preventDefault();
                }
            });
        });
    </script>
    <h1>
        FormsAuthentication
    </h1>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:UpdateProgress runat="server" DisplayAfter="0">
                <ProgressTemplate>
                    Processing...
                </ProgressTemplate>
            </asp:UpdateProgress>

            <asp:Panel runat="server" GroupingText="Hint">
                <ul>
                    <li>
                        <span>specialuser</span> - <span>password!</span>
                    </li>
                </ul>
            </asp:Panel>

            <asp:Panel runat="server" GroupingText="Login">
                <div>
                    <asp:Label Text="Username" runat="server" AssociatedControlID="username" />
                </div>
                <div>
                    <asp:TextBox runat="server" ID="username" data-bind="value: username, valueUpdate: 'afterkeydown', enable: editMode" ToolTip="Please enter your username" />
                </div>
                <div>
                    <asp:Label Text="Password" runat="server" AssociatedControlID="password" />
                </div>
                <div>
                    <asp:TextBox runat="server" TextMode="Password"  ID="password" data-bind="value: password, valueUpdate: 'afterkeydown', enable: editMode" ToolTip="Please provide your password" />
                </div>
                <div>
                    <asp:CheckBox Text="Remember me" runat="server" ID="remmeberMe" Checked="true" />
                </div>
                <div>
                    <asp:CheckBox Text="Set Manual Authentication (reload required)" runat="server" ID="manualAuthentication" />
                </div>
                <div>
                    <asp:CheckBox Text="Use RedirectFromLoginPage" runat="server" ID="useRedirectFromLoginPage" />
                    <input type="hidden" id="redirectUrl" runat="server" data-bind="value: redirectUrl" />
                </div>
                <div>
                    <asp:Button Text="Login" runat="server" ID="login" OnClick="login_Click" data-bind="enable: isValid() && !editMode(), visible: !authenticated()" />
                    <asp:Button Text="Logout" runat="server" ID="logout" OnClick="logout_Click" data-bind="visible: authenticated(), enable: !editMode()" />
                    <input type="button" id="edit" value="Edit" data-bind="visible: !editMode()" />
                    <input type="button" id="commit" value="OK" data-bind="visible: editMode()" />
                    <input type="button" id="cancelEdit" value="Cancel Edit" style="display:none;" data-bind="visible: editMode()" />
                </div>
                <div>
                    <asp:Label ID="msg" runat="server" />
                </div>
            </asp:Panel>
            <hr />
            <asp:Panel runat="server" GroupingText="Values... Non security at all =)">
                <div>
                    <span>
                        Username entered:
                    </span>
                </div>
                <div>
                    <span data-bind="text: username, valueUpdate: 'afterkeydown'"></span>
                </div>
                <div>
                    <span>
                        Password:
                    </span>
                </div>
                <div>
                    <span data-bind="text: password, valueUpdate: 'afterkeydown'"></span>
                </div>
                <div>
                    <span data-bind="text: redirectUrl"></span>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
