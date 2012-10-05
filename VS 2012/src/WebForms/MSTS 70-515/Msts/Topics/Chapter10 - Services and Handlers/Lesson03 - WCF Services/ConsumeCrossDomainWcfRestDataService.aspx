<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="ConsumeCrossDomainWcfRestDataService.aspx.cs" Inherits="Msts.Topics.Chapter10___Services_and_Handlers.Lesson03___WCF_Services.ConsumeCrossDomainWcfRestDataService" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        $(function () {
            var $dialog = $("#dialog");
            var $call = $("input:submit[id$=call]");
            var $accordion = $("#accordion");
            var $slider = $("#slider");
            var $autoComplete = $("input:text[id$=firstName]");
            var viewModel = {
                min: ko.observable(0),
                employees: ko.observableArray(),
                jobs: ko.observableArray(),
                date: ko.observable(new Date()),
                employeeNamePattern: ko.observable(""),
                selectedEmployee: ko.observable("")
            };

            $accordion.accordion();
            $accordion.accordion("activate, 0");

            $call.button();

            $slider.slider({
                value: 0,
                min: 0,
                max: 1000,
                step: 50,
                slide: function (e, ui) {
                    viewModel.min(ui.value);
                }
            });

            $dialog.dialog({
                autoOpen: false,
                closeOnEscape: false,
                draggable: false,
                resizanle: false,
                modal: true,
                height: 140,
                open: function (e, ui) {
                    $(this).closest(".ui-dialog").find(".ui-dialog-titlebar-close").hide();
                }
            });

            $autoComplete.autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "http://localhost:64044/ExternalHelloWorldWcfRestDataService.svc/employees?$format=json&$callback=myCallback",
                        type: "GET",
                        contentType: "application/json;odata=verbose;charset=utf-8;",
                        dataType: "jsonp",
                        jsonpCallback: "myCallback",
                        data: "",
                        success: function (msg) {
                            response($.map(msg.d, function (item) {
                                return {
                                    label: item.fname + " " + item.lname,
                                    value: item.fname
                                };
                            }));
                        }
                    });
                },
                minLength: 2,
                select: function (e, ui) {
                    viewModel.selectedEmployee(ui.item.label.length === 0 ? $autoComplete.val() : ui.item.label);
                }
            });
            $autoComplete.blur(function (e) {
                viewModel.employeeNamePattern($(this).val());
            });

            $.ajaxSetup({
                type: "POST",
                contentType: "application/json;charset=utf-8;",
                dataType: "json",
                async: true,
                cache: false,
                error: function (XHResponse, errorMessage, errorCode) {
                    $dialog.dialog("close");
                    $call.prop("disabled", false);
                    console.log("AJAX Error: %o", XHResponse);
                }
            });

            $call.click(function (e) {
                e.preventDefault();

                var min = $slider.slider("value");
                var fname = $autoComplete.val();
                var filter = "";

                filter = "$filter=job_lvl gt " + min;

                if (fname.length > 0) {
                    filter += " and fname eq '" + fname + "'";
                }

                //&$callback=myCallback
                $.ajax({
                    url: "http://localhost:64044/ExternalHelloWorldWcfRestDataService.svc/employees?$format=json&$callback=myCallback",
                    type: "GET",
                    contentType: "application/json;odata=verbose;charset=utf-8;",
                    dataType: "jsonp",
                    jsonpCallback: "myCallback",
                    data: filter,
                    success: function (msg) {
                        viewModel.employees(msg.d);
                        viewModel.date(new Date());
                    },
                    complete: function () {
                        $dialog.dialog("close");
                        $call.prop("disabled", false);
                    },
                    beforeSend: function () {
                        $dialog.dialog("open");
                        $call.prop("disabled", true);
                    }
                });
            });

            ko.applyBindings(viewModel);
        });
    </script>
    <h1>
        Consuming Cross Domain WCF REST Data Service
    </h1>
    <h3>
        Using JQuery, JQuery UI [AutoComplete, Accordion, Dialog, Slider, Button] and KnockoutJS
    </h3>
    <div id="accordion">
        <h3>
            <a href="#">Set Filter</a>
        </h3>
        <div>
            <div>
                <label for="slider">Specify the Minimum Level filter</label>
            </div>
            <div>
                <div id="slider"></div>
            </div>
            <div>
                <p>Minimum value: <span data-bind="text: min"></span></p>
            </div>
            <div>
                <asp:Label Text="Search by first name" runat="server" AssociatedControlID="firstName" />
            </div>
            <div>
                <asp:TextBox runat="server" ID="firstName" />
            </div>
            <div>
                Selected employee:
                <span data-bind="text: selectedEmployee"></span>
            </div>
            <div>
                Employee Name pattern:
                <span data-bind="text: employeeNamePattern"></span>
            </div>
        </div>
        <h3>
            <a href="#">Call Service</a>
        </h3>
        <div>
            <div>
                <asp:Button Text="Call Service" runat="server" ID="call" />
            </div>
        </div>
    </div>
    <div>
        <span>Render at:</span>
        <b>
            <span data-bind="text: date"></span>
        </b>
    </div>
    <div>
        <h3>Employees</h3>
    </div>
    <div>
        <span>Elements found:</span>
        <span data-bind="text: employees().length"></span>
    </div>
    <div>
        <ul data-bind="foreach: employees">
            <li>
                <b>
                    First Name:
                </b>
                <span data-bind="text: fname"></span>
                <b>
                    Job Level:
                </b>
                <span data-bind="text: job_lvl"></span>
            </li>
        </ul>
    </div>
    <div id="dialog" style="display:none;">
        <div>
            Processing please wait...
        </div>
    </div>
</asp:Content>
