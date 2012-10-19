<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="Msts.CreateAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:CreateUserWizard runat="server" ID="createUser"
            ContinueDestinationPageUrl="~/"
            DisplayCancelButton="true" CancelDestinationPageUrl="~/"
            EditProfileText="Edit Profile" EditProfileUrl="~/Topics/Chapter13 - Profiles and security/Lesson01 - Profiles/WorkingWithTheProfileOnTheServerSide.aspx"
            BackColor="#F7F6F3" BorderColor="#E6E2D8" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" 
            ActiveStepIndex="0" 
            AutoGeneratePassword="false"
            OnSendingMail="createUser_SendingMail" 
            MailDefinition-BodyFileName="~/Topics/Chapter13 - Profiles and security/Lesson02 - Membership/UserCreatedEmailBody.txt" 
            MailDefinition-CC="myccemail@mailinator.com" 
            MailDefinition-From="admin@mysite.com" 
            MailDefinition-IsBodyHtml="True" 
            MailDefinition-Priority="High" 
            MailDefinition-Subject="User created">
            <ContinueButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" ForeColor="#284775"></ContinueButtonStyle>

            <CreateUserButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" ForeColor="#284775"></CreateUserButtonStyle>

            <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></TitleTextStyle>
            <MailDefinition>
                <EmbeddedObjects>
                    <asp:EmbeddedMailObject Name="logo" Path="~/Topics/Chapter13 - Profiles and security/Lesson02 - Membership/logo.jpg" />
                </EmbeddedObjects>
            </MailDefinition>
            <WizardSteps>
                <asp:CreateUserWizardStep runat="server">
                    <ContentTemplate>
                        <table style="font-family: Verdana; font-size: 100%;">
                            <tr>
                                <td align="center" colspan="2" style="color: White; background-color: #5D7B9D; font-weight: bold;">Sign Up for Your New Account</td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label runat="server" AssociatedControlID="UserName" ID="UserNameLabel">User Name:</asp:Label></td>
                                <td>
                                    <asp:TextBox runat="server" ID="UserName"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ValidationGroup="createUser" ToolTip="User Name is required." ID="UserNameRequired">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label runat="server" AssociatedControlID="Password" ID="PasswordLabel">Password:</asp:Label></td>
                                <td>
                                    <asp:TextBox runat="server" TextMode="Password" ID="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ValidationGroup="createUser" ToolTip="Password is required." ID="PasswordRequired">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label runat="server" AssociatedControlID="ConfirmPassword" ID="ConfirmPasswordLabel">Confirm Password:</asp:Label></td>
                                <td>
                                    <asp:TextBox runat="server" TextMode="Password" ID="ConfirmPassword"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword" ErrorMessage="Confirm Password is required." ValidationGroup="createUser" ToolTip="Confirm Password is required." ID="ConfirmPasswordRequired">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label runat="server" AssociatedControlID="Email" ID="EmailLabel">E-mail:</asp:Label></td>
                                <td>
                                    <asp:TextBox runat="server" ID="Email"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" ErrorMessage="E-mail is required." ValidationGroup="createUser" ToolTip="E-mail is required." ID="EmailRequired">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label runat="server" AssociatedControlID="Question" ID="QuestionLabel">Security Question:</asp:Label></td>
                                <td>
                                    <asp:TextBox runat="server" ID="Question"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Question" ErrorMessage="Security question is required." ValidationGroup="createUser" ToolTip="Security question is required." ID="QuestionRequired">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label runat="server" AssociatedControlID="Answer" ID="AnswerLabel">Security Answer:</asp:Label></td>
                                <td>
                                    <asp:TextBox runat="server" ID="Answer"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Answer" ErrorMessage="Security answer is required." ValidationGroup="createUser" ToolTip="Security answer is required." ID="AnswerRequired">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" ErrorMessage="The Password and Confirmation Password must match." Display="Dynamic" ValidationGroup="createUser" ID="PasswordCompare"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="color: Red;">
                                    <asp:Literal runat="server" ID="ErrorMessage" EnableViewState="False"></asp:Literal>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                    <CustomNavigationTemplate>
                        <table cellspacing="5" border="0" style="width: 100%; height: 100%;">
                            <tr align="right">
                                <td align="right" colspan="0">
                                    <asp:Button runat="server" CommandName="MoveNext" Text="Create User" ValidationGroup="createUser" BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" ForeColor="#284775" ID="StepNextButton"></asp:Button>
                                </td>
                                <td align="right" colspan="0">
                                    <asp:Button runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" ValidationGroup="createUser" BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" ForeColor="#284775" ID="CancelButton"></asp:Button>
                                </td>
                            </tr>
                        </table>
                    </CustomNavigationTemplate>
                </asp:CreateUserWizardStep>
                <asp:CompleteWizardStep runat="server">
                    <ContentTemplate>
                        <table style="font-family: Verdana; font-size: 100%;">
                            <tr>
                                <td align="center" colspan="2" style="color: White; background-color: #5D7B9D; font-weight: bold;">Complete</td>
                            </tr>
                            <tr>
                                <td>Your account has been successfully created.</td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2">
                                    <asp:Button runat="server" CausesValidation="False" CommandName="Continue" Text="Continue" ValidationGroup="createUser" BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" ForeColor="#284775" ID="ContinueButton"></asp:Button>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:HyperLink runat="server" NavigateUrl="~/Topics/Chapter13 - Profiles and security/Lesson01 - Profiles/WorkingWithTheProfileOnTheServerSide.aspx" ID="EditProfileLink">Edit Profile</asp:HyperLink>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:CompleteWizardStep>
            </WizardSteps>
            <FinishNavigationTemplate>
                <asp:Button runat="server" CausesValidation="False" CommandName="MovePrevious" Text="Previous" BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" ForeColor="#284775" ID="FinishPreviousButton"></asp:Button>
                <asp:Button runat="server" CommandName="MoveComplete" Text="Finish" BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" ForeColor="#284775" ID="FinishButton"></asp:Button>
                <asp:Button runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" ValidationGroup="createUser" BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" ForeColor="#284775" ID="CancelButton"></asp:Button>
            </FinishNavigationTemplate>

            <HeaderStyle HorizontalAlign="Center" BackColor="#5D7B9D" BorderStyle="Solid" Font-Bold="True" Font-Size="0.9em" ForeColor="White"></HeaderStyle>

            <NavigationButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" ForeColor="#284775"></NavigationButtonStyle>

            <SideBarButtonStyle ForeColor="White" BorderWidth="0px" Font-Names="Verdana"></SideBarButtonStyle>

            <SideBarStyle VerticalAlign="Top" BackColor="#5D7B9D" Font-Size="0.9em" BorderWidth="0px"></SideBarStyle>
            <StartNavigationTemplate>
                <asp:Button runat="server" CommandName="MoveNext" Text="Next" BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" ForeColor="#284775" ID="StartNextButton"></asp:Button>
                <asp:Button runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" ValidationGroup="createUser" BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" ForeColor="#284775" ID="CancelButton"></asp:Button>
            </StartNavigationTemplate>

            <StepNavigationTemplate>
                <asp:Button runat="server" CausesValidation="False" CommandName="MovePrevious" Text="Previous" BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" ForeColor="#284775" ID="StepPreviousButton"></asp:Button>
                <asp:Button runat="server" CommandName="MoveNext" Text="Next" BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" ForeColor="#284775" ID="StepNextButton"></asp:Button>
                <asp:Button runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" ValidationGroup="createUser" BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" ForeColor="#284775" ID="CancelButton"></asp:Button>
            </StepNavigationTemplate>

            <StepStyle BorderWidth="0px"></StepStyle>
        </asp:CreateUserWizard>
    </div>
</asp:Content>
