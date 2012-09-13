<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="16_DisplayCheckedObjectsImmediatly.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.ForCheckBox._16_DisplayCheckedObjectsImmediatly" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeatureHeader" runat="server">
    Display checked controls immediatly
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureDescription" runat="server">
    Display checked controls immediatly
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function usingArray() {
            var useArray = $(".radios input:radio:checked").val() == "0";

            return useArray;
        }
        $(function () {
            var $checks = $(".options input:checkbox");
            $checks.click(function () {
                var $msg = $("div[id$=msg]");
                var $checked = $checks.filter(function (i) {
                    return $(this).is(":checked");
                });

                $msg.text("");

                if (usingArray()) {
                    var res = new Array();

                    $checked.each(function () {
                        res.push($(this).val());
                        $msg.text(res.join(" | "));
                    });
                }
                else {
                    var res = $checked.map(function () {
                        return $(this).val();
                    }).get();

                    $msg.text(res.join(" | "));
                }
            });
        });
    </script>
    <asp:RadioButtonList runat="server" ID="radios" CssClass="radios">
        <asp:ListItem Text="Using array push" Value="0" Selected="True" />
        <asp:ListItem Text="Using map function" Value="1" />
    </asp:RadioButtonList>
    <br />
    <asp:CheckBoxList runat="server" ID="chks" CssClass="options">
        <asp:ListItem Text="Option 1" />
        <asp:ListItem Text="Option 2" />
        <asp:ListItem Text="Option 3" />
        <asp:ListItem Text="Option 4" />
        <asp:ListItem Text="Option 5" />
    </asp:CheckBoxList>
    <br />
    <div id="msg" />
</asp:Content>

