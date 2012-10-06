<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="ManipulatingXmlWithJQuery.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery.ManipulatingXmlWithJQuery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        $(function () {
            var $requst = $("input:submit[id$=requestXml]");
            var $res = $("#res");
            var $dialog = $("#dialog");

            $dialog.dialog({
                autoOpen: false,
                height: 140,
                modal: true,
                closeOnEscape: false,
                open: function () {
                    $(this).closest(".ui-dialog").find(".ui-dialog-titlebar-close").hide();
                }
            });

            $.ajaxSetup({
                complete: function () {
                    $dialog.dialog("close");
                    $requst.prop("disabled", false);
                },
                beforeSend: function () {
                    $dialog.dialog("open");
                    $requst.prop("disabled", true);
                },
                async: true,
                cache: false,
                error: function (xhr) {
                    $res.html(xhr.responseText);
                    $dialog.dialog("close");
                    $requst.prop("disabled", false);
                }
            });

            $requst.on("click", function (e) {
                e.preventDefault();

                $.ajax({
                    url: "<%: this.ResolveClientUrl("~/Topics/Chapter09 - Scripts/Lesson03 - JQuery/CustomXmlService.asmx/GetCustomXml") %>",
                    type: "GET",
                    contentType: "application/xml; charset=utf-8;",
                    dataType: "xml",
                    data: "{}",
                    success: function (msg) {
                        //this.works for IE
                        //alert(msg.text);
                        //alert($(msg.text).find("DomainUser").length);
                        //return;
                        //***************

                        console.log("doc %o", msg);
                        console.log("doc jquery %o", $(msg));

                        //var $elements = $($(msg).text()).find("DomainUser");

                        var $elements = $(msg).find("DomainUser");

                        $res.text("");

                        if ($elements.length > 0) {
                            $elements.each(function (i, x) {
                                var id = $(x).attr("ID");
                                var fname = $(x).find("FirstName").text();
                                var lname = $(x).find("LastName").text();

                                $res
                                    .append("<br />").append("ID: " + id)
                                    .append("<br />").append("First Name: " + fname)
                                    .append("<br />").append("Last Name" + lname);
                            });
                        }
                        else {
                            $res.text("No records found");
                        }
                    }
                });
            });
        });
    </script>
    <h1>
        Manipulating XML with JQuery
    </h1>
    <div>
        <asp:Button Text="Request XML..." runat="server" ID="requestXml" />
    </div>
    <div>
        <div id="res">

        </div>
    </div>
    <div id="dialog" style="display:none;">
        Processing...
    </div>
</asp:Content>
