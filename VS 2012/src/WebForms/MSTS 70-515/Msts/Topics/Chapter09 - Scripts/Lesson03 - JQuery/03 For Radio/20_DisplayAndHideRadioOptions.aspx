<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="20_DisplayAndHideRadioOptions.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._03_For_Radio._20_DisplayAndHideRadioOptions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(function () {
            var $tbl = $("table.tbl");
            var $creditCard = $("input:radio[value='0']", $tbl);

            $tbl.hide();

            $(".cls input:radio").click(function (e) {
                var currentID = e.target.id;

                $tbl.show();

                if (currentID === $(".cls input:radio[id$=delivery]").attr("id")) {
                    $creditCard.hide().next().hide();
                }

                if (currentID === $(".cls input:radio[id$=takeAway]").attr("id")) {
                    $creditCard.show().next().show();
                }
            });
        });
    </script>
    <h1>
        Display and Hide radio options
    </h1>
    <h2>
        Display and Hide radio options, when delivery is selected the credit card option won't be available
    </h2>
    <asp:RadioButton runat="server" ID="delivery" GroupName="BaseOptions" Text="Delivery" CssClass="cls" />
    <asp:RadioButton runat="server" ID="takeAway" GroupName="BaseOptions" Text="Take Away" CssClass="cls" />
    <asp:RadioButtonList runat="server" ID="radios" style="display:none;" CssClass="tbl">
        <asp:ListItem Text="Credit card" Value="0" />
        <asp:ListItem Text="Paypal" Value="1" />
        <asp:ListItem Text="Direct deposit" Value="2" />
    </asp:RadioButtonList>
</asp:Content>
