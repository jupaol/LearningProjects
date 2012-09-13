<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="34_HighlightAndRemoveColumns.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.ForGridView._34_HighlightAndRemoveColumns" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeatureHeader" runat="server">
    Highlight and remove columns
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureDescription" runat="server">
    Highlight and remove columns
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
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
    <asp:LinqDataSource runat="server" ID="lds"
        TableName="employee"
        ContextTypeName="JQueryRecipesForAsp.Net.DataAccess.PubsDataContext">
    </asp:LinqDataSource>
    <asp:GridView runat="server" ID="gv" DataSourceID="lds"
        AllowPaging="true" PageSize="5" DataKeyNames="emp_id">
    </asp:GridView>
    <div id="data"></div>
    <div id="error"></div>
</asp:Content>
