<%@ Page EnableViewStateMac="true" Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="InitCompleteEventAndViewState.aspx.cs" Inherits="Msts.Topics.Chapter03.Lesson01.InitCompleteEventAndViewState" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label Text="This won't be overriden because its text property is set on the InitComplete event therefore before the ViewState has been loaded" runat="server" AssociatedControlID="txt" />
    </div>
    <div>
        <asp:TextBox runat="server" ID="txt"></asp:TextBox>
    </div>
    <div>
        <asp:Label Text="This will be overridden because its text property is set on the PreLoad event therefore the ViewState has already been loaded" runat="server" AssociatedControlID="txt2" />
    </div>
    <div>
        <asp:TextBox runat="server" ID="txt2"></asp:TextBox>
    </div>
    <div>
        <asp:Button Text="Subit me" runat="server" />
    </div>
</asp:Content>
