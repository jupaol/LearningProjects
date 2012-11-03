<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="46_ChangeUrlFromALink.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._09_For_HyperLink._46_ChangeUrlFromALink" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(function () {
            var $change = $("input:submit[id$=change]");
            var $url = $("input:text[id$=url]");
            var $link = $("a[id$=link]");

            $change.click(function (e) {
                var value = $url.val().trim();

                e.preventDefault();

                if (value) {
                    $link.text(value).attr("href", value);
                }
            });
        });
    </script>
    <h1>
        Change the URL from a HyperLink
    </h1>
    <asp:HyperLink runat="server" ID="link" />
    <br />
    <asp:Label ID="Label1" Text="URL" runat="server" AssociatedControlID="url" /> <asp:TextBox runat="server" ID="url" /><br />
    <asp:Button Text="Change URL" runat="server" ID="change" />
</asp:Content>
