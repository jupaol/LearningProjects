<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="36_AddEventsToGridViewControls.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery._06_For_GridView._36_AddEventsToGridViewControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .rows {
            background-color:aliceblue;
            cursor:pointer;
        }

        .inputs {
            background-color:lightblue;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            var $gv = $("table[id$=gv]");
            var $rows = $("> tbody > tr:not(:has(table, th))", $gv);
            var $texts = $("textarea[id*=_desc_]", $rows);

            $rows.addClass("rows");
            $texts.addClass("inputs");
            $texts.bind("keyup blur", function (e) {
                var value = $(this).val();

                if (value.match(/[^a-zA-Z]/g)) {
                    $(this).val(value.replace(/[^a-zA-Z]/g, ""));
                }
            });
        });
    </script>
    <h1>
        Quickly add events to controls inside the GridView
    </h1>
    <asp:LinqDataSource runat="server" ID="lds"
        TableName="employee"
        ContextTypeName="Msts.DataAccess.PubsDataContext">
    </asp:LinqDataSource>
    <asp:GridView runat="server" ID="gv" DataSourceID="lds"
        AllowPaging="true" PageSize="5" DataKeyNames="emp_id">
        <Columns>
            <asp:TemplateField HeaderText="Description">
                <ItemTemplate>
                    <asp:TextBox runat="server" ID="desc" TextMode="MultiLine"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div id="data"></div>
    <div id="error"></div>
</asp:Content>
