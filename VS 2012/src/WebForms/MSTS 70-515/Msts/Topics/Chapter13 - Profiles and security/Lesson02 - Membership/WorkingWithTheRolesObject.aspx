﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="WorkingWithTheRolesObject.aspx.cs" Inherits="Msts.Topics.Chapter13___Profiles_and_security.Lesson02___Membership.WorkingWithTheRolesObject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Roles
    </h1>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:UpdateProgress runat="server" DisplayAfter="0">
                <ProgressTemplate>
                    Processing...
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:GridView runat="server" ID="gv"
                DataKeyNames="Name"
                ItemType="Msts.Topics.Chapter13___Profiles_and_security.Lesson02___Membership.RoleDto"
                SelectMethod="gv_GetData"
                PageSize="5" AllowPaging="true"
                AutoGenerateDeleteButton="true"
                DeleteMethod="gv_DeleteItem"
                OnRowDeleted="gv_RowDeleted"
                AutoGenerateEditButton="true"
                UpdateMethod="gv_UpdateItem"
                OnRowUpdated="gv_RowUpdated">

            </asp:GridView>
            <hr />
            <div>
                <asp:Button Text="New" runat="server" ID="newRole" OnClick="newRole_Click" />
            </div>
            <hr />
            <asp:Panel runat="server" ID="newRolePanel" 
                GroupingText="New Role" 
                Visible="false"
                DefaultButton="createRole">
                <div>
                    Role Name:
                </div>
                <div>
                    <asp:TextBox runat="server" ID="roleName" />
                    <asp:RequiredFieldValidator ErrorMessage="Role Name required" ControlToValidate="roleName" runat="server" Text="*" />
                </div>
                <div>
                    <asp:Button Text="Create role" runat="server" ID="createRole" OnClick="createRole_Click" />
                    <asp:Button Text="Cancel" runat="server" ID="cancelRoleCreation" OnClick="cancelRoleCreation_Click" CausesValidation="false" />
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
