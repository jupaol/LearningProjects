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
            var $form = $("form");
            var $name = $("input:text[id$=name]");

            $.validator.setDefaults({
                submitHandler: function () {
                    alert("submitted");
                },
                showErrors: function (map, list) {
                    var focussed = document.activeElement;
                    if (focussed && $(focussed).is("input, textarea")) {
                        $(this.currentForm).tooltip("close", { currentTarget: focussed }, true)
                    }
                    this.currentElements.removeAttr("title").removeClass("ui-state-highlight");
                    $.each(list, function (index, error) {
                        $(error.element).attr("title", error.message).addClass("ui-state-highlight");
                    });
                    if (focussed && $(focussed).is("input, textarea")) {
                        $(this.currentForm).tooltip("open", { target: focussed });
                    }
                }
            });

            $form.tooltip({
                show: false,
                hide: false
            });

            //$name.tooltip({
            //    content: ""
            //});
            //$birthdayDate.tooltip({
            //    content: "Your birthday date (mm/dd/yyyy)"
            //});

            $birthdayDate.mask("99/99/9999");

            $.validator.addMethod("normalDate", function (value, element) {
                var momentoWrapped = moment(value, "MM/DD/YYYY");

                return momentoWrapped.isValid();
            });

            $("form").validate({
                ignore: []
            });

            $name.rules("add", {
                required: true,
                minlength: 2,
                maxlength: 10,
                messages: {
                    required: "The name is required bro",
                    minlength: "The min length is {0}",
                    maxlength: "Calm down, we only support {0}"
                }
            });

            $birthdayDate.rules("add", {
                required: true,
                normalDate: true,
                messages: {
                    required: "The birthday date is required dude!",
                    normalDate: "The date is not valid mate (DD/MM/YYYY)"
                }
            });

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

            $accordion.accordion({
                activate: function (e, ui) {
                    var accordionIndex = $accordion.accordion("option", "active");

                    console.log("accordion index: %o", accordionIndex);

                    if (accordionIndex === 0) {
                        //$name.tooltip("open");
                        //$birthdayDate.tooltip("open");
                    }
                }
            });
            $accordion.accordion("activate", 0);

            $birthdayDate.datepicker({
                dateFormat: "mm/dd/yy"
            });

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
                var validator = $("form").validate();
                var isFormValid = validator.form();

                console.log(isFormValid);

                if (!isFormValid) {
                    $accordion.accordion("activate", 0);
                    validator.focusInvalid();
                    return false;
                }

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
                    <fieldset class="ui-widget ui-widget-content ui-corner-all">
                        <legend class="ui-widget ui-widget-header ui-carner-all">
                            Enter your info
                        </legend>
                        <div>
                            <asp:Label ID="Label1" Text="Please enter your name" runat="server" AssociatedControlID="name" />
                        </div>
                        <div>
                            <asp:TextBox runat="server" ID="name" CssClass="ui-widget-content" />
                        </div>
                        <div>
                            <asp:Label ID="Label2" Text="Please enter your birthday date" runat="server" AssociatedControlID="birthdayDate" />
                        </div>
                        <div>
                            <asp:TextBox runat="server" ID="birthdayDate" CssClass="ui-widget-content" />
                        </div>
                    </fieldset>
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
