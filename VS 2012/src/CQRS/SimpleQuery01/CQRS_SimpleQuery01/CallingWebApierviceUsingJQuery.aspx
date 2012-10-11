<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CallingWebApierviceUsingJQuery.aspx.cs" Inherits="CQRS_SimpleQuery01.CallingWebApierviceUsingJQuery" %>

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
            var $dialog = $("#dialog");
            var $initializeGrid = $("#initializeGrid");
            var $grid = $("#grid");

            //$.ajaxSetup({
            //    type: "GET",
            //    async: true,
            //    cache: false,
            //    contentType: "application/json;charset=utf-8;",
            //    dataType: "jsonp"
            //});

            $initializeGrid.click(function (e) {
                e.preventDefault();

                $grid.jqGrid({
                    url: "http://localhost:50725/api/values?jsonpCallback=callback",
                    datatype: "jsonp",
                    mtype: "GET",
                    colNames: ["ID"],
                    colModel: [
                        { name: "ID" }
                    ],
                    pager: $("#pager"),
                    rowNum: 1000,
                    rowList: [1000],
                    sortname: "ID",
                    sortorder: "desc",
                    viewrecords: true,
                    caption: "Test",
                    autowidth: true
                }).navGrid("#pager", {
                    edit: false,
                    add: false,
                    del: false,
                    search: false,
                    refresh: true
                });
            });

            $dialog.dialog({
                modal: true,
                autoOpen: false,
                closeOnEscape: false,
                height: 140,
                open: function (e, ui) {
                    $(this).closest(".ui-dialog").find(".ui-dialog-titlebar-close").hide();
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="button" id="initializeGrid" value="Initialize Grid" />
        </div>
        <table id="grid">

        </table>
        <div id="pager"></div>
        <div id="dialog" style="display:none;">
            <div>
                Processing...
            </div>
        </div>
    </form>
</body>
</html>
