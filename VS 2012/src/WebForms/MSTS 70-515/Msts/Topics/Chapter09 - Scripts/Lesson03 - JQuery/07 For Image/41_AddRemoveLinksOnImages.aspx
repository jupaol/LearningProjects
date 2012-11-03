<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="41_AddRemoveLinksOnImages.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._07_For_Image._41_AddRemoveLinksOnImages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .thumb {
            width:300px;
            height:300px;
        }

        input:disabled {
            background-color:silver;
            cursor:initial;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            var $links = $("a.link");
            var $remove = $("input:submit[id$=remove]");

            $remove.click(function (e) {
                e.preventDefault();

                $links.each(function (i, x) {
                    $(x).replaceWith($(this).children());
                });

                $(this).attr("disabled", "disabled");
            });
        });
    </script>
    <h1>
        Add / Remove hyperlinks on images
    </h1>
    <asp:HyperLink NavigateUrl="www.stackoverflow.com" runat="server" ID="HyperLink1" CssClass="link">
        <asp:image ID="Image3" imageurl="~/Content/images/1.jpg" runat="server" CssClass="thumb" />
    </asp:HyperLink><br />
    <asp:HyperLink NavigateUrl="www.microsoft.com" runat="server" ID="HyperLink2" CssClass="link">
        <asp:image ID="Image1" imageurl="~/Content/images/2.jpg" runat="server" CssClass="thumb" />
    </asp:HyperLink><br />
    <asp:HyperLink NavigateUrl="www.google.com" runat="server" ID="HyperLink3" CssClass="link">
        <asp:image ID="Image2" imageurl="~/Content/images/3.jpg" runat="server" CssClass="thumb" />
    </asp:HyperLink><br />
    <asp:Button Text="Remove links" runat="server" ID="remove" />
</asp:Content>
