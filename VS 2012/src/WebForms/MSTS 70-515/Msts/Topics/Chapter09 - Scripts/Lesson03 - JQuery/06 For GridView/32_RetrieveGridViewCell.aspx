<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="32_RetrieveGridViewCell.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._06_For_GridView._32_RetrieveGridViewCell" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(function () {
            var $gv = $("table[id$=gv]");
            var $rows = $("> tbody tr:not(:has(table, th))", $gv);

            $rows.css("background-color", "aliceblue");

            $rows.dblclick(function (e) {
                var $current = $(e.target).closest("td");
                var currentIndex = $current.parent().children().index($current);
                var $header = $current.closest("table").find("th").eq(currentIndex);
                var $data = $("#data");
                var $next = $current.next();
                var $prev = $current.prev();

                e.preventDefault();

                $data.text("").append($current.text() + " Header: " + $header.text())
                    .append(" Next: " + $next.text())
                    .append(" Prev: " + $prev.text());

                $rows.css("background-color", "aliceblue");
                $("td", $rows).css("background-color", "aliceblue");;
                $current.css("background-color", "yellow");
            });
        });
    </script>
    <h1>
        Retrieve GridView cell
    </h1>
    <asp:LinqDataSource runat="server" ID="lds"
        TableName="employee"
        ContextTypeName="Msts.DataAccess.PubsDataContext">
    </asp:LinqDataSource>
    <asp:GridView runat="server" ID="gv" DataSourceID="lds"
        AllowPaging="true" AllowSorting="true" PageSize="5" DataKeyNames="emp_id">
    </asp:GridView>
    <div id="data"></div>
    <div id="error"></div>
</asp:Content>
