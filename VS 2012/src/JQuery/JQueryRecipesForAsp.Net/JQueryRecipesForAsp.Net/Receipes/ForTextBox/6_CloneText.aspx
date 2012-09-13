<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="6_CloneText.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.TextBox.CloneText" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeatureHeader" runat="server">
    Clone text
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureDescription" runat="server">
    Clone text while typing
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            $("input[id$=source]").keyup(function (e) {
                $("input[id$=target]").val($(this).val());
            });
        });
    </script>
    <asp:TextBox runat="server" ID="source" />
    <asp:TextBox runat="server" ID="target" />
</asp:Content>
