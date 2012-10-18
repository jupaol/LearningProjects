<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="AjaxEncapsulatedAjaxBehavior.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson02___Client_MS_AJAX.AjaxEncapsulatedAjaxBehavior" %>
<%@ Register Assembly="Msts" Namespace="Msts.Topics.Chapter09___Scripts.Lesson02___Client_MS_AJAX" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Testing Behavior created with MS AJAX
    </h1>
    <div>
        <asp:Label Text="Password:" runat="server" ID="passwordMessage" AssociatedControlID="password" />
    </div>
    <div>
        <asp:TextBox runat="server" ID="password" TextMode="Password" />
        <uc:PasswordLengthBehavior 
            runat="server" 
            ID="passwordBehavior" 
            TargetControlID="password"
            WeakCssClass="weak"
            MediumCssClass="medium"
            StrongCssClass="strong" />
    </div>
</asp:Content>
