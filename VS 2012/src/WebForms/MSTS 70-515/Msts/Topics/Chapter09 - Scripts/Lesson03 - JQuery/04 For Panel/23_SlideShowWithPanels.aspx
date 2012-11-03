<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="23_SlideShowWithPanels.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._04_For_Panel._23_SlideShowWithPanels" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    <h1>
        Slide show with panels
    </h1>
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
