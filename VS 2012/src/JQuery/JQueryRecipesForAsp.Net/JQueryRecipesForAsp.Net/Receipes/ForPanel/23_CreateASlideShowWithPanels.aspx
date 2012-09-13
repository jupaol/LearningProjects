<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="23_CreateASlideShowWithPanels.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.ForPanel._23_CreateASlideShowWithPanels" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeatureHeader" runat="server">
    Slide show with panels
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureDescription" runat="server">
    Slide show with panels
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            var $slides = $("div.slide");
            var numberOfSlides = $slides.length;

            $slides.hide().eq(0).show();
            setInterval(panelSlider, 3000);

            function panelSlider() {
                $slides.eq(($slides.length++) % numberOfSlides).slideUp("slow", function () {
                    $slides.eq($slides.length % numberOfSlides).slideDown("slow");
                });
            }
        });
    </script>
    <asp:Panel runat="server" ID="Panel1" CssClass="slide" style="display:none;">
        Panel 1 content
    </asp:Panel>
    <asp:Panel runat="server" ID="Panel2" CssClass="slide" style="display:none;">
        Panel 2 content
    </asp:Panel>
    <asp:Panel runat="server" ID="Panel3" CssClass="slide" style="display:none;">
        Panel 3 content
    </asp:Panel>
    <asp:Panel runat="server" ID="Panel4" CssClass="slide" style="display:none;">
        Panel 4 content
    </asp:Panel>
</asp:Content>
