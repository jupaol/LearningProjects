<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="TestingTheSkipTextProperty.aspx.cs" Inherits="Msts.Topics.Chapter06___Globalization_and_Accessibility.Lesson02___Accessibility.TestingTheSkipTextProperty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Wizard runat="server" ID="wizard"
        SkipLinkText="dedede">
        <WizardSteps>
            <asp:WizardStep>
                <asp:Button Text="text" runat="server" />
            </asp:WizardStep>
        </WizardSteps>
    </asp:Wizard>
</asp:Content>
