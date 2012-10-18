<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="TemplatedServerAddress.aspx.cs" Inherits="Msts.Topics.Chapter07___Server_Controls.Lesson02___Server_Controls.TemplatedServerAddress" %>
<%@ Register Assembly="Msts" Namespace="Msts.Topics.Chapter07___Server_Controls.Lesson02___Server_Controls" TagPrefix="address" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <address:TemplatedServerAddressControl runat="server" ID="addressControl1">
        <AddressTemplate>
            <b>
                Address:
            </b>
            <u>
                <asp:Literal Text="<%# Container.Address %>" runat="server" />
            </u>
            <asp:Button Text="text" runat="server" OnClick="Unnamed_Click" ID="myButton" />
            <br />
            <asp:Button Text="Command bubbled" runat="server" CommandName="DoSomething" OnClick="Unnamed2_Click1" />
        </AddressTemplate>
    </address:TemplatedServerAddressControl>
</asp:Content>
