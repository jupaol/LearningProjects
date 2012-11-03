<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="08_SelectContentOnFocus.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._01_For_TextBox._08_SelectContentOnFocus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(function () {
            $("input[id$=txt]").click(function () {
                $(this).focus().select();
            });
        });
    </script>
    <h1>
        Select textbox content on focus
    </h1>
    <asp:TextBox runat="server" ID="txt" Text="something"></asp:TextBox>
</asp:Content>
