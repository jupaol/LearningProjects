<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="45_KeyboardShortcutsForHyperlinks.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._09_For_HyperLink._45_KeyboardShortcutsForHyperlinks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(function () {
            var $links = $("#customLinks a");

            $(document).keyup(function (e) {
                var key = e.keyCode ? e.keyCode : e.charCode;

                switch (key) {
                    case 49:
                        navigateUrl($links.eq(0));
                        break;
                    case 50:
                        navigateUrl($links.eq(1));
                        break;
                    case 51:
                        navigateUrl($links.eq(2));
                        break;
                }
            });

            function navigateUrl($link) {
                var url = $($link).attr("href");

                window.top.location.href = url;
                alert("Navigating to: " + url);
            }
        });
    </script>
    <h1>
        Add keyboard shortcuts for hyperlinks
    </h1>
    <div>Press 1,2 or 3 to access the links</div>
    <div id="customLinks">
        <asp:HyperLink NavigateUrl="http://www.microosft.com" runat="server" ID="HyperLink1" Text="1 Microsoft" /><br />
        <asp:HyperLink NavigateUrl="http://www.stackoverflow.com" runat="server" ID="HyperLink2" Text="2 Stackoverflow" /><br />
        <asp:HyperLink NavigateUrl="http://www.google.com" runat="server" ID="HyperLink3" Text="3 Google" />
    </div>
</asp:Content>
