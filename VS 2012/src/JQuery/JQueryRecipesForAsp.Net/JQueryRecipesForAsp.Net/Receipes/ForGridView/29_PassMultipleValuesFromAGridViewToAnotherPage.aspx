<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="29_PassMultipleValuesFromAGridViewToAnotherPage.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.ForGridView._29_PassMultipleValuesFromAGridViewToAnotherPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeatureHeader" runat="server">
    Pass multiple values from a GridView to another page
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureDescription" runat="server">
    Pass multiple values from a GridView to another page
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            var $rows = $('table[id$=gv] > tbody > tr:not(:has(table, th))');

            $rows.css("background-color", "blue");

            $rows.css("cursor", "pointer").hover(function () {
                $(this).css({ "background-color": "yellow" });
            }, function () {
                $(this).css({ "background-color": "blue" });
            }).click(function (e) {
                var $row = $(this);

                var id = $("td", $row).eq(0).text();
                var firstName = $("td", $row).eq(1).text();
                var lastName = $("td", $row).eq(3).text();

                var b = new Sys.StringBuilder();

                b.append("29_1_ReceivingUrl.aspx?");
                b.append("id=");
                b.append(id);
                b.append("&fname=");
                b.append(firstName);
                b.append("&lname=");
                b.append(lastName);

                top.location = b.toString();
            });
        });
    </script>
    <asp:LinqDataSource runat="server" ID="lds" 
        ContextTypeName="JQueryRecipesForAsp.Net.DataAccess.PubsDataContext" 
        TableName="employee"></asp:LinqDataSource>
    <asp:GridView runat="server" ID="gv" DataSourceID="lds"
        AllowPaging="true" AllowSorting="true" PageSize="5" UseAccessibleHeader="True" />
</asp:Content>
