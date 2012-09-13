<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="26_AddItemsToADropDownList.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.ForDropDownList._26_AddItemsToADropDownList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        input:disabled {
            background-color:gray;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeatureHeader" runat="server">
    Add items to a dropdownlist
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureDescription" runat="server">
    Add items to a dropdownlist
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
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
    <asp:DropDownList runat="server" ID="ddl">
        <asp:ListItem Text="Item 1" />
        <asp:ListItem Text="Item 2" />
        <asp:ListItem Text="Item 3" />
    </asp:DropDownList>
    <br />
    <asp:Button Text="Add items" runat="server" ID="add" />
    <br />
    <asp:Button Text="Just post" runat="server" />
    <div id="msg"></div>
</asp:Content>
