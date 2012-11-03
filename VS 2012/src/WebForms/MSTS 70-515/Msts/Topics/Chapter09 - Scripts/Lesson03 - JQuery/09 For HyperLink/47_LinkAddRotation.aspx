<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="47_LinkAddRotation.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._09_For_HyperLink._47_LinkAddRotation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(function () {
            var $links = $("a.dev");
            var count = $links.length;
            var i = count;

            $links.hide().eq(0).show();

            setInterval(function () {
                $links.eq(i % count).fadeOut("slow", function () {
                    $links.eq((++i) % count).fadeIn("slow");
                });
            }, 3000);
        });
    </script>
    <h1>
        Link AD rotation
    </h1>
    <asp:HyperLink NavigateUrl="http://www.microsoft.com" runat="server" ID="HyperLink3" Text="Microsoft" CssClass="dev" />
    <asp:HyperLink NavigateUrl="http://www.stackoverflow.com" runat="server" ID="HyperLink1" Text="Stackoverflow" CssClass="dev" />
    <asp:HyperLink NavigateUrl="http://www.google.com" runat="server" ID="HyperLink2" Text="Google" CssClass="dev" />
</asp:Content>
