<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="20_DisplayAndHideRadioOptions.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.ForRadio._20_DisplayAndHideRadioOptions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeatureHeader" runat="server">
    Display and Hide radio options
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureDescription" runat="server">
    Display and Hide radio options, when delivery is selected the credit card option won't be available
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
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
    <asp:RadioButton runat="server" ID="delivery" GroupName="BaseOptions" Text="Delivery" CssClass="cls" />
    <asp:RadioButton runat="server" ID="takeAway" GroupName="BaseOptions" Text="Take Away" CssClass="cls" />
    <asp:RadioButtonList runat="server" ID="radios" style="display:none;" CssClass="tbl">
        <asp:ListItem Text="Credit card" Value="0" />
        <asp:ListItem Text="Paypal" Value="1" />
        <asp:ListItem Text="Direct deposit" Value="2" />
    </asp:RadioButtonList>
</asp:Content>
