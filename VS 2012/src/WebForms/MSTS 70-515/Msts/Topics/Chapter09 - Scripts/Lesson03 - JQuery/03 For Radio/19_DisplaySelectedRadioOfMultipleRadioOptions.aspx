<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="19_DisplaySelectedRadioOfMultipleRadioOptions.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._03_For_Radio._19_DisplaySelectedRadioOfMultipleRadioOptions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(function () {
            var $radios = $(".options input:radio");

            $radios.click(function () {
                var $checked = $radios.filter(":checked");

                $("#msg").text("");

                $checked.each(function (i, x) {
                    $("#msg")
                        .append("<br /><b>Value: </b>" + $(x).val())
                        .append("<br /><b>Text: </b>" + $(x).next().text());
                });
            });
        });
    </script>
    <h1>
        Display selected radio of multiple radio button lists
    </h1>
    First option
    <asp:RadioButtonList runat="server" ID="radios1" CssClass="options">
        <asp:ListItem Text="Option 1.1" />
        <asp:ListItem Text="Option 1.2" />
        <asp:ListItem Text="Option 1.3" />
        <asp:ListItem Text="Option 1.4" />
    </asp:RadioButtonList>
    Second option
    <asp:RadioButtonList runat="server" ID="radios2" CssClass="options">
        <asp:ListItem Text="Option 2.1" />
        <asp:ListItem Text="Option 2.2" />
        <asp:ListItem Text="Option 2.3" />
    </asp:RadioButtonList>
    <div id="msg" />
</asp:Content>
