<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="24_RetrieveSelectedDropDownList.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._05_For_DropDownList._24_RetrieveSelectedDropDownList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(function () {
            $("select[id$=ddl]").change(function () {
                var $selected = $("select[id$=ddl] :selected");

                $("#msg").html("")
                    .append("<b>Value: </b>" + $selected.val())
                    .append("<b>Text: </b>" + $selected.text());
            });
        });
    </script>
    <h1>
        Retrieve the text and value from the selected dropdownlist item
    </h1>
    <asp:DropDownList runat="server" ID="ddl" CssClass="options">
        <asp:ListItem Text="Option 1" />
        <asp:ListItem Text="Option 2" />
        <asp:ListItem Text="Option 3" />
        <asp:ListItem Text="Option 4" />
    </asp:DropDownList>
    <div id="msg" />
</asp:Content>
