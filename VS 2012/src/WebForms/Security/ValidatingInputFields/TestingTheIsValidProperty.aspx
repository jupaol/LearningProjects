<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestingTheIsValidProperty.aspx.cs" Inherits="ValidatingInput.TestingTheIsValidProperty" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <fieldset>
            <legend>
                Some data
            </legend>
            <div>
                <asp:ValidationSummary runat="server" />
            </div>
            <div>
                <asp:Label ID="Label1" Text="First Name" runat="server" AssociatedControlID="firstName" />
                <asp:TextBox runat="server" ID="firstName"></asp:TextBox>
                <asp:RequiredFieldValidator EnableClientScript="false" ErrorMessage="First name is required" ControlToValidate="firstName" runat="server" Text="Required" />
            </div>
            <div>
                <asp:Label ID="Label2" Text="Last Name" runat="server" AssociatedControlID="lastName" />
                <asp:TextBox runat="server" ID="lastName"></asp:TextBox>
                <asp:RequiredFieldValidator EnableClientScript="false" ErrorMessage="Last name is required" ControlToValidate="lastName" runat="server" Text="Required" />
            </div>
            <div>
                <asp:Label Text="Gender" runat="server" AssociatedControlID="gender" />
                <asp:DropDownList runat="server" ID="gender" AutoPostBack="true" CausesValidation="true" OnSelectedIndexChanged="gender_SelectedIndexChanged">
                    <asp:ListItem Text="Please select a gender" Value="0" Selected="True" />
                    <asp:ListItem Text="Male" />
                    <asp:ListItem Text="Female" />
                    <asp:ListItem Text="Undefined" />
                </asp:DropDownList>
                <asp:RequiredFieldValidator EnableClientScript="false" ErrorMessage="The gender is required" ControlToValidate="gender" runat="server" InitialValue="0" Text="Required" />
            </div>
            <div>
                <asp:Button runat="server" CausesValidation="true" ID="btn" Text="Submit" OnClick="btn_Click" />
            </div>
        </fieldset>
    </div>
    </form>
</body>
</html>
