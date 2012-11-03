<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="38_ChangeImageOpacityOnMouseOver.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._07_For_Image._38_ChangeImageOpacityOnMouseOver" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .thumb {
            width:100px;
            height:100px;
            cursor:pointer;
            opacity:0.3;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            var $images = $(".thumb");

            $images.hover(function (e) {
                $(this).stop().animate({ opacity: 1.0 }, 800);
            }, function (e) {
                $(this).stop().animate({ opacity: 0.3 }, 800);
            });
        });
    </script>
    <h1>
        Change image opacity on mouse over
    </h1>
    <asp:Image ID="Image1" ImageUrl="~/Content/images/1.jpg" runat="server" CssClass="thumb" />
    <asp:Image ID="Image2" ImageUrl="~/Content/images/2.jpg" runat="server" CssClass="thumb" />
    <asp:Image ID="Image3" ImageUrl="~/Content/images/3.jpg" runat="server" CssClass="thumb" />
    <asp:Image ID="Image4" ImageUrl="~/Content/images/4.jpg" runat="server" CssClass="thumb" />
    <asp:Image ID="Image5" ImageUrl="~/Content/images/5.jpg" runat="server" CssClass="thumb" />
    <asp:Image ID="Image6" ImageUrl="~/Content/images/6.jpg" runat="server" CssClass="thumb" />
    <asp:Image ID="Image7" ImageUrl="~/Content/images/7.jpg" runat="server" CssClass="thumb" />
    <asp:Image ID="Image8" ImageUrl="~/Content/images/8.jpg" runat="server" CssClass="thumb" />
</asp:Content>
