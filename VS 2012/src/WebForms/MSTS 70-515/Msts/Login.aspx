<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Msts.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Login runat="server" ID="logn" BackColor="#E3EAEB" BorderColor="#E6E2D8" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" TextLayout="TextOnTop">

        <InstructionTextStyle Font-Italic="True" ForeColor="Black"></InstructionTextStyle>

        <LayoutTemplate>
            <table cellspacing="0" cellpadding="4" style="border-collapse: collapse;">
                <tr>
                    <td>
                        <table cellpadding="0">
                            <tr>
                                <td align="center" style="color: White; background-color: #1C5E55; font-size: 0.9em; font-weight: bold;">Log In</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="UserName" ID="UserNameLabel">User Name:</asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox runat="server" Font-Size="0.8em" ID="UserName"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ValidationGroup="logn" ToolTip="User Name is required." ID="UserNameRequired">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" AssociatedControlID="Password" ID="PasswordLabel">Password:</asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox runat="server" TextMode="Password" Font-Size="0.8em" ID="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ValidationGroup="logn" ToolTip="Password is required." ID="PasswordRequired">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox runat="server" Text="Remember me next time." ID="RememberMe"></asp:CheckBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="color: Red;">
                                    <asp:Literal runat="server" ID="FailureText" EnableViewState="False"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Button runat="server" CommandName="Login" Text="Log In" ValidationGroup="logn" BackColor="White" BorderColor="#C5BBAF" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#1C5E55" ID="LoginButton"></asp:Button>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>

        <LoginButtonStyle BackColor="White" BorderColor="#C5BBAF" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#1C5E55"></LoginButtonStyle>

        <TextBoxStyle Font-Size="0.8em"></TextBoxStyle>

        <TitleTextStyle BackColor="#1C5E55" Font-Bold="True" Font-Size="0.9em" ForeColor="White"></TitleTextStyle>
    </asp:Login>
    <asp:ValidationSummary runat="server" ValidationGroup="logn" />
    <hr />
    <div>
        <asp:HyperLink NavigateUrl="~/CreateAccount.aspx" runat="server" ID="createAccountLink" Text="Create account" />
    </div>
    <div>
        <asp:HyperLink runat="server" ID="forgotPassword" NavigateUrl="~/ForgotPassword.aspx" Text="Forgot password?"></asp:HyperLink>
    </div>
</asp:Content>
