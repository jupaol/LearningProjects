<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="21_FadePanelsWithAnimations.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._04_For_Panel._21_FadePanelsWithAnimations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(function () {
            $("input:submit[id$=animate]").click(function (e) {
                var $panel = $("div[id$=pnl]");
                var currentAnimation = $("table.animationOptions input:radio:checked");

                e.preventDefault();

                switch (currentAnimation.val()) {
                    case "0":
                        $panel.toggle("slow");
                        break;
                    case "1":
                        if ($panel.is(":hidden")) {
                            $panel.slideDown("fast");
                        }
                        else {
                            $panel.slideUp("fast");
                        }
                        break;
                    case "2":
                        $panel.slideToggle("slow");
                        break;
                    case "3":
                        $panel.animate({
                            height: "toggle",
                            margin: "toggle",
                            opacity: "toggle"
                        }, 500);
                        break;
                }
            });
        });
    </script>
    <h1>
        Show/Hide panels with animations
    </h1>
    <asp:RadioButtonList runat="server" ID="animationOption" CssClass="animationOptions">
        <asp:ListItem Text="Toogle" Value="0" Selected="True" />
        <asp:ListItem Text="SlideUpDown" Value="1" />
        <asp:ListItem Text="SlideToogle" Value="2" />
        <asp:ListItem Text="Animate" Value="3" />
    </asp:RadioButtonList>
    <asp:Button runat="server" ID="animate" Text="Animate" /><br />
    <asp:Panel runat="server" ID="pnl">
        some text some text some text some text some text some text some text some text some text
        some text some text some text some text some text some text some text some text some text
        some text some text some text some text some text some text some text some text some text
        some text some text some text some text some text some text some text some text some text
        some text some text some text some text some text some text some text some text some text
        some text some text some text some text some text some text some text some text some text
    </asp:Panel>
</asp:Content>
