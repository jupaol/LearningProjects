<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="19_DisplaySelectedRadioOfMultipleRadioButtonLists.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.ForRadio._19_DisplaySelectedRadioOfMultipleRadioButtonLists" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeatureHeader" runat="server">
    Display selected radio of multiple radio button lists
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureDescription" runat="server">
    Display selected radio of multiple radio button lists
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            var $radios = $(".options input:radio");

            $radios.click(function () {
                var $checked = $radios.filter(":checked");

                $("#msg").text("");

                $checked.each(function (i, x) {
                    $("#msg")
                        .append("<br /><b>Value: </b>" + $(x).val())
                        .append("<br /><b>Text: </b>" + $(x).next().text());
                });
            });
        });
    </script>
    First option
    <asp:RadioButtonList runat="server" ID="radios1" CssClass="options">
        <asp:ListItem Text="Option 1.1" />
        <asp:ListItem Text="Option 1.2" />
        <asp:ListItem Text="Option 1.3" />
        <asp:ListItem Text="Option 1.4" />
    </asp:RadioButtonList>
    Second option
    <asp:RadioButtonList runat="server" ID="radios2" CssClass="options">
        <asp:ListItem Text="Option 2.1" />
        <asp:ListItem Text="Option 2.2" />
        <asp:ListItem Text="Option 2.3" />
    </asp:RadioButtonList>
    <div id="msg" />
</asp:Content>
