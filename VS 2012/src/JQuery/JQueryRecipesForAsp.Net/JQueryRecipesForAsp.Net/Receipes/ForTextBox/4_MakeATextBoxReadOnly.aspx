<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="4_MakeATextBoxReadOnly.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.TextBox.MakeATextBoxReadOnly" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeatureHeader" runat="server">
    Make a textbox readonly
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureDescription" runat="server">
    The textbox with data are read only now
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            $("input:text[value!='']").each(function () {
                $(this).attr("readonly", true);
            });
        });
    </script>
    <asp:TextBox runat="server" ID="Text1" Text="Some text" /><br />
    <asp:TextBox runat="server" ID="TextBox1" Text="" /><br />
    <asp:TextBox runat="server" ID="TextBox2" Text="" /><br />
    <asp:TextBox runat="server" ID="TextBox3" Text="Some text" /><br />
</asp:Content>
