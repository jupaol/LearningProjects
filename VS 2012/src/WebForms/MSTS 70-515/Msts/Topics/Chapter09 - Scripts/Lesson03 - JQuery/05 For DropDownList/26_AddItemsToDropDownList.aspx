<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="26_AddItemsToDropDownList.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._05_For_DropDownList._26_AddItemsToDropDownList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(function () {
            $("input:submit[id$=add]").click(function (e) {
                e.preventDefault();

                var $ddl = $("select[id$=ddl]");
                var itemsBefore = $("option", $ddl).length;
                var myData = { "6": "Item 6", "7": "Item 7", "8": "Item 8" };

                $.each(myData, function (value, text) {
                    $ddl.append($("<option></option>").val(value).text(text));
                });

                var itemsAfter = $("option", $ddl).length;

                $(this).attr("disabled", "disabled");
                $("#msg").text("").text("Items added: " + (itemsAfter - itemsBefore));
            });
        });
    </script>
    <h1>
        Add items to a dropdownlist
    </h1>
    <asp:DropDownList runat="server" ID="ddl">
        <asp:ListItem Text="Item 1" />
        <asp:ListItem Text="Item 2" />
        <asp:ListItem Text="Item 3" />
    </asp:DropDownList>
    <br />
    <asp:Button Text="Add items" runat="server" ID="add" />
    <br />
    <asp:Button ID="Button1" Text="Just post" runat="server" />
    <div id="msg"></div>
</asp:Content>
