<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="SimpleWebPart.aspx.cs" Inherits="Msts.Topics.Chapter05.Lesson03___WebParts.SimpleWebPart" %>

<%@ Register Src="~/Topics/Chapter05 - Validation and navigation/Lesson03 - WebParts/UserControl1.ascx" TagPrefix="uc1" TagName="UserControl1" %>
<%@ Register Src="~/Topics/Chapter05 - Validation and navigation/Lesson03 - WebParts/UserControl2.ascx" TagPrefix="uc1" TagName="UserControl2" %>
<%@ Register Src="~/Topics/Chapter05 - Validation and navigation/Lesson03 - WebParts/UserControl3.ascx" TagPrefix="uc1" TagName="UserControl3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ProxyWebPartManager runat="server" ID="pwpm">
        <StaticConnections>
            <asp:WebPartConnection 
                ID="dateChangedConnection"
                ProviderID="UserControl1"
                ConsumerID="UserControl3"
                ProviderConnectionPointID="Date Changed"
                ConsumerConnectionPointID="Date Changed Handler" >
                
            </asp:WebPartConnection>
        </StaticConnections>
    </asp:ProxyWebPartManager>
    <h1>
        Simple WebPart
    </h1>
    <h3>
        Dynamic WebPartManager modes
    </h3>
    <div>
        <asp:DropDownList runat="server" ID="dynamicWebPartZonesMode">
        </asp:DropDownList>
    </div>
    <h3>
        Custom WebPartManager modes
    </h3>
    <div>
        <asp:DropDownList runat="server" ID="webPartZonesMode" CausesValidation="true" AutoPostBack="true" OnSelectedIndexChanged="webPartZonesMode_SelectedIndexChanged">
            <asp:ListItem Text="Browse" Selected="True" />
            <asp:ListItem Text="Design" />
            <asp:ListItem Text="Catalog" />
            <asp:ListItem Text="Edit" />
            <asp:ListItem Text="Connect" />
        </asp:DropDownList>
    </div>
    <table style="width:100%; vertical-align:top;">
        <caption>
            Simple WebPart
        </caption>
        <thead>
            <tr>
                <th>
                    WebPart - 1
                </th>
                <th>
                    WebPart -2
                </th>
                <th>
                    WebPart - 3
                </th>
            </tr>
        </thead>
        <tbody style="vertical-align:top;">
            <tr>
                <td style="background-color:green">
                    <asp:WebPartZone Width="100%" runat="server" ID="webPartZone1" HeaderText="Left WebPartZone" BorderColor="#CCCCCC" Font-Names="Verdana" Padding="6">
                        <ZoneTemplate>
                            <uc1:UserControl1 runat="server" ID="UserControl1" title="Choose a date" />
                        </ZoneTemplate>
                        <MenuLabelHoverStyle ForeColor="#FFCC66"></MenuLabelHoverStyle>

                        <MenuLabelStyle ForeColor="White"></MenuLabelStyle>

                        <MenuPopupStyle BackColor="#990000" BorderColor="#CCCCCC" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.6em"></MenuPopupStyle>

                        <MenuVerbHoverStyle BackColor="#FFFBD6" BorderColor="#CCCCCC" BorderWidth="1px" BorderStyle="Solid" ForeColor="#333333"></MenuVerbHoverStyle>

                        <MenuVerbStyle BorderColor="#990000" BorderWidth="1px" BorderStyle="Solid" ForeColor="White"></MenuVerbStyle>

                        <TitleBarVerbStyle Font-Size="0.6em" Font-Underline="False" ForeColor="White"></TitleBarVerbStyle>

                        <EmptyZoneTextStyle Font-Size="0.8em"></EmptyZoneTextStyle>

                        <HeaderStyle HorizontalAlign="Center" Font-Size="0.7em" ForeColor="#CCCCCC"></HeaderStyle>

                        <PartChromeStyle BackColor="#FFFBD6" BorderColor="#FFCC66" Font-Names="Verdana" ForeColor="#333333"></PartChromeStyle>

                        <PartStyle Font-Size="0.8em" ForeColor="#333333"></PartStyle>

                        <PartTitleStyle BackColor="#990000" Font-Bold="True" Font-Size="0.8em" ForeColor="White"></PartTitleStyle>
                    </asp:WebPartZone>
                </td>
                <td style="background-color:white;">
                    <asp:WebPartZone Width="100%" runat="server" ID="webPartZone2" BorderColor="#CCCCCC" Font-Names="Verdana" Padding="6">
                        <ZoneTemplate>
                            <uc1:UserControl2 runat="server" ID="UserControl2" title="Select a file" />
                        </ZoneTemplate>
                        <MenuLabelHoverStyle ForeColor="#FFCC66"></MenuLabelHoverStyle>

                        <MenuLabelStyle ForeColor="White"></MenuLabelStyle>

                        <MenuPopupStyle BackColor="#990000" BorderColor="#CCCCCC" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.6em"></MenuPopupStyle>

                        <MenuVerbHoverStyle BackColor="#FFFBD6" BorderColor="#CCCCCC" BorderWidth="1px" BorderStyle="Solid" ForeColor="#333333"></MenuVerbHoverStyle>

                        <MenuVerbStyle BorderColor="#990000" BorderWidth="1px" BorderStyle="Solid" ForeColor="White"></MenuVerbStyle>

                        <TitleBarVerbStyle Font-Size="0.6em" Font-Underline="False" ForeColor="White"></TitleBarVerbStyle>

                        <EmptyZoneTextStyle Font-Size="0.8em"></EmptyZoneTextStyle>

                        <HeaderStyle HorizontalAlign="Center" Font-Size="0.7em" ForeColor="#CCCCCC"></HeaderStyle>

                        <PartChromeStyle BackColor="#FFFBD6" BorderColor="#FFCC66" Font-Names="Verdana" ForeColor="#333333"></PartChromeStyle>

                        <PartStyle Font-Size="0.8em" ForeColor="#333333"></PartStyle>

                        <PartTitleStyle BackColor="#990000" Font-Bold="True" Font-Size="0.8em" ForeColor="White"></PartTitleStyle>
                    </asp:WebPartZone>
                </td>
                <td style="background-color:red;">
                    <asp:WebPartZone Width="100%" runat="server" ID="webPartZone3" BorderColor="#CCCCCC" Font-Names="Verdana" Padding="6">
                        <ZoneTemplate>
                            <uc1:UserControl3 runat="server" ID="UserControl3" title="Process your data" />
                        </ZoneTemplate>
                        <MenuLabelHoverStyle ForeColor="#FFCC66"></MenuLabelHoverStyle>

                        <MenuLabelStyle ForeColor="White"></MenuLabelStyle>

                        <MenuPopupStyle BackColor="#990000" BorderColor="#CCCCCC" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.6em"></MenuPopupStyle>

                        <MenuVerbHoverStyle BackColor="#FFFBD6" BorderColor="#CCCCCC" BorderWidth="1px" BorderStyle="Solid" ForeColor="#333333"></MenuVerbHoverStyle>

                        <MenuVerbStyle BorderColor="#990000" BorderWidth="1px" BorderStyle="Solid" ForeColor="White"></MenuVerbStyle>

                        <TitleBarVerbStyle Font-Size="0.6em" Font-Underline="False" ForeColor="White"></TitleBarVerbStyle>

                        <EmptyZoneTextStyle Font-Size="0.8em"></EmptyZoneTextStyle>

                        <HeaderStyle HorizontalAlign="Center" Font-Size="0.7em" ForeColor="#CCCCCC"></HeaderStyle>

                        <PartChromeStyle BackColor="#FFFBD6" BorderColor="#FFCC66" Font-Names="Verdana" ForeColor="#333333"></PartChromeStyle>

                        <PartStyle Font-Size="0.8em" ForeColor="#333333"></PartStyle>

                        <PartTitleStyle BackColor="#990000" Font-Bold="True" Font-Size="0.8em" ForeColor="White"></PartTitleStyle>
                    </asp:WebPartZone>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:CatalogZone runat="server" ID="catalogZone" BackColor="#FFFBD6" BorderColor="#CCCCCC" BorderWidth="1px" Font-Names="Verdana" Padding="6">
                        <ZoneTemplate>
                            <asp:PageCatalogPart runat="server" ID="pageCatalogPart" />
                        </ZoneTemplate>
                        <PartLinkStyle Font-Size="0.8em"></PartLinkStyle>

                        <SelectedPartLinkStyle Font-Size="0.8em"></SelectedPartLinkStyle>

                        <EditUIStyle Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333"></EditUIStyle>

                        <HeaderVerbStyle Font-Bold="False" Font-Size="0.8em" Font-Underline="False" ForeColor="#333333"></HeaderVerbStyle>

                        <InstructionTextStyle Font-Size="0.8em" ForeColor="#333333"></InstructionTextStyle>

                        <LabelStyle Font-Size="0.8em" ForeColor="#333333"></LabelStyle>

                        <EmptyZoneTextStyle Font-Size="0.8em" ForeColor="#333333"></EmptyZoneTextStyle>

                        <FooterStyle HorizontalAlign="Right" BackColor="#FFCC66"></FooterStyle>

                        <HeaderStyle BackColor="#FFCC66" Font-Bold="True" Font-Size="0.8em" ForeColor="#333333"></HeaderStyle>

                        <PartChromeStyle BorderColor="#FFCC66" BorderWidth="1px" BorderStyle="Solid"></PartChromeStyle>

                        <PartStyle BorderColor="#FFFBD6" BorderWidth="5px"></PartStyle>

                        <PartTitleStyle BackColor="#990000" Font-Bold="True" Font-Size="0.8em" ForeColor="White"></PartTitleStyle>

                        <VerbStyle Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333"></VerbStyle>
                    </asp:CatalogZone>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:EditorZone runat="server" ID="editorZone" BackColor="#FFFBD6" BorderColor="#CCCCCC" BorderWidth="1px" Font-Names="Verdana" Padding="6">
                        <ZoneTemplate>
                            <asp:LayoutEditorPart runat="server" ID="layoutEditorPart" />
                            <asp:AppearanceEditorPart runat="server" ID="apperanceEditorPart" />
                            <asp:PropertyGridEditorPart runat="server" ID="propertiesEditorPart" />
                        </ZoneTemplate>
                        <EditUIStyle Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333"></EditUIStyle>

                        <HeaderVerbStyle Font-Bold="False" Font-Size="0.8em" Font-Underline="False" ForeColor="#333333"></HeaderVerbStyle>

                        <InstructionTextStyle Font-Size="0.8em" ForeColor="#333333"></InstructionTextStyle>

                        <LabelStyle Font-Size="0.8em" ForeColor="#333333"></LabelStyle>

                        <EmptyZoneTextStyle Font-Size="0.8em" ForeColor="#333333"></EmptyZoneTextStyle>

                        <ErrorStyle Font-Size="0.8em"></ErrorStyle>

                        <FooterStyle HorizontalAlign="Right" BackColor="#FFCC66"></FooterStyle>

                        <HeaderStyle BackColor="#FFCC66" Font-Bold="True" Font-Size="0.8em" ForeColor="#333333"></HeaderStyle>

                        <PartChromeStyle BorderColor="#FFCC66" BorderWidth="1px" BorderStyle="Solid"></PartChromeStyle>

                        <PartStyle BorderColor="#FFFBD6" BorderWidth="5px"></PartStyle>

                        <PartTitleStyle Font-Bold="True" Font-Size="0.8em" ForeColor="#333333"></PartTitleStyle>

                        <VerbStyle Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333"></VerbStyle>
                    </asp:EditorZone>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:ConnectionsZone runat="server" ID="connectionsZone" BackColor="#FFFBD6" BorderColor="#CCCCCC" BorderWidth="1px" Font-Names="Verdana" Padding="6">
                        <EditUIStyle Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333"></EditUIStyle>

                        <HeaderVerbStyle Font-Bold="False" Font-Size="0.8em" Font-Underline="False" ForeColor="#333333"></HeaderVerbStyle>

                        <InstructionTextStyle Font-Size="0.8em" ForeColor="#333333"></InstructionTextStyle>

                        <LabelStyle Font-Size="0.8em" ForeColor="#333333"></LabelStyle>

                        <FooterStyle HorizontalAlign="Right" BackColor="#FFCC66"></FooterStyle>

                        <HeaderStyle BackColor="#FFCC66" Font-Bold="True" Font-Size="0.8em" ForeColor="#333333"></HeaderStyle>

                        <VerbStyle Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333"></VerbStyle>
                    </asp:ConnectionsZone>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
