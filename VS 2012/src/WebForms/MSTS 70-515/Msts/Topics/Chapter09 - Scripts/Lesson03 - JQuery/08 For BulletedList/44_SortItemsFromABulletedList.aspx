<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="44_SortItemsFromABulletedList.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._08_For_BulletedList._44_SortItemsFromABulletedList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    <h1>
        Sort items from a BulletedList
    </h1>
    <asp:LinqDataSource runat="server" ID="lds"
        TableName="employee"
        ContextTypeName="Msts.DataAccess.PubsDataContext">
    </asp:LinqDataSource>
    <asp:BulletedList runat="server" ID="bl" DisplayMode="Text" BulletStyle="Square"
        DataSourceID="lds" DataTextField="fname" DataValueField="emp_id"
        ClientIDMode="Predictable" />
    <asp:Button Text="Sort data" runat="server" ID="sort" />
</asp:Content>
