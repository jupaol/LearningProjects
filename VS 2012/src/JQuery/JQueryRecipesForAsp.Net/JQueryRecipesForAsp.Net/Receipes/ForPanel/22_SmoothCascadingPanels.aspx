<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="22_SmoothCascadingPanels.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.ForPanel._22_SmoothCascadingPanels" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeatureHeader" runat="server">
    Smooth cascading panels
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureDescription" runat="server">
    Smooth cascading panels
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#panels #body .panelBody").hide();
            var $panels = $("#panels #body .panelBody");
            var numberOfPanels = $panels.length;
            var i = -1;
            var $showAll = $("#panels #header a[id$=showAll]");
            var $hideAll = $("#panels #header a[id$=hideAll]");

            $showAll.click(function displayPanels (e) {
                e.preventDefault();
                if (i < numberOfPanels) {
                    $panels.eq(++i).fadeIn(1000, function () {
                        displayPanels(e);
                    });
                    if (i == numberOfPanels) {
                        $showAll.hide();
                        $hideAll.show();
                    }
                }
            });
            $hideAll.click(function hidePanels(e) {
                e.preventDefault();
                if (i >= 0) {
                    $panels.eq(--i).fadeOut(1000, function () {
                        hidePanels(e);
                    });
                    if (i < 0) {
                        $showAll.show();
                        $hideAll.hide();
                    }
                }
            });
        });
    </script>
    <div id="panels">
        <div id="header">
            <asp:LinkButton runat="server" Text="Show All" ID="showAll"></asp:LinkButton>
            <asp:LinkButton runat="server" Text="Hide all" ID="hideAll" style="display:none;"></asp:LinkButton>
        </div>
        <div id="body">
            <asp:Panel runat="server" ID="Panel1" CssClass="panelBody" style="display:none;">
                Panel 1 content
            </asp:Panel>
            <asp:Panel runat="server" ID="Panel2" CssClass="panelBody" style="display:none;">
                Panel 2 content
            </asp:Panel>
            <asp:Panel runat="server" ID="Panel3" CssClass="panelBody" style="display:none;">
                Panel 3 content
            </asp:Panel>
        </div>    
    </div>
</asp:Content>
