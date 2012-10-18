<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="JQueryCustomEvents.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery.JQueryCustomEvents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .footer {
            background-color: aliceblue;
        }
        .header {
            background-color: lightgreen;
        }
        .items {
            background-color:yellow;
        }
        .item-hover {
            background-color: lightcoral;
            cursor:pointer;
        }
        .header-hover {
            cursor:pointer;
            background-color:Highlight;
        }
        .header-selected {
            background-color:red;
        }
        .item-selected {
            background-color:blue;
        }
    </style>
    <script>
        $(function () {
            var $gv = $("table[id$=gv].custom-content");
            var $gvButtons = $("input:submit", $gv);
            var $gvChecks = $("input:checkbox", $gv);
            var $footer = $("table", $gv).closest("tr");
            var $header = $("th", $gv).closest("tr");
            var $items = $("> tbody > tr:not(:has(table, th))", $gv);
            var $headerItems = $("th", $header);
            var $cellItems = $("> td", $items);
            var $res = $("#res");

            $gvButtons.button();
            $gvChecks.button();

            $footer.addClass("footer");
            $header.addClass("header");
            $items.addClass("items");

            $items.hover(function () {
                $(this).stop(true, true).toggleClass("item-hover");
            }, function () {
                $(this).stop(true, true).toggleClass("item-hover");
            });

            $gvButtons.click(function (e) {
                e.preventDefault();

                if (!confirm("Are you sure you want to proceed?")) {
                    return;
                }

                $gv.trigger("processing", [$(this)]);

                // simulate something

                $gv.trigger("processed", [$(this)]);
            });

            $headerItems.hover(function () {
                $(this).stop(true, true).toggleClass("header-hover");
            }, function () {
                $(this).stop(true, true).toggleClass("header-hover");
            });

            $headerItems.click(function (e) {
                e.preventDefault();

                var colIndex = $(this).parent().children().index($(this));

                $("th:eq(" + colIndex + "), > tbody > tr:not(:has(table)) > td:nth-child(" + (colIndex + 1) + ")", $gv).toggleClass("header-selected");

                $gv.trigger("colSelected", [colIndex, $(this)]);
            });

            $cellItems.click(function () {
                var colIndex = $(this).parent().children().index($(this));
                var $row = $(this).closest("tr");
                var rowIndex = $row.parent().children().index($row);

                if ($(this).find("input").length > 0) {
                    return;
                }

                $("> tbody > tr:eq("+rowIndex+") > td", $gv)
                    .toggleClass("item-selected");

                $gv.trigger("rowSelected", [rowIndex, $(this)]);
            });

            $gvChecks.click(function (e) {
                var $check = $(this);
                var id = $(this).attr("id");
                var segments = new String(id).split("_");
                var $row = $(this).closest("tr");

                if (segments.length > 0) {
                    var jobid = new String(segments[segments.length - 1]);
                    var $button = $("input:submit[id$=_process_" + jobid + "]", $row);

                    if ($(this).is(":checked")) {
                        $button.show();
                    } else {
                        $button.hide();
                    }

                    $gv.trigger("accepted", [id, $(this), $(this).is(":checked")]);
                }
            });

            // From here we start handling custom events

            $gv.on("colSelected", function (e, index, element) {
                $res.append(", colSelected");
            });

            $gv.on("rowSelected", function (e, index, element) {
                $res.append(", rowSelected");
            });

            $gv.on("accepted", function (e, id, element, checked) {
                $res.append(", accepted : " + checked);
            });

            $gv.on("processing", function (e, element) {
                $res.append(", processing");
            });

            $gv.on("processed", function (e, element) {
                $res.append(", processed");
            });
        });
    </script>
    <h1>
        JQuery custom events
    </h1>
    <div>
        <b>
            The following table expose the following events:
        </b>
    </div>
    <div>
        <ul>
            <li>
                colSelected
            </li>
            <li>
                rowSelected
            </li>
            <li>
                accepted
            </li>
            <li>
                processing
            </li>
            <li>
                processed
            </li>
        </ul>
    </div>
    <asp:LinqDataSource runat="server" ID="lds"
        TableName="jobs"
        ContextTypeName="Msts.DataAccess.PubsDataContext">
    </asp:LinqDataSource>

    <asp:GridView runat="server" ID="gv" AllowPaging="true" PageSize="5" CssClass="custom-content"
        DataSourceID="lds" ItemType="Msts.DataAccess.jobs" ClientIDRowSuffix="job_id" >
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <div>
                        <asp:Button Text="Process" runat="server" ID="process" style="display:none;" />
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <div>
                        <asp:CheckBox Text="OK" runat="server" ID="accepted" Checked="false" />
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <hr />
    <h3>
        Custom events triggered
    </h3>
    <div id="res">

    </div>
</asp:Content>
