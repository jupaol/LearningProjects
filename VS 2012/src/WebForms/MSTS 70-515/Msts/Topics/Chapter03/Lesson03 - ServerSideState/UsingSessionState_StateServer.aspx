<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="UsingSessionState_StateServer.aspx.cs" Inherits="Msts.Topics.Chapter03.Lesson03___ServerSideState.UsingSessionState_StateServer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Session state
    </h1>
    <h2>
        Be sure that the session state in the web.config file is configured to StateServer or SqlServer
    </h2>
    <asp:Label runat="server" ID="msg"></asp:Label>
    <div>
        <asp:Button Text="Update session state" runat="server" ID="updateSessionState" OnClick="updateSessionState_Click" />
    </div>
</asp:Content>
