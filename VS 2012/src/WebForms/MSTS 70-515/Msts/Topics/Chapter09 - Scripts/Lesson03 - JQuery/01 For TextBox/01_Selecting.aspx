<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="01_Selecting.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._01_For_TextBox._01_Selecting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .selected {
            font-style:italic;
            background-color:aqua;
        }
        #res {
            background-color:azure;
        }
    </style>
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
    <h1>
        Selecting dom objects
    </h1>
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
