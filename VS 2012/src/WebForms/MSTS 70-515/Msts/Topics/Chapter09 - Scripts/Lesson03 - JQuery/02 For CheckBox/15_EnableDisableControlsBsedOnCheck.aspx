<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="15_EnableDisableControlsBsedOnCheck.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._02_For_CheckBox._15_EnableDisableControlsBsedOnCheck" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(function () {
            $("input:checkbox[id$=chk]").click(function () {
                var $button = $("input:submit[id$=btn]");

                if ($(this).is(":checked")) {
                    $button.removeAttr("disabled");
                }
                else {
                    $button.attr("disabled", "disabled");
                }
            });
        });
    </script>
    <h1>
        Enable / disable controls based on checkbox status
    </h1>
    <asp:CheckBox runat="server" ID="chk" Text="I accept" />
    <br />
    <asp:Button runat="server" ID="btn" Text="Proceed" Enabled="false" />
</asp:Content>
