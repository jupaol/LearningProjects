<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="ConsumingXmlWebServicesViaScriptManager.aspx.cs" Inherits="Msts.Topics.Chapter10___Services_and_Handlers.Lesson02___XML_Services.ConsumingXmlWebServicesViaScriptManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManagerProxy runat="server" ID="smp">
        <Services>
            <asp:ServiceReference Path="~/Topics/Chapter10 - Services and Handlers/Lesson02 - XML Services/HelloWorldService.asmx" />
        </Services>
    </asp:ScriptManagerProxy>
    <script>
        $(function () {
            var $res = $("#msg");
            var $button = $("input:submit[id$=sendRequest]");
            var $txt = $("input:text[id$=name]");
            var $tabs = $("#tabs");
            var $dialog = $("#dialog");

            $tabs.tabs();
            $tabs.tabs("select", 0);
            $dialog.dialog({
                autoOpen: false,
                closeOnEscape: false,
                modal: true,
                height: 140,
                open: function (e, ui) {
                    $(this).closest(".ui-dialog").find(".ui-dialog-titlebar-close").hide();
                }
            });

            $button.click(function (e) {
                e.preventDefault();

                try {
                    var s = new Msts.Topics.Chapter10___Services_and_Handlers.Lesson02___XML_Services.HelloWorldService();

                    $dialog.dialog("open");
                    $button.prop("disabled", true);

                    s.HelloWorld(
                        $txt.val(),
                        function (m) {
                            $res.text(m);
                            $tabs.tabs("select", 2);
                            $dialog.dialog("close");
                            $button.prop("disabled", false);
                        },
                        function (err) {
                            alert(err);
                            $dialog.dialog("close");
                            $button.prop("disabled", false);
                        },
                        null);
                } catch (exc) {
                    $dialog.dialog("close");
                    $button.prop("disabled", false);
                }
            });
        });
    </script>
    <h1>
        Consuming XML Web Services using the ScriptManager control
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
                <asp:Label Text="Please enter your name" runat="server" AssociatedControlID="name" />
            </div>
            <div>
                <asp:TextBox runat="server" ID="name" />
            </div>
        </div>
        <div id="tabs-2">
            <div>
                <asp:Button Text="Send request" runat="server" ID="sendRequest" />
            </div>
        </div>
        <div id="tabs-3">
            <div>
                <div id="msg"></div>
            </div>
        </div>
    </div>
    <div id="dialog" style="display:none;">
        <div>
            Processing...
        </div>
    </div>
</asp:Content>
