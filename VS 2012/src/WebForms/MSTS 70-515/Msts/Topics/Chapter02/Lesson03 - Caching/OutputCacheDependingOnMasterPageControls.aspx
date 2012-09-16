<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson03/CachedMaster.Master" AutoEventWireup="true" CodeBehind="OutputCacheDependingOnMasterPageControls.aspx.cs" Inherits="Msts.Topics.Chapter02.Lesson03.OutputCacheDependingOnMasterPageControls" %>
<%@ OutputCache CacheProfile="shortTime" VaryByParam="none" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        OutputCache depending on the MasterPage controls (cached for 15 seconds)
    </h1>
    <div>
        Page rendered at: <b><asp:Literal runat="server" ID="msg" Mode="Encode"></asp:Literal></b>
    </div>
    <div>
        Current time (using substitution): <b><asp:Substitution ID="Substitution1" runat="server" MethodName="CustomSubstitution" /></b>
    </div>
    <asp:DropDownList runat="server" ID="ddl1">
        <asp:ListItem Text="text1" />
        <asp:ListItem Text="text2" />
    </asp:DropDownList>
    <asp:DropDownList runat="server" ID="ddl2">
        <asp:ListItem Text="text3" />
        <asp:ListItem Text="text4" />
    </asp:DropDownList>
    <br />
    <asp:Button Text="Post" runat="server" />
</asp:Content>
