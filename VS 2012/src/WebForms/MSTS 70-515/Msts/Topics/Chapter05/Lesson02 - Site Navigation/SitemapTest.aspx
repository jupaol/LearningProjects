<%@ Page Trace="true" TraceMode="SortByTime" Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="SitemapTest.aspx.cs" Inherits="Msts.Topics.Chapter05.Lesson02.SitemapTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        SiteMap test
    </h1>
    <asp:SiteMapDataSource runat="server" ID="smds" 
        ShowStartingNode="false" />
    <div>
        <h1>
            TreeView
        </h1>
    </div>
    <div>
        <asp:TreeView runat="server" ID="tv" DataSourceID="smds" ImageSet="Contacts" NodeIndent="10">
            <HoverNodeStyle Font-Underline="False"></HoverNodeStyle>

            <NodeStyle HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black"></NodeStyle>

            <ParentNodeStyle Font-Bold="True" ForeColor="#5555DD"></ParentNodeStyle>

            <SelectedNodeStyle HorizontalPadding="0px" VerticalPadding="0px" Font-Underline="True"></SelectedNodeStyle>
        </asp:TreeView>
    </div>
    <div>
        <h2>
            Menu
        </h2>
    </div>
    <div>
        <asp:Menu runat="server" ID="memu" Orientation="Horizontal" DataSourceID="smds" BackColor="#FFFBD6" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" StaticSubMenuIndent="10px">

            <DynamicHoverStyle BackColor="#990000" ForeColor="White"></DynamicHoverStyle>

            <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px"></DynamicMenuItemStyle>

            <DynamicMenuStyle BackColor="#FFFBD6"></DynamicMenuStyle>

            <DynamicSelectedStyle BackColor="#FFCC66"></DynamicSelectedStyle>

            <StaticHoverStyle BackColor="#990000" ForeColor="White"></StaticHoverStyle>

            <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px"></StaticMenuItemStyle>

            <StaticSelectedStyle BackColor="#FFCC66"></StaticSelectedStyle>
        </asp:Menu>
    </div>
    <div>
        <h1>
            Breadcrumb
        </h1>
    </div>
    <div>
        <asp:SiteMapPath runat="server" ID="siteMap" Font-Names="Verdana" Font-Size="0.8em" PathSeparator=" : ">

            <CurrentNodeStyle ForeColor="#333333"></CurrentNodeStyle>

            <NodeStyle Font-Bold="True" ForeColor="#990000"></NodeStyle>

            <PathSeparatorStyle Font-Bold="True" ForeColor="#990000"></PathSeparatorStyle>

            <RootNodeStyle Font-Bold="True" ForeColor="#FF8000"></RootNodeStyle>
        </asp:SiteMapPath>
    </div>
</asp:Content>
