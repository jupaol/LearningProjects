<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="05_TabControlsUsingEnterKey.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._01_For_TextBox._05_TabControlsUsingEnterKey" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(function () {
            var $inp = $("#customInputs > input:text");

            $inp.first().focus();

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

                    var $next = $inp.eq(nextID);

                    if (!$next.is("input:text")) {
                        if (e.shiftKey) {
                            $inp.last().focus().select();
                        }
                        else {
                            $inp.first().focus().select();
                        }
                    }
                    else {
                        $next.focus().select();
                    }
                }
            });
        });
    </script>
    <h1>
        Tab through textboxes using the enter key
    </h1>
    <h2>
        The <kbd>shift</kbd> + <kbd>enter</kbd> combination is supported
    </h2>
    <div id="customInputs">
        <asp:TextBox runat="server" ID="TextBox1"></asp:TextBox>
        <asp:TextBox runat="server" ID="TextBox2"></asp:TextBox>
        <asp:TextBox runat="server" ID="TextBox3"></asp:TextBox>
        <asp:TextBox runat="server" ID="TextBox4"></asp:TextBox>
        <asp:TextBox runat="server" ID="TextBox5"></asp:TextBox>
    </div>
</asp:Content>
