<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="31_HandlingMasterDetailScenarios.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.ForGridView._31_HandlingMasterDetailScenarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeatureHeader" runat="server">
    Handling master-detail scenarios
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureDescription" runat="server">
    Handling master-detail scenarios
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            var $gv = $("table[id$=_gv]");
            var $rows = $("> tbody > tr:not(:has(th, table))", $gv);
            var $dialog = $("#dialog");
            var $error = $("#error");
            var $data = $("#data");

            $error.ajaxError(function (xhr, settings, error) {
                $(this).text("Error occurred on: " + settings.url);
            });

            $rows.css({ "background-color": "blue", "cursor": "pointer" }).hover(function (e) {
                $(this).css("background-color", "yellow");
            }, function (e) {
                $(this).css("background-color", "blue");
            }).click(function (e) {
                var id = $(this).find("td").eq(0).text();

                e.preventDefault();

                $.ajax({
                    type: "POST",
                    url: "<%: this.ResolveClientUrl("~/Receipes/ForGridView/31_HandlingMasterDetailScenarios.aspx/GetDetails") %>",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: '{"employeeID" : "' + id + '"}',
                    async: true,
                    cache: false,
                    success: function (msg) {
                        showDetails(msg.d);
                    }
                });
            });

            function showDetails(msg) {
                $data.text("");

                $data
                    .append("ID: ")
                    .append(msg.EmployeeID)
                    .append("<br />")
                    .append("First Name: ")
                    .append(msg.FirstName)
                    .append("<br />")
                    .append("Last Name: ")
                    .append(msg.LastName);

                $dialog.dialog({ "width": 450, "modal": true});
                $dialog.dialog("open");
            }
        });
    </script>
    <asp:LinqDataSource runat="server" ID="lds"
        TableName="employee"
        ContextTypeName="JQueryRecipesForAsp.Net.DataAccess.PubsDataContext">
    </asp:LinqDataSource>
    <asp:GridView runat="server" ID="gv" DataSourceID="lds"
        AllowPaging="true" AllowSorting="true" PageSize="5" DataKeyNames="emp_id">
    </asp:GridView>
    <div id="dialog">
        <div id="data"></div>
    </div>
    <div id="error"></div>
</asp:Content>
