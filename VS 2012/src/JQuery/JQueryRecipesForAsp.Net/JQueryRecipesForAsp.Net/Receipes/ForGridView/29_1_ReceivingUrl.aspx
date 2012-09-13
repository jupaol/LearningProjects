<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="29_1_ReceivingUrl.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.ForGridView._29_1_ReceivingUrl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeatureHeader" runat="server">
    Receiving data
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureDescription" runat="server">
    Receiving data
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    ID: <b><%: this.Request.QueryString["id"] %></b><br />
    First Name: <b><%: this.Request.QueryString["fname"] %></b><br />
    Last Name: <b><%: this.Request.QueryString["lname"] %></b><br />
</asp:Content>
