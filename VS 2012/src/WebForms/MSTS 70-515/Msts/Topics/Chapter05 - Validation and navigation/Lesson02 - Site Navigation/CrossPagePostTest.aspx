<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="CrossPagePostTest.aspx.cs" Inherits="Msts.Topics.Chapter05.Lesson02.CrossPagePostTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Cross page testing
    </h1>
    <asp:TextBox runat="server" ID="txt" />
    <asp:Button 
        Text="Send info to be processed on another page" 
        runat="server" 
        PostBackUrl="~/Topics/Chapter05 - Validation and navigation/Lesson02 - Site Navigation/ProcessingPage.aspx"
        OnClick="Unnamed_Click" />
</asp:Content>
