<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="34_HightlightAndRemoveColumns.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._06_For_GridView._34_HightlightAndRemoveColumns" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .highlite {
            background-color:yellow;
        }
        .headers {
            background-color:lightblue;
            cursor:pointer;
        }
        .rows {
            background-color:aliceblue;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            var $gv = $("table[id$=gv]");
            var $rows = $("> tbody tr:not(:has(table, th))", $gv);
            var $data = $("#data");
            var $headers = $("th", $gv);

            $rows.addClass("rows");
            //$headers.addClass("headers");

            $headers.click(function (e) {
                var colIndex = $(this).parent().children().index($(this));

                e.preventDefault();

                $("th:eq(" + colIndex + "), > tbody > tr:not(:has(table)) td:nth-child(" + (colIndex + 1) + ")", $gv)
                    .toggleClass("highlite");

                $(document).keyup(function (e) {
                    var key = e.keyCode ? e.keyCode : e.charCode;

                    if (key == 68) {//d or D
                        var $selected = $("td.highlite, th.highlite", $gv);

                        $selected.remove();
                    }
                });
            });
        });
    </script>
    <h1>
        Highlight and remove columns
    </h1>
    <asp:LinqDataSource runat="server" ID="lds"
        TableName="employee"
        ContextTypeName="Msts.DataAccess.PubsDataContext">
    </asp:LinqDataSource>
    <asp:GridView runat="server" ID="gv" DataSourceID="lds"
        AllowPaging="true" PageSize="5" DataKeyNames="emp_id">
    </asp:GridView>
    <div id="data"></div>
    <div id="error"></div>
</asp:Content>
