<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsumingMyRestServiceByCode.aspx.cs" Inherits="MyServiceConsumer.ConsumingMyRestServiceByCode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-1.8.2.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <script>
            $(function () {
                var $but = $("input:submit[id$=callService]");
                var $res = $("#res");

                $but.click(function (e) {
                    e.preventDefault();

                    $.ajax({
                        url: "http://localhost:52356/MyService.svc",
                        type: "GET",
                        dataType: "jsonp",
                        data: "{}",
                        jsonp: "jsonp",
                        success: function (m) {
                            $res.text("Message: " + m.Message);
                        },
                        error: function (err) {
                            alert(err.responseText);
                        }
                    });
                });
            });
        </script>
    <div>
    <h1>
        Consuming my WCF REST service in the code behind
    </h1>
        <div>
            <asp:Button Text="Call REST service" runat="server" OnClick="Unnamed_Click" />
        </div>
        <div>
            <asp:Label Text="text" runat="server" ID="msg" />
        </div>
    </div>
        <div>
            <h1>
                Consuming my WCF REST service via JQuery
            </h1>
            <div>
                <asp:Button Text="Call REST service via JQuery" runat="server" ID="callService" />
            </div>
            <div>
                <div id="res"></div>
            </div>
        </div>
    </form>
</body>
</html>
