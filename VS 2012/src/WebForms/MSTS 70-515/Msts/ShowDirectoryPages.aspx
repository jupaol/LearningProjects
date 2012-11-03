<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="ShowDirectoryPages.aspx.cs" Inherits="Msts.ShowDirectoryPages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        <asp:Literal ID="directory" runat="server" />
    </h1>
    <h2>
        Available pages
    </h2>
    <asp:GridView runat="server" ID="gv"
        AutoGenerateColumns="false" Caption="Pages" EmptyDataText="No pages =(" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal">
        <Columns>
            <asp:TemplateField HeaderText="Page">
                <ItemTemplate>
                    <asp:HyperLink NavigateUrl='<%#: Eval("Url") %>' runat="server" Text='<%#: Eval("Display") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#333333"></FooterStyle>

        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White"></HeaderStyle>

        <PagerStyle HorizontalAlign="Center" BackColor="#336666" ForeColor="White"></PagerStyle>

        <RowStyle BackColor="White" ForeColor="#333333"></RowStyle>

        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

        <SortedAscendingCellStyle BackColor="#F7F7F7"></SortedAscendingCellStyle>

        <SortedAscendingHeaderStyle BackColor="#487575"></SortedAscendingHeaderStyle>

        <SortedDescendingCellStyle BackColor="#E5E5E5"></SortedDescendingCellStyle>

        <SortedDescendingHeaderStyle BackColor="#275353"></SortedDescendingHeaderStyle>
    </asp:GridView>
    <hr />
    <h2>
        Available directories
    </h2>
    <asp:GridView runat="server" ID="gvDirectories"
        AutoGenerateColumns="false" Caption="Directories" EmptyDataText="None at the moment buaaa" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
        <Columns>
            <asp:TemplateField HeaderText="Directory">
                <ItemTemplate>
                    <asp:HyperLink NavigateUrl='<%#: Eval("Url") %>' runat="server" Text='<%#: Eval("Display") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#CCCCCC"></FooterStyle>

        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White"></HeaderStyle>

        <PagerStyle HorizontalAlign="Left" BackColor="#CCCCCC" ForeColor="Black"></PagerStyle>

        <RowStyle BackColor="White"></RowStyle>

        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

        <SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>

        <SortedAscendingHeaderStyle BackColor="#808080"></SortedAscendingHeaderStyle>

        <SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>

        <SortedDescendingHeaderStyle BackColor="#383838"></SortedDescendingHeaderStyle>
    </asp:GridView>
</asp:Content>
