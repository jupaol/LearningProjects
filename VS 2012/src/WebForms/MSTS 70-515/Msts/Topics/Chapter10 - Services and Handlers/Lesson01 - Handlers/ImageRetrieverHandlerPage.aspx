<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="ImageRetrieverHandlerPage.aspx.cs" Inherits="Msts.Topics.Chapter10___Services_and_Handlers.Lesson01___Handlers.ImageRetrieverHandlerPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        HttpHandler
    </h1>
    <h3>
        Calling the `ImageRetrieverHandler.ashx` to retrieve an image and send it as part 
        of the request. This handler uses the `@WebHandler` directive
    </h3>
    <asp:Image ImageUrl="~/Topics/Chapter10 - Services and Handlers/Lesson01 - Handlers/ImageRetrieverHandler.ashx" runat="server" AlternateText="Image using a handler (ASHX)" />
</asp:Content>
