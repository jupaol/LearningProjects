<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="03_OnlyAllowAlphaNumeric.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._01_For_TextBox._03_OnlyAllowAlphaNumeric" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(function () {
            $("input[id$=txt]").bind("keyup blur", function (e) {
                var $val = $(this).val();
                if ($val.match(/[^a-zA-Z0-9 ]/g)) {
                    $(this).val($val.replace(/[^a-zA-Z0-9 ]/g, ''));
                }
            });
        });
    </script>
    <h1>
        Only allow alpha numeric characters
    </h1>
    <h2>
        Only allow alpha numeric charactres, it reacts to key events therefore if you use your mouse
        to paste something won't be detected. 
    </h2>
    <asp:TextBox runat="server" ID="txt"></asp:TextBox>
</asp:Content>
