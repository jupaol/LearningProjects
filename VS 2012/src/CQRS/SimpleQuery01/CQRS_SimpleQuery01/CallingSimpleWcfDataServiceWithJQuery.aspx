<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CallingSimpleWcfDataServiceWithJQuery.aspx.cs" Inherits="CQRS_SimpleQuery01.CallingSimpleWcfDataServiceWithJQuery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/themes/base/jquery.ui.all.css" rel="stylesheet" />
    <link href="Content/jquery.jqGrid/ui.jqgrid.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.7.2.min.js"></script>
    <script src="Scripts/jquery-ui-1.8.24.min.js"></script>
    <script src="Scripts/jquery.jqGrid.min.js"></script>
    <script>
        $(function () {
            var $call = $("input:submit[id$=call]");
            var $dialog = $("#dialog");
            var $grid = $("#grid");

            $dialog.dialog({
                autoOpen: false,
                modal: true,
                height: 140
            });

            function requestData() {
                $.ajax({
                    url: "http://localhost:58284/JobsWcfDataService.svc/jobs/?$format=json&$callback=mycallback",
                    type: "GET",
                    contentType: "application/json;odata=verbose;charset=utf-8;",
                    dataType: "jsonp",
                    jsonpCallback: "mycallback",
                    data: "{}",
                    success: function (msg) {
                        $grid.addJSONData
                    },
                    error: function (err) {
                        console.log(err);
                        alert(err.responseText);
                    }
                });
            }

            $call.click(function (e) {
                e.preventDefault();

                $grid.jqGrid({
                    datatype: requestData,
                    colNames: ["ID"],
                    colModel: [
                        { name: "id", index: "job_id" }
                    ],
                    rowNum: 3,
                    rowList: [10, 20, 30],
                    pager: "#pager",
                    sortname: "job_id",
                    viewrecords: true,
                    sortorder: "desc",
                    caption: "JSON example"
                });

                $grid.jqGrid("navGrid", "#pager", {
                    edit: false,
                    add: false,
                    del: false
                });

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
