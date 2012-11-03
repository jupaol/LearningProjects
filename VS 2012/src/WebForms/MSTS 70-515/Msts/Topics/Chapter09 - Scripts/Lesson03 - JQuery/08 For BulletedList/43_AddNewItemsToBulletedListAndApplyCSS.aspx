<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="43_AddNewItemsToBulletedListAndApplyCSS.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._08_For_BulletedList._43_AddNewItemsToBulletedListAndApplyCSS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(function () {
            var $ul = $("ul[id$=bl]");
            var $lis = $("li", $ul);
            var $txt = $("input:text[id$=txt]");
            var $add = $("input:submit[id$=add]");

            $add.click(function (e) {
                var value = $txt.val().trim();

                e.preventDefault();

                if (value) {
                    $("<li />").text(value).appendTo($ul);
                }
            });
        });
    </script>
    <h1>
        Add new items to the BulletedList and apply CSS
    </h1>
    <asp:BulletedList runat="server" ID="bl" DisplayMode="Text" BulletStyle="Circle">
        <asp:ListItem Text="Item1" />
        <asp:ListItem Text="Item2" />
        <asp:ListItem Text="Item3" />
    </asp:BulletedList>
    <asp:TextBox runat="server" ID="txt" />
    <br />
    <asp:Button Text="Add item" runat="server" ID="add" />
</asp:Content>
