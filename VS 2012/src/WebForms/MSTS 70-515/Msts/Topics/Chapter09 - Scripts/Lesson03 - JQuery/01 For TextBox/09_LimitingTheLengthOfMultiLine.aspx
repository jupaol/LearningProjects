<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="09_LimitingTheLengthOfMultiLine.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._01_For_TextBox._09_LimitingTheLengthOfMultiLine" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .excess {
            background-color:red;
        }
    </style>
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
    <h1>
        Limiting the length of the multiline textbox
    </h1>
    <h2>
        Limiting the length of the multiline textbox showing characteres count
    </h2>
    <asp:TextBox runat="server" ID="txt" TextMode="MultiLine"></asp:TextBox><br />
    <div id="msg" />
</asp:Content>
