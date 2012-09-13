<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="47_LinkAdRotation.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.ForHyperLink._47_LinkAdRotation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeatureHeader" runat="server">
    Link AD rotation
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureDescription" runat="server">
    Link AD rotation
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            var $links = $("a.dev");
            var count = $links.length;
            var i = count;

            $links.hide().eq(0).show();

            setInterval(function () {
                $links.eq(i % count).fadeOut("slow", function () {
                    $links.eq((++i) % count).fadeIn("slow");
                });
            }, 3000);
        });
    </script>
    <asp:HyperLink NavigateUrl="http://www.microsoft.com" runat="server" ID="HyperLink3" Text="Microsoft" CssClass="dev" />
    <asp:HyperLink NavigateUrl="http://www.stackoverflow.com" runat="server" ID="HyperLink1" Text="Stackoverflow" CssClass="dev" />
    <asp:HyperLink NavigateUrl="http://www.google.com" runat="server" ID="HyperLink2" Text="Google" CssClass="dev" />
</asp:Content>
