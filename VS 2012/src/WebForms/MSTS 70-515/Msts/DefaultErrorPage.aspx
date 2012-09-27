<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="DefaultErrorPage.aspx.cs" Inherits="Msts.Topics.Chapter08___Debugging_and_Deploying.Lesson01___Debugging.DefaultErrorPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        An error occurred with your request. This is the default redirection page when
        an error occurs in the application
    </div>
    <asp:Panel runat="server" ID="errorPanel" Visible="false">
        <div>
            Error message:
        </div>
        <div>
            <asp:Literal ID="errorMessage" runat="server" />
        </div>
        <div>
            Error trace
        </div>
        <div>
            <asp:Literal ID="errorTrace" runat="server" />
        </div>
    </asp:Panel>
</asp:Content>
