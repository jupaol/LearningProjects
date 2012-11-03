<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="29_1_ReceivingDataFromGridViewLinks.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._06_For_GridView._29_ReceivingDataFromGridViewLinks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Receiving data
    </h1>
    <h2>
        Receiving data from the links inside the GridView
    </h2>
    ID: <b><%: this.Request.QueryString["id"] %></b><br />
    First Name: <b><%: this.Request.QueryString["fname"] %></b><br />
    Last Name: <b><%: this.Request.QueryString["lname"] %></b><br />
    <hr />
    <asp:HyperLink NavigateUrl="29_PassMultipleValuesFromGridViewToAPage.aspx" runat="server" Text="Go back" />
</asp:Content>
