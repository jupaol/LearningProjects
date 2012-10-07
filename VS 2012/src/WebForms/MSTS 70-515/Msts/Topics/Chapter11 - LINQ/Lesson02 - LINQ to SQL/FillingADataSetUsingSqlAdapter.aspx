<%@ Page Trace="true" TraceMode="SortByTime" Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="FillingADataSetUsingSqlAdapter.aspx.cs" Inherits="Msts.Topics.Chapter11___LINQ.Lesson02___LINQ_to_SQL.FillingADataSetUsingSqlAdapter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        $(function () {
            var $gv = $("table[id$=gvpicker]");
            var $rows = $("> tbody > tr:not(:has(th, table))", $gv);
            var $inputs = $(".myDatePickerClass", $rows);

            $rows.css("background-color", "yellow");

            $inputs.datepicker();
        });
    </script>
    <h1>
        Working with datasets
    </h1>
    <h3>
        Creating a dataset using <code>SqlAdapter</code> and <code>SqlCommandBuilder</code>
    </h3>
    <asp:GridView runat="server" ID="gvpicker">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:TextBox runat="server" ID="myDatePicker" CssClass="myDatePickerClass" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div>
        <asp:Label ID="msg" runat="server" />
    </div>
</asp:Content>
