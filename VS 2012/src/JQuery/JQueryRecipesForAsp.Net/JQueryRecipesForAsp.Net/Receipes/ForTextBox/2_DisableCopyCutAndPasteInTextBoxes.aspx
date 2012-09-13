<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="2_DisableCopyCutAndPasteInTextBoxes.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.TextBox.DisableCopyCutAndPasteInTextBoxes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureHeader" runat="server">
    Disabling copy, cut and paste in the textboxes
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FeatureDescription" runat="server">
    Disabling copy, cut and paste in the text boxes
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            $("input[id$=txt]").bind("copy cut paste", function (e) {
                e.preventDefault();
            });
        });
    </script>
    <asp:TextBox runat="server" ID="txt" />
</asp:Content>
