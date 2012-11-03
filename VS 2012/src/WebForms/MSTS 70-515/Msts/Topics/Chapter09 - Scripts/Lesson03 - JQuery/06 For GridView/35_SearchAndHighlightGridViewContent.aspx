<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="35_SearchAndHighlightGridViewContent.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._06_For_GridView._35_SearchAndHighlightGridViewContent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .rows {
            background-color:aliceblue;
            cursor:pointer;
        }

        .highlight {
            background-color: yellow;
        }
    </style>
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
    <h1>
        Search and highlight a GridView cell
    </h1>
    <asp:LinqDataSource runat="server" ID="lds"
        TableName="employee"
        ContextTypeName="Msts.DataAccess.PubsDataContext">
    </asp:LinqDataSource>
    <asp:GridView runat="server" ID="gv" DataSourceID="lds"
        AllowPaging="true" PageSize="5" DataKeyNames="emp_id">
    </asp:GridView>
    <asp:TextBox runat="server" ID="txt"></asp:TextBox>
    <div id="data"></div>
    <div id="error"></div>
</asp:Content>
