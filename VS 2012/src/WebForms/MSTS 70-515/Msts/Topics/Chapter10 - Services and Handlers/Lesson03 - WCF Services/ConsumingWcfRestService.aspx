<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="ConsumingWcfRestService.aspx.cs" Inherits="Msts.Topics.Chapter10___Services_and_Handlers.Lesson03___WCF_Services.ConsumingWcfRestService" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        $(function () {
            var $res1 = $("#res1");
            var $butt1 = $("input:submit[id$=callWcfRestServiceUsingProxy]");
            var $dialog = $("#dialog");

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
                type: "POST",
                async: true,
                cache: false,
                contentType: "application/json; charset=utf-8;",
                dataType: "json",
                beforeSend: function () {
                    $dialog.dialog("open");
                },
                complete: function () {
                    $dialog.dialog("close");
                },
                error: function (xhr, errorMessage, status) {
                    alert(errorMessage);
                }
            });

            $butt1.click(function (e) {
                e.preventDefault();

                $.ajax({
                    type: "GET",
                    url: "<%: this.ResolveClientUrl("~/Topics/Chapter10 - Services and Handlers/Lesson03 - WCF Services/HelloWorldWcfRestService.svc/HelloWorldRequestWrapped") %>",
                    data: "{}",
                    success: function (msg) {
                        $res1.html("Message: " + msg.Message);
                    }
                });
            });
        });
</script>
    <h3>
        Using JavaScript - AJAX
    </h3>
    <asp:Button Text="Call REST sercice using jQuery AJAX" runat="server" ID="callWcfRestServiceUsingProxy" />
    <div>
        <div id="res1"></div>
    </div>
    <div id="dialog">
        <div>
            Processing...
        </div>
    </div>
</asp:Content>
