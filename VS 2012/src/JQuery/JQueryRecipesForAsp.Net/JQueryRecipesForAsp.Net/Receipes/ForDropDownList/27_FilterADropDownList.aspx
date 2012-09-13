<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="27_FilterADropDownList.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.ForDropDownList._27_FilterADropDownList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeatureHeader" runat="server">
    Filter a dropdownlist
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureDescription" runat="server">
    Filter a dropdownlist with the value from a textbox
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            var $text = $("input:text[id$=txt]");
            var $ddl = $("select[id$=ddl]");
            var $options = $("option", $ddl);
            var $msg = $("#msg");

            $text.keyup(function (e) {
                searchDll($(e.target).val());
            });

            function searchDll(text) {
                var exp = new RegExp(text, "i");
                var $matchs = $.grep($options, function (n) {
                    return exp.test($(n).text());
                });

                $ddl.empty();

                if ($matchs.length > 0) {
                    $.each($matchs, function () {
                        $ddl.append($(this));
                    });
                    $(":first", $ddl).attr("selected", "selected");
                    showSearchStatus($matchs.length);
                }
                else {
                    $ddl.append("<option>No items found</option>");
                    showSearchStatus(0);
                }
            }

            function showSearchStatus(matchs) {
                if ($text.val().length) {
                    $msg.text(matchs + " items found");
                }
                else {
                    $msg.text("");
                }
            }
        });
    </script>
    <asp:TextBox runat="server" ID="txt" />
    <br />
    <asp:DropDownList runat="server" ID="ddl">
        <asp:ListItem Text="Orange" Selected="True" />
        <asp:ListItem Text="Apple" />
        <asp:ListItem Text="Pear" />
        <asp:ListItem Text="Pineapple" />
        <asp:ListItem Text="Cocconut" />
        <asp:ListItem Text="Grapes" />
        <asp:ListItem Text="Lemmon" />
        <asp:ListItem Text="Peach" />
        <asp:ListItem Text="Banana" />
        <asp:ListItem Text="Melon" />
        <asp:ListItem Text="Cherry" />
        <asp:ListItem Text="Blackberry" />
        <asp:ListItem Text="Mulberry" />
        <asp:ListItem Text="Apricot" />
        <asp:ListItem Text="Pomegranate" />
    </asp:DropDownList>
    <br />
    <asp:Button Text="Just post" runat="server" />
    <br />
    <div id="msg"></div>
</asp:Content>
