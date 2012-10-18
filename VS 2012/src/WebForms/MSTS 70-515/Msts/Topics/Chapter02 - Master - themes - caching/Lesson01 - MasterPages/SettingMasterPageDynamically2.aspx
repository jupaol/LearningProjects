<%@ Page Trace="false" TraceMode="SortByTime" Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="SettingMasterPageDynamically2.aspx.cs" Inherits="Msts.Topics.Chapter02.Lesson01___MasterPages.SettingMasterPageDynamically2" %>
<%@ MasterType TypeName="Msts.Topics.Chapter02.Lesson01___MasterPages.BaseMasterPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        EnableViewState is : <%: this.EnableViewState %>
    </p>
    <p>
        IsViewStateEnabled is: <%: this.IsViewStateEnabled %>
    </p>
    <p>
        The current master page title is: <b><%: this.Master.CurrentTitle %></b>
    </p>
</asp:Content>
