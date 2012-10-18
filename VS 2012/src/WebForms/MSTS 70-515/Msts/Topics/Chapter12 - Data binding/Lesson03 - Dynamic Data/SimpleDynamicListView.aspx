<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="SimpleDynamicListView.aspx.cs" Inherits="Msts.Topics.Chapter12___Data_binding.Lesson03___Dynamic_Data.SimpleDynamicListView" %>

<%@ Register Src="~/DynamicData/Content/GridViewPager.ascx" TagPrefix="uc1" TagName="GridViewPager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Dynamic Data
    </h1>
    <h2>
        ListView
    </h2>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:UpdateProgress runat="server" DisplayAfter="0">
                <ProgressTemplate>
                    Processing...
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:ListView runat="server" ID="lv"
                DataKeyNames="job_id"
                ItemType="Msts.DataAccess.EFData.job"
                SelectMethod="lv_GetData"
                UpdateMethod="lv_UpdateItem"
                DeleteMethod="lv_DeleteItem"
                InsertMethod="lv_InsertItem"
                OnItemCommand="lv_ItemCommand"
                OnItemInserted="lv_ItemInserted">
                <LayoutTemplate>
                    <h3>
                        Jobs List
                    </h3>
                    <hr />
                    <asp:Panel ID="Panel1" runat="server" GroupingText="Sorting">
                        <asp:LinkButton ID="LinkButton1" Text="Description" runat="server" CommandName="Sort" CommandArgument="job_desc" />
                    </asp:Panel>
                    <div>
                        <asp:ValidationSummary runat="server" ValidationGroup="lv_validation" />
                    </div>
                    <div id="itemPlaceHolder" runat="server"></div>
                    <hr />
                    <div>
                        <asp:Button Text="New" runat="server" CommandName="New" CausesValidation="false" />
                    </div>
                    <div>
                        <asp:DataPager runat="server" ID="pager" PageSize="5">
                            <Fields>
                                <asp:NumericPagerField />
                            </Fields>
                        </asp:DataPager>
                    </div>
                </LayoutTemplate>
                <ItemTemplate>
                    <div>
                        <div>
                            <b>
                                <asp:DynamicControl ID="DynamicControl3" DataField="job_desc" runat="server" />
                            </b>
                        </div>
                        <div>
                            <i>(<asp:DynamicControl ID="DynamicControl1" DataField="min_lvl" runat="server" /> - <asp:DynamicControl ID="DynamicControl2" DataField="max_lvl" runat="server" />)</i>
                        </div>
                        <div>
                            <asp:DynamicHyperLink runat="server" ID="dynamicLink"
                                Action="Details" 
                                Text="Details"
                                NavigateUrl='<%#: string.Format("~/Topics/Chapter12 - Data binding/Lesson03 - Dynamic Data/SimpleDynamicDetailsView.aspx?job_id={0}", Item.job_id) %>'>

                            </asp:DynamicHyperLink>
                        </div>
                        <div>
                            <asp:Button Text="Edit" runat="server" CommandName="Edit" CausesValidation="false" />
                            <asp:Button Text="Delete" runat="server" CommandName="Delete" CausesValidation="false" OnClientClick="return confirm('Are you sure you want to delete this element?');" />
                        </div>
                    </div>
                </ItemTemplate>
                <EditItemTemplate>
                    <div>
                        <b><asp:Label ID="jobDescriptionLabel" Text="Job Description" runat="server" AssociatedControlID="jobDescription" /></b>
                    </div>
                    <div>
                        <asp:DynamicControl ValidationGroup="lv_validation" DataField="job_desc" Mode="Edit" runat="server" ID="jobDescription" />
                    </div>
                    <div>
                        <b><asp:Label runat="server" ID="minimumLevelLabel" Text="Minimum Level" AssociatedControlID="minimumLevel"></asp:Label></b>
                    </div>
                    <div>
                        <asp:DynamicControl ValidationGroup="lv_validation" DataField="min_lvl" runat="server" Mode="Edit" ID="minimumLevel" />
                    </div>
                    <div>
                        <b><asp:Label runat="server" ID="maximumLevelLabel" Text="Maximum Level" AssociatedControlID="maximumLevel"></asp:Label></b>
                    </div>
                    <div>
                        <asp:DynamicControl ValidationGroup="lv_validation" DataField="max_lvl" Mode="Edit" runat="server" ID="maximumLevel" />
                    </div>
                    <div>
                        <asp:Button Text="Update" runat="server" CommandName="Update" ValidationGroup="lv_validation" CausesValidation="true" />
                        <asp:Button Text="Cancel" runat="server" CommandName="Cancel" CausesValidation="false" />
                    </div>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <div>
                        <b>Job Description</b>
                    </div>
                    <div>
                        <asp:DynamicControl DataField="job_desc" runat="server" ValidationGroup="lv_validation" Mode="Insert" />
                    </div>
                    <div>
                        <b>Minimum Level</b>
                    </div>
                    <div>
                        <asp:DynamicControl DataField="min_lvl" runat="server" ValidationGroup="lv_validation" Mode="Insert" />
                    </div>
                    <div>
                        <b>Maximum Level</b>
                    </div>
                    <div>
                        <asp:DynamicControl DataField="max_lvl" runat="server" ValidationGroup="lv_validation" Mode="Insert" />
                    </div>
                    <div>
                        <asp:Button Text="Add" runat="server" CommandName="Insert" ValidationGroup="lv_validation" />
                        <asp:Button Text="Cancel" runat="server" CommandName="CancelInsert" CausesValidation="false" />
                    </div>
                </InsertItemTemplate>
            </asp:ListView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
