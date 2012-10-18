<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="TestingSomeSelectors.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery.TestingSomeSelectors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        $(function () {
            var $buttons = $("input:submit[id*=Button]");

            $buttons.fadeOut('slow').fadeIn('slow').each(function (i, x) {
                $(this).val($(x).val() + " index: " + i);
            });

            //get the same element - DOM element
            var $b1 = $buttons.get(0);
            var b1 = $buttons[0];
            //************

            //returns a jQuery element
            var $b1_1 = $buttons.eq(0);
            //***********
        });
    </script>
    <h1>
        JQuery tests
    </h1>
    <h2>
        Selectros
    </h2>
    <asp:Button Text="Button1" runat="server" ID="Button1" />
    <asp:Button Text="Button2" runat="server" ID="Button2" />
    <asp:Button Text="Button3" runat="server" ID="Button3" />
</asp:Content>
