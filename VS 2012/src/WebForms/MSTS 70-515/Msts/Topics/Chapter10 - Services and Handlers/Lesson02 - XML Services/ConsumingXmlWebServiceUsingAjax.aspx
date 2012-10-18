<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="ConsumingXmlWebServiceUsingAjax.aspx.cs" Inherits="Msts.Topics.Chapter10___Services_and_Handlers.Lesson02___XML_Services.ConsumingXmlWebServiceUsingAjax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        $(function () {
            var $accordion = $("#accordion");
            var $res = $("#res");
            var $button = $("input:submit[id$=sendRequest]");
            var $txt = $("input:text[id$=name]");
            var $dialog = $("#dialog");

            $accordion.accordion();
            $accordion.accordion("activate", 0);

            $dialog.dialog({
                modal: true,
                autoOpen: false,
                height: 140,
                closeOnEscape: false,
                open: function (e, ui) {
                    $(this).closest(".ui-dialog").find(".ui-dialog-titlebar-close").hide();
                }
            });

            function enableControls() {
                $button.prop("disabled", false);
                $dialog.dialog("close");
            }

            $button.click(function (e) {
                e.preventDefault();

                $dialog.dialog("open");
                $button.prop("disabled", true);

                try {
                    $.ajax({
                        url: "<%: this.ResolveClientUrl("~/Topics/Chapter10%20-%20Services%20and%20Handlers/Lesson02%20-%20XML%20Services/HelloWorldService.asmx/HelloWorld") %>",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        data: '{"name": "' + $txt.val() + '"}',
                        async: true,
                        cache: false,
                        success: function (msg) {
                            $res.text(msg.d);
                            enableControls();
                            $accordion.accordion("activate", 2);
                        },
                        error: function (err) {
                            alert("Error: " + err.responseText);
                            enableControls();
                        }
                    });
                } catch (exc) {
                    alert("Exception: " + exc);
                    enableControls();
                }
            });
        });
    </script>
    <h1>
        Consuming Web Service using JQuery AJAX
    </h1>
    <div id="accordion">
        <h3>
            <a href="#">Prepare request</a>
        </h3>
        <div>
            <div>
                <asp:Label ID="Label1" Text="Please enter your name" runat="server" AssociatedControlID="name" />
            </div>
            <div>
                <asp:TextBox runat="server" ID="name" />
            </div>
        </div>
        <h3>
            <a href="#">Send request</a>
        </h3>
        <div>
            <div>
                <asp:Button Text="Send request" runat="server" ID="sendRequest" />
            </div>
        </div>
        <h3>
            <a href="#">Results</a>
        </h3>
        <div>
            <div id="res">

            </div>
        </div>
    </div>
    <div id="dialog">
        <div>
            Processing
        </div>
    </div>
</asp:Content>
