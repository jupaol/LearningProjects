<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="OutputCacheUsingVaryByCustom.aspx.cs" Inherits="Msts.Topics.Chapter02.Lesson03.OutputCacheUsingVaryByCustom" %>
<%@ OutputCache CacheProfile="shortTime" VaryByCustom="session" VaryByParam="none" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        OutputCache using vary by custom
    </h1>
    <h2>
        This page is cached for 15 seconds max and it's varied by the session ID
    </h2>
    <div>
        Processed at: <b><asp:Literal runat="server" ID="msg" Mode="Encode"></asp:Literal></b>
    </div>
    <div>
        Current time: <b><asp:Substitution runat="server" MethodName="CustomSusbtitution" /></b>
    </div>
</asp:Content>
