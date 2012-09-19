<%@ Page MaintainScrollPositionOnPostback="true" Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="SpecializedServerControls.aspx.cs" Inherits="Msts.Topics.Chapter04.Lesson01___Server_Controls.SpecializedServerControls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Specialized server controls
    </h1>
    <div>
        <asp:Table runat="server" ID="tableControl">
            <asp:TableHeaderRow TableSection="TableHeader">
                <asp:TableHeaderCell>
                    im a header
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow TableSection="TableBody">
                <asp:TableCell>
                    im a td
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableFooterRow TableSection="TableFooter">
                <asp:TableCell>
                    im a td on the footer
                </asp:TableCell>
            </asp:TableFooterRow>
        </asp:Table>
    </div>
    <div>
        <asp:Calendar runat="server" ID="calendar"
            Caption="calendar caption"
            CaptionAlign="Right"
            DayNameFormat="Full"
            FirstDayOfWeek="Sunday"
            NextMonthText="Next Month"
            NextPrevFormat="CustomText"

            PrevMonthText="Previous Month"
            SelectionMode="DayWeekMonth"
            SelectMonthText="Select month"
            SelectWeekText="select week"
            ShowDayHeader="true"
            ShowGridLines="true"
            ShowNextPrevMonth="true"
            ShowTitle="true"
            TitleFormat="MonthYear"
            ToolTip="my tooltip"
            UseAccessibleHeader="true"
            
            OnDayRender="calendar_DayRender"
            OnSelectionChanged="calendar_SelectionChanged1"
            OnVisibleMonthChanged="calendar_VisibleMonthChanged">
        </asp:Calendar>
    </div>
    <div>
        <asp:FileUpload runat="server" ID="fileUpload" />
        <asp:Button Text="Send File" runat="server" ID="sendFile" OnClick="sendFile_Click" />
        <br />
        <asp:Literal ID="msg" runat="server" />
    </div>
    <div>
        <h2>
            Panel control
        </h2>
        <asp:Panel runat="server" GroupingText="Something cool"></asp:Panel>
    </div>
    <div>
        <h2>
            Multiview control
        </h2>
        <asp:MultiView ActiveViewIndex="0" runat="server" ID="multiView" OnActiveViewChanged="multiView_ActiveViewChanged">
            <asp:View runat="server" ID="view1" OnActivate="view1_Activate" OnDeactivate="view1_Deactivate">
                View: 1
                <br />
                <asp:Literal ID="viewMsg1" runat="server" />
            </asp:View>
            <asp:View runat="server" ID="view2" OnActivate="view2_Activate" OnDeactivate="view2_Deactivate">
                View: 2
                <br />
                <asp:Literal ID="viewMsg2" runat="server" />
            </asp:View>
            <asp:View runat="server" ID="view3" OnActivate="view3_Activate" OnDeactivate="view3_Deactivate">
                View: 3
                <br />
                <asp:Literal ID="viewMsg3" runat="server" />
            </asp:View>
        </asp:MultiView>
        <br />
        <asp:DropDownList runat="server" ID="ddlViews" AutoPostBack="true" CausesValidation="true" OnSelectedIndexChanged="ddlViews_SelectedIndexChanged">
            <asp:ListItem Text="View1" Selected="True" />
            <asp:ListItem Text="View2" />
            <asp:ListItem Text="View3" />
        </asp:DropDownList>
        <br />
        <asp:Button Text="Prev view" runat="server" ID="prevCommand" OnCommand="view_Command" CommandName="prev" />
        <asp:Button Text="Next view" runat="server" ID="nextCommand" OnCommand="view_Command" CommandName="next" />
    </div>
    <div>
        <h2>
            The Wizard control
        </h2>
        <div>
            <asp:ValidationSummary ValidationGroup="mywizatd" ID="ValidationSummary1" runat="server" />
        </div>
        <asp:TextBox runat="server" ID="txt" ValidationGroup="simpleValidation" />
        <asp:RequiredFieldValidator EnableClientScript="true" ErrorMessage="errormessage" ControlToValidate="txt" runat="server" Text="*" ValidationGroup="simpleValidation" />
        <asp:Button Text="text" runat="server" ValidationGroup="simpleValidation" />
        <asp:Wizard 
            runat="server" ID="wizard"
            OnNextButtonClick="wizard_NextButtonClick" 
            OnActiveStepChanged="wizard_ActiveStepChanged"
            OnFinishButtonClick="wizard_FinishButtonClick"
            OnSideBarButtonClick="wizard_SideBarButtonClick" 
            BackColor="#FFFBD6" BorderColor="#FFDFAD" BorderWidth="1px" 
            Font-Names="Verdana" Font-Size="0.8em" Width="100%" ActiveStepIndex="0">
            <HeaderStyle HorizontalAlign="Center" BackColor="#FFCC66" BorderColor="#FFFBD6" BorderWidth="2px" BorderStyle="Solid" Font-Bold="True" Font-Size="0.9em" ForeColor="#333333"></HeaderStyle>
            <NavigationButtonStyle BackColor="White" BorderColor="#CC9966" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000"></NavigationButtonStyle>
            <SideBarButtonStyle ForeColor="White"></SideBarButtonStyle>
            <SideBarStyle VerticalAlign="Top" BackColor="#990000" Font-Size="0.9em"></SideBarStyle>
            <StepNavigationTemplate>
                <asp:Button runat="server" CausesValidation="False" CommandName="MovePrevious" Text="Previous" BackColor="White" BorderColor="#CC9966" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" ID="StepPreviousButton"></asp:Button>
                <asp:Button runat="server" CausesValidation="true" ValidationGroup="mywizatd" CommandName="MoveNext" Text="Next" BackColor="White" BorderColor="#CC9966" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" ID="StepNextButton"></asp:Button>
            </StepNavigationTemplate>
            <WizardSteps>
                <asp:WizardStep runat="server" ID="wizardStep1" AllowReturn="true" Title="Username" StepType="Auto">
                    <asp:Panel runat="server" ID="pnlUsername" GroupingText="Username settings">
                        <div>
                            <asp:Label ID="usernameLabel" Text="Please enter your username" runat="server" AssociatedControlID="username" />
                        </div>
                        <div>
                            <asp:TextBox runat="server" ID="username" ValidationGroup="mywizatd" />
                            <asp:RequiredFieldValidator EnableClientScript="true" ValidationGroup="mywizatd" ErrorMessage="The username is required" ControlToValidate="username" runat="server" Text=" - Required" />
                        </div>
                    </asp:Panel>
                </asp:WizardStep>
                <asp:WizardStep runat="server" ID="wizardStep2" Title="Password" StepType="Auto" AllowReturn="true">
                    <asp:Panel runat="server" ID="pnlPassword" GroupingText="Password settings">
                        <div>
                            <asp:Label Text="Please enter your password" runat="server" ID="passwordLabel" AssociatedControlID="password" />
                        </div>
                        <div>
                            <asp:TextBox runat="server" ID="password" TextMode="Password" />
                            <asp:RequiredFieldValidator ErrorMessage="The password is required" ControlToValidate="password" runat="server" Text=" - Required" ValidationGroup="mywizatd" />
                        </div>
                        <div>
                            <asp:Label Text="Please confirm your password" runat="server" ID="confirmPasswordLabel" AssociatedControlID="confirmPassword" />
                        </div>
                        <div>
                            <asp:TextBox runat="server" ID="confirmPassword" TextMode="Password" />
                            <asp:RequiredFieldValidator ErrorMessage="Please confirm your password" Display="Dynamic" ControlToValidate="confirmPassword" runat="server" ValidationGroup="mywizatd" Text=" - Required" />
                            <asp:CompareValidator ErrorMessage="The passwords do not match" Display="Dynamic" ControlToValidate="confirmPassword" ControlToCompare="password" runat="server" Text=" - No match" ValidationGroup="mywizatd" Operator="Equal" />
                        </div>
                    </asp:Panel>
                </asp:WizardStep>
                <asp:WizardStep ID="wizardStep3" runat="server" AllowReturn="true" StepType="Auto" Title="Email">
                    <asp:Panel runat="server" ID="pnlEmail" GroupingText="Email settings">
                        <div>
                            <asp:Label Text="Please enter your email" runat="server" ID="emailLabel" AssociatedControlID="email" />
                        </div>
                        <div>
                            <asp:TextBox runat="server" ID="email" TextMode="SingleLine" />
                            <asp:RequiredFieldValidator ErrorMessage="The email is required" ControlToValidate="email" runat="server" ValidationGroup="mywizatd" Display="Dynamic" Text=" - Required" />
                            <asp:RegularExpressionValidator ErrorMessage="The email is not valid" ControlToValidate="email" runat="server" ValidationGroup="mywizatd" Display="Dynamic" Text=" - Not valid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                        </div>
                        <div>
                            <asp:Label runat="server" ID="confirmEmailMsg" Text="Please confirm your email" AssociatedControlID="confirmEmail"></asp:Label>
                        </div>
                        <div>
                            <asp:TextBox runat="server" ID="confirmEmail" TextMode="SingleLine" />
                            <asp:RequiredFieldValidator ErrorMessage="You need to confirm your email" ControlToValidate="confirmEmail" runat="server" ValidationGroup="mywizatd" Display="Dynamic" Text=" - Required" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ErrorMessage="The email is not valid" ControlToValidate="confirmEmail" runat="server" ValidationGroup="mywizatd" Display="Dynamic" Text=" - Not valid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                            <asp:CompareValidator ErrorMessage="The emails do not match" ControlToValidate="confirmEmail" runat="server" ValidationGroup="mywizatd" Display="Dynamic" Text=" - do not match" ControlToCompare="email" Operator="Equal" />
                        </div>
                    </asp:Panel>
                </asp:WizardStep>
                <asp:WizardStep runat="server" ID="finishWizardStep" AllowReturn="false" StepType="Complete" Title="Process Complete">
                    <asp:Panel runat="server" ID="pnlComplete">
                        Thanks for your time!
                    </asp:Panel>
                </asp:WizardStep>
            </WizardSteps>
        </asp:Wizard>
        <asp:DropDownList runat="server" ID="ddlWizardSteps" AutoPostBack="true" CausesValidation="true" OnSelectedIndexChanged="ddlWizardSteps_SelectedIndexChanged">
            <asp:ListItem Text="Username" Selected="True" />
            <asp:ListItem Text="Password" />
            <asp:ListItem Text="Email" />
        </asp:DropDownList>
    </div>
</asp:Content>
