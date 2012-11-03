<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="33_HighlightAndRemoveRows.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._06_For_GridView._33_HighlightAndRemoveRows" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .highlight {
            background-color:yellow;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            var $gv = $("table[id$=gv]");
            var $rows = $("> tbody tr:not(:has(table, th))", $gv);

            //$rows.css("background-color", "blue").css("cursor", "pointer");

            $rows.toggle(function () {
                //$(this).css("background-color", "yellow");
                $(this).addClass("highlight");
            }, function () {
                //$(this).css("background-color", "blue");
                $(this).removeClass("highlight");
            });

            $(document).keyup(function (e) {
                var key = e.keyCode ? e.keyCode : e.charCode;

                if (key == 68) {
                    // D or d
                    var $selected = $rows.filter(".highlight");

                    $selected.remove();
                    $("#data").html($selected.length + " rows deleted!");
                }
            });
        });
    </script>
    <h1>
        Highlight and remove rows
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
