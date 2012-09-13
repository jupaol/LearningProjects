<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="10_AutoScrollMultilineTextbox.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.TextBox._10_AutoScrollMultilineTextbox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeatureHeader" runat="server">
    Autoscroll multiline textbox
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureDescription" runat="server">
    Autoscroll multiline textbox
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            var $area = $("textarea[id$=txt]");
            $("input[id$=scroll]").toggle(function (e) {
                e.preventDefault();
                scrollArea($area, $area[0].scrollHeight);
            }, function (e) {
                e.preventDefault();
                scrollArea($area, 0);
            });
        });

        function scrollArea(ctrl, ht) {
            ctrl.animate({ scrollTop: ht }, 1000);
        }
    </script>
    <asp:TextBox runat="server" ID="txt" TextMode="MultiLine" Text="
        something something something something something something something something something something
        something something something something something something something something something something
        something something something something something something something something something something
        something something something something something something something something something something
        something something something something something something something something something something
        something something something something something something something something something something
        something something something something something something something something something something
        something something something something something something something something something something
        something something something something something something something something something something
        something something something something something something something something something something
        something something something something something something something something something something
        something something something something something something something something something something
        something something something something something something something something something something
        something something something something something something something something something something
        something something something something something something something something something something
        something something something something something something something something something something
        something something something something something something something something something something
        something something something something something something something something something something
        something something something something something something something something something something
        something something something something something something something something something something
        something something something something something something something something something something
        something something something something something something something something something something
        something something something something something something something something something something
        something something something something something something something something something something
        something something something something something something something something something something
        something something something something something something something something something something
        
        " Rows="5"></asp:TextBox>
    <br />
    <asp:Button Text="Scroll" runat="server" ID="scroll" />
</asp:Content>
