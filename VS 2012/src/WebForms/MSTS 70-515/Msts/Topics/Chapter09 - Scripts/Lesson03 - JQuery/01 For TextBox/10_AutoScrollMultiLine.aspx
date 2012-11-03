<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="10_AutoScrollMultiLine.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._01_For_TextBox._10_AutoScrollMultiLine" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    <h1>
        Autoscroll multiline textbox
    </h1>
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
