<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="24_RetrieveSelectedDropDownList.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.ForDropDownList._24_RetrieveSelectedDropDownList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeatureHeader" runat="server">
    Retrieve the text and value from the selected dropdownlist item
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureDescription" runat="server">
    Retrieve the text and value from the selected dropdownlist item
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            $("select[id$=ddl]").change(function () {
                var $selected = $("select[id$=ddl] :selected");

                $("#msg").html("")
                    .append("<b>Value: </b>" + $selected.val())
                    .append("<b>Text: </b>" + $selected.text());
            });
        });
    </script>
    <asp:DropDownList runat="server" ID="ddl" CssClass="options">
        <asp:ListItem Text="Option 1" />
        <asp:ListItem Text="Option 2" />
        <asp:ListItem Text="Option 3" />
        <asp:ListItem Text="Option 4" />
    </asp:DropDownList>
    <div id="msg" />
</asp:Content>
