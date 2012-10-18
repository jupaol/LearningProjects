<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="Msts.CreateAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:CreateUserWizard runat="server" ID="createUser" ContinueDestinationPageUrl="~/">

        </asp:CreateUserWizard>
    </div>
</asp:Content>
