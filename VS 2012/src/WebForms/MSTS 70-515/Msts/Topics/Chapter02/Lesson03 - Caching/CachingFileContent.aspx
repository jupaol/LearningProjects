<%@ Page Trace="true" TraceMode="SortByTime" Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="CachingFileContent.aspx.cs" Inherits="Msts.Topics.Chapter02.Lesson03.CachingFileContent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Showing content of: <asp:Literal runat="server" ID="fileName"></asp:Literal></h2>
    <div style="font-weight:bold;">
        Change the content of the file to trigger the cache dependency and reload the file 
        content into the cache
    </div>
    <b><asp:Literal runat="server" ID="msg"></asp:Literal></b>
    <div>
        <asp:Literal runat="server" ID="fileContent" Mode="Encode"></asp:Literal>
    </div>
    <hr />
    <h2>Showing content of: <asp:Literal runat="server" ID="fileName2"></asp:Literal></h2>
    <div style="font-weight:bold;">
        Change the content of the file to trigger the cache dependency and reload the file 
        content into the cache or wait 30 seconds (in this case the file content will be cached
        only for 30 sec max, but if you don't request the page at least once every 10 sec, the 
        cache will be invalidated)
    </div>
    <div>
        <%: DateTime.Now %>
    </div>
    <b><asp:Literal runat="server" ID="msg2"></asp:Literal></b>
    <div>
        <asp:Literal runat="server" ID="fileContent2" Mode="Encode"></asp:Literal>
    </div>
</asp:Content>
