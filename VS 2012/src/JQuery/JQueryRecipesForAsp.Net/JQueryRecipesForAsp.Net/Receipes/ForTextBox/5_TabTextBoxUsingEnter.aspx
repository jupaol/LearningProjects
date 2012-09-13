<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="5_TabTextBoxUsingEnter.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.TextBox.TabTextBoxUsingEnter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeatureHeader" runat="server">
    Tab through textboxes using the enter key
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureDescription" runat="server">
    Tab through textboxes using the enter key
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            $("input:text:first").focus();
            var $inp = $("input:text");
            $inp.bind("keydown", function (e) {
                var key = (e.keyCode ? e.keyCode : e.charCode);
                if (key == 13) {
                    e.preventDefault();
                    var nextID = $inp.index(this);

                    if (e.shiftKey) {
                        nextID--;
                    }
                    else {
                        nextID++;
                    }

                    var $next = $(":input:text:eq(" + nextID + ")");

                    if (!$next.is("input:text")) {
                        if (e.shiftKey) {
                            $("input:text:last").focus().select();
                        }
                        else {
                            $("input:text:first").focus().select();
                        }
                    }
                    else {
                        $next.focus().select();
                    }
                }
            });
        });
    </script>
    <asp:TextBox runat="server" ID="TextBox1"></asp:TextBox>
    <asp:TextBox runat="server" ID="TextBox2"></asp:TextBox>
    <asp:TextBox runat="server" ID="TextBox3"></asp:TextBox>
    <asp:TextBox runat="server" ID="TextBox4"></asp:TextBox>
    <asp:TextBox runat="server" ID="TextBox5"></asp:TextBox>
</asp:Content>
