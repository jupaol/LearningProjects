﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="WorkingWithTheProfileOnTheServerSide.aspx.cs" Inherits="Msts.Topics.Chapter13___Profiles_and_security.Lesson01___Profiles.WorkingWithTheProfileOnTheServerSide" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        User Profile
    </h1>
    <h2>
        Server Side
    </h2>
    <asp:DynamicDataManager runat="server" ID="ddm">
        <DataControls>
            <asp:DataControlReference ControlID="dv" />
        </DataControls>
    </asp:DynamicDataManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:UpdateProgress runat="server" DisplayAfter="0">
                <ProgressTemplate>
                    Processing...
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:ValidationSummary runat="server" />
            <asp:DetailsView runat="server" ID="dv"
                DataKeyNames="UserName"
                ItemType="Msts.CustomProfile"
                SelectMethod="dv_GetItem"
                AutoGenerateRows="false"
                DefaultMode="ReadOnly"
                AutoGenerateEditButton="true"
                UpdateMethod="dv_UpdateItem"
                AutoGenerateDeleteButton="true"
                DeleteMethod="dv_DeleteItem"
                OnItemDeleted="dv_ItemDeleted"
                OnItemUpdated="dv_ItemUpdated">
                <Fields>
                    <asp:DynamicField DataField="UserName" />
                    <asp:DynamicField DataField="MasterPage" />
                    <asp:DynamicField DataField="Language" />
                    <asp:DynamicField DataField="Theme" />
                    <asp:DynamicField DataField="LastLogin" />
                </Fields>
            </asp:DetailsView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
