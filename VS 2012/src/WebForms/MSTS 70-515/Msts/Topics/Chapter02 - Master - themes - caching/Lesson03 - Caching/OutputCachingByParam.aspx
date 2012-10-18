<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="OutputCachingByParam.aspx.cs" Inherits="Msts.Topics.Chapter02.Lesson03.OutputCachingByParam" %>
<%@ OutputCache Duration="30" VaryByParam="ctl00$ctl00$ContentPlaceHolder1$ContentPlaceHolder1$ddl1;ctl00$ctl00$ContentPlaceHolder1$ContentPlaceHolder1$ddl2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Output caching by param for 30 seconds</h1>
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
            <asp:Button Text="Post" runat="server" />
        </div>
    </fieldset>
    <h2>Rendered (without cache) at:</h2>
    <h3>
        <asp:Label Text="text" runat="server" ID="msg" />
    </h3>
    <h2>Substitution datetime at:</h2>
    <h3>
        <asp:Substitution ID="Substitution1" runat="server" MethodName="MySubstitution" />
    </h3>
</asp:Content>
