<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="50_PopulateAListBox.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.ForAjax._50_PopulateAListBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeatureHeader" runat="server">
    Populate  a ListBox
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureDescription" runat="server">
    Populate  a ListBox
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            var $table = $("table[id$=rbl]");
            var $emp = $("select[id$=lb]");

            $.ajax({
                type: "POST",
                url: "<%: this.ResolveClientUrl("~/Receipes/ForAjax/EmployeesServiceWCF.svc/GetJobs") %>",
                contentType: "application/json; charset=utf-8;",
                dataType: "json",
                data: "{}",
                async: true,
                cache: false,
                success: function (msg) {
                    $table.children().remove();

                    $.each(msg.d, function (i, x) {
                        var $td = $("<td />");
                        var $row = $("<tr />");
                        var $rad = $("<input type=\"radio\" />")
                            .val(x.JobID)
                            .attr("id", "rbl_" + i)
                            .attr("name", "rbl_items");
                        var $lab = $("<label />")
                            .attr("for", "rbl_" + i)
                            .text(x.Description);

                        $td.append($rad).append($lab);
                        $row.append($td);
                        $table.append($row);
                    });

                    var $opt = $("input:radio", $table);

                    $opt.click(function (e) {
                        showEmployees();
                    });
                },
                error: function (xhr, text, error) {
                    alert(text);
                }
            });

            function showEmployees() {
                var $checked = $("input:radio:checked", $table);
                var selectedJobID = $checked.val();

                $.ajax({
                    type: "POST",
                    url: "<%: this.ResolveClientUrl("~/Receipes/ForAjax/EmployeesServiceWCF.svc/GetEmployeeByJob") %>",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: '{"jobID": '+selectedJobID+'}',
                    async: true,
                    cache: false,
                    success: function (msg) {
                        $emp.children().remove();

                        $.each(msg.d, function (i, x) {
                            $("<option/>")
                                .text(x.FirstName + " " + x.LastName)
                                .val(x.EmployeeID)
                                .appendTo($emp);
                        });
                    },
                    error: function (xhr, text, errorThrown) {
                        alert(text);
                    }
                });
            }
        });
    </script>
    <table id="rbl">
    </table>
    <br />
    <asp:ListBox runat="server" ID="lb">
    </asp:ListBox>
</asp:Content>
