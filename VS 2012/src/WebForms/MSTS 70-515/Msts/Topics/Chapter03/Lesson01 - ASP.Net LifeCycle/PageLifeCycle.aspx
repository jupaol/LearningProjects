<%@ Page Trace="true" TraceMode="SortByTime" Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="PageLifeCycle.aspx.cs" Inherits="Msts.Topics.Chapter03.Lesson01.PageLifeCycle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DropDownList runat="server" AutoPostBack="true" CausesValidation="true" ID="ddl" OnSelectedIndexChanged="ddl_SelectedIndexChanged">
        <asp:ListItem Text="text1" />
        <asp:ListItem Text="text2" />
    </asp:DropDownList>
    <br />
    <asp:CheckBox Text="Check option" runat="server" ID="chk" AutoPostBack="true" CausesValidation="true" OnCheckedChanged="chk_CheckedChanged" />
    <br />
    <asp:Button Text="Submit" runat="server" ID="postButton" OnClick="postButton_Click" />
    <asp:LinqDataSource runat="server" ID="lds" AutoPage="true" AutoSort="true"
        TableName="jobs"
        ContextTypeName="Msts.DataAccess.PubsDataContext">

    </asp:LinqDataSource>
    <asp:GridView runat="server" ID="gv" ClientIDMode="Predictable" ClientIDRowSuffix="job_id" DataSourceID="lds"
        AllowPaging="true" AllowSorting="true" PageSize="5" AutoGenerateColumns="true">

    </asp:GridView>
</asp:Content>
