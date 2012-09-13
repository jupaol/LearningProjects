<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="14_CheckAllCheckBoxes.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.ForCheckBox._14_CheckAllCheckBoxes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeatureHeader" runat="server">
    Check all check boxes
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureDescription" runat="server">
    Check all check boxes
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
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
    <asp:CheckBox runat="server" ID="chkAll" Text="Check all" /><br />
    <asp:CheckBoxList runat="server" ID="chklist" CssClass="options">
        <asp:ListItem Text="Option 1" />
        <asp:ListItem Text="Option 2" />
        <asp:ListItem Text="Option 3" />
        <asp:ListItem Text="Option 4" />
    </asp:CheckBoxList>
</asp:Content>
