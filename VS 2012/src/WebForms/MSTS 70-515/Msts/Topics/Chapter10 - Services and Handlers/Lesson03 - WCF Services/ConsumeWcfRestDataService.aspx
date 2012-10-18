<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="ConsumeWcfRestDataService.aspx.cs" Inherits="Msts.Topics.Chapter10___Services_and_Handlers.Lesson03___WCF_Services.ConsumeWcfRestDataService" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        $(function () {
            var $tabs = $("#tabs");
            var $dialog = $("#dialog");
            var $res1 = $("#res1");
            var $callUsingAjax = $("input:submit[id$=callUsingAjax]");

            $tabs.tabs();
            $tabs.tabs("select", 0);

            $dialog.dialog({
                modal: true,
                closeOnEscape: false,
                autoOpen: false,
                height: 140,
                open: function (e, ui) {
                    $(this).closest(".ui-dialog").find(".ui-dialog-titlebar-close").hide();
                }
            });

            $.ajaxSetup({
                type: "POST",
                contentType: "application/json; charset=utf-8;",
                dataType: "json",
                async: true,
                cache: false,
                error: function (XHResponse, errorMessage, errorCode) {
                    alert(errorMessage);
                    console.log("Error: %o", XHResponse);
                    $dialog.dialog("close");
                },
                complete: function () {
                    $dialog.dialog("close");
                },
                beforeSend: function () {
                    $dialog.dialog("open");
                }
            });

            $callUsingAjax.click(function (e) {
                e.preventDefault();

                try {
                    $.ajax({
                        url: "<%: this.ResolveClientUrl("~/Topics/Chapter10%20-%20Services%20and%20Handlers/Lesson03%20-%20WCF%20Services/HelloWorldWcfDataService.svc/jobs") %>",
                        type: "GET",
                        contentType: "application/json;odata=verbose;charset=utf-8;",
                        dataType: "json",
                        data: "",
                        success: function (msg) {
                            $res1.text("");

                            console.log("Received object: %o", msg);

                            $.each(msg.d, function (i, x) {
                                $res1.append("<br />").append("Description: " + this.job_desc);
                            });
                        }
                    });
                } catch (exc) {
                    $dialog.dialog("close");
                    console.log("Exception: %0", exc);
                }
            });
        });
    </script>
    <h1>
        Consuming WCF REST Data Service
    </h1>
    <div id="tabs">
        <ul>
            <li>
                <a href="#tabs-1">Using JQuery</a>
            </li>
        </ul>
        <div id="tabs-1">
            <h3>
                Using JQuery
            </h3>
            <div>
                <asp:Button Text="Call Service" runat="server" ID="callUsingAjax" />
            </div>
            <div>
                <div id="res1"></div>
            </div>
        </div>
    </div>
    <div id="dialog" style="display:none;">
        <div>
            Processing...
        </div>
    </div>
</asp:Content>
