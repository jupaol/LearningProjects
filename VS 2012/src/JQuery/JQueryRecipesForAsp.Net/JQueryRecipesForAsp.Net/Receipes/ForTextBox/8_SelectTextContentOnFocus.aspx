<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="8_SelectTextContentOnFocus.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.TextBox._8_SelectTextContentOnFocus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeatureHeader" runat="server">
    Select textbox content on focus
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureDescription" runat="server">
    Select textbox content on focus
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            $("input[id$=txt]").click(function () {
                $(this).focus().select();
            });
        });
    </script>
    <asp:TextBox runat="server" ID="txt" Text="something"></asp:TextBox>
</asp:Content>
