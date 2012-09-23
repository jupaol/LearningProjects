<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserControl2.ascx.cs" Inherits="Msts.Topics.Chapter05.Lesson03___WebParts.UserControl2" %>

<asp:FileUpload runat="server" ID="fileUpload" />

<asp:Panel runat="server" GroupingText="Date Summary">
    <asp:Literal ID="msg" runat="server" />
</asp:Panel>
