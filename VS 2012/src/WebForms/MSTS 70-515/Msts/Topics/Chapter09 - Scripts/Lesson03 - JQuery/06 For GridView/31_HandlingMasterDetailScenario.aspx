<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="31_HandlingMasterDetailScenario.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._06_For_GridView._31_HandlingMasterDetailScenario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                    url: "31_HandlingMasterDetailScenario.aspx/GetDetails",
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

                if (!msg) {
                    $data.text("No details found");
                }
                else {
                    //$("#data").setTemplateURL("detailsTemplate.html", null, { filter_data: false });
                    //$data.processTemplate(msg);

                    $data
                        .append("ID: ")
                        .append(msg.EmployeeID)
                        .append("<br />")
                        .append("First Name: ")
                        .append(msg.FirstName)
                        .append("<br />")
                        .append("Last Name: ")
                        .append(msg.LastName);
                }

                $dialog.dialog({ "width": 450, "modal": true });
                $dialog.dialog("open");
            }
        });
    </script>
    <h1>
        Handling master-detail scenarios
    </h1>
    <asp:LinqDataSource runat="server" ID="lds"
        TableName="employee"
        ContextTypeName="Msts.DataAccess.PubsDataContext">
    </asp:LinqDataSource>
    <asp:GridView runat="server" ID="gv" DataSourceID="lds"
        AllowPaging="true" AllowSorting="true" PageSize="5" DataKeyNames="emp_id">
    </asp:GridView>
    <div id="dialog">
        <div id="data"></div>
    </div>
    <div id="error"></div>
</asp:Content>
