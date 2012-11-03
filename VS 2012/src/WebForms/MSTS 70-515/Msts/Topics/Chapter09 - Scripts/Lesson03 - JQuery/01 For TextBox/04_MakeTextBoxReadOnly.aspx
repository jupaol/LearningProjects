<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="04_MakeTextBoxReadOnly.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._01_For_TextBox._04_MakeTextBoxReadOnly" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(function () {
            $("input:text[value!='']").each(function () {
                $(this).attr("readonly", true);
            });
        });
    </script>
    <h1>
        Make a textbox readonly
    </h1>
    <h2>
        The textbox with data are read only now
    </h2>
    <asp:TextBox runat="server" ID="Text1" Text="Some text" /><br />
    <asp:TextBox runat="server" ID="TextBox1" Text="" /><br />
    <asp:TextBox runat="server" ID="TextBox2" Text="" /><br />
    <asp:TextBox runat="server" ID="TextBox3" Text="Some text" /><br />
</asp:Content>
