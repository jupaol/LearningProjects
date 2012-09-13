<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="39_CreateAnImageSlideShow.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.ForImage._39_CreateAnImageSlideShow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <style>
        .thumb {
            width:300px;
            height:300px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeatureHeader" runat="server">
    Create an image slideshow
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureDescription" runat="server">
    Create an image slideshow
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            var $slide = $("img[id$=slide]");
            var imgArray = new Array();

            imgArray.push("<%: this.ResolveClientUrl("~/Content/images/1.jpg") %>");
            imgArray.push("<%: this.ResolveClientUrl("~/Content/images/2.jpg") %>");
            imgArray.push("<%: this.ResolveClientUrl("~/Content/images/3.jpg") %>");
            imgArray.push("<%: this.ResolveClientUrl("~/Content/images/4.jpg") %>");
            imgArray.push("<%: this.ResolveClientUrl("~/Content/images/5.jpg") %>");
            imgArray.push("<%: this.ResolveClientUrl("~/Content/images/6.jpg") %>");
            imgArray.push("<%: this.ResolveClientUrl("~/Content/images/7.jpg") %>");
            imgArray.push("<%: this.ResolveClientUrl("~/Content/images/8.jpg") %>");

            var count = imgArray.length;
            var i = count;

            $slide.attr("src", imgArray[0]);

            setInterval(function () {
                $slide.attr("src", imgArray[(++i) % count]).fadeIn("slow");
            }, 3000);
        });
    </script>
    <asp:Image ID="slide" runat="server" CssClass="thumb" />
</asp:Content>
