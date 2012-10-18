<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="ConsumingWcfService.aspx.cs" Inherits="Msts.Topics.Chapter10___Services_and_Handlers.Lesson03___WCF_Services.ConsumingWcfService" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function pageLoad() {
            var $dialog = $("#dialog");
            var $accordion = $("#accordion");
            var $birthdayDate = $("input:text[id$=birthdayDate]");
            var $sendRequest = $("input:submit[id$=sendRequest]");
            var $yes = $("input:submit[id$=yes]");
            var $no = $("input:submit[id$=no]");
            var confirmAccepted = false;
            var $confirm = $("#confirm");

            Sys.Application.add_init(function () {
                Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(function () {
                    $dialog.dialog("open");
                    $sendRequest.prop("disabled", true);
                });

                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
                    $dialog.dialog("close");
                    //$accordion.accordion("activate", 2);
                    $sendRequest.prop("disabled", false);
                });
            });

            $dialog.dialog({
                modal: true,
                autoOpen: false,
                height: 140,
                closeOnEscape: false,
                open: function (e, ui) {
                    $(this).closest(".ui-dialog").find(".ui-dialog-titlebar-close").hide();
                }
            });

            $accordion.accordion();
            $accordion.accordion("activate", 0);

            $birthdayDate.datepicker();

            $yes.click(function (e) {
                e.preventDefault();

                confirmAccepted = true;
                $confirm.dialog("close");
                $sendRequest.click();
            });

            $no.click(function (e) {
                e.preventDefault();

                confirmAccepted = false;
                $confirm.dialog("close");
            });

            $sendRequest.click(function (e) {
                if (!confirmAccepted) {
                    $confirm.dialog("open");
                    e.preventDefault();
                    return false;
                }

                return true;
            });

            $confirm.dialog({
                modal: true,
                autoOpen: false,
                height: 140
            });
        }
    </script>
    <h1>
        Consuming WCF service Asynchronously
    </h1>
    <asp:UpdatePanel runat="server" ChildrenAsTriggers="true" UpdateMode="Always" ID="updatePanel">
        <ContentTemplate>
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
                    <div>
                        <asp:Label ID="Label2" Text="Please enter your birthday date" runat="server" AssociatedControlID="birthdayDate" />
                    </div>
                    <div>
                        <asp:TextBox runat="server" ID="birthdayDate" />
                    </div>
                </div>
                <h3>
                    <a href="#">Send Request</a>
                </h3>
                <div>
                    <div>
                        <asp:Button Text="Send request asynchronously" runat="server" ID="sendRequest" OnClick="sendRequest_Click" />
                    </div>
                </div>
                <h3>
                    <a href="#">Results</a>
                </h3>
                <div>
                    <asp:Label ID="msg" runat="server" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div id="dialog">
        <div>
            Processing...
        </div>
    </div>
    <div id="confirm">
        <div>
            Are you sure you want to continue?
        </div>
        <div>
            <asp:Button Text="Yes" runat="server" ID="yes" />
            <asp:Button Text="No" runat="server" ID="no" />
        </div>
    </div>
</asp:Content>
