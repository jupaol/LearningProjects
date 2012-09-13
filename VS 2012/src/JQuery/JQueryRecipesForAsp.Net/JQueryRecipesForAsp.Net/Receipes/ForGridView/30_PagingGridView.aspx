<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="30_PagingGridView.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.ForGridView._30_PagingGridView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        input:disabled {
            background-color:gray;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeatureHeader" runat="server">
    Paging GridView
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureDescription" runat="server">
    Paging GridView on the server with jQuery
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        var take = 5;

        function printResults(msg) {
            $("#number").text("").text(msg.TotalRecords);
            $("#results").text("");
            $.each(msg.Employees, function (i, x) {
                $("#results")
                    .append("ID: ").append(x.EmployeeID)
                    .append(", First Name: ").append(x.FirstName)
                    .append(", Last Name: ").append(x.LastName).append("<br />");
            });
        }

        $(function () {
            $("#error").ajaxError(function (e, xht, settings, error) {
                $(this).text("AJAX error");
                $("input:submit[id$=fetch]").removeAttr("disabled");
            });

            $("input:submit[id$=fetch]").click(function (e) {
                e.preventDefault();
                $(this).attr("disabled", "disabled");
                $.ajax({
                    type: "POST",
                    url: "30_PagingGridView.aspx/GetEmployees",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: '{"skip":' + 0 + ', "take":' + take + '}',
                    async: true,
                    cache: false,
                    success: function (msg) {
                        var total = msg.d.TotalRecords;
                        
                        if (total > 0) {
                            var pageTotal = Math.ceil(total / take);

                            printResults(msg.d);

                            for (var i = 0; i < pageTotal; i++) {
                                $("<a />").text(i + 1).attr("href", "#").click(function (e1) {
                                    var page = $(this).text();
                                    var skip = page == 1 ? 0 : page * take - take;

                                    e1.preventDefault();

                                    $.ajax({
                                        type: "POST",
                                        url: "30_PagingGridView.aspx/GetEmployees",
                                        contentType: "application/json; charset=utf-8",
                                        dataType: "json",
                                        data: '{"skip":' + skip + ', "take":' + take + '}',
                                        async: true,
                                        cache: false,
                                        success: function (msg1) {
                                            printResults(msg1.d);
                                        }
                                    });
                                }).appendTo("#pager");
                            }
                        }
                    }
                });
            });
        });
    </script>
    <asp:Button Text="Fetch" runat="server" ID="fetch" />
    <div id="number"></div>
    <br />
    <div id="results"></div>
    <div id="pager"></div>
    <div id="error"></div>
</asp:Content>
