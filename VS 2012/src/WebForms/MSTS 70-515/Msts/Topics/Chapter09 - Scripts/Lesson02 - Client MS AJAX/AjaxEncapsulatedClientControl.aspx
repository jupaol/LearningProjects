<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="AjaxEncapsulatedClientControl.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson02___Client_MS_AJAX.AjaxEncapsulatedClientControl" %>
<%@ Register Assembly="Msts" TagPrefix="uc" Namespace="Msts.Topics.Chapter09___Scripts.Lesson02___Client_MS_AJAX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Testing a MS AJAX control embedded in an assembly
    </h1>
    <div>
        <asp:Label Text="Password:" runat="server" ID="passwordMessage" AssociatedControlID="password" />
    </div>
    <div>
        <uc:PasswordLengthControl runat="server" ID="password" WeakCssClass="weak" MediumCssClass="medium" StrongCssClass="strong">

        </uc:PasswordLengthControl>
    </div>
    <div>
        <asp:Label Text="Confirm password:" runat="server" ID="confirmPasswordMessage" AssociatedControlID="confirmPassword" />
    </div>
    <div>
        <uc:PasswordLengthControl runat="server" ID="confirmPassword" WeakCssClass="weak" MediumCssClass="medium" StrongCssClass="strong">

        </uc:PasswordLengthControl>
    </div>
    <hr />
    <div>
        <asp:TextBox runat="server" ID="password2" TextMode="Password" />
        <uc:PasswordLengthBehavior 
            runat="server" 
            ID="passBehavior1" 
            WeakCssClass="weak" 
            MediumCssClass="medium" 
            StrongCssClass="strong"
            TargetControlID="password2" />
    </div>
</asp:Content>
