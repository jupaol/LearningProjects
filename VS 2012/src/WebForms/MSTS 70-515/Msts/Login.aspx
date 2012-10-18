<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Msts.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Login runat="server" ID="logn">
        
    </asp:Login>
    <hr />
    <div>
        <asp:HyperLink NavigateUrl="~/CreateAccount.aspx" runat="server" ID="createAccountLink" Text="Create account" />
    </div>
    <div>
        <asp:HyperLink runat="server" ID="forgotPassword" NavigateUrl="~/ForgotPassword.aspx" Text="Forgot password?"></asp:HyperLink>
    </div>
</asp:Content>
