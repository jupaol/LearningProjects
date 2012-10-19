<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="DisplayingCultureInformation.aspx.cs" Inherits="Msts.Topics.Chapter06___Globalization_and_Accessibility.Lesson01___Resources.DisplayingCultureInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Displaying CultureInfo information
    </h1>
    <asp:GridView runat="server" ID="gv" 
        ItemType="System.Globalization.CultureInfo" 
        SelectMethod="gv_GetData"
        PageSize="50" AllowSorting="true" AllowPaging="true">

    </asp:GridView>
</asp:Content>
