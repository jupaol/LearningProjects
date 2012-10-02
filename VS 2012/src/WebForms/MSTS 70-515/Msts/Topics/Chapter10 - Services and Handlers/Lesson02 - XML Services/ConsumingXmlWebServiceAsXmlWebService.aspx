<%@ Page Title="" Async="true" Trace="true" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="ConsumingXmlWebServiceAsXmlWebService.aspx.cs" Inherits="Msts.Topics.Chapter10___Services_and_Handlers.Lesson02___XML_Services.ConsumingXmlWebServiceAsXmlWebService" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        $(function () {
            var $accordion = $("#accordion");

            $accordion.accordion();
        });
    </script>
    <h1>
        Consuming an XML Web Service referenced as a "Web Service Reference" (for XML Web Services)
        Service executed Asynchronously
    </h1>
    <div id="accordion">
        <h3>
            <a href="#">Prepare the request</a>
        </h3>
        <div>
            <p>
                <div>
                    <asp:Label ID="Label1" Text="Enter your name" runat="server" AssociatedControlID="name" />
                </div>
                <div>
                    <asp:TextBox runat="server" ID="name" />
                </div>
            </p>
        </div>
        <h3>
            <a href="#">Send the request</a>
        </h3>
        <div>
            <div>
                <asp:Button ID="Button1" Text="Invoke web service..." runat="server" OnClick="Unnamed_Click" />
            </div>
        </div>
        <h3>
            <a href="#">See the results</a>
        </h3>
        <div>
            <div>
                <asp:Label Text="text" runat="server" ID="msg" />
            </div>
        </div>
    </div>
</asp:Content>
