<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="40_ImageSwapping.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.ForImage._40_ImageSwapping" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        .img {
            width:500px;
            height:500px;
            cursor:pointer;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeatureHeader" runat="server">
    Image swapping
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureDescription" runat="server">
    Image swapping
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            var $img = $("img[id$=img]");

            $img.toggle(function (e) {
                $(this).attr("src", "<%: this.ResolveClientUrl("~/Content/images/2.jpg") %>").fadeIn(5000);
            }, function (e) {
                $(this).attr("src", "<%: this.ResolveClientUrl("~/Content/images/1.jpg") %>").fadeIn(5000);
            });
        });
    </script>
    <asp:Image ImageUrl="~/Content/images/1.jpg" runat="server" ID="img" CssClass="img" />
</asp:Content>
