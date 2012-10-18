<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="CompositeControlsTest.aspx.cs" Inherits="Msts.Topics.Chapter07___Server_Controls.Lesson02___Server_Controls.CompositeControlsTest" %>
<%@ Register Assembly="Msts" Namespace="Msts.Topics.Chapter07___Server_Controls.Lesson02___Server_Controls" TagPrefix="userPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>
        Try with: user-password!
    </h3>
    <userPassword:UserPassword runat="server" ID="userPassword1">
    </userPassword:UserPassword>
</asp:Content>
