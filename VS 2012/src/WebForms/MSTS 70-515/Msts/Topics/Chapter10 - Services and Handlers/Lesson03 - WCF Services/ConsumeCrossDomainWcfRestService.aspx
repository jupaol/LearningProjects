<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="ConsumeCrossDomainWcfRestService.aspx.cs" Inherits="Msts.Topics.Chapter10___Services_and_Handlers.Lesson03___WCF_Services.ConsumeCrossDomainWcfRestService" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        $(function () {
            var $res = $("#res");
            var $dialog = $("#dialog");
            var $call = $("#call");

            $dialog.dialog({
                autoOpen: false,
                modal: true,
                closeOnEscape: false,
                height: 140,
                open: function (e, ui) {
                    $(this).closest(".ui-dialog").find(".ui-dialog-titlebar-close").hide();
                }
            });

            $.ajaxSetup({
                beforeSend: function () {
                    $dialog.dialog("open");
                },
                complete: function () {
                    $dialog.dialog("close");
                },
                error: function (xhr) {
                    alert(xhr.responseText);
                    $dialog.dialog("close");
                },
                async: true,
                cache: false
            });

            $call.click(function (e) {
                e.preventDefault();

                try {
                    $.ajax({
                        url: "http://localhost:64044/wcf/hello",
                        type: "GET",
                        contentType: "application/json; charset=utf-8;",
                        dataType: "jsonp",
                        data: "{}",
                        success: function (msg) {
                            $res.text(msg.Message);
                        }
                    });
                } catch (exc) {
                    $dialog.dialog("close");
                    console.log("Exception: %o", exc);
                }
            });
        });
    </script>
    <h1>
        Consuming a WCF REST service (Cross Domain)
    </h1>
    <input type="button" id="call" value="Call service..." />
    <div id="res">

    </div>
    <div id="dialog" style="display:none;">
        <div>
            Processing...
        </div>
    </div>
</asp:Content>
