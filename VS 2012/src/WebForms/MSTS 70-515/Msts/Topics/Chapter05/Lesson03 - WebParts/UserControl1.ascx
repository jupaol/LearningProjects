<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserControl1.ascx.cs" Inherits="Msts.Topics.Chapter05.Lesson03___WebParts.UserControl1" %>

<asp:Calendar OnSelectionChanged="calendar_SelectionChanged" runat="server" ID="calendar" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" Width="220px">

    <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px"></DayHeaderStyle>

    <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC"></NextPrevStyle>

    <OtherMonthDayStyle ForeColor="#CC9966"></OtherMonthDayStyle>

    <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True"></SelectedDayStyle>

    <SelectorStyle BackColor="#FFCC66"></SelectorStyle>

    <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC"></TitleStyle>

    <TodayDayStyle BackColor="#FFCC66" ForeColor="White"></TodayDayStyle>
</asp:Calendar>

<asp:Panel runat="server" GroupingText="Postal code summary">
    <asp:Literal ID="msg" runat="server" />
</asp:Panel>
