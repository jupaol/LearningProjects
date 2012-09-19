<%@ Page MaintainScrollPositionOnPostback="true" Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="TestingValidation.aspx.cs" Inherits="Msts.Topics.Chapter05.Lesson01___Input_Validation.TestingValidation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Testing ASP:Net valdiators
    </h1>
    <fieldset>
        <legend>
            Validator controls
        </legend>
        <div>
            <asp:ValidationSummary DisplayMode="BulletList" ShowModelStateErrors="true" ShowMessageBox="true" ShowSummary="true" ShowValidationErrors="true" runat="server" ID="registeringUserValidationSummary" ValidationGroup="registeringUserValidationGroup" />
        </div>
        <div>
            <asp:Label Text="Username" runat="server" ID="usernameMsg" AssociatedControlID="username" />
        </div>
        <div>
            <asp:TextBox ID="username" runat="server" ValidationGroup="registeringUserValidationGroup" />
            <asp:RequiredFieldValidator ErrorMessage="The username is required" ControlToValidate="username" runat="server" Text="*" ValidationGroup="registeringUserValidationGroup" Display="Dynamic" />
        </div>
        <div>
            <asp:Label Text="Password" runat="server" ID="passwordMsg" AssociatedControlID="password" />
        </div>
        <div>
            <asp:TextBox runat="server" ID="password" TextMode="Password" ValidationGroup="registeringUserValidationGroup" />
            <asp:RequiredFieldValidator ErrorMessage="Password required" ControlToValidate="password" runat="server" ValidationGroup="registeringUserValidationGroup" Display="Dynamic" Text="*" />
        </div>
        <div>
            <asp:Label Text="Confirm password" runat="server" ID="confirmPasswordMsg" AssociatedControlID="confirmPassword" />
        </div>
        <div>
            <asp:TextBox runat="server" ID="confirmPassword" TextMode="Password" ValidationGroup="registeringUserValidationGroup" />
            <asp:RequiredFieldValidator ErrorMessage="Confirm password required" ControlToValidate="confirmPassword" runat="server" Text="*" ValidationGroup="registeringUserValidationGroup" Display="Dynamic" />
            <asp:CompareValidator ErrorMessage="Password do not match" ControlToValidate="confirmPassword" runat="server" Text="No matc" ValidationGroup="registeringUserValidationGroup" Display="Dynamic" ControlToCompare="password" Operator="Equal" />
        </div>
        <div>
            <asp:Label Text="Email" runat="server" ID="emailMsg" AssociatedControlID="email" />
        </div>
        <div>
            <asp:TextBox runat="server" ID="email" />
            <asp:RequiredFieldValidator ErrorMessage="Email is required" ControlToValidate="email" runat="server" Text="*" Display="Dynamic" ValidationGroup="registeringUserValidationGroup" />
            <asp:RegularExpressionValidator ErrorMessage="Email is not valid" ControlToValidate="email" runat="server" Text="Not valid" Display="Dynamic" ValidationGroup="registeringUserValidationGroup" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
        </div>
        <div>
            <asp:Label Text="Confirm email" runat="server" ID="confirmEmailMsg" AssociatedControlID="confirmEmail" />
        </div>
        <div>
            <asp:TextBox runat="server" ID="confirmEmail" />
            <asp:RequiredFieldValidator ErrorMessage="Confirm email is required" ControlToValidate="confirmEmail" runat="server" Text="*" Display="Dynamic" ValidationGroup="registeringUserValidationGroup" />
            <asp:RegularExpressionValidator ErrorMessage="Confirm email is not valid" ControlToValidate="confirmEmail" runat="server" Text="Not valid" Display="Dynamic" ValidationGroup="registeringUserValidationGroup" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
            <asp:CompareValidator ErrorMessage="Emails do not match" ControlToValidate="confirmEmail" runat="server" Text="Not match" Display="Dynamic" ValidationGroup="registeringUserValidationGroup" ControlToCompare="email" Operator="Equal" />
        </div>
        <div>
            <asp:Label Text="Birthday date" runat="server" ID="birthdayDateMsg" AssociatedControlID="birthdayDate" />
        </div>
        <div>
            <asp:TextBox runat="server" ID="birthdayDate" ValidationGroup="registeringUserValidationGroup" />
            <asp:RequiredFieldValidator ErrorMessage="Birthdaye Date is required" ControlToValidate="birthdayDate" runat="server" Text="*" Display="Dynamic" ValidationGroup="registeringUserValidationGroup" />
            <asp:CompareValidator ErrorMessage="Birthday Date is not valid" ControlToValidate="birthdayDate" runat="server" Text="Not valid" Display="Dynamic" ValidationGroup="registeringUserValidationGroup" Operator="DataTypeCheck" Type="Date" CultureInvariantValues="true" />
            <asp:RangeValidator 
                ErrorMessage="Birthday date is out of range" 
                ControlToValidate="birthdayDate" 
                runat="server" 
                Text="Out of range" 
                Display="Dynamic" 
                ValidationGroup="registeringUserValidationGroup" 
                Type="Date" 
                CultureInvariantValues="false" 
                ID="birthdayDateRangeValidator" />
        </div>
        <div>
            <asp:Label Text="Please entre your personal rating (1-10)" runat="server" ID="personalRatingMsg" AssociatedControlID="personalRating" />
        </div>
        <div>
            <asp:TextBox runat="server" ID="personalRating" ValidationGroup="registeringUserValidationGroup" />
            <asp:RequiredFieldValidator ErrorMessage="Personal rating is required" ControlToValidate="personalRating" runat="server" Text="*" Display="Dynamic" ValidationGroup="registeringUserValidationGroup" />
            <asp:CompareValidator ErrorMessage="The personal rating must be a number" ControlToValidate="personalRating" runat="server" Text="Must be a number" Display="Dynamic" ValidationGroup="registeringUserValidationGroup" Operator="DataTypeCheck" Type="Integer" />
            <asp:RangeValidator ErrorMessage="The personal rating range is not valid" ControlToValidate="personalRating" runat="server" ID="personalRatingValidator" Text="Out of range" Display="Dynamic" ValidationGroup="registeringUserValidationGroup" MinimumValue="1" MaximumValue="10" Type="Integer" />
        </div>
        <div>
            <asp:Label Text="Prefered color" runat="server" ID="preferedColorMsg" AssociatedControlID="preferedColors" />
        </div>
        <div>
            <asp:DropDownList runat="server" ID="preferedColors" AutoPostBack="true" CausesValidation="true" OnSelectedIndexChanged="preferedColors_SelectedIndexChanged" ValidationGroup="registeringUserValidationGroup">
                <asp:ListItem Text="Select your prefered color" Selected="True" Value="-1" />
                <asp:ListItem Text="Blue" />
                <asp:ListItem Text="Red" />
                <asp:ListItem Text="Black" />
            </asp:DropDownList>
            <asp:RequiredFieldValidator ErrorMessage="The prefered color is required" ControlToValidate="preferedColors" runat="server" Text="*" Display="Dynamic" ValidationGroup="registeringUserValidationGroup" InitialValue="-1" />
        </div>
        <div>
            <asp:Label Text="Favorite email provider" runat="server" ID="favoriteEmailProviderMsg" AssociatedControlID="favoriteEmailProvider" />
        </div>
        <div>
            <asp:TextBox runat="server" ID="favoriteEmailProvider" ValidationGroup="registeringUserValidationGroup" />
            <asp:RequiredFieldValidator ErrorMessage="The favorite email provider is required" ControlToValidate="favoriteEmailProvider" runat="server" Text="*" Display="Dynamic" ValidationGroup="registeringUserValidationGroup" />
            <asp:CustomValidator 
                ErrorMessage="The email provider is not valid" 
                ControlToValidate="favoriteEmailProvider" 
                runat="server" 
                Text="Not valid (Google | Microsoft)" 
                ToolTip="Valid providers: Google | Microsoft"
                Display="Dynamic" 
                ValidationGroup="registeringUserValidationGroup" 
                ValidateEmptyText="false" 
                ClientValidationFunction="favoriteEmailProviderValidation" 
                ID="favoriteEmailProviderValdiator" 
                OnServerValidate="favoriteEmailProviderValdiator_ServerValidate" />
            <script type="text/javascript">
                function favoriteEmailProviderValidation(source, args) {
                    var value = new String(args.Value);

                    switch (value.toLowerCase()) {
                        case "google":
                        case "microosft":
                            args.IsValid = true;
                            break;
                        default:
                            args.IsValid = false;
                            break;
                    }
                }
            </script>
        </div>
        <div>
            <asp:LinkButton Text="Send info" runat="server" ID="sendInfo" ValidationGroup="registeringUserValidationGroup" OnClick="sendInfo_Click" />
        </div>
    </fieldset>
</asp:Content>

