<%@ Page Title="Forgot Password" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="WebSecurity.Account.ForgotPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1><%: this.Title %>.</h1>
    </hgroup>
    <section id="forgotPassword">
        <h2>Enter your data to retrieve your password</h2>
        <asp:PasswordRecovery runat="server" ID="passwordRecovery">
            
        </asp:PasswordRecovery>
    </section>
</asp:Content>
