<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="LocalResourcesTest.aspx.cs" Inherits="Msts.Topics.Chapter06___Globalization_and_Accessibility.Lesson01___Globalization_and_Localization.LocalResourcesTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        <asp:Literal Text="<%$ Resources:MyResources, SiteTitle_Message %>" runat="server" />
    </h1>
    <h1>
        Local resources test
    </h1>
    <h2>
        <asp:Localize runat="server" Text="<%$ Resources:, loc.Text %>">

        </asp:Localize>
    </h2>
    <h2>
        <asp:Literal Text="<%$ Resources:MyResources, Greetings_Message %>" runat="server" />
    </h2>
    <div>
        <asp:Label Text="text" runat="server" ID="lbl" meta:resourcekey="lbl" />
    </div>
    <div>
        Resource from satellite assembly
    </div>
    <div>
        <asp:Literal ID="satelliteAssemblyMessage" runat="server" />
    </div>
    <div>
        <asp:Literal ID="satelliteAssemblyResourceManagerMessage" runat="server" />
    </div>
    <div>
        Resource from satellite assembly declaratively
    </div>
    <div>
        <asp:Literal Text="<%# Msts.Domain.GlobalResources.GoodBye_Message %>" runat="server" />
    </div>
</asp:Content>
