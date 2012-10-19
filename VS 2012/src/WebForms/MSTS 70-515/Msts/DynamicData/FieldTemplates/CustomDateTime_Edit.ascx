<%@ Control Language="C#" CodeBehind="CustomDateTime_Edit.ascx.cs" Inherits="Msts.DynamicData.FieldTemplates.CustomDateTime_EditField" %>

<asp:TextBox ID="TextBox1" runat="server" Text='<%# FieldValueEditString %>'></asp:TextBox>

<ajaxToolkit:CalendarExtender runat="server" ID="calendarExtender"
    TargetControlID="TextBox1">

</ajaxToolkit:CalendarExtender>

<asp:DynamicValidator runat="server" ID="DynamicValidator1" CssClass="DDControl DDValidator" ControlToValidate="TextBox1" Display="Static" />
<asp:CompareValidator ErrorMessage="Invalid Value" ControlToValidate="TextBox1" runat="server" Type="Date" Text="*" Operator="DataTypeCheck" />