<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="WorkingWithTheChartControl.aspx.cs" Inherits="Msts.Topics.Chapter12___Data_binding.Lesson02___DataBound.WorkingWithTheChartControl" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Chart Control
    </h1>
    <asp:EntityDataSource runat="server" ID="eds"
        ContextTypeName="Msts.DataAccess.EFData.PubsEntities"
        EntitySetName="employees"
        Select="it.job.job_desc, COUNT(it.emp_id) as c"
        GroupBy="it.job.job_desc"
        EnableFlattening="true"
        OnContextCreating="eds_ContextCreating"
        OnQueryCreated="eds_QueryCreated">

    </asp:EntityDataSource>
    <asp:Chart ID="Chart1" runat="server"
        DataSourceID="eds"
        RenderType="ImageTag"
        Height="600" Width="450">
        <Series>
            <asp:Series 
                Name="Series1"
                ChartType="Bar"
                IsXValueIndexed="true"
                XValueMember="job_desc"
                XValueType="String"
                YValueMembers="c"
                IsValueShownAsLabel="true"
                IsVisibleInLegend="true"
                YValueType="Int32">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
                <AxisX Interval="1">
                </AxisX>
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
</asp:Content>
