<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="WorkingWithSimpleDataBoundControls.aspx.cs" Inherits="Msts.Topics.Chapter12___Data_binding.Lesson02___DataBound.WorkingWithSimpleDataBoundControls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Simple DataBound controls
    </h1>
    <asp:EntityDataSource runat="server" ID="eds"
        ContextTypeName="Msts.DataAccess.EFData.PubsEntities"
        EntitySetName="jobs"
        OnContextCreating="eds_ContextCreating">

    </asp:EntityDataSource>
    <asp:UpdatePanel runat="server" ID="mainUpdatePanel">
        <ContentTemplate>
            <asp:UpdateProgress runat="server" ID="mainProgress">
                <ProgressTemplate>
                    Processing...
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div>
                <h3>
                    DropDownList
                </h3>
                <asp:DropDownList runat="server" ID="ddl" AutoPostBack="true" CausesValidation="false"
                    AppendDataBoundItems="true"
                    DataSourceID="eds" DataTextField="job_desc" DataValueField="job_id"
                    OnSelectedIndexChanged="ddl_SelectedIndexChanged"
                    >
                    <asp:ListItem Text="Select a value..." />
                </asp:DropDownList>
                <div>
                    <asp:Label ID="ddlRes" runat="server" />
                </div>
            </div>
            <div>
                <h3>
                    ListBox
                </h3>
                <asp:ListBox runat="server" ID="lb"
                    DataSourceID="eds"
                    SelectionMode="Multiple"
                    DataTextField="job_desc" DataValueField="job_id"
                    AutoPostBack="false" CausesValidation="false">
                </asp:ListBox>
                <div>
                    <asp:Button Text="Refresh..." runat="server" ID="refreshListBox" OnClick="refreshListBox_Click" />
                </div>
                <div>
                    <asp:Label runat="server" ID="lbRes"></asp:Label>
                </div>
            </div>
            <div>
                <h3>
                    CheckBoxList
                </h3>
                <asp:CheckBoxList runat="server" ID="cbl" 
                    DataSourceID="eds"
                    AutoPostBack="true" 
                    CausesValidation="false"
                    RepeatColumns="3" RepeatDirection="Horizontal" RepeatLayout="Table"
                    OnSelectedIndexChanged="cbl_SelectedIndexChanged"
                    DataTextField="job_desc" DataValueField="job_id">
                </asp:CheckBoxList>
                <div>
                    <asp:Label runat="server" ID="cblRes"></asp:Label>
                </div>
            </div>
            <div>
                <h3>
                    RadioButtonList
                </h3>
                <asp:RadioButtonList runat="server" ID="rbl"
                    DataSourceID="eds" DataTextField="job_desc" DataValueField="job_id"
                    AutoPostBack="true"
                    CausesValidation="false"
                    RepeatDirection="Vertical" RepeatLayout="OrderedList"
                    OnSelectedIndexChanged="rbl_SelectedIndexChanged">

                </asp:RadioButtonList>
                <div>
                    <asp:Label Text="text" runat="server" ID="rblRes" />
                </div>
            </div>
            <div>
                <h3>
                    BulletedList
                </h3>
                <asp:BulletedList runat="server" ID="bl"
                    DataSourceID="eds" DataTextField="job_desc" DataValueField="job_id"
                    BulletStyle="Disc">

                </asp:BulletedList>
            </div>
            <div>
                <h3>
                    AdRotator
                </h3>
                <div>
                    <asp:AdRotator runat="server" ID="adRotator" Width="100" Height="100"
                        SelectMethod="adRotator_SelectMethod" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
