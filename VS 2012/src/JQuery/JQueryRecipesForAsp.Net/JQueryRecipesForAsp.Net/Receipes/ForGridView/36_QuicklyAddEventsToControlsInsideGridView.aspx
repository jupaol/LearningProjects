<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="36_QuicklyAddEventsToControlsInsideGridView.aspx.cs" Inherits="JQueryRecipesForAsp.Net.Receipes.ForGridView._36_QuicklyAddEventsToControlsInsideGridView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        .rows {
            background-color:aliceblue;
            cursor:pointer;
        }

        .inputs {
            background-color:lightblue;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeatureHeader" runat="server">
    Quickly add events to controls inside the GridView
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FeatureDescription" runat="server">
    Quickly add events to controls inside the GridView
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
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
    <asp:LinqDataSource runat="server" ID="lds"
        TableName="employee"
        ContextTypeName="JQueryRecipesForAsp.Net.DataAccess.PubsDataContext">
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
