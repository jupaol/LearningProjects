<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="TemplatedAddress.aspx.cs" Inherits="Msts.Topics.Chapter07___Server_Controls.Lesson01___User_Controls.TemplatedAddress1" %>

<%@ Register Src="~/Topics/Chapter07 - Server Controls/Lesson01 - User Controls/TemplatedAddress.ascx" TagPrefix="uc1" TagName="TemplatedAddress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Testing Templated User Controls
    </h1>
    <uc1:TemplatedAddress runat="server" ID="templatedAddress1" Address="some street from markup. this should be displayd as part of the template">
        <AddressTemplate>
            <div>
                Street content
            </div>
            <asp:Label ID="Label1" Text="<%# Container.Street %>" runat="server" />
        </AddressTemplate>
    </uc1:TemplatedAddress>
</asp:Content>
