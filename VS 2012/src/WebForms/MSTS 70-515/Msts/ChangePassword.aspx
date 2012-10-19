<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Msts.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ChangePassword runat="server" ID="changePassword"
        CancelDestinationPageUrl="~/"
        ContinueDestinationPageUrl="~/" BackColor="#EFF3FB" BorderColor="#B5C7DE" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" MailDefinition-CC="myccemail@mailinator.com" MailDefinition-From="admin@mysite.com" MailDefinition-IsBodyHtml="True" MailDefinition-Priority="High" MailDefinition-Subject="Password reset dah" MailDefinition-BodyFileName="~/Topics/Chapter13 - Profiles and security/Lesson02 - Membership/PasswordResetMailContent.txt">

        <CancelButtonStyle BackColor="White" BorderColor="#507CD1" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98"></CancelButtonStyle>

        <ChangePasswordButtonStyle BackColor="White" BorderColor="#507CD1" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98"></ChangePasswordButtonStyle>
        <MailDefinition>
            <EmbeddedObjects>
                <asp:EmbeddedMailObject Path="~/Topics/Chapter13 - Profiles and security/Lesson02 - Membership/logo.jpg" />
            </EmbeddedObjects>
        </MailDefinition>
        <ChangePasswordTemplate>
            <table cellspacing="0" cellpadding="4" style="border-collapse: collapse;">
                <tr>
                    <td>
                        <table cellpadding="0">
                            <tr>
                                <td align="center" colspan="2" style="color: White; background-color: #507CD1; font-size: 0.9em; font-weight: bold;">Change Your Password</td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label runat="server" AssociatedControlID="CurrentPassword" ID="CurrentPasswordLabel">Password:</asp:Label></td>
                                <td>
                                    <asp:TextBox runat="server" TextMode="Password" Font-Size="0.8em" ID="CurrentPassword"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="CurrentPassword" ErrorMessage="Password is required." ValidationGroup="changePassword" ToolTip="Password is required." ID="CurrentPasswordRequired">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label runat="server" AssociatedControlID="NewPassword" ID="NewPasswordLabel">New Password:</asp:Label></td>
                                <td>
                                    <asp:TextBox runat="server" TextMode="Password" Font-Size="0.8em" ID="NewPassword"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="NewPassword" ErrorMessage="New Password is required." ValidationGroup="changePassword" ToolTip="New Password is required." ID="NewPasswordRequired">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label runat="server" AssociatedControlID="ConfirmNewPassword" ID="ConfirmNewPasswordLabel">Confirm New Password:</asp:Label></td>
                                <td>
                                    <asp:TextBox runat="server" TextMode="Password" Font-Size="0.8em" ID="ConfirmNewPassword"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmNewPassword" ErrorMessage="Confirm New Password is required." ValidationGroup="changePassword" ToolTip="Confirm New Password is required." ID="ConfirmNewPasswordRequired">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:CompareValidator runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword" ErrorMessage="The Confirm New Password must match the New Password entry." Display="Dynamic" ValidationGroup="changePassword" ID="NewPasswordCompare"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="color: Red;">
                                    <asp:Literal runat="server" ID="FailureText" EnableViewState="False"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Button runat="server" CommandName="ChangePassword" Text="Change Password" ValidationGroup="changePassword" BackColor="White" BorderColor="#507CD1" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" ID="ChangePasswordPushButton"></asp:Button>
                                </td>
                                <td>
                                    <asp:Button runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" BackColor="White" BorderColor="#507CD1" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" ID="CancelPushButton"></asp:Button>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ChangePasswordTemplate>

        <ContinueButtonStyle BackColor="White" BorderColor="#507CD1" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98"></ContinueButtonStyle>

        <InstructionTextStyle Font-Italic="True" ForeColor="Black"></InstructionTextStyle>

        <PasswordHintStyle Font-Italic="True" ForeColor="#507CD1"></PasswordHintStyle>

        <TextBoxStyle Font-Size="0.8em"></TextBoxStyle>

        <TitleTextStyle BackColor="#507CD1" Font-Bold="True" Font-Size="0.9em" ForeColor="White"></TitleTextStyle>
    </asp:ChangePassword>
</asp:Content>
