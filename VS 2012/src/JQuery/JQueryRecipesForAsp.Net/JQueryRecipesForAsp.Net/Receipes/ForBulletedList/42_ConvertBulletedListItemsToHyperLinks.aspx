<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="42_ConvertBulletedListItemsToHyperLinks.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.ForBulletedList._42_ConvertBulletedListItemsToHyperLinks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        input:disabled {
            background-color:silver;
            cursor:initial;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeatureHeader" runat="server">
    Convert bulleted list items to hyperlinks
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureDescription" runat="server">
    Convert bulleted list items to hyperlinks
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            var $ul = $("ul[id$=bl]");
            var $create = $("input:submit[id$=create]");
            var $lis = $("li", $ul);

            $create.click(function (e) {
                e.preventDefault();

                $lis.each(function (i, x) {
                    var link = $(x).text();
                    var $link = $("<a />").attr("href", link);

                    $(x).wrapInner($link);
                });

                $(this).attr("disabled", "disabled");
            });
        });
    </script>
    <asp:BulletedList runat="server" ID="bl" DisplayMode="Text" BulletStyle="Disc">
        <asp:ListItem Text="Item 1" />
        <asp:ListItem Text="Item 2" />
        <asp:ListItem Text="Item 3" />
    </asp:BulletedList>
    <asp:Button Text="Create links" runat="server" ID="create" />
</asp:Content>
