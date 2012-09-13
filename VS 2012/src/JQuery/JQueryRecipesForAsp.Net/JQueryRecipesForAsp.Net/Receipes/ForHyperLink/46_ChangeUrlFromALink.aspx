<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="46_ChangeUrlFromALink.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.ForHyperLink._46_ChangeUrlFromALink" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeatureHeader" runat="server">
    Change the URL from a HyperLink
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureDescription" runat="server">
    Change the URL from a HyperLink
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            var $change = $("input:submit[id$=change]");
            var $url = $("input:text[id$=url]");
            var $link = $("a[id$=link]");

            $change.click(function (e) {
                var value = $url.val().trim();

                e.preventDefault();

                if (value) {
                    $link.text(value).attr("href", value);
                }
            });
        });
    </script>
    <asp:HyperLink runat="server" ID="link" />
    <br />
    <asp:Label Text="URL" runat="server" AssociatedControlID="url" /> <asp:TextBox runat="server" ID="url" /><br />
    <asp:Button Text="Change URL" runat="server" ID="change" />
</asp:Content>
