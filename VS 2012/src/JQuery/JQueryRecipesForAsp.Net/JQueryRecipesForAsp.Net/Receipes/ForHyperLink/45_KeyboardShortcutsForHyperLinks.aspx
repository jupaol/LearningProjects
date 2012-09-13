<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="45_KeyboardShortcutsForHyperLinks.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.ForHyperLink._45_KeyboardShortcutsForHyperLinks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeatureHeader" runat="server">
    Add keyboard shortcuts for hyperlinks
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureDescription" runat="server">
    Add keyboard shortcuts for hyperlinks
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            var $links = $("#customLinks a");

            $(document).keyup(function (e) {
                var key = e.keyCode ? e.keyCode : e.charCode;

                switch (key) {
                    case 49:
                        navigateUrl($links.eq(0));
                        break;
                    case 50:
                        navigateUrl($links.eq(1));
                        break;
                    case 51:
                        navigateUrl($links.eq(2));
                        break;
                }
            });

            function navigateUrl($link) {
                var url = $($link).attr("href");

                window.top.location.href = url;
                alert("Navigating to: " + url);
            }
        });
    </script>
    <div>Press 1,2 or 3 to access the links</div>
    <div id="customLinks">
        <asp:HyperLink NavigateUrl="http://www.microosft.com" runat="server" ID="HyperLink1" Text="1 Microsoft" /><br />
        <asp:HyperLink NavigateUrl="http://www.stackoverflow.com" runat="server" ID="HyperLink2" Text="2 Stackoverflow" /><br />
        <asp:HyperLink NavigateUrl="http://www.google.com" runat="server" ID="HyperLink3" Text="3 Google" />
    </div>
</asp:Content>
