<%@ Page
    EnableViewState="true"
    ViewStateMode="Enabled"

    ViewStateEncryptionMode="Always"
    EnableViewStateMac="true"

    EnableEventValidation="true"
    ValidateRequest="true"

    MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" Language="C#" AutoEventWireup="true" CodeBehind="ViewStateSecurity.aspx.cs" Inherits="Msts.Topics.Chapter03.Lesson02___ClientSideState.ViewStateSecurity" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:TextBox runat="server" />
    <asp:Button Text="Submit me" runat="server" />
</asp:Content>