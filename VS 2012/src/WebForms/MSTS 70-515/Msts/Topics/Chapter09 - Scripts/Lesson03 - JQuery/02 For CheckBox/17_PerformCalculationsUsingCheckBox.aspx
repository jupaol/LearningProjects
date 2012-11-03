<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="17_PerformCalculationsUsingCheckBox.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._02_For_CheckBox._17_PerformCalculationsUsingCheckBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(function () {
            $(".options input:checkbox").click(function () {
                var $checks = $(".options input:checkbox:checked");
                var total = 0;
                var $msg = $("div[id$=msg]");

                $checks.each(function (i, item) {
                    total += parseFloat($(this).next().text());
                });

                $msg.text("The total is: " + total);
            });
        });
    </script>
    <h1>
        Performing calculations using checkboxes
    </h1>
    <asp:CheckBoxList runat="server" ID="checks" CssClass="options">
        <asp:ListItem Text="1" />
        <asp:ListItem Text="2" />
        <asp:ListItem Text="3" />
        <asp:ListItem Text="4" />
    </asp:CheckBoxList>
    <br />
    <div id="msg" />
</asp:Content>
