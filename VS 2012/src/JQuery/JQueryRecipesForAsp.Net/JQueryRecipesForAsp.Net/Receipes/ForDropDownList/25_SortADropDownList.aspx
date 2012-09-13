<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="25_SortADropDownList.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.ForDropDownList._25_SortADropDownList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        input:disabled {
            background-color : gray;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeatureHeader" runat="server">
    Sort a dropdownlist
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureDescription" runat="server">
    Sort a dropdownlist
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            $("input:submit[id$=order]").click(function (e) {
                var $ddl = $("select[id$=ddl]");

                e.preventDefault();

                var $ordered = $.makeArray($("option", $ddl))
                    .sort(function (o, n) {
                        return $(o).text() < $(n).text() ? -1 : 1;
                    });

                $ddl.empty().html($ordered).val("1");
                $(this).attr("disabled", "disabled");
            });
        });
    </script>
    <asp:DropDownList runat="server" ID="ddl">
        <asp:ListItem Text="Item 3" />
        <asp:ListItem Text="Item 1" />
        <asp:ListItem Text="Item 2" />
    </asp:DropDownList>
    <br />
    <asp:Button Text="Order" runat="server" ID="order" />
</asp:Content>
