<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="ServerTransferTest.aspx.cs" Inherits="Msts.Topics.Chapter05.Lesson02.ServerTransferTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Server transfer
    </h1>
    <asp:TextBox runat="server" ID="txt" />
    <asp:Button Text="Send info" runat="server" OnClick="Unnamed_Click" />
</asp:Content>
