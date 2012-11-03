<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="14_CheckUncheckAll.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._02_For_CheckBox._14_CheckUncheckAll" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(function () {
            var $checkAll = $("input:checkbox[id$=chkAll]");
            var $checks = $(".options input:checkbox");

            $checkAll.click(function () {
                $checks.attr("checked", $checkAll.is(":checked"));
            });

            $checks.click(function () {
                if (!$(this).is(":checked")) {
                    $checkAll.attr("checked", false);
                }
                else {
                    var $unchecked = $checks.filter(function (i) {
                        return !$(this).is(":checked");
                    });

                    if ($unchecked.length <= 0) {
                        $checkAll.attr("checked", true);
                    }
                }
            });
        });
    </script>
    <h1>
        Check all
    </h1>
    <asp:CheckBox runat="server" ID="chkAll" Text="Check all" /><br />
    <asp:CheckBoxList runat="server" ID="chklist" CssClass="options">
        <asp:ListItem Text="Option 1" />
        <asp:ListItem Text="Option 2" />
        <asp:ListItem Text="Option 3" />
        <asp:ListItem Text="Option 4" />
    </asp:CheckBoxList>
</asp:Content>
