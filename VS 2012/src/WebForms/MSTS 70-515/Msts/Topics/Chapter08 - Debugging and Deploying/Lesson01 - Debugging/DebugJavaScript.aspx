<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="DebugJavaScript.aspx.cs" Inherits="Msts.Topics.Chapter08___Debugging_and_Deploying.Lesson01___Debugging.DebugJavaScript" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Make sure to debug this page using Internet Explorer with the debugging script enabled
    </h1>
    <script>
        $(function () {
            var d = new Date();

            alert(dd);
        });
    </script>
</asp:Content>
