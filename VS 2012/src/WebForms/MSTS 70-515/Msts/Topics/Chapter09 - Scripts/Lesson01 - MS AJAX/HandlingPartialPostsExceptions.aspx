<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="HandlingPartialPostsExceptions.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson01___MS_AJAX.HandlingPartialPostsExceptions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Handling Partial posts exceptions
    </h1>
    <script>
        $(function () {
            $msg = $("#msg");
            $btn = $("input:submit[id$=partialPost]");

            $msg.hide();

            Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(function (s, a) {
                $btn.prop("disabled", true);
            });

            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function (s, a) {
                var e = a.get_error();
                var error = e.message;
                var $error = $("#errorMsg");

                if (error != undefined) {
                    a.set_errorHandled(true);
                    $error.html(error);
                    $msg.toggle();
                }
            });

            $("#closeError").click(function (e) {
                e.preventDefault();

                $btn.prop("disabled", false);
                $msg.toggle();
            });
        });
    </script>
    <asp:ScriptManagerProxy runat="server" ID="scriptManagerProxy1">

    </asp:ScriptManagerProxy>
    <asp:UpdatePanel runat="server" UpdateMode="Always" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div>
                <asp:Label ID="msg" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel runat="server" ID="updatePanel1" UpdateMode="Always" ChildrenAsTriggers="true">
        <ContentTemplate>
            <asp:Button Text="Partial Post" runat="server" ID="partialPost" OnClick="Unnamed_Click" />
            <div>
                <asp:UpdateProgress runat="server" DisplayAfter="0">
                    <ProgressTemplate>
                        Updating
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div id="msg">
        <div id="errorMsg">

        </div>
        <div>
            <input type="button" id="closeError" value="OK" />
        </div>
    </div>
</asp:Content>
