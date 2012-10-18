<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="WorkingWithTheListViewControl.aspx.cs" Inherits="Msts.Topics.Chapter12___Data_binding.Lesson02___DataBound.WorkingWithTheListViewControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        ListView control
    </h1>
    <asp:EntityDataSource runat="server" ID="eds2"
        ContextTypeName="Msts.DataAccess.EFData.PubsEntities"
        OnContextCreating="eds_ContextCreating"
        EntitySetName="jobs"
        EnableFlattening="true"
        EnableDelete="false" EnableInsert="false" EnableUpdate="false"
        AutoPage="false"
        AutoGenerateWhereClause="false"
        AutoSort="false" AutoGenerateOrderByClause="false">

    </asp:EntityDataSource>
    <asp:UpdatePanel runat="server" ID="updatePanel" ChildrenAsTriggers="true" UpdateMode="Always">
        <ContentTemplate>
            <asp:UpdateProgress runat="server" ID="updateProgress" DisplayAfter="0">
                <ProgressTemplate>
                    Processing...
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div>
                <asp:Button Text="New" runat="server" ID="new" OnClick="new_Click" />
            </div>
            <div>
                <fieldset>
                    <legend>
                        Search filters
                    </legend>
                    <div>
                        <b>Job:</b>
                    </div>
                    <div>
                        <asp:DropDownList runat="server" ID="jobFilter"
                            DataSourceID="eds2" DataTextField="job_desc" DataValueField="job_id"
                            AutoPostBack="false" AppendDataBoundItems="true">
                            <asp:ListItem Text="All" Value="" />
                        </asp:DropDownList>
                    </div>
                    <div>
                        <b>First Name:</b>
                    </div>
                    <div>
                        <asp:TextBox runat="server" ID="firstNameFilter" />
                    </div>
                    <div>
                        <asp:Button Text="Apply Filter" runat="server" ID="applyFilter" OnClick="applyFilter_Click" />
                    </div>
                    <div>
                        <asp:Button Text="Reset filter" runat="server" ID="resetFilter" OnClick="resetFilter_Click" />
                    </div>
                </fieldset>
            </div>
            <asp:EntityDataSource runat="server" ID="eds"
                ContextTypeName="Msts.DataAccess.EFData.PubsEntities"
                OnContextCreating="eds_ContextCreating"
                EntitySetName="employees"
                Include="job"
                AutoPage="true" AutoGenerateWhereClause="false"
                AutoSort="true" AutoGenerateOrderByClause="true"
                EnableFlattening="false"
                EnableDelete="true" EnableInsert="true" EnableUpdate="true"
                OnQueryCreated="eds_QueryCreated">
            </asp:EntityDataSource>
            <asp:ListView runat="server" ID="lv"
                DataSourceID="eds" DataKeyNames="emp_id"
                OnItemEditing="lv_ItemEditing"
                OnItemDataBound="lv_ItemDataBound"
                OnItemUpdating="lv_ItemUpdating"
                OnItemInserting="lv_ItemInserting"
                OnItemInserted="lv_ItemInserted">
                <LayoutTemplate>
                    <div>
                        <h2>
                            List of employees
                        </h2>
                        <h3>
                            Using EntityDataSource, and the PUBS database
                        </h3>
                        <div runat="server" id="groupPlaceHolder">

                        </div>
                        <div style="background-color:yellow;">
                            <asp:DataPager runat="server" PagedControlID="lv" PageSize="5">
                                <Fields>
                                    <asp:NumericPagerField />
                                </Fields>
                            </asp:DataPager>
                        </div>
                    </div>
                </LayoutTemplate>
                <GroupTemplate>
                    <div style="background-color:green;">
                        <div runat="server" id="itemPlaceHolder">

                        </div>
                    </div>
                </GroupTemplate>
                <GroupSeparatorTemplate>
                    <b>***************************</b>
                    <hr />
                    <b>***************************</b>
                </GroupSeparatorTemplate>
                <ItemSeparatorTemplate>
                    <hr />
                </ItemSeparatorTemplate>
                <ItemTemplate>
                    <div>
                        <div>
                            <b>ID:</b>
                        </div>
                        <div>
                            <asp:Label Text='<%# Eval("emp_id") %>' runat="server" />
                        </div>
                        <div>
                            <b>First Name:</b>
                        </div>
                        <div>
                            <asp:Label Text='<%# Eval("fname") %>' runat="server" />
                        </div>
                        <div>
                            <b>Last Name:</b>
                        </div>
                        <div>
                            <asp:Label Text='<%# Eval("lname") %>' runat="server" />
                        </div>
                        <div>
                            <b>Job Description:</b>
                        </div>
                        <div>
                            <asp:Label Text='<%# Eval("job.job_desc") %>' runat="server" />
                        </div>
                        <div>
                            <b>Minimum Job's level</b>
                        </div>
                        <div>
                            <asp:Label Text='<%# Eval("job.min_lvl") %>' runat="server" />
                        </div>
                        <div>
                            <b>Maximum Job's level</b>
                        </div>
                        <div>
                            <asp:Label Text='<%# Eval("job.max_lvl") %>' runat="server" />
                        </div>
                        <div>
                            <b>Hire Date:</b>
                        </div>
                        <div>
                            <asp:Label ID="Label1" Text='<%# Eval("hire_date") %>' runat="server" />
                        </div>
                        <div>
                            <fieldset>
                                <legend>
                                    Actions
                                </legend>
                                <div>
                                    <asp:Button Text="Delete" runat="server" CommandName="Delete" OnClientClick="return confirm('This action cannot be undone. Are you sure to proceed?');" />
                                </div>
                                <div>
                                    <asp:Button Text="Edit" runat="server" CommandName="Edit" />
                                </div>
                            </fieldset>
                        </div>
                    </div>
                </ItemTemplate>
                <EditItemTemplate>
                    <div>
                        <asp:Label Text="First Name" runat="server" AssociatedControlID="firstName" />
                    </div>
                    <div>
                        <asp:TextBox runat="server" ID="firstName" Text='<%# Bind("fname") %>' />
                    </div>
                    <div>
                        <asp:Label Text="Last Name" runat="server" AssociatedControlID="lastName" />
                    </div>
                    <div>
                        <asp:TextBox runat="server" ID="lastName" Text='<%# Bind("lname") %>' />
                    </div>
                    <div>
                        <asp:Label Text="Job Description" runat="server" AssociatedControlID="job" />
                    </div>
                    <div>
                        <asp:DropDownList runat="server" ID="job" 
                            DataSourceID="eds2"
                            DataTextField="job_desc" DataValueField="job_id"
                            AppendDataBoundItems="true"
                            AutoPostBack="true" CausesValidation="false"
                            OnSelectedIndexChanged="job_SelectedIndexChanged">
                            <asp:ListItem Text="Please select a JOB" Value="" />
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="job" Text=" - Required" />
                    </div>
                    <div>
                        <asp:Label Text="Job level" runat="server" AssociatedControlID="jobLevel" />
                        <asp:Label ID="jobLevelRangeMessage" runat="server"
                            Text='<%# string.Format("({0} - {1})", Eval("job.min_lvl"), Eval("job.max_lvl")) %>' />
                    </div>
                    <div>
                        <asp:TextBox runat="server" ID="jobLevel" Text='<%# Bind("job_lvl") %>' />
                        <asp:RangeValidator ID="jobLevelRangeValidator" runat="server" 
                            ControlToValidate="jobLevel"
                            Text="Invalid range"
                            MinimumValue='<%# Eval("job.min_lvl") %>'
                            MaximumValue='<%# Eval("job.max_lvl") %>'
                            Type="Integer" />
                    </div>
                    <div>
                        <fieldset>
                            <legend>
                                Actions
                            </legend>
                            <div>
                                <asp:Button Text="Cancel" runat="server" CommandName="Cancel" CausesValidation="false" />
                            </div>
                            <div>
                                <asp:Button Text="Update" runat="server" CommandName="Update" />
                            </div>
                            <div>
                                <asp:Button Text="Just a post" runat="server" CommandName="simple post" CausesValidation="false" />
                            </div>
                        </fieldset>
                    </div>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <div>
                        <div>
                            <b>ID (PMA42628M):</b>
                        </div>
                        <div>
                            <asp:TextBox runat="server" ID="employeeID" Text='<%# Bind("emp_id") %>' />
                        </div>
                        <div>
                            <b>First Name:</b>
                        </div>
                        <div>
                            <asp:TextBox runat="server" ID="firstName" Text='<%# Bind("fname") %>' />
                        </div>
                        <div>
                            <b>Last Name:</b>
                        </div>
                        <div>
                            <asp:TextBox runat="server" ID="lastName" Text='<%# Bind("lname") %>' />
                        </div>
                        <div>
                            <b>Job:</b>
                            <asp:Label ID="jobLevelRangeMessage" runat="server"
                                Text='<%# string.Format("({0} - {1})", Eval("job.min_lvl"), Eval("job.max_lvl")) %>' />
                        </div>
                        <div>
                            <asp:DropDownList runat="server" ID="job"
                                DataSourceID="eds2" DataTextField="job_desc" DataValueField="job_id"
                                CausesValidation="false" AutoPostBack="true"
                                OnSelectedIndexChanged="job_SelectedIndexChanged1"
                                AppendDataBoundItems="true">
                                <asp:ListItem Text="Please select a job" Value="" />
                            </asp:DropDownList>
                        </div>
                        <div>
                            <b>Job Level:</b>
                        </div>
                        <div>
                            <asp:TextBox runat="server" ID="jobLevel" Text='<%# Bind("job_lvl") %>' />
                            <asp:RangeValidator ID="jobLevelRangeValidator" runat="server" 
                                ControlToValidate="jobLevel"
                                Text="Invalid range"
                                MinimumValue='10'
                                MaximumValue='250'
                                Type="Integer" />
                        </div>
                        <div>
                            <b>Hire Date:</b>
                        </div>
                        <div>
                            <asp:TextBox runat="server" ID="hireDate" Text='<%# Bind("hire_date") %>' />
                            <ajaxToolkit:CalendarExtender runat="server" ID="calendarExtender"
                                TargetControlID="hireDate" >

                            </ajaxToolkit:CalendarExtender>
                        </div>
                        <div>
                            <b>Publisher</b>
                        </div>
                        <div>
                            <asp:EntityDataSource runat="server" ID="eds3"
                                ContextTypeName="Msts.DataAccess.EFData.PubsEntities"
                                OnContextCreating="eds_ContextCreating"
                                EntitySetName="publishers">

                            </asp:EntityDataSource>
                            <asp:DropDownList runat="server" ID="publisher"
                                DataSourceID="eds3" DataTextField="pub_name" DataValueField="pub_id"
                                AppendDataBoundItems="true">
                                <asp:ListItem Text="Please select a publisher" Value="" />
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ControlToValidate="publisher" runat="server" Text="- Required" />
                        </div>
                        <div>
                            <fieldset>
                                <legend>
                                    Actions
                                </legend>
                                <div>
                                    <asp:Button Text="Cancel" runat="server" CommandName="Cancel" CausesValidation="false" />
                                </div>
                                <div>
                                    <asp:Button Text="Insert" runat="server" CommandName="Insert" />
                                </div>
                            </fieldset>
                        </div>
                    </div>
                </InsertItemTemplate>
            </asp:ListView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
