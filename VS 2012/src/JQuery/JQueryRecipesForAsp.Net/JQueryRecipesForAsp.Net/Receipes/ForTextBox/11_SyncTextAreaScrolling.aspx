<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="11_SyncTextAreaScrolling.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.TextBox._11_SyncTextAreaScrolling" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeatureHeader" runat="server">
    Sync text area scrolling
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureDescription" runat="server">
    Sync text area scrolling
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            var $txt1 = $("textarea[id$=txt1]");
            var $txt2 = $("textarea[id$=txt2]");

            $txt1.scroll(function () {
                $txt2.scrollTop($txt1.scrollTop());
            });

            $txt2.scroll(function () {
                $txt1.scrollTop($txt2.scrollTop());
            });
        });
    </script>
    <asp:TextBox Width="33%" runat="server" ID="txt1" TextMode="MultiLine" Rows="5" Text="
        Sync text area scrolling Sync text area scrolling Sync text area scrolling Sync text area scrolling
        Sync text area scrolling Sync text area scrolling Sync text area scrolling Sync text area scrolling
        Sync text area scrolling Sync text area scrolling Sync text area scrolling Sync text area scrolling
        Sync text area scrolling Sync text area scrolling Sync text area scrolling Sync text area scrolling
        Sync text area scrolling Sync text area scrolling Sync text area scrolling Sync text area scrolling
        Sync text area scrolling Sync text area scrolling Sync text area scrolling Sync text area scrolling
        Sync text area scrolling Sync text area scrolling Sync text area scrolling Sync text area scrolling
        Sync text area scrolling Sync text area scrolling Sync text area scrolling Sync text area scrolling
        Sync text area scrolling Sync text area scrolling Sync text area scrolling Sync text area scrolling
        Sync text area scrolling Sync text area scrolling Sync text area scrolling Sync text area scrolling
        Sync text area scrolling Sync text area scrolling Sync text area scrolling Sync text area scrolling
        Sync text area scrolling Sync text area scrolling Sync text area scrolling Sync text area scrolling
        ">
    </asp:TextBox>
    <asp:TextBox Width="33%" runat="server" ID="txt2" TextMode="MultiLine" Rows="5" Text="
        Sync text area scrolling Sync text area scrolling Sync text area scrolling Sync text area scrolling
        Sync text area scrolling Sync text area scrolling Sync text area scrolling Sync text area scrolling
        Sync text area scrolling Sync text area scrolling Sync text area scrolling Sync text area scrolling
        Sync text area scrolling Sync text area scrolling Sync text area scrolling Sync text area scrolling
        Sync text area scrolling Sync text area scrolling Sync text area scrolling Sync text area scrolling
        Sync text area scrolling Sync text area scrolling Sync text area scrolling Sync text area scrolling
        Sync text area scrolling Sync text area scrolling Sync text area scrolling Sync text area scrolling
        Sync text area scrolling Sync text area scrolling Sync text area scrolling Sync text area scrolling
        Sync text area scrolling Sync text area scrolling Sync text area scrolling Sync text area scrolling
        Sync text area scrolling Sync text area scrolling Sync text area scrolling Sync text area scrolling
        Sync text area scrolling Sync text area scrolling Sync text area scrolling Sync text area scrolling
        Sync text area scrolling Sync text area scrolling Sync text area scrolling Sync text area scrolling
        ">
    </asp:TextBox>
</asp:Content>
