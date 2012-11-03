<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="49_TabsAndLazyLoading.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._10_For_AJAX._49_TabsAndLazyLoading" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(function () {
            var $tabs = $("#customtabs");

            $tabs.tabs({ selected: 0 });
            $tabs.bind("tabsselect", function (e, ui) {
                var index = ui.index;
                var $currentHidden = $(getCurrentHidden(index));
                var page = index;

                if ($currentHidden.val() == "0") {
                    $.ajax({
                        type: "POST",
                        url: "EmployeesServiceWCF.svc/GetEmployees",
                        contentType: "application/json; charset=utf-8;",
                        dataType: "json",
                        data: '{"page": ' + page + '}',
                        async: true,
                        cache: false,
                        success: function (msg) {
                            displayData(msg, index);

                            $currentHidden.val("1");
                        },
                        error: function (xhr, text, code) {
                            alert(code + " " + text);
                        }
                    });
                }
            });
            $tabs.bind("tabsshow", function (e, ui) {
                //var $currentHidden = $(getCurrentHidden(ui.index));

                //$currentHidden.val("1");
            });

            function displayData(data, index) {
                var $res = $("#res" + index);

                $.each(data, function (i, x) {
                    $res
                        .append("ID: ")
                        .append(x.EmployeeID)
                        .append("<br />")
                        .append("First Name: ")
                        .append(x.FirstName)
                        .append("<br />")
                        .append("Last Name: ")
                        .append(x.LastName)
                        .append("<hr />");
                });
            }

            function getCurrentHidden(index) {
                var $tmp = $("input:hidden[id$=tab" + index + "]", $tabs);

                return $tmp;
            }
        });
    </script>
    <h1>
        Tabs and Lazy loading
    </h1>
    <div id="customtabs">
        <ul>
            <li><a href="#tabs-0">Employees 1</a></li>
            <li><a href="#tabs-1">Employees 2</a></li>
            <li><a href="#tabs-2">Employees 3</a></li>
        </ul>
        <div id="tabs-0">
            Tabs 1 content
            <asp:HiddenField runat="server" ID="tab0" Value="0" />
            <div id="res0"></div>
        </div>
        <div id="tabs-1">
            Tabs 2 content
            <asp:HiddenField runat="server" ID="tab1" Value="0" />
            <div id="res1"></div>
        </div>
        <div id="tabs-2">
            Tabs 3 content
            <asp:HiddenField runat="server" ID="tab2" Value="0" />
            <div id="res2"></div>
        </div>
    </div>
</asp:Content>
