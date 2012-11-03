<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="11_SyncTextAreaScrolling.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._01_For_TextBox._11_SyncTextAreaScrolling" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    <h1>
        Sync text area scrolling
    </h1>
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
