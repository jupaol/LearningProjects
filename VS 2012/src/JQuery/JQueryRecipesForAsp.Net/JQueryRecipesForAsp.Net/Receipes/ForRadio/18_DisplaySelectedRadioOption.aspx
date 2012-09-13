<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="18_DisplaySelectedRadioOption.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.ForRadio._18_DisplaySelectedRadioOption" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeatureHeader" runat="server">
    Get the selected radio option
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureDescription" runat="server">
    Get the selected radio option
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            $radios = $(".options input:radio");
            $radios.click(function () {
                $checked = $radios.filter(":checked");

                $("#msg").text("")
                    .append("<b>Index: </b>" + $checked.val())
                    .append("<br /><b>Text: </b>" + $checked.next().text());
            });
        });
    </script>
    <asp:RadioButtonList runat="server" ID="radios" CssClass="options">
        <asp:ListItem Text="Option 1" />
        <asp:ListItem Text="Option 2" />
        <asp:ListItem Text="Option 3" />
        <asp:ListItem Text="Option 4" />
        <asp:ListItem Text="Option 5" />
        <asp:ListItem Text="Option 6" />
    </asp:RadioButtonList>
    <br />
    <div id="msg" />
</asp:Content>
