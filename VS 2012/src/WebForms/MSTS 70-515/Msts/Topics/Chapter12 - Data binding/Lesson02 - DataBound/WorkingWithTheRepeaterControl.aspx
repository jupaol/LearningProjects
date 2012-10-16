<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="WorkingWithTheRepeaterControl.aspx.cs" Inherits="Msts.Topics.Chapter12___Data_binding.Lesson02___DataBound.WorkingWithTheRepeaterControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Repeater control
    </h1>
    <asp:UpdatePanel runat="server" ID="updatePanel">
        <ContentTemplate>
            <asp:UpdateProgress runat="server" ID="updateProgress">
                <ProgressTemplate>
                    Processing...
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:EntityDataSource runat="server" ID="eds"
                ContextTypeName="Msts.DataAccess.EFData.PubsEntities"
                OnContextCreating="eds_ContextCreating"
                EntitySetName="jobs"
                Include="employees"
                AutoPage="false" AutoSort="false"
                EnableDelete="false" EnableInsert="false" EnableUpdate="false"
                EnableFlattening="false">

            </asp:EntityDataSource>
            <asp:Repeater runat="server" ID="repeater"
                DataSourceID="eds">
                <ItemTemplate>
                    <b>ID</b>
                    <div>
                        <asp:Label Text='<%# Eval("job_id") %>' runat="server" />
                    </div>
                    <b>Description</b>
                    <div>
                        <asp:Label Text='<%# Eval("job_desc") %>' runat="server" />
                    </div>
                    <b>Minimum</b>
                    <div>
                        <asp:Label Text='<%# Eval("min_lvl") %>' runat="server" />
                    </div>
                    <b>Maximum</b>
                    <div>
                        <asp:Label Text='<%# Eval("max_lvl") %>' runat="server" />
                    </div>
                </ItemTemplate>
                <SeparatorTemplate>
                    <hr />
                </SeparatorTemplate>
            </asp:Repeater>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
