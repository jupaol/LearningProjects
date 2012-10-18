<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="WorkingWithTheFormViewControl.aspx.cs" Inherits="Msts.Topics.Chapter12___Data_binding.Lesson02___DataBound.WorkingWithTheFormViewControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Form View Control
    </h1>
    <asp:UpdatePanel runat="server" ID="updatePanel">
        <ContentTemplate>
            <asp:UpdateProgress runat="server" ID="updateProgress">
                <ProgressTemplate>
                    Processing
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:EntityDataSource runat="server" ID="eds"
                ContextTypeName="Msts.DataAccess.EFData.PubsEntities"
                OnContextCreating="eds_ContextCreating"
                EntitySetName="jobs"
                EnableFlattening="false"
                EnableDelete="true" EnableInsert="true" EnableUpdate="true"
                AutoPage="true" 
                AutoSort="false" AutoGenerateOrderByClause="true"
                Include="employees">

            </asp:EntityDataSource>
            <asp:Button Text="New..." runat="server" ID="new" OnClick="new_Click" />
            <asp:FormView runat="server" ID="fv"
                DataSourceID="eds" DataKeyNames="job_id"
                AllowPaging="true"
                DefaultMode="ReadOnly"
                GridLines="None"
                PagerSettings-Mode="NumericFirstLast"
                RenderOuterTable="false"
                OnItemUpdating="fv_ItemUpdating">
                <ItemTemplate>
                    <div>
                        <b>ID</b>
                        <asp:Label Text='<%# Eval("job_id") %>' runat="server" />
                    </div>
                    <div>
                        <b>Description</b>
                        <asp:Label Text='<%# Eval("job_desc") %>' runat="server" />
                    </div>
                    <div>
                        <b>Minimum</b>
                        <asp:Label Text='<%# Eval("min_lvl") %>' runat="server" />
                    </div>
                    <div>
                        <b>Maximum</b>
                        <asp:Label Text='<%# Eval("max_lvl") %>' runat="server" />
                    </div>
                    <div>
                        <asp:GridView runat="server" ID="employeesGrid"
                            DataSource='<%# Eval("employees") %>'
                            DataKeyNames="emp_id"
                            AutoGenerateColumns="true">

                        </asp:GridView>
                    </div>
                    <div>
                        <asp:Button Text="Edit" runat="server" CommandName="Edit" />
                        <asp:Button Text="Delete" runat="server" CommandName="Delete" />
                        <asp:Button Text="New..." runat="server" CommandName="New" />
                    </div>
                </ItemTemplate>
                <EditItemTemplate>
                    <div>
                        <b>Description</b>
                        <asp:TextBox runat="server" ID="description" Text='<%# Bind("job_desc") %>' />
                    </div>
                    <div>
                        <b>Minimum</b>
                        <asp:TextBox runat="server" ID="minimum" Text='<%# Bind("min_lvl") %>' />
                    </div>
                    <div>
                        <b>Maximum</b>
                        <asp:TextBox runat="server" ID="maximum" Text='<%# Bind("max_lvl") %>' />
                    </div>
                    <div>
                        <asp:EntityDataSource runat="server" ID="eds2"
                            ContextTypeName="Msts.DataAccess.EFData.PubsEntities"
                            OnContextCreating="eds_ContextCreating"
                            EntitySetName="employees"
                            EnableFlattening="false"
                            EnableDelete="false" EnableInsert="false" EnableUpdate="false"
                            AutoPage="false" 
                            AutoSort="false" AutoGenerateOrderByClause="false">

                        </asp:EntityDataSource>
                        <asp:CheckBoxList runat="server" ID="employeesList" 
                            DataSourceID="eds2" DataTextField="fname" DataValueField="emp_id"
                            OnDataBound="employeesList_DataBound"
                            RepeatColumns="6" RepeatDirection="Horizontal" RepeatLayout="Table"/>
                    </div>
                    <div>
                        <asp:Button Text="Cancel" runat="server" CommandName="Cancel" />
                        <asp:Button Text="Update" runat="server" CommandName="Update" />
                    </div>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <div>
                        <b>Description</b>
                        <asp:TextBox runat="server" ID="description" Text='<%# Bind("job_desc") %>' />
                    </div>
                    <div>
                        <b>Minimum</b>
                        <asp:TextBox runat="server" ID="minimum" Text='<%# Bind("min_lvl") %>' />
                    </div>
                    <div>
                        <b>Maximum</b>
                        <asp:TextBox runat="server" ID="maximum" Text='<%# Bind("max_lvl") %>' />
                    </div>
                    <div>
                        <asp:Button Text="Cacnel..." runat="server" CommandName="Cancel" />
                        <asp:Button Text="Add" runat="server" CommandName="Insert" />
                    </div>
                </InsertItemTemplate>
            </asp:FormView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
