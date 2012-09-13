<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebSecurity.Account.Login" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
    </hgroup>
    <section id="loginForm">
        <h2>Use a local account to log in.</h2>
        <p>
            The login info is: <b>admin-<%= Server.HtmlEncode("passw0rd!") %></b>
            <br />
            Try using this information to hack the site: 
            <br />
            <ul>
                <li>
                    User Name: <b><%= Server.HtmlEncode("admin' or 1=1;--") %></b>
                </li>
                <li>
                    Password: <b>Anything you like</b>
                </li>
                <li>
                    <b>Be sure to select the <%= Server.HtmlEncode(@"""Use fragil authentication mechanism""") %></b>
                </li>
            </ul>
        </p>
        <asp:Login runat="server" ID="login" ViewStateMode="Disabled" RenderOuterTable="false" OnLoggingIn="Unnamed1_LoggingIn">
            <LayoutTemplate>
                <p class="validation-summary-errors">
                    <asp:Literal runat="server" ID="FailureText" />
                </p>
                <fieldset>
                    <legend>Log in Form</legend>
                    <ol>
                        <li>
                            <asp:Label runat="server" AssociatedControlID="UserName">User name</asp:Label>
                            <asp:TextBox runat="server" ID="UserName" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" CssClass="field-validation-error" ErrorMessage="The user name field is required." />
                        </li>
                        <li>
                            <asp:Label runat="server" AssociatedControlID="Password">Password</asp:Label>
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="field-validation-error" ErrorMessage="The password field is required." />
                        </li>
                        <li>
                            <asp:CheckBox runat="server" ID="RememberMe" />
                            <asp:Label runat="server" AssociatedControlID="RememberMe" CssClass="checkbox">Remember me?</asp:Label>
                        </li>
                        <li>
                            <asp:CheckBox runat="server" ID="useFragilAuthentication" />
                            <asp:Label runat="server" AssociatedControlID="useFragilAuthentication" CssClass="checkbox" Text="Use fragil authentication mechanism"></asp:Label>
                        </li>
                    </ol>
                    <asp:Button runat="server" CommandName="Login" Text="Log in" />
                </fieldset>
            </LayoutTemplate>
        </asp:Login>
        <p>
            <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register</asp:HyperLink>
            if you don't have an account.
        </p>
        <p>
            <asp:HyperLink runat="server" ID="forgotPasswordHyperLink" ViewStateMode="Disabled">Forgot your password?</asp:HyperLink>
        </p>
    </section>

    <section id="socialLoginForm">
        <h2>Use another service to log in.</h2>
        <uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" />
    </section>
</asp:Content>
