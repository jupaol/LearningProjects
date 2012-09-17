<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="TestingTheClientIdMode.aspx.cs" Inherits="Msts.Topics.Chapter04.Lesson01___Server_Controls.TestingTheClientIdMode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Testing the client ID Mode
    </h1>
    <fieldset>
        <legend>
            <h2>
                Non-bound controls
            </h2>
        </legend>
        <div>
            <asp:Label ID="nbAutoid" ClientIDMode="AutoID" Text="Im an AutoID" runat="server" />
            <br />
            <b><%: this.nbAutoid.ClientID %></b>
        </div>
        <div>
            <asp:Label ID="nbInherit" ClientIDMode="Inherit" Text="Im an Inherit" runat="server" />
            <br />
            <b><%: this.nbInherit.ClientID %></b>
        </div>
        <div>
            <asp:Label ID="nbPredictable" ClientIDMode="Predictable" Text="Im a Predictable" runat="server" />
            <br />
            <b><%: this.nbPredictable.ClientID %></b>
        </div>
        <div>
            <asp:Label ID="nbStatic" ClientIDMode="Static" Text="Im a Static" runat="server" />
            <br />
            <b><%: this.nbStatic.ClientID %></b>
        </div>
    </fieldset>
    <asp:LinqDataSource runat="server" ID="lds"
        ContextTypeName="Msts.DataAccess.PubsDataContext"
        TableName="jobs">
    </asp:LinqDataSource>
    <fieldset>
        <legend>
            <h2>
                Bound controls
            </h2>
            <div>
                <asp:GridView runat="server" ID="gv" DataSourceID="lds" 
                    OnRowDataBound="gv_RowDataBound" AutoGenerateColumns="false" PageSize="1" AllowPaging="true"
                    ClientIDRowSuffix="job_id">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <div>
                                    <asp:Label ID="bAutoID" ClientIDMode="AutoID" Text="Im an AutoID" runat="server" />
                                    <br />
                                    <b><asp:Literal runat="server" ID="bAutoIDmsg"></asp:Literal></b>
                                </div>
                                <div>
                                    <asp:Label ID="bInherit" ClientIDMode="Inherit" Text="Im an Inherit" runat="server" />
                                    <br />
                                    <b><asp:Literal runat="server" ID="bInheritMsg"></asp:Literal></b>
                                </div>
                                <div>
                                    <asp:Label ID="bPredicatble" ClientIDMode="Predictable" Text="Im a Predictable" runat="server" />
                                    <br />
                                    <b><asp:Literal runat="server" ID="bPredicatbleMsg"></asp:Literal></b>
                                </div>
                                <div>
                                    <asp:Label ID="bStatic" ClientIDMode="Static" Text="Im a Static" runat="server" />
                                    <br />
                                    <b><asp:Literal runat="server" ID="bStaticMsg"></asp:Literal></b>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </legend>
    </fieldset>
</asp:Content>
