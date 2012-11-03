<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="13_MakeItRequiredWhenSubmitting.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._02_For_CheckBox._13_MakeItRequiredWhenSubmitting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    <h1>
        Make a checkbox field required
    </h1>
    <h2>
        Make a checkbox field required when submitting data
    </h2>
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
