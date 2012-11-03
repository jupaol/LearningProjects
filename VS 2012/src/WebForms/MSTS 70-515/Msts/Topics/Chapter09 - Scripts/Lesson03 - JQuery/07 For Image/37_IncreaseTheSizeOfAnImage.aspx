<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="37_IncreaseTheSizeOfAnImage.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._07_For_Image._37_IncreaseTheSizeOfAnImage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .thumb {
            width:50px;
            height:50px;
            cursor:pointer;
        }

        .selectedImage {
            width:95%;
            height:95%;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            var $imgDiv = $("#img");

            $images = $(".thumb").click(function (e) {
                var url = $(this).attr("src");
                var $img = $("<img/>").attr("src", url).addClass("selectedImage");

                $imgDiv.html($img);
                $imgDiv.dialog({ height: "400", width: "400", modal: false });
                $imgDiv.dialog("open");
                $imgDiv.animate({ height: "400", width: "400" }, 1500);

                e.preventDefault();
            });
        });
    </script>
    <h1>
        Click and increase the size of an image
    </h1>
    <asp:Image ID="Image1" ImageUrl="~/Content/images/1.jpg" runat="server" CssClass="thumb" />
    <asp:Image ID="Image2" ImageUrl="~/Content/images/2.jpg" runat="server" CssClass="thumb" />
    <asp:Image ID="Image3" ImageUrl="~/Content/images/3.jpg" runat="server" CssClass="thumb" />
    <asp:Image ID="Image4" ImageUrl="~/Content/images/4.jpg" runat="server" CssClass="thumb" />
    <asp:Image ID="Image5" ImageUrl="~/Content/images/5.jpg" runat="server" CssClass="thumb" />
    <asp:Image ID="Image6" ImageUrl="~/Content/images/6.jpg" runat="server" CssClass="thumb" />
    <asp:Image ID="Image7" ImageUrl="~/Content/images/7.jpg" runat="server" CssClass="thumb" />
    <asp:Image ID="Image8" ImageUrl="~/Content/images/8.jpg" runat="server" CssClass="thumb" />
    <br /><div id="img"></div>
</asp:Content>
