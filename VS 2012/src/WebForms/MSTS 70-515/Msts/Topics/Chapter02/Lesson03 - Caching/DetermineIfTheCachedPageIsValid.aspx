<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="DetermineIfTheCachedPageIsValid.aspx.cs" Inherits="Msts.Topics.Chapter02.Lesson03.DetermineIfTheCachedPageIsValid" %>
<%@ OutputCache CacheProfile="genericDependency" VaryByParam="none" Location="Server" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        This page is cached for 45 seconds and depending on the 'status' query string parameter, the
        page will be invalidated
    </h1>
    <div>
        Message: <b><asp:Literal runat="server" ID="msg" ClientIDMode="Static" Mode="Encode"></asp:Literal></b>
    </div>
    <div>
        Rendered at: <b><asp:Literal runat="server" ID="msg2" Mode="Encode"></asp:Literal></b>
    </div>
    <div>
        Processed at: <b><asp:Substitution runat="server" MethodName="CurrentSubstitution" /></b>
    </div>
    <div>
        <asp:HyperLink NavigateUrl="DetermineIfTheCachedPageIsValid.aspx?status=valid" runat="server" Text="Valid" />
    </div>
    <div>
        <asp:HyperLink ID="HyperLink1" NavigateUrl="DetermineIfTheCachedPageIsValid.aspx?status=invalid" runat="server" Text="Invalid" />
    </div>
    <div>
        <asp:HyperLink ID="HyperLink2" NavigateUrl="DetermineIfTheCachedPageIsValid.aspx?status=ignore" runat="server" Text="Invalidate once (ignore this request)" />
    </div>
</asp:Content>
