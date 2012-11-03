<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="40_ImageSwapping.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._07_For_Image._40_ImageSwapping" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .img {
            width:500px;
            height:500px;
            cursor:pointer;
        }
    </style>
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
    <h1>
        Image swapping
    </h1>
    <asp:Image ImageUrl="~/Content/images/1.jpg" runat="server" ID="img" CssClass="img" />
</asp:Content>
