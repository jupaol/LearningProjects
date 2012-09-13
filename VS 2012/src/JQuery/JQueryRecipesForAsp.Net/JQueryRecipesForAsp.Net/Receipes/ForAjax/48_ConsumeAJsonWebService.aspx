<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="48_ConsumeAJsonWebService.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.ForAjax._48_ConsumeAJsonWebService" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        input:disabled {
            background-color: silver;
            cursor: initial;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeatureHeader" runat="server">
    Consume a JSON Web Service
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureDescription" runat="server">
    Consume a JSON Web Service
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            var $pull = $("input:submit[id$=pull]");
            var $res = $("#res");

            $pull.click(function (e) {
                e.preventDefault();

                $.ajax({
                    type: "POST",
                    url: "<%: this.ResolveClientUrl("~/Receipes/ForAjax/EmployeesService.asmx/GetEmployees") %>",
                    contentType: "application/json; charset=utf-8;",
                    dataType: "json",
                    data: "{}",
                    async: true,
                    cache: false,
                    success: function (msg) {
                        displayData(msg.d);
                    },
                    error: function (xmlHttpResponse, textStatus, errorThrown) {
                        alert(textStatus);
                    }
                });
            });

            function displayData(msg) {
                $.each(msg, function (i, x) {
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

                $pull.attr("disabled", "disabled");
            }
        });
    </script>
    <asp:Button Text="Pull data" runat="server" ID="pull" /><br />
    <div id="res"></div>
</asp:Content>
