<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="06_CloneText.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._01_For_TextBox._06_CloneText" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(function () {
            $("input[id$=source]").keyup(function (e) {
                $("input[id$=target]").val($(this).val());
            });
        });
    </script>
    <h1>
        Clone text
    </h1>
    <h2>
        Clone text while typing
    </h2>
    <asp:TextBox runat="server" ID="source" />
    <asp:TextBox runat="server" ID="target" />
</asp:Content>
