<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="22_SmoothCascadingPanels.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._04_For_Panel._22_SmoothCascadingPanels" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#panels #body .panelBody").hide();
            var $panels = $("#panels #body .panelBody");
            var numberOfPanels = $panels.length;
            var i = -1;
            var $showAll = $("#panels #header a[id$=showAll]");
            var $hideAll = $("#panels #header a[id$=hideAll]");

            $showAll.click(function displayPanels(e) {
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
    <h1>
        Smooth cascading panels
    </h1>
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
