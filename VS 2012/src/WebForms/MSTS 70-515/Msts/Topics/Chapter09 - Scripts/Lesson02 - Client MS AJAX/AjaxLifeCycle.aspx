<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="AjaxLifeCycle.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson02___Client_MS_AJAX.AjaxLifeCycle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        $(function () {
            var $msg = $("#msg");

            Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(function (a, e) {
                $msg.append("<br />begin request");
                var $btn = $("input:submit[id$=btn]");

                $btn.prop('disabled', true);
            });

            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function (a, e) {
                $msg.append("<br />end request");
                var $btn = $("input:submit[id$=btn]");

                $btn.prop('disabled', false);
            });

            Sys.WebForms.PageRequestManager.getInstance().add_initializeRequest(function (a, e) {
                $msg.append("<br />initialize request");
            });

            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function (a, e) {
                $msg.append("<br />page loaded");

                var $btn = $("input:submit[id$=btn]");

                $btn.click(function () {
                    $msg.append("<hr />");
                    return true;
                });
            });

            Sys.WebForms.PageRequestManager.getInstance().add_pageLoading(function (a, e) {
                $msg.append("<br />page loading");
            });
        });
    </script>
    <h1>
        AJAX life cycle
    </h1>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:Button Text="Partial Post" runat="server" ID="btn" OnClick="btn_Click" />
            <div>
                <asp:UpdateProgress runat="server">
                    <ProgressTemplate>
                        Updating...
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div id="msg">

    </div>
</asp:Content>
