<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="TracingAjax.aspx.cs" Inherits="Msts.Topics.Chapter08___Debugging_and_Deploying.Lesson02___Troubleshooting.TracingAjax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Script Trace testing
    </h1>
    <h3>
        If you are using Chrome, press Ctrl + Shift + J to show the developer tools
        and in the console panel will appear the tracing messages
    </h3>
    <textarea id="TraceConsole" style="width:95%" rows="10"></textarea>
    <script>
        $(function () {
            Sys.Debug.trace("This trace is fired when the DOM is fully loaded");
        });

        Sys.Debug.trace("this is a trace from the page");
    </script>
</asp:Content>
