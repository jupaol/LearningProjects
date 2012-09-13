<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="28_ConvertADropDownListInMultiple.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.ForDropDownList._28_ConvertADropDownListInMultiple" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeatureHeader" runat="server">
    Convert a dropdownlist to allow multiple selections
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureDescription" runat="server">
    Convert a dropdownlist to allow multiple selections
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
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
    <asp:DropDownList runat="server" ID="ddl">
        <asp:ListItem Text="Item 1" />
        <asp:ListItem Text="Item 2" />
        <asp:ListItem Text="Item 3" />
    </asp:DropDownList>
    <asp:ListBox runat="server" Rows="2">
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
