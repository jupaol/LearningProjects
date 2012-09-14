<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="OutputCacheWithSqlPollingDeclaratively.aspx.cs" Inherits="Msts.Topics.Chapter02.Lesson03.OutputCacheWithSqlPollingDeclaratively" %>
<%@ OutputCache CacheProfile="genericDependency" VaryByParam="*" SqlDependency="PUBS:jobs;PUBS:employee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        OutputCache with multiple SqlCacheDependency declaratively
    </h1>
    <h2>
        This page will be cached for max 45 seconds or the page will be invalidated when a 
        record is updated in the 'jobs' table
    </h2>
    <div>
        Rendered at: <b><asp:Literal runat="server" ID="msg" Mode="Encode"></asp:Literal></b>
    </div>
    <div>
        Current time: <b><asp:Substitution runat="server" MethodName="CurrentSubstitution" /></b>
    </div>
    <asp:LinqDataSource runat="server" ID="lds"
        ContextTypeName="Msts.DataAccess.PubsDataContext"
        TableName="jobs">

    </asp:LinqDataSource>
    <asp:GridView runat="server" DataSourceID="lds"></asp:GridView>
</asp:Content>
