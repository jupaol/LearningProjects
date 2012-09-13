<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="43_AddNewItemsToBulletedListAndApplyCSS.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.ForBulletedList._43_AddNewItemsToBulletedListAndApplyCSS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeatureHeader" runat="server">
    Add new items to the BulletedList and apply CSS
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureDescription" runat="server">
    Add new items to the BulletedList and apply CSS
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            var $ul = $("ul[id$=bl]");
            var $lis = $("li", $ul);
            var $txt = $("input:text[id$=txt]");
            var $add = $("input:submit[id$=add]");

            $add.click(function (e) {
                var value = $txt.val().trim();

                e.preventDefault();

                if (value) {
                    $("<li />").text(value).appendTo($ul);
                }
            });
        });
    </script>
    <asp:BulletedList runat="server" ID="bl" DisplayMode="Text" BulletStyle="Circle">
        <asp:ListItem Text="Item1" />
        <asp:ListItem Text="Item2" />
        <asp:ListItem Text="Item3" />
    </asp:BulletedList>
    <asp:TextBox runat="server" ID="txt" />
    <br />
    <asp:Button Text="Add item" runat="server" ID="add" />
</asp:Content>
