﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="LinqToSqlManualMappingsTest.aspx.cs" Inherits="Msts.Topics.Chapter11___LINQ.Lesson02___LINQ_to_SQL.LinqToSqlManualMappingsTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Linq to SQL
    </h1>
    <h2>
        Manual mappings
    </h2>
    <h3>
        CRUD operations
    </h3>
    <ajaxToolkit:TabContainer runat="server" ID="tabs">
        <ajaxToolkit:TabPanel runat="server" ID="panel1">
            <HeaderTemplate>
                Manual mappings
            </HeaderTemplate>
            <ContentTemplate>
                <asp:UpdatePanel runat="server" ID="gridUpdatePanel">
                    <ContentTemplate>
                        <asp:GridView runat="server" ID="gv"
                            DataKeyNames="ID" AutoGenerateEditButton="true" AutoGenerateDeleteButton="true" AutoGenerateSelectButton="true" AutoGenerateColumns="true"
                            OnRowEditing="gv_RowEditing"
                            OnRowCancelingEdit="gv_RowCancelingEdit"
                            OnRowUpdating="gv_RowUpdating"
                            OnRowDeleting="gv_RowDeleting"
                            OnSelectedIndexChanging="gv_SelectedIndexChanging">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <div>
                                            <asp:Label Text='<%# Eval("ID") %>' runat="server" ID="idMessage" AssociatedControlID="id" />
                                        </div>
                                        <div>
                                            <asp:TextBox runat="server" ID="id" Text='<%# Bind("ID") %>' Enabled="false" />
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle Font-Bold="true" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <ajaxToolkit:UpdatePanelAnimationExtender runat="server" ID="upax" TargetControlID="gridUpdatePanel">
                </ajaxToolkit:UpdatePanelAnimationExtender>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel runat="server" ID="panel2">
            <HeaderTemplate>
                Insert new
            </HeaderTemplate>
            <ContentTemplate>
                <asp:UpdatePanel runat="server" ID="updatePanel">
                    <ContentTemplate>
                        <div>
                            <asp:Label Text="Description" runat="server" ID="descriptionMessage" AssociatedControlID="description" />
                        </div>
                        <div>
                            <asp:TextBox runat="server" ID="description" TextMode="MultiLine" Rows="8" />
                        </div>
                        <div>
                            <asp:Label Text="Minimum level (10-200)" runat="server" ID="minimumMessage" AssociatedControlID="minimum" />
                        </div>
                        <div>
                            <asp:TextBox runat="server" ID="minimum" />
                        </div>
                        <div>
                            <asp:Label Text="Maximum level (Minimum level - 200)" runat="server" ID="maximumMessage" AssociatedControlID="maximum" />
                        </div>
                        <div>
                            <asp:TextBox runat="server" ID="maximum" />
                        </div>
                        <div>
                            <asp:Button Text="Save..." runat="server" ID="save" OnClick="save_Click" />
                        </div>
                        <div>
                            <asp:Label ID="msg" runat="server" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>
</asp:Content>
