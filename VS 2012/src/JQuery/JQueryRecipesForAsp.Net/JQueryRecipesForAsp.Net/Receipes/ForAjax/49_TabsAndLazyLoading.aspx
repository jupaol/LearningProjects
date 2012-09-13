<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="49_TabsAndLazyLoading.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.ForAjax._49_TabsAndLazyLoading" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeatureHeader" runat="server">
    Tabs and Lazy loading
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureDescription" runat="server">
    Tabs and Lazy loading
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            var $ul = $("ul[id$=bl]");
            var $lis = $("li", $ul);
            var $tabs = $("#tabs");

            $tabs.tabs({ selected: -1 });
            $tabs.bind("tabsselect", function (e, ui) {
                var index = ui.index;
                var $currentHidden = $(getCurrentHidden(index));
                var url = new String("<%: this.ResolveClientUrl("~/Receipes/ForAjax/EmployeesServiceWCF.svc/GetEmployees") %>");
                var page = index;

                if ($currentHidden.val() == "0") {
                    $.ajax({
                        type: "POST",
                        url: url,
                        contentType: "application/json; charset=utf-8;",
                        dataType: "json",
                        data: '{"page": '+page+'}',
                        async: true,
                        cache: false,
                        success: function (msg) {
                            displayData(msg.d, index);

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
                return $("input:hidden[id$=tab" + index + "]", $tabs);
            }
        });
    </script>
    <div id="tabs">
        <asp:BulletedList runat="server" ID="bl" DisplayMode="HyperLink" BulletStyle="Disc">
            <asp:ListItem Text="Employees 1" Value="#tabs-0" />
            <asp:ListItem Text="Employees 2" Value="#tabs-1" />
            <asp:ListItem Text="Employees 3" Value="#tabs-2" />
        </asp:BulletedList>
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
