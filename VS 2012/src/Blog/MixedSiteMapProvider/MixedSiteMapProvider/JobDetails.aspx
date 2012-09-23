<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="JobDetails.aspx.cs" Inherits="MixedSiteMapProvider.JobDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:LinqDataSource runat="server" ID="lds"
        TableName="jobs"
        ContextTypeName="MixedSiteMapProvider.PubsDataContext">
    </asp:LinqDataSource>
    <asp:QueryExtender runat="server" ID="qeJob" TargetControlID="lds">
        <asp:PropertyExpression>
            <asp:QueryStringParameter Name="job_id" Type="Int16" ValidateInput="true" QueryStringField="id" />
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
    <hr />
    <asp:LinqDataSource runat="server" ID="ldsempl"
        TableName="employee"
        ContextTypeName="MixedSiteMapProvider.PubsDataContext">
    </asp:LinqDataSource>
    <asp:QueryExtender runat="server" ID="qeEmpl" TargetControlID="ldsempl">
        <asp:PropertyExpression>
            <asp:QueryStringParameter QueryStringField="id" Type="Int16" ValidateInput="true" Name="job_id" />
        </asp:PropertyExpression>
    </asp:QueryExtender>
    <asp:GridView runat="server" ID="gv" DataSourceID="ldsempl" AutoGenerateColumns="false" ItemType="MixedSiteMapProvider.employee" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
        <Columns>
            <asp:TemplateField HeaderText="Employee name">
                <ItemTemplate>
                    <asp:HyperLink NavigateUrl='<%# "~/EmployeeDetails.aspx?id=" + Item.emp_id %>' runat="server" Text='<%# Item.fname + " " + Item.lname %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White"></FooterStyle>

        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White"></HeaderStyle>

        <PagerStyle HorizontalAlign="Center" BackColor="#FFCC66" ForeColor="#333333"></PagerStyle>

        <RowStyle BackColor="#FFFBD6" ForeColor="#333333"></RowStyle>

        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy"></SelectedRowStyle>

        <SortedAscendingCellStyle BackColor="#FDF5AC"></SortedAscendingCellStyle>

        <SortedAscendingHeaderStyle BackColor="#4D0000"></SortedAscendingHeaderStyle>

        <SortedDescendingCellStyle BackColor="#FCF6C0"></SortedDescendingCellStyle>

        <SortedDescendingHeaderStyle BackColor="#820000"></SortedDescendingHeaderStyle>
    </asp:GridView>
</asp:Content>
