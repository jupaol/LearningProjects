<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="ServerExecuteTest.aspx.cs" Inherits="Msts.Topics.Chapter05.Lesson02.ServerExecuteTest" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Server Execute tests
    </h1>
    <asp:TextBox runat="server" ID="mytext" />
    <asp:Button Text="Send info" runat="server" OnClick="Unnamed_Click" />
</asp:Content>
