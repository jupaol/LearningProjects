<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="33_HighlightAndRemoveRows.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.ForGridView._33_HighlightAndRemoveRows" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        .highlight {
            background-color:yellow;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeatureHeader" runat="server">
    Highlight and remove rows
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureDescription" runat="server">
    Highlight and remove rows
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
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
    <asp:LinqDataSource runat="server" ID="lds"
        TableName="employee"
        ContextTypeName="JQueryRecipesForAsp.Net.DataAccess.PubsDataContext">
    </asp:LinqDataSource>
    <asp:GridView runat="server" ID="gv" DataSourceID="lds"
        AllowPaging="true" AllowSorting="true" PageSize="5" DataKeyNames="emp_id">
    </asp:GridView>
    <div id="data"></div>
    <div id="error"></div>
</asp:Content>
