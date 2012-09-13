<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="44_SortItemsFromABulletedList.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.ForBulletedList._44_SortItemsFromABulletedList" %>
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
    Sort items from a BulletedList
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureDescription" runat="server">
    Sort items from a BulletedList
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            var $ul = $("ul[id$=bl]");
            var $sort = $("input:submit[id$=sort]");
            var $lis = $("li", $ul);

            $sort.click(function (e) {
                e.preventDefault();

                var $lisArray = $.makeArray($lis);
                var $sorted = $lisArray.sort(function (o, n) {
                    return ($(o).text() < $(n).text()) ? -1 : 1;
                });

                $ul.html($sorted);

                $(this).attr("disabled", "disabled");
            });
        });
    </script>
    <asp:LinqDataSource runat="server" ID="lds"
        TableName="employee"
        ContextTypeName="JQueryRecipesForAsp.Net.DataAccess.PubsDataContext">
    </asp:LinqDataSource>
    <asp:BulletedList runat="server" ID="bl" DisplayMode="Text" BulletStyle="Square"
        DataSourceID="lds" DataTextField="fname" DataValueField="emp_id"
        ClientIDMode="Predictable" />
    <asp:Button Text="Sort data" runat="server" ID="sort" />
</asp:Content>
