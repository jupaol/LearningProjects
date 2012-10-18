<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserControl3.ascx.cs" Inherits="Msts.Topics.Chapter05.Lesson03___WebParts.UserControl3" %>

<div>
    <asp:TextBox runat="server" ID="postalCode" />
</div>
<asp:LinkButton Text="Gogogogogog process" runat="server" ID="process" OnClick="process_Click" />

<asp:Panel runat="server" GroupingText="Summary">
    <asp:Literal ID="msg" runat="server" />
</asp:Panel>
