<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="MsAjaxControls.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson01___MS_AJAX.MsAjaxControls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        MS AJAX controls
    </h1>
    <asp:Button Text="Full postback" runat="server" />
    <div>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0">
            <ProgressTemplate>
                Updating...
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
    <asp:UpdatePanel runat="server" ID="parentUpdatePanel" 
        ChildrenAsTriggers="true" UpdateMode="Always">
        <ContentTemplate>
            <asp:Panel runat="server" BackColor="Yellow">
                <h3>
                    This is inside an UpdatePanel with UpdateMode = Always
                </h3>
                <div>
                    <asp:Button Text="Partial post" runat="server" />
                </div>
                <div>
                    <%: DateTime.Now.ToString() %>
                </div>
                <div>
                    <asp:UpdateProgress runat="server" DisplayAfter="0">
                        <ProgressTemplate>
                            Updating...
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="triggerButton" EventName="Click" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel runat="server" BackColor="LightBlue">
                <h3>
                    This is inside an UpdatePanel with UpdateMode = Conditional and ChildrenAsTriggers = false
                </h3>
                <div>
                    <asp:Button ID="Button1" Text="Partial post" runat="server" />
                </div>
                <div>
                    <%: DateTime.Now.ToString() %>
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <asp:Panel runat="server" BackColor="AliceBlue">
                            <h3>
                                This is in a nested UpdatePanel with UpdateMode = Always and ChildrenAsTriggers = true
                            </h3>
                            <div>
                                <asp:Button ID="Button2" Text="Partial post" runat="server" />
                            </div>
                            <div>
                                <%: DateTime.Now.ToString() %>
                            </div>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                    <ContentTemplate>
                        <asp:Panel runat="server" BackColor="LightCoral">
                            <h3>
                                This is another nested UpdatePanel with UpdateMode = Conditional and ChildrenAsTriggers = false
                            </h3>
                            <div>
                                <asp:Button Text="Partial post" runat="server" />
                            </div>
                            <div>
                                <%: DateTime.Now.ToString() %>
                            </div>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <asp:Panel runat="server" BackColor="White">
                            <h3>
                                Anooother Nested UpdatePanel with UpdateMode = Conditional and ChildrenAsTriggers = true
                            </h3>
                            <div>
                                <asp:Button Text="Partial post" runat="server" />
                            </div>
                            <div>
                                <%: DateTime.Now.ToString() %>
                            </div>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <asp:Panel runat="server" BackColor="Violet">
                            <h3>
                                Yet another nested UpdatePanel with UpdateMode = Conditional and ChildrenAsTriggers = true
                                This UpdatePanel contains a button and this button will be used as trigger
                                for the outer UpdatePanel...
                                Therefore, clicking the button on this UpdatePanel will cause the
                                outer UpdatePanel to update itself which in turn will cause, all
                                child UpdatePanels to update
                            </h3>
                            <div>
                                <asp:Button Text="Partial Post" runat="server" ID="triggerButton" />
                            </div>
                            <div>
                                <%: DateTime.Now.ToString() %>
                            </div>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div>
                    End of parent panel
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel runat="server" UpdateMode="Always" ChildrenAsTriggers="true">
        <ContentTemplate>
            <asp:Panel runat="server" BackColor="LightGoldenrodYellow">
                <h3>
                    This UpdatePanel has UpdateMode = Always and ChildrenAsTriggers = true
                </h3>
                <div>
                    <asp:Button Text="Partial Post" runat="server" />
                </div>
                <div>
                    <%: DateTime.Now.ToString() %>
                </div>
                <asp:UpdatePanel runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                    <ContentTemplate>
                        <asp:Panel runat="server" BackColor="Fuchsia">
                            <h3>
                                This is a nested UpdatePanel has UpdateMode = Conditional and ChildrenAsTriggers = false
                            </h3>
                            <div>
                                <asp:Button Text="Partial Post" runat="server" />
                            </div>
                            <div>
                                <%: DateTime.Now.ToString() %>
                            </div>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div>
                    End of parent panel
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
        <ContentTemplate>
            <asp:Panel runat="server" BackColor="Pink">
                <h3>
                    This panel has UpdateMode = Conditional and ChildrenAsTriggers = true
                </h3>
                <div>
                    <asp:Button Text="Partial Post" runat="server" />
                </div>
                <div>
                    <%: DateTime.Now.ToString() %>
                </div>
                <div>
                    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <asp:Panel runat="server" BackColor="LawnGreen">
                                <h3>
                                    This nested UpdatePanel has UpdateMode = Conditional and childrenAsTriggers = true
                                </h3>
                                <div>
                                    <asp:Button Text="Partial Post" runat="server" />
                                </div>
                                <div>
                                    <%: DateTime.Now.ToString() %>
                                </div>
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div>
                    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                        <ContentTemplate>
                            <asp:Panel runat="server" BackColor="LightSeaGreen">
                                <h3>
                                    Another nested UpdatePanel with UpdateMode = Conditional and ChildrenAsTriggers = false
                                </h3>
                                <div>
                                    <asp:Button Text="Partial post" runat="server" />
                                </div>
                                <div>
                                    <%: DateTime.Now.ToString() %>
                                </div>
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div>
                    End of parent panel
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
