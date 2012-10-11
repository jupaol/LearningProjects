<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CallingSimpleWcfDataServiceWithJQuery.aspx.cs" Inherits="CQRS_SimpleQuery01.CallingSimpleWcfDataServiceWithJQuery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/themes/base/jquery.ui.all.css" rel="stylesheet" />
    <link href="Content/jquery.jqGrid/ui.jqgrid.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.7.2.min.js"></script>
    <script src="Scripts/jquery-ui-1.8.24.min.js"></script>
    <script src="Scripts/i18n/grid.locale-en.js"></script>
    <script src="Scripts/jquery.jqGrid.min.js"></script>
    <script src="Scripts/json2.min.js"></script>
    <script>
        $(function () {
            var $call = $("input:submit[id$=call]");
            var $dialog = $("#dialog");
            var $grid = $("#grid");

            $dialog.dialog({
                autoOpen: false,
                modal: true,
                height: 140,
                closeOnEscape: false,
                open: function (e, ui) {
                    $(this).closest(".ui-dialog").find(".ui-dialog-titlebar-close").hide();
                }
            });

            function requestData() {
                $dialog.dialog("open");

                $.ajax({
                    url: "http://localhost:58284/JobsWcfDataService.svc/jobs/?$format=json&$callback=mycallback",
                    type: "GET",
                    contentType: "application/json;odata=verbose;charset=utf-8;",
                    dataType: "jsonp",
                    jsonpCallback: "mycallback",
                    data: "{}",
                    success: function (msg) {
                        console.log(msg.d);

                        $grid.clearGridData(true);
                        $grid.setGridParam({
                            data: msg.d,
                            rowNum: msg.d.length
                        }).trigger("reloadGrid");
                    },
                    error: function (err) {
                        console.log(err);
                        alert(err.responseText);
                    },
                    complete: function () {
                        $dialog.dialog("close");
                    }
                });
            }

            $call.click(function (e) {
                e.preventDefault();

                $grid.jqGrid({
                    datatype: "local",
                    colNames: ["ID", "Description", "Minimum", "Maximum"],
                    colModel: [
                        { name: "job_id", index: "job_id", sorttype: "int", jsonmap: "job_id" },
                        { name: "job_desc", index: "job_desc", jsonmap: "job_desc" },
                        { name: "min_lvl", index: "min_lvl", jsonmap: "min_lvl", sorttype: "min_lvl" },
                        { name: "max_lvl", index: "max_lvl", jsonmap: "max_lvl", sorttype: "max_lvl" }
                    ],
                    rowList: [3, 6, 9],
                    pager: "#pager",
                    sortname: "job_id",
                    viewrecords: true,
                    sortorder: "desc",
                    caption: "JSON example",
                    multiselect: false,
                    autowidth: true,
                    forceFit: true
                });

                $grid.jqGrid("navGrid", "#pager", {
                    edit: false,
                    add: false,
                    del: false
                });

                requestData();
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button Text="Call Service" runat="server" ID="call" />
    </div>
        <table id="grid"></table>
        <div id="pager"></div>
        <div id="dialog" style="display:none;">
            <div>
                Processing...
            </div>
        </div>
    </form>
</body>
</html>
