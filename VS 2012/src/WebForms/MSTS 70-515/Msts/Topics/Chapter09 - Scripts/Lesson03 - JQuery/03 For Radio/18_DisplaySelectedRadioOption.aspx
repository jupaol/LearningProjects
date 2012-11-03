<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="18_DisplaySelectedRadioOption.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._03_For_Radio._18_DisplaySelectedRadioOption" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(function () {
            $radios = $(".options input:radio");
            $radios.click(function () {
                $checked = $radios.filter(":checked");

                $("#msg").text("")
                    .append("<b>Index: </b>" + $checked.val())
                    .append("<br /><b>Text: </b>" + $checked.next().text());
            });
        });
    </script>
    <h1>
        Display selected radio option
    </h1>
    <asp:RadioButtonList runat="server" ID="radios" CssClass="options">
        <asp:ListItem Text="Option 1" />
        <asp:ListItem Text="Option 2" />
        <asp:ListItem Text="Option 3" />
        <asp:ListItem Text="Option 4" />
        <asp:ListItem Text="Option 5" />
        <asp:ListItem Text="Option 6" />
    </asp:RadioButtonList>
    <br />
    <div id="msg" />
</asp:Content>
