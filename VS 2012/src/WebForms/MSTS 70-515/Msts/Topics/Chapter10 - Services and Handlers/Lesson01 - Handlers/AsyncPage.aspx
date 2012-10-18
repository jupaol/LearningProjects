<%@ Page Trace="true" TraceMode="SortByTime" Async="true" Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="AsyncPage.aspx.cs" Inherits="Msts.Topics.Chapter10___Services_and_Handlers.Lesson01___Handlers.AsyncPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Async page
    </h1>
    <h2>
        This page is executed asynchronously and it was configured adding the 
        <code>Async="true"</code> page's directive property
    </h2>
    <div>
        <asp:Button Text="Call long time consuming operation asynchronously..." runat="server" OnClick="Unnamed_Click" />
    </div>
    <div>
        <asp:Label Text="text" runat="server" ID="msg" />
    </div>
</asp:Content>
