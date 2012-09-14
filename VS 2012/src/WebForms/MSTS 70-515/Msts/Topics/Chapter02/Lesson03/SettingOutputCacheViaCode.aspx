<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="SettingOutputCacheViaCode.aspx.cs" Inherits="Msts.Topics.Chapter02.Lesson03.SettingOutputCacheViaCode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Output caching by param for 30 seconds using code</h1>
    <fieldset>
        <legend>
            Options
        </legend>
        <div>
            <asp:DropDownList runat="server" ID="ddl1" ClientIDMode="Static">
                <asp:ListItem Text="text1" />
                <asp:ListItem Text="text2" />
            </asp:DropDownList>
        </div>
        <div>
            <asp:DropDownList runat="server" ID="ddl2" ClientIDMode="Static">
                <asp:ListItem Text="text3" />
                <asp:ListItem Text="text4" />
            </asp:DropDownList>
        </div>
        <div>
            <asp:Button ID="Button1" Text="Post" runat="server" />
        </div>
    </fieldset>
    <h2>Rendered (without cache) at:</h2>
    <h3>
        <asp:Label runat="server" ID="msg" />
    </h3>
    <h2>Substitution datetime at:</h2>
    <h3>
        <asp:Substitution ID="Substitution1" runat="server" MethodName="MySubstitution" />
    </h3>
</asp:Content>
