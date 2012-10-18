﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="LinqToEntitiesCrudOperations.aspx.cs" Inherits="Msts.Topics.Chapter11___LINQ.Lesson02___LINQ_to_SQL.LinqToEntitiesCrudOperations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        $(function () {
            var $dialog = $("#dialog");
            var $addNew = $("input:submit[id$=new]");
            var $dialogUpdatePanel = $("div[id$=insertUpdatePanel]");

            $dialog.dialog({
                modal: true,
                autoOpen: false,
                open: function (e, ui) {
                    $(this).parent().appendTo("form");
                }
            });

            $addNew.click(function (e) {
                e.preventDefault();

                $dialog.dialog("open");
            });
        });
    </script>
    <h1>
        LINQ To Entities
    </h1>
    <h2>
        CRUD operations
    </h2>
    <h3>
        Using the EntityDataSource control
    </h3>
    <asp:EntityDataSource runat="server" ID="eds"
        ConnectionString="<%$ ConnectionStrings:PubsEntities %>" 
        DefaultContainerName="PubsEntities"
        AutoPage="true"
        AutoSort="true"
        EntitySetName="jobs"
        AutoGenerateOrderByClause="true"
        AutoGenerateWhereClause="true"
        EnableDelete="true"
        EnableInsert="true"
        EnableUpdate="true">

    </asp:EntityDataSource>
    <div>
        <asp:Button Text="New..." runat="server" ID="new" />
    </div>
    <asp:UpdatePanel runat="server" ID="updatePanel">
        <ContentTemplate>
            <asp:UpdateProgress runat="server" ID="updatePanelProgress" DisplayAfter="0">
                <ProgressTemplate>
                    Processing...
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div>
                <asp:Button Text="Cacel selection..." runat="server" ID="cancelSelection" OnClick="cancelSelection_Click" />
            </div>
            <asp:GridView runat="server" ID="gv" DataKeyNames="job_id"
                AllowPaging="true" AllowSorting="true"
                AutoGenerateColumns="true" AutoGenerateDeleteButton="true" AutoGenerateEditButton="true" AutoGenerateSelectButton="true"
                DataSourceID="eds">
                <SelectedRowStyle Font-Bold="true" />
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div id="dialog" style="display:none;">
        <asp:UpdatePanel runat="server" ID="insertUpdatePanel">
            <ContentTemplate>
                <asp:UpdateProgress runat="server" ID="UpdateProgress1" DisplayAfter="0">
                    <ProgressTemplate>
                        Processing...
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <div>
                    Description:
                    <asp:TextBox runat="server" ID="description" />
                </div>
                <div>
                    Minimum:
                    <asp:TextBox runat="server" ID="minimum" />
                </div>
                <div>
                    Maximum:
                    <asp:TextBox runat="server" ID="maximum" />
                </div>
                <div>
                    <asp:Button Text="Add new..." runat="server" ID="addNew" OnClick="addNew_Click" />
                </div>
                <div>
                    <asp:Label Text="text" runat="server" ID="status" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <h3>
        Manually, using an ObjectDataSource control
    </h3>
    <asp:ObjectDataSource runat="server" ID="ods"
        TypeName="Msts.Topics.Chapter11___LINQ.Lesson02___LINQ_to_SQL.ObjectDataSourceProvider"
        SelectMethod="GetJobs" EnablePaging="true" 
        StartRowIndexParameterName="startRow"
        MaximumRowsParameterName="maximumRows"
        SelectCountMethod="GetJobsCount" UpdateMethod="UpdateJob" DeleteMethod="DeleteJob">

    </asp:ObjectDataSource>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:GridView runat="server" ID="gv2" DataSourceID="ods" DataKeyNames="ID"
                AllowPaging="true" AutoGenerateDeleteButton="true" AutoGenerateEditButton="true" AutoGenerateColumns="true" AutoGenerateSelectButton="true">
                <SelectedRowStyle Font-Bold="true" />
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
