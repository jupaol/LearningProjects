<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="Msts.ForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:UpdateProgress runat="server" DisplayAfter="0">
                <ProgressTemplate>
                    Processing...
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:LoginView runat="server">
                <AnonymousTemplate>
                    <asp:PasswordRecovery runat="server" ID="passwordRecovery" BackColor="#FFFBD6" BorderColor="#FFDFAD" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em">

                        <SubmitButtonStyle BackColor="White" BorderColor="#CC9966" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000"></SubmitButtonStyle>

                        <InstructionTextStyle Font-Italic="True" ForeColor="Black"></InstructionTextStyle>

                        <SuccessTextStyle Font-Bold="True" ForeColor="#990000"></SuccessTextStyle>

                        <TextBoxStyle Font-Size="0.8em"></TextBoxStyle>

                        <TitleTextStyle BackColor="#990000" Font-Bold="True" Font-Size="0.9em" ForeColor="White"></TitleTextStyle>
                        <UserNameTemplate>
                            <table cellspacing="0" cellpadding="4" style="border-collapse: collapse;">
                                <tr>
                                    <td>
                                        <table cellpadding="0">
                                            <tr>
                                                <td align="center" colspan="2" style="color: White; background-color: #990000; font-size: 0.9em; font-weight: bold;">Forgot Your Password?</td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2" style="color: Black; font-style: italic;">Enter your User Name to receive your password.</td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label runat="server" AssociatedControlID="UserName" ID="UserNameLabel">User Name:</asp:Label></td>
                                                <td>
                                                    <asp:TextBox runat="server" Font-Size="0.8em" ID="UserName"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ValidationGroup="passwordRecovery" ToolTip="User Name is required." ID="UserNameRequired">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2" style="color: Red;">
                                                    <asp:Literal runat="server" ID="FailureText" EnableViewState="False"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" colspan="2">
                                                    <asp:Button runat="server" CommandName="Submit" Text="Submit" ValidationGroup="passwordRecovery" BackColor="White" BorderColor="#CC9966" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" ID="SubmitButton"></asp:Button>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </UserNameTemplate>
                    </asp:PasswordRecovery>
                </AnonymousTemplate>
                <LoggedInTemplate>
                    In order to change your password please go to the 
                    <asp:HyperLink NavigateUrl="~/ChangePassword.aspx" runat="server" Text="Change password page" />
                </LoggedInTemplate>
            </asp:LoginView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
