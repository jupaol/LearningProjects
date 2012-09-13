<%@ Page MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="1_SelectingTextboxs.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.TextBox.SelectingTextboxs" %>


<asp:Content runat="server" ContentPlaceHolderID="HeadContent">
    <style>
        .selected {
            font-style:italic;
            background-color:aqua;
        }
        #res {
            background-color:azure;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeatureHeader" runat="server">
    Selecting dom objects
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureDescription" runat="server">
    Selecting dom objects
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <script type="text/javascript">
        $(function () {
            $("input[id$=selectAll]").click(function (e) {
                e.preventDefault();
                $("#res").text("");
                $("#res").append($("input:text").map(function () {
                    return $(this).val() || null;
                }).get().join("<br />"));
            });

            $("input[id$=selectFiltering]").click(function (e) {
                e.preventDefault();
                $("#res").text("");
                $("#res").append($("input.selected").map(function () {
                    return $(this).val() || null;
                }).get().join("<br />"));
            });
        });
    </script>
    <asp:TextBox runat="server" ID="TextBox1" Text="Text1"></asp:TextBox><br />
    <asp:TextBox runat="server" ID="TextBox2" Text="Text2"></asp:TextBox><br />
    <asp:TextBox runat="server" ID="TextBox3" Text="Text3"></asp:TextBox><br />
    <asp:TextBox runat="server" ID="TextBox4" Text="Text4" CssClass="selected"></asp:TextBox><br />
    <asp:TextBox runat="server" ID="TextBox5" Text="Text5"></asp:TextBox><br />
    <asp:TextBox runat="server" ID="TextBox6" Text="Text6" CssClass="selected"></asp:TextBox><br />
    <asp:TextBox runat="server" ID="TextBox7" Text="Text7"></asp:TextBox><br />
    <asp:Button runat="server" ID="selectAll" Text="Select all textboxes" />
    <asp:Button runat="server" ID="selectFiltering" Text="Select filtering textboxes" />
    <div id="res"></div>
</asp:Content>

