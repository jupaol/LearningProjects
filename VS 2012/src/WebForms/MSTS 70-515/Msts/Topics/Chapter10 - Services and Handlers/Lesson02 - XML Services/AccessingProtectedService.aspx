<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="AccessingProtectedService.aspx.cs" Inherits="Msts.Topics.Chapter10___Services_and_Handlers.Lesson02___XML_Services.AccessingProtectedService" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Accessing protected Web Service
    </h1>
    <h3>
        You need to be authenticated to access the service
    </h3>
    <asp:Button Text="Invoke service" runat="server" OnClick="Unnamed_Click" />
    <div>
        <asp:Label Text="text" runat="server" ID="res" />
    </div>
</asp:Content>
