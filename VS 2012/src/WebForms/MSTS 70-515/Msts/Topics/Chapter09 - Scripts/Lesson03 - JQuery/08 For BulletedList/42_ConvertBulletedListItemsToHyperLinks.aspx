<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="42_ConvertBulletedListItemsToHyperLinks.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._08_For_BulletedList._42_ConvertBulletedListItemsToHyperLinks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    <h1>
        Convert bulleted list items to hyperlinks
    </h1>
    <asp:BulletedList runat="server" ID="bl" DisplayMode="Text" BulletStyle="Disc">
        <asp:ListItem Text="Item 1" />
        <asp:ListItem Text="Item 2" />
        <asp:ListItem Text="Item 3" />
    </asp:BulletedList>
    <asp:Button Text="Create links" runat="server" ID="create" />
</asp:Content>
