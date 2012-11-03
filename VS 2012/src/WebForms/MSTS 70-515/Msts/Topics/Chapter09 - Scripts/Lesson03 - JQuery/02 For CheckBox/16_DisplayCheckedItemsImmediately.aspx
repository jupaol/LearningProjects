<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="16_DisplayCheckedItemsImmediately.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._02_For_CheckBox._16_DisplayCheckedItemsImmediately" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function usingArray() {
            var useArray = $(".radios input:radio:checked").val() == "0";

            return useArray;
        }
        $(function () {
            var $checks = $(".options input:checkbox");
            $checks.click(function () {
                var $msg = $("div[id$=msg]");
                var $checked = $checks.filter(function (i) {
                    return $(this).is(":checked");
                });

                $msg.text("");

                if (usingArray()) {
                    var res = new Array();

                    $checked.each(function () {
                        res.push($(this).val());
                        $msg.text(res.join(" | "));
                    });
                }
                else {
                    var res = $checked.map(function () {
                        return $(this).val();
                    }).get();

                    $msg.text(res.join(" | "));
                }
            });
        });
    </script>
    <h1>
        Display checked controls immediatly
    </h1>
    <asp:RadioButtonList runat="server" ID="radios" CssClass="radios">
        <asp:ListItem Text="Using array push" Value="0" Selected="True" />
        <asp:ListItem Text="Using map function" Value="1" />
    </asp:RadioButtonList>
    <br />
    <asp:CheckBoxList runat="server" ID="chks" CssClass="options">
        <asp:ListItem Text="Option 1" />
        <asp:ListItem Text="Option 2" />
        <asp:ListItem Text="Option 3" />
        <asp:ListItem Text="Option 4" />
        <asp:ListItem Text="Option 5" />
    </asp:CheckBoxList>
    <br />
    <div id="msg" />
</asp:Content>
