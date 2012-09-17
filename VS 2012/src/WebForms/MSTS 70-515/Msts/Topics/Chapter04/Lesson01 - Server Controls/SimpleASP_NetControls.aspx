<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="SimpleASP_NetControls.aspx.cs" Inherits="Msts.Topics.Chapter04.Lesson01___Server_Controls.SimpleASP_NetControls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Simple ASP.Net server controls
    </h1>
    <h2>
        Check the rendered HTML
    </h2>
    <div>
        <asp:Button Text="Button" runat="server" ID="button" />
    </div>
    <div>
        <asp:CheckBox Text="Checkbox" runat="server" ID="checkbox" Checked="true" />
    </div>
    <div>
        <asp:DropDownList runat="server" ID="dropDownList">
            <asp:ListItem Text="text1" Enabled="false" />
            <asp:ListItem Text="text2" Selected="True" />
        </asp:DropDownList>
    </div>
    <div>
        <asp:FileUpload runat="server" ID="fileUpload" />
    </div>
    <div>
        <asp:HiddenField runat="server" ID="hiddenField" Value="some hidden value" />
    </div>
    <div>
        <asp:HyperLink runat="server" ID="hyperLink" Text="Link text" NavigateUrl="navigateUrl"></asp:HyperLink>
    </div>
    <div>
        <asp:Image runat="server" ID="image" ImageUrl="someImageUrl" />
    </div>
    <div>
        <asp:ImageButton runat="server" ID="imageButton" AlternateText="alternate text" ImageUrl="anotherImageUrl" />
    </div>
    <div>
        <asp:ImageMap runat="server" ID="imageMap" ImageUrl="mappurl">
            <asp:CircleHotSpot />
            <asp:PolygonHotSpot />
            <asp:RectangleHotSpot />
        </asp:ImageMap>
    </div>
    <div>
        <asp:Label runat="server" ID="label" Text="Im a label"></asp:Label>
    </div>
    <div>
        <asp:LinkButton runat="server" ID="linkButton" Text="Link button"></asp:LinkButton>
    </div>
    <div>
        <asp:ListBox runat="server" ID="listBox" SelectionMode="Multiple">
            <asp:ListItem Text="text1" Enabled="false" />
            <asp:ListItem Text="text2" Selected="True" />
        </asp:ListBox>
    </div>
    <div>
        <asp:Literal Text="Literal text" runat="server" ID="literal" />
    </div>
    <div>
        <asp:Localize runat="server" ID="localize" Text="localize text"></asp:Localize>
    </div>
    <div>
        <asp:Panel runat="server" ID="panel"></asp:Panel>
    </div>
    <div>
        <asp:PlaceHolder runat="server" ID="placeHolder"></asp:PlaceHolder>
    </div>
    <div>
        <asp:RadioButton runat="server" ID="radioButton" Text="some radio text1" Checked="true" GroupName="radioGroup" />
    </div>
    <div>
        <asp:RadioButton runat="server" ID="radioButton1" Text="some radio text2" Checked="true" GroupName="radioGroup" />
    </div>
    <div>
        <asp:RadioButtonList runat="server" ID="radioButtonList">
            <asp:ListItem Text="text1" Value="text1value1" Enabled="false" />
            <asp:ListItem Text="text2" Value="textvalue2" Selected="True" />
        </asp:RadioButtonList>
    </div>
    <div>
        <asp:TextBox runat="server" Text="textbox text" ID="textbox" />
    </div>
</asp:Content>              
