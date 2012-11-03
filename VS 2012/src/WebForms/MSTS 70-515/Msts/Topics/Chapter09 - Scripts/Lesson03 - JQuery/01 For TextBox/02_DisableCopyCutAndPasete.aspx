<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="02_DisableCopyCutAndPasete.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._01_For_TextBox.DisableCopyCutAndPasete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(function () {
            $("input[id$=txt]").bind("copy cut paste", function (e) {
                e.preventDefault();
            });
        });
    </script>
    <h1>
        Disabling copy, cut and paste in the text boxes
    </h1>
    <asp:TextBox runat="server" ID="txt" />
</asp:Content>
