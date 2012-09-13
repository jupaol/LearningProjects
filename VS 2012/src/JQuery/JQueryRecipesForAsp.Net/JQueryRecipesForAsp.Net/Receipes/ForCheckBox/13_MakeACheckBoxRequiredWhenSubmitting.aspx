<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="13_MakeACheckBoxRequiredWhenSubmitting.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.ForCheckBox._01_MakeACheckBoxRequiredWhenSubmitting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeatureHeader" runat="server">
    Make a checkbox field required
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureDescription" runat="server">
    Make a checkbox field required when submitting data
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            $("input[id$=btn]").click(function (e) {
                var $chks = $("#options input:checkbox:checked");
                
                if ($chks.length <= 0) {
                    e.preventDefault();
                    $("#msg").text("You must select at least one option");
                }
                else {
                    $("#msg").text("");
                    alert("validation ok");
                }
            });
        });
    </script>
    <b>Please check at least one option before submitting</b>
    <div id="options">
        <asp:CheckBox runat="server" ID="chk1" Text="Option 1" />
        <asp:CheckBox runat="server" ID="chk2" Text="Option 2" />
        <asp:CheckBox runat="server" ID="chk3" Text="Option 3" />
    </div>
    <br /><asp:Button Text="Submit" runat="server" ID="btn" />
    <br />
    <div id="msg"></div>
</asp:Content>
