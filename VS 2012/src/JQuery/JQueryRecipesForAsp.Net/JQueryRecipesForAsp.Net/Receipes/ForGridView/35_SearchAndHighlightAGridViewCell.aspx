<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="35_SearchAndHighlightAGridViewCell.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.ForGridView._35_SearchAndHighlightAGridViewCell" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        .rows {
            background-color:aliceblue;
            cursor:pointer;
        }

        .highlight {
            background-color: yellow;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeatureHeader" runat="server">
    Search and highlight a GridView cell
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureDescription" runat="server">
    Search and highlight a GridView cell
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            var $gv = $("table[id$=gv]");
            var $rows = $("> tbody > tr:not(:has(table, th))", $gv);
            var $txt = $("input:text[id$=txt]");

            $rows.addClass("rows");
            $txt.keyup(function (e) {
                var value = $(this).val().trim().toLowerCase();

                $("td", $rows).removeClass("highlight");

                if (value != "") {
                    $("td", $rows).filter(function (x) {
                        return $(this).text().toLowerCase().trim().indexOf(value) != -1;
                    }).addClass("highlight");
                }
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
    <asp:TextBox runat="server" ID="txt"></asp:TextBox>
    <div id="data"></div>
    <div id="error"></div>
</asp:Content>
