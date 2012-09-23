<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="EmployeeDetails.aspx.cs" Inherits="MixedSiteMapProvider.EmployeeDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:LinqDataSource runat="server" ID="lds"
        TableName="employee" ContextTypeName="MixedSiteMapProvider.PubsDataContext">
    </asp:LinqDataSource>
    <asp:QueryExtender runat="server" ID="qeEmployee" TargetControlID="lds">
        <asp:PropertyExpression>
            <asp:QueryStringParameter Name="emp_id" Type="String" ValidateInput="true" QueryStringField="id" />
        </asp:PropertyExpression>
    </asp:QueryExtender>
    <asp:DetailsView runat="server" DataSourceID="lds" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>

        <CommandRowStyle BackColor="#FFFFC0" Font-Bold="True"></CommandRowStyle>

        <FieldHeaderStyle BackColor="#FFFF99" Font-Bold="True"></FieldHeaderStyle>

        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White"></FooterStyle>

        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White"></HeaderStyle>

        <PagerStyle HorizontalAlign="Center" BackColor="#FFCC66" ForeColor="#333333"></PagerStyle>

        <RowStyle BackColor="#FFFBD6" ForeColor="#333333"></RowStyle>
    </asp:DetailsView>
</asp:Content>
