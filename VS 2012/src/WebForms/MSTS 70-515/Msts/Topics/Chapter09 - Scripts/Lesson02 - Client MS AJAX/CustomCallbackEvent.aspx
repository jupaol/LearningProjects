<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="CustomCallbackEvent.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson02___Client_MS_AJAX.CustomCallbackEvent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Custom callback events
    </h1>
    <script>
        function clientCallback(argsmm) {
            alert(argsmm);
        }
    </script>
    <asp:DropDownList runat="server" onchange="callServer(this.value);">
        <asp:ListItem Text="text1" />
        <asp:ListItem Text="text2" />
    </asp:DropDownList>
</asp:Content>
