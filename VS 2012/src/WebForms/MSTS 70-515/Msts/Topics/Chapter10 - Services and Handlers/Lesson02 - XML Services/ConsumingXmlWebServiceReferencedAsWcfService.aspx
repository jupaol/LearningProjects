<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="ConsumingXmlWebServiceReferencedAsWcfService.aspx.cs" Inherits="Msts.Topics.Chapter10___Services_and_Handlers.Lesson02___XML_Services.ConsumingXmlWebServiceReferencedAsWcfService" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        $(function () {
            var $tabs = $("#tabs");

            $tabs.tabs();
        });
    </script>
    <h1>
        Calling an XML Web Service referenced as a WCF Service asynchronously
    </h1>
    <div id="tabs">
        <ul>
            <li>
                <a href="#tabs-1">Prepare Request</a>
            </li>
            <li>
                <a href="#tabs-2">Send Request</a>
            </li>
            <li>
                <a href="#tabs-3">Results</a>
            </li>
        </ul>
        <div id="tabs-1">
            <div>
                <asp:Label Text="Enter your name" runat="server" AssociatedControlID="name" />
            </div>
            <div>
                <asp:TextBox runat="server" ID="name" />
            </div>
        </div>
        <div id="tabs-2">
            <div>
                <asp:Button Text="Send request asynchronously" runat="server" OnClick="Unnamed_Click" />
            </div>
        </div>
        <div id="tabs-3">
            <div>
                <asp:Label Text="text" runat="server" ID="msg" />
            </div>
        </div>
    </div>
</asp:Content>
