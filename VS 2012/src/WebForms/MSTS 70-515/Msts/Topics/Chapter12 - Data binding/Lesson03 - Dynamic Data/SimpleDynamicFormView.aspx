<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="SimpleDynamicFormView.aspx.cs" Inherits="Msts.Topics.Chapter12___Data_binding.Lesson03___Dynamic_Data.SimpleDynamicFormView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Dynamic Data
    </h1>
    <h2>
        FormView
    </h2>
    <asp:DynamicDataManager runat="server" ID="dynamicManager" AutoLoadForeignKeys="true">
        <DataControls>
            <asp:DataControlReference ControlID="fv" />
        </DataControls>
    </asp:DynamicDataManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:UpdateProgress runat="server" DisplayAfter="0">
                <ProgressTemplate>
                    Processing...
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:ValidationSummary  ValidationGroup="fvActions" runat="server" />
            <asp:FormView runat="server" ID="fv"
                DataKeyNames="job_id"
                ItemType="Msts.DataAccess.EFData.job"
                SelectMethod="fv_GetItem"
                UpdateMethod="fv_UpdateItem"
                DeleteMethod="fv_DeleteItem"
                InsertMethod="fv_InsertItem"
                DefaultMode="ReadOnly"
                RenderOuterTable="false"
                OnItemCommand="fv_ItemCommand">
                <ItemTemplate>
                    <div>
                        <asp:DynamicControl DataField="job_desc" runat="server" />
                    </div>
                    <div>
                        <i>
                            <asp:Label ID="Label1" Text='<%#: string.Format("({0} - {1})", Item.min_lvl, Item.max_lvl) %>' runat="server" />
                        </i>
                    </div>
                    <div>
                        <asp:Button Text="Edit" runat="server" CommandName="Edit" CausesValidation="false" />
                        <asp:Button Text="Delete" runat="server" CommandName="Delete" CausesValidation="false" OnClientClick="return confirm('Are you sure you want to delete this element?');" />
                    </div>
                </ItemTemplate>
                <EditItemTemplate>
                    <div>
                        <b>Job Description</b>
                    </div>
                    <div>
                        <asp:DynamicControl Mode="Edit" ValidationGroup="fvActions" DataField="job_desc" runat="server" />
                    </div>
                    <div>
                        <b>Minimum level</b>
                    </div>
                    <div>
                        <asp:DynamicControl Mode="Edit" DataField="min_lvl" runat="server" ValidationGroup="fvActions" />
                    </div>
                    <div>
                        <b>Maximum level</b>
                    </div>
                    <div>
                        <asp:DynamicControl Mode="Edit" DataField="max_lvl" runat="server" ValidationGroup="fvActions" />
                    </div>
                    <div>
                        <asp:Button Text="Update" runat="server" CommandName="Update" ValidationGroup="fvActions" />
                        <asp:Button Text="Cancel" runat="server" CommandName="Cancel" CausesValidation="false" />
                    </div>
                </EditItemTemplate>
            </asp:FormView>
            <div>
                <asp:HyperLink NavigateUrl="~/Topics/Chapter12 - Data binding/Lesson03 - Dynamic Data/SimpleDynamicDataGridView.aspx" runat="server" Text="Go back to the list" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
