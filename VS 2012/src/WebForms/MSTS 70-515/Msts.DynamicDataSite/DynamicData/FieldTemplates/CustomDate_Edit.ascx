<%@ Control Language="C#" CodeBehind="CustomDate_Edit.ascx.cs" Inherits="Msts.DynamicDataSite.DynamicData.FieldTemplates.CustomDate_EditField" %>

<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <asp:Calendar runat="server" ID="Calendar1">

        </asp:Calendar>
    </ContentTemplate>
</asp:UpdatePanel>
