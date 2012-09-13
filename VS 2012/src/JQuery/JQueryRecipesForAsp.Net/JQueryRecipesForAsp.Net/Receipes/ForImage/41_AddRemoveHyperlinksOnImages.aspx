<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="41_AddRemoveHyperlinksOnImages.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.ForImage._41_AddRemoveHyperlinksOnImages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeatureHeader" runat="server">
    Add / Remove hyperlinks on images
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureDescription" runat="server">
    Add / Remove hyperlinks on images
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
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