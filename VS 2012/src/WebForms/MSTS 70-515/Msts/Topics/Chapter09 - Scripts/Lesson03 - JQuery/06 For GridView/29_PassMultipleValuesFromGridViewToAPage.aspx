<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="29_PassMultipleValuesFromGridViewToAPage.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._06_For_GridView._29_PassMultipleValuesFromGridViewToAPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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

                b.append("29_1_ReceivingDataFromGridViewLinks.aspx?");
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
    <h1>
        Pass multiple values from a GridView to another page
    </h1>
    <asp:LinqDataSource runat="server" ID="lds" 
        ContextTypeName="Msts.DataAccess.PubsDataContext" 
        TableName="employee"></asp:LinqDataSource>
    <asp:GridView runat="server" ID="gv" DataSourceID="lds"
        AllowPaging="true" AllowSorting="true" PageSize="5" UseAccessibleHeader="True" />
</asp:Content>
