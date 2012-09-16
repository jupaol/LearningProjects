<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="OutputCacheWithCacheItemDependency.aspx.cs" Inherits="Msts.Topics.Chapter02.Lesson03.OutputCacheWithCacheItemDependency" %>
<%@ OutputCache CacheProfile="genericDependency" VaryByParam="none" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        OuputCache with generic item cache dependency
    </h1>
    <h2>
        This page will be cached max for 45 seconds with an sliding time of: 10 seconds
    </h2>
    <h3>
        In order to keep this page in the cache you should access it at least once every 10 seconds
    </h3>
    <div>
        Page rendered at: <b><asp:Literal runat="server" ID="msg" Mode="Encode"></asp:Literal></b>
    </div>
    <div>
        Current time (using substitution): <b><asp:Substitution runat="server" MethodName="CustomSubstitution" /></b>
    </div>
</asp:Content>
