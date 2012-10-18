<%@ Page Trace="true" TraceMode="SortByTime" Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="AddingPersistentCookies.aspx.cs" Inherits="Msts.Topics.Chapter03.Lesson02___ClientSideState.AddingPersistentCookies" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div runat="server" id="myContainer">
        <h1>Working with cookies
        </h1>
        <h2>Press the save settings in order to save the settings using persistent cookies
        </h2>
        <fieldset>
            <legend>Customizations
            </legend>
            <div>
                <asp:Label Text="Choose your favorite color" runat="server" AssociatedControlID="colors" />
            </div>
            <div>
                <asp:DropDownList runat="server" ID="colors">
                    <asp:ListItem Text="Not set" Value="-1" Selected="True" />
                    <asp:ListItem Text="Blue" />
                    <asp:ListItem Text="Red" />
                </asp:DropDownList>
            </div>
            <div>
                <asp:CheckBox runat="server" ID="rememberMe" Checked="false" />
                <asp:Label ID="Label1" Text="Remmeber me on this computer" runat="server" AssociatedControlID="rememberMe" />
            </div>
            <div>
                <asp:Button Text="Save settings" runat="server" ID="saveSettings" OnClick="saveSettings_Click" />
            </div>
            <div>
                <asp:Button Text="Delete settings from this computer" runat="server" ID="deleteSettings" OnClick="deleteSettings_Click" />
            </div>
        </fieldset>
        <fieldset>
            <legend>
                Cookie content
            </legend>
            <div>
                <asp:Literal runat="server" ID="msg" Mode="Encode"></asp:Literal>
            </div>
            <div>
                <asp:Literal runat="server" ID="expiresDate" Mode="Encode"></asp:Literal>
            </div>
        </fieldset>
    </div>
</asp:Content>
