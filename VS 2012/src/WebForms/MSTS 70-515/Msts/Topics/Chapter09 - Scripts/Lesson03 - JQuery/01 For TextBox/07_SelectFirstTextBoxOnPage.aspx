<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="07_SelectFirstTextBoxOnPage.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._01_For_TextBox._07_SelectFirstTextBoxOnPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(function () {
            $("input:disabled").css("background-color", "gray");
            $("input:text[value!=]:enabled:first").focus().select();
        });
    </script>
    <h1>
        Select first textbox on the page
    </h1>
    <h2>
        Select first textbox on the page when it's not disabled and contains text
    </h2>
    <asp:TextBox runat="server" ID="TextBox1" Enabled="true" Text=""></asp:TextBox><br />
    <asp:TextBox runat="server" ID="TextBox2" Enabled="false" Text="Some text"></asp:TextBox><br />
    <asp:TextBox runat="server" ID="TextBox3" Enabled="true" Text="plop"></asp:TextBox><br />
    <asp:TextBox runat="server" ID="TextBox4" Enabled="true" Text="Some text"></asp:TextBox><br />
    <asp:TextBox runat="server" ID="TextBox5" Enabled="false" Text="Some text"></asp:TextBox><br />
</asp:Content>
