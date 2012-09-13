<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="3_OnlyAllowAlphaNumericValues.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.TextBox.OnlyAllowAlphaNumericValues" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureHeader" runat="server">
    Only allow alpha numeric characters
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FeatureDescription" runat="server">
    Only allow alpha numeric charactres, it reacts to key events therefore if you use your mouse
    to paste something won't be detected. 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            $("input[id$=txt]").bind("keyup blur", function (e) {
                var $val = $(this).val();
                if($val.match(/[^a-zA-Z0-9 ]/g)) {
                    $(this).val($val.replace(/[^a-zA-Z0-9 ]/g, ''));
                }
            });
        });
    </script>
    <asp:TextBox runat="server" ID="txt"></asp:TextBox>
</asp:Content>
