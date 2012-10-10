<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CQRS_SimpleQuery01.Models.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView runat="server" ID="gv" AllowPaging="true" AllowSorting="true"
            DataKeyNames="ID"
            AutoGenerateColumns="true"
            SelectMethod="gv_GetData"
            ItemType="QueryRepository.JobDto, QueryRepository">
            <Columns>
                <asp:BoundField DataField="Description" HeaderText="My custom description" SortExpression="Description" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
