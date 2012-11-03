<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="12_WaterMarkEfect.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._01_For_TextBox._13_WaterMarkEfect" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .water {
            background-color : aliceblue;
            color : gray;
        }
    </style>
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
    <h1>
        Water mark effect
    </h1>
    <asp:TextBox CssClass="water" ToolTip="Write something" runat="server" ID="txt" Text=""></asp:TextBox>
</asp:Content>
