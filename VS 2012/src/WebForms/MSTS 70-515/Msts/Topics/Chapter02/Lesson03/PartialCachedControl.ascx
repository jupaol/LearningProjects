<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PartialCachedControl.ascx.cs" Inherits="Msts.Topics.Chapter02.Lesson03.PartialCachedControl" %>
<%@ OutputCache Shared="false" Duration="15" VaryByParam="none" %>

<div style="background-color:lightcoral;">
    <h2>Last time this control was processed (This control is cached for 15 seconds):</h2>
    <h3>
        <asp:Label ID="msg" runat="server" />
    </h3>
</div>
