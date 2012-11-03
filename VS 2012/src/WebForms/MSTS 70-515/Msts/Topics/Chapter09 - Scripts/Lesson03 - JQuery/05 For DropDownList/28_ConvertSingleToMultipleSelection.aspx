<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="28_ConvertSingleToMultipleSelection.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._05_For_DropDownList._28_ConvertSingleToMultipleSelection" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(function () {
            var $convert = $("input:submit[id$=convert]");
            var $show = $("input:submit[id$=show]");
            var $ddl = $("select[id$=ddl]");
            var $msg = $("#msg");

            $show.hide();
            $convert.show();

            $convert.click(function (e) {
                e.preventDefault();
                $ddl.attr("multiple", "multiple").attr("size", "2");
                $show.show();
                $convert.hide();
            });

            $show.click(function (e) {
                e.preventDefault();
                var $selected = $(":selected", $ddl);
                $msg.text("");
                $selected.each(function (i, x) {
                    $msg.append("<br />" + $(x).text() + " " + $(this).val());
                });
            });
        });
    </script>
    <h1>
        Convert a dropdownlist to allow multiple selections
    </h1>
    <asp:DropDownList runat="server" ID="ddl">
        <asp:ListItem Text="Item 1" />
        <asp:ListItem Text="Item 2" />
        <asp:ListItem Text="Item 3" />
    </asp:DropDownList>
    <asp:ListBox ID="ListBox1" runat="server" Rows="2">
        <asp:ListItem Text="text1" />
        <asp:ListItem Text="text2" />
        <asp:ListItem Text="text3" />
        <asp:ListItem Text="text4" />
    </asp:ListBox>
    <asp:Button Text="Convert to multiple selection" runat="server" ID="convert" />
    <br />
    <asp:Button Text="Show selected options" runat="server" ID="show" style="display:none;" />
    <br />
    <div id="msg" />
</asp:Content>
