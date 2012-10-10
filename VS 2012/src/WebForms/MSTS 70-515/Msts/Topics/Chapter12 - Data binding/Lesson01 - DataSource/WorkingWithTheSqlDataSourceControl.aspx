<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="WorkingWithTheSqlDataSourceControl.aspx.cs" Inherits="Msts.Topics.Chapter12___Data_binding.Lesson01___DataSource.WorkingWithTheSqlDataSourceControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Working with the SqlDataSource control
    </h1>
    <asp:SqlDataSource runat="server" ID="sds"
        ConnectionString="<%$ConnectionStrings: Msts %>"
        DataSourceMode="DataSet"
        SelectCommand="select * from jobs"
        SelectCommandType="Text">
        
    </asp:SqlDataSource>
    <asp:GridView runat="server" ID="gv" 
        DataSourceID="sds"
        >

    </asp:GridView>
</asp:Content>
