<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="7_SelectFirstTextBoxOnPage.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.TextBox.SelectFirstTextBoxOnPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeatureHeader" runat="server">
    Select first textbox on the page
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureDescription" runat="server">
    Select first textbox on the page when it's not disabled and contains text
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            $("input:disabled").css("background-color", "gray");
            $("input:text[value!=]:enabled:first").focus().select();
        });
    </script>
    <asp:TextBox runat="server" ID="TextBox1" Enabled="true" Text=""></asp:TextBox><br />
    <asp:TextBox runat="server" ID="TextBox2" Enabled="false" Text="Some text"></asp:TextBox><br />
    <asp:TextBox runat="server" ID="TextBox3" Enabled="true" Text="plop"></asp:TextBox><br />
    <asp:TextBox runat="server" ID="TextBox4" Enabled="true" Text="Some text"></asp:TextBox><br />
    <asp:TextBox runat="server" ID="TextBox5" Enabled="false" Text="Some text"></asp:TextBox><br />
</asp:Content>
