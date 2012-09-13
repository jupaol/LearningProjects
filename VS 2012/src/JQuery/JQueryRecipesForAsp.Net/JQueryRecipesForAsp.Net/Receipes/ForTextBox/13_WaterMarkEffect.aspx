<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="13_WaterMarkEffect.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.TextBox._13_WaterMarkEffect" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        .water {
            background-color : aliceblue;
            color : gray;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeatureHeader" runat="server">
    WaterMark effect
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureDescription" runat="server">
    WaterMark effect
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            $(".water").each(function () {
                var $text = $(this);

                if ($.trim($text.val()) !== "" && $.trim($text.val()) != $.trim(this.title)) {
                    $text.removeClass("water");
                }
                else {
                    $text.val(this.title);
                    $text.addClass("water");
                }
            });

            $(".water").focusin(function () {
                var $text = $(this);

                if ($.trim($text.val()) === $.trim(this.title)) {
                    $text.val("");
                    $text.removeClass("water");
                }
            });

            $(".water").focusout(function () {
                var $text = $(this);

                if ($.trim($text.val()) === "" || $.trim($text.val()) === $.trim(this.title)) {
                    $text.val(this.title);
                    $text.addClass("water");
                }
            });
        });
    </script>
    <asp:TextBox CssClass="water" ToolTip="Write something" runat="server" ID="txt" Text=""></asp:TextBox>
</asp:Content>
