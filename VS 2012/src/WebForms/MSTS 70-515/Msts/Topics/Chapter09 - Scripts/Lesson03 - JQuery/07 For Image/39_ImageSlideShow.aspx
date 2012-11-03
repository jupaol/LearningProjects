<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="39_ImageSlideShow.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._07_For_Image._39_ImageSlideShow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .thumb {
            width:300px;
            height:300px;
        }
    </style>
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
    <h1>
        Create an image slideshow
    </h1>
    <asp:Image ID="slide" runat="server" CssClass="thumb" />
</asp:Content>
