<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="48_ConsumeAJsonWebService.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._10_For_AJAX._48_ConsumeAJsonWebService" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(function () {
            var $pull = $("input:submit[id$=pull]");
            var $res = $("#res");

            $pull.click(function (e) {
                e.preventDefault();

                $.ajax({
                    type: "POST",
                    url: "EmployeesService.asmx/GetEmployees",
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
    <h1>
        Consume a JSON Web Service
    </h1>
    <asp:Button Text="Pull data" runat="server" ID="pull" /><br />
    <div id="res"></div>
</asp:Content>
