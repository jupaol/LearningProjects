<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="WorkingWithTheXmlDataSourceControl.aspx.cs" Inherits="Msts.Topics.Chapter12___Data_binding.Lesson01___DataSource.WorkingWithTheXmlDataSourceControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        XmlDataSource control
    </h1>
    <asp:UpdatePanel runat="server" ID="mainUpdatePanel">
        <ContentTemplate>
            <asp:UpdateProgress runat="server" ID="mainProgressPanel" DisplayAfter="0">
                <ProgressTemplate>
                    Processing...
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:XmlDataSource runat="server" ID="xds"
                DataFile="~/Topics/Chapter09 - Scripts/Lesson03 - JQuery/MyXmlFile.xml"
                >

            </asp:XmlDataSource>
            <asp:TreeView runat="server" ID="tv"
                DataSourceID="xds" 
                ShowCheckBoxes="All"
                OnTreeNodeCheckChanged="tv_TreeNodeCheckChanged"
                OnSelectedNodeChanged="tv_SelectedNodeChanged">
            </asp:TreeView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
