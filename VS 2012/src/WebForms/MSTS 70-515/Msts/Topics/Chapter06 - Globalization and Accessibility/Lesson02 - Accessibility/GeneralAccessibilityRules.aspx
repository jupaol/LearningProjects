<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="GeneralAccessibilityRules.aspx.cs" Inherits="Msts.Topics.Chapter06___Globalization_and_Accessibility.Lesson02___Accessibility.GeneralAccessibilityRules" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Image 
        AlternateText="Somedescription" 
        Width="100" 
        Height="100" 
        GenerateEmptyAlternateText="true"
        ImageUrl="~/App_Themes/Blue/Images/logo.jpg" 
        runat="server" />
</asp:Content>
