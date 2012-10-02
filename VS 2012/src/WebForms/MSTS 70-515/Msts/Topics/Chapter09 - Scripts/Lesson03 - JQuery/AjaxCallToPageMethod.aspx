<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="AjaxCallToPageMethod.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery.AjaxCallToPageMethod" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        $(document).ready(function () {
            var $btn = $("input:submit[id$=process]");
            var $res = $("#res");
            var $txt = $("input:text[id$=name]");
            var $dialog = $("#dialog");

            $dialog.toggle();

            $.ajaxSetup({
                error: function (jqXHR, textStatus, errorThrown) {
                    //$dialog.dialog("close");

                    alert(jqXHR.responseText);

                    //$btn.prop('disabled', false);
                }
            });

            $btn.on("click", function (e) {
                e.preventDefault();

                $(this).prop('disabled', true);

                $dialog.dialog({
                    modal: true,
                    height: 140,
                    autoOpen: false,
                    closeOnEscape: false,
                    open: function (event, ui) {
                        $(this).closest('.ui-dialog').find('.ui-dialog-titlebar-close').hide();
                    }
                });

                $dialog.dialog("open");

                $.ajax({
                    url: "<%: this.ResolveClientUrl("~/Topics/Chapter09%20-%20Scripts/Lesson03%20-%20JQuery/AjaxCallToPageMethod.aspx/GetDomainObject") %>",
                    type: "POST",
                    contentType: "application/json; charset=utf-8;",
                    dataType: "json",
                    async: true,
                    cache: false,
                    data: "{'name': '" + $txt.val() + "'}",
                    success: function (msg, textStatus, jqXHR) {
                        var date = new Date(parseInt(msg.d.DateTime.substr(6)));

                        $res.text("")
                            .append("<br />").append("Name: " + msg.d.Name)
                            .append("<br />").append("ID: " + msg.d.ID)
                            .append("<br />").append("Processing date: " + date)
                            .append("<hr />");

                        var range = $.makeArray(msg.d.Range);

                        if (range.length > 0) {
                            $res.append("Range of numbers:").append("<ul>");

                            $.each(range, function (i, x) {
                                $("<li />").text("Number: " + x + " at index: " + i).appendTo($res);
                            });

                            $res.append("</ul>");
                        }
                        else {
                            $res.append("The range of numbers is empty");
                        }

                        // from here calling simple method in an xml service .asmx

                        $.ajax({
                            url: "<%: this.ResolveClientUrl("~/Topics/Chapter09%20-%20Scripts/Lesson03%20-%20JQuery/CustomXmlService.asmx/Hello") %>",
                            type: "POST",
                            data: "{}",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (m) {
                                $res.append("<hr /><br/>").append("Message: " + m.d);
                            }
                        });
                    },
                    complete: function (jqXHR, textStatus) {
                        $dialog.dialog("close");
                        $btn.prop('disabled', false);
                    }
                });
            });
        });
    </script>
    <h1>
        JQuery AJAX call to PageMmethod
    </h1>
    <div>
        <asp:Label Text="Enter your name" runat="server" ID="nameMessage" AssociatedControlID="name" />
    </div>
    <div>
        <asp:TextBox runat="server" ID="name" />
    </div>
    <div>
        <asp:Button Text="Process..." runat="server" ID="process" />
    </div>
    <div>
        <div id="res">

        </div>
    </div>
    <div id="dialog">
        Processing...
    </div>
</asp:Content>
