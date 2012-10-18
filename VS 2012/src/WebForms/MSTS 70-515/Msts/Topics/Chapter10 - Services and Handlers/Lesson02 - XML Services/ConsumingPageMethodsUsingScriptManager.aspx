<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="ConsumingPageMethodsUsingScriptManager.aspx.cs" Inherits="Msts.Topics.Chapter10___Services_and_Handlers.Lesson02___XML_Services.ConsumingPageMethodsUsingScriptManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        $(function () {
            var $dialog = $("#dialog");
            var $tabs = $("#tabs");
            var $bdate = $("input:text[id$=bdate]");
            var $button = $("input:submit[id$=sendRequest]");
            var $res = $("#res");

            $button.click(function (e) {
                e.preventDefault();

                $dialog.dialog("open");
                $button.prop("disabled", true);

                try {
                    PageMethods.HelloWorld($bdate.datepicker("getDate"), function (msg) {
                        $res.text(msg);
                        $tabs.tabs("select", 2);

                        enableControls();
                    }, function (err) {
                        alert(err.message);
                        enableControls();
                    });
                } catch (exc) {
                    alert(exc);
                    enableControls();
                }
            });

            function enableControls() {
                $button.prop("disabled", false);
                $dialog.dialog("close");
            }

            $dialog.dialog({
                autoOpen: false,
                modal: true,
                closeOnEscape: false,
                height: 140,
                open: function (e, ui) {
                    $(this).closest(".ui-dialog").find(".ui-dialog-titlebar-close").hide();
                }
            });

            $tabs.tabs();
            $tabs.tabs("select", 0);

            $bdate.datepicker({
                changeYear: true,
                changeMonth: true
            });
        });
    </script>
    <asp:ScriptManagerProxy runat="server" ID="smp">
    </asp:ScriptManagerProxy>
    <h1>
        Consuming PageMethod's using the ScriptManager control
    </h1>
    <div id="tabs">
        <ul>
            <li>
                <a href="#tabs-1">Prepare request</a>
            </li>
            <li>
                <a href="#tabs-2">Send request</a>
            </li>
            <li>
                <a href="#tabs-3">Results</a>
            </li>
        </ul>
        <div id="tabs-1">
            <div>
                <asp:Label Text="Please specify your birthday date" runat="server" AssociatedControlID="bdate" />
            </div>
            <div>
                <asp:TextBox runat="server" ID="bdate" />
            </div>
        </div>
        <div id="tabs-2">
            <div>
                <asp:Button Text="Send request" runat="server" ID="sendRequest" />
            </div>
        </div>
        <div id="tabs-3">
            <div id="res">

            </div>
        </div>
    </div>
    <div id="dialog">
        <div>
            Processing...
        </div>
    </div>
</asp:Content>
