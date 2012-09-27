<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="CancelingAsyncPost.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson01___MS_AJAX.CancelingAsyncPost" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Canceling Async post
    </h1>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:Button Text="Fire Partial Post" runat="server" OnClick="Unnamed_Click" />
            <div>
                <%: DateTime.Now.ToString() %>
            </div>
            <asp:UpdateProgress runat="server">
                <ProgressTemplate>
                    Updating...
                    <div>
                        <asp:Button Text="Cancel" runat="server" CommandName="Cancel" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
