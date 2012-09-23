<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="PartialOutputCaching.aspx.cs" Inherits="Msts.Topics.Chapter02.Lesson03.PartialOutputCaching" %>
<%@ OutputCache Duration="30" VaryByParam="*" %>
<%@ Register Src="~/Topics/Chapter02/Lesson03 - Caching/PartialCachedControl.ascx" TagPrefix="uc1" TagName="PartialCachedControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="background-color:lightgreen;">
        <h1>
            Partial page cache
        </h1>
        <h2>
            This page is cached for 30 seconds
        </h2>
        <h3>
            Last time this page was processed: <asp:Literal ID="msg" runat="server" />
        </h3>
        <div>
            <b>Current time (using substitution):</b> <asp:Substitution runat="server" MethodName="CustomSubstitution" />
        </div>
        <div>
            Note:
            <p>
                Since this page has more cache duration than the control, the whole page including 
                the control will be cached for the whole page's cache duration time
            </p>
        </div>
    </div>
    <uc1:PartialCachedControl runat="server" id="PartialCachedControl" />
</asp:Content>
