<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="9_LimitingTheLengthOnMultilineTextBox.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.TextBox.LimitingTheLengthOnMultilineTextBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        .excess {
            background-color:red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeatureHeader" runat="server">
    Limiting the length of the multiline textbox
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureDescription" runat="server">
    Limiting the length of the multiline textbox showing characteres count
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            var limit = 10;
            $("#msg").text("Characters left: " + limit);
            $("textarea[id$=txt]").keyup(function (e) {
                e.preventDefault();
                var value = $(this).val();

                if (value.length > limit) {
                    $(this).addClass("excess");
                    // $(this).val(value.substring(0, limit));
                    $("#msg").text("Characters exceded: " + (value.length - limit));
                }
                else {
                    $(this).removeClass("excess");
                    $("#msg").text("Characters left: " + (limit - value.length));
                }
            });
        });
    </script>
    <asp:TextBox runat="server" ID="txt" TextMode="MultiLine"></asp:TextBox><br />
    <div id="msg" />
</asp:Content>
