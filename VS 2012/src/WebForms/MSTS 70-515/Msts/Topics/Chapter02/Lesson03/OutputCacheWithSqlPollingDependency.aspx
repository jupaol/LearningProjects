<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="OutputCacheWithSqlPollingDependency.aspx.cs" Inherits="Msts.Topics.Chapter02.Lesson03.OutputCacheWithSqlPollingDependency" %>
<%@ OutputCache CacheProfile="genericDependency" VaryByParam="*" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        OutputCache with a SqlCacheDependency via code
    </h1>
    <h2>
        This page is cached for max 45 seconds or when the 'jobs' table is updated
    </h2>
    <div>
        Rendered at: <b><asp:Literal runat="server" ID="msg" Mode="Encode"></asp:Literal></b>
    </div>
    <div>
        Current time: <b><asp:Substitution runat="server" MethodName="CustomSubstitution" /></b>
    </div>
    <asp:LinqDataSource runat="server" ID="lds"
        ContextTypeName="Msts.DataAccess.PubsDataContext"
        TableName="jobs">

    </asp:LinqDataSource>
    <asp:GridView runat="server" DataSourceID="lds">

    </asp:GridView>
</asp:Content>
