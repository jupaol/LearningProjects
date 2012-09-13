<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="15_EnableDisableControlsBasedOnCheckBox.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.ForCheckBox._15_EnableDisableControlsBasedOnCheckBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        input:disabled {
            background-color : lightgray;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeatureHeader" runat="server">
    Enable / disable controls based on checkbox status
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureDescription" runat="server">
    Enable / disable controls based on checkbox status
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            $("input:checkbox[id$=chk]").click(function () {
                var $button = $("input:submit[id$=btn]");

                if ($(this).is(":checked")) {
                    $button.removeAttr("disabled");
                }
                else {
                    $button.attr("disabled", "disabled");
                }
            });
        });
    </script>
    <asp:CheckBox runat="server" ID="chk" Text="I accept" />
    <br />
    <asp:Button runat="server" ID="btn" Text="Proceed" Enabled="false" />
</asp:Content>
