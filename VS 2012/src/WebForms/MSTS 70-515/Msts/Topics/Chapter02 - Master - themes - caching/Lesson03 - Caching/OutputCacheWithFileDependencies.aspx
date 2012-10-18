<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="OutputCacheWithFileDependencies.aspx.cs" Inherits="Msts.Topics.Chapter02.Lesson03.OutputCacheWithFileDependencies" %>
<%@ OutputCache CacheProfile="filesDependency" VaryByParam="none" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Outputcache with file dependency
    </h1>
    <h2>
        This page is cached for 30 seconds (using cache profiles).
    </h2>
    <h3>
        The output cache for this page contains a dependency to a physical file on the server
    </h3>
    <div>
        Rendered time: <b><asp:Literal runat="server" ID="msg" Mode="Encode"></asp:Literal></b>
    </div>
    <div>
        Current time: <b><asp:Substitution ID="Substitution1" runat="server" MethodName="CustomSubstitution" /></b>
    </div>
    <hr />
    <div>
        <div>
            <b>
                File content
            </b>
        </div>
        <div>
            <asp:Literal runat="server" ID="fileContent" Mode="Encode">

            </asp:Literal>
        </div>
    </div>
</asp:Content>
