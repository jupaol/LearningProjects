<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="17_PerformCalculationsUsingCheckBoxes.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.ForCheckBox._17_PerformCalculationsUsingCheckBoxes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeatureHeader" runat="server">
    Performing calculations using checkboxes
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureDescription" runat="server">
    Performing calculations using checkboxes
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
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
    <asp:CheckBoxList runat="server" ID="checks" CssClass="options">
        <asp:ListItem Text="1" />
        <asp:ListItem Text="2" />
        <asp:ListItem Text="3" />
        <asp:ListItem Text="4" />
    </asp:CheckBoxList>
    <br />
    <div id="msg" />
</asp:Content>
