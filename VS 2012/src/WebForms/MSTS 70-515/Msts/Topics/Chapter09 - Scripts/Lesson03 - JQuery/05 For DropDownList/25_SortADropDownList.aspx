<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="25_SortADropDownList.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._05_For_DropDownList._25_SortADropDownList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    <h1>
        Sort a dropdownlist
    </h1>
    <asp:DropDownList runat="server" ID="ddl">
        <asp:ListItem Text="Item 3" />
        <asp:ListItem Text="Item 1" />
        <asp:ListItem Text="Item 2" />
    </asp:DropDownList>
    <br />
    <asp:Button Text="Order" runat="server" ID="order" />
</asp:Content>
