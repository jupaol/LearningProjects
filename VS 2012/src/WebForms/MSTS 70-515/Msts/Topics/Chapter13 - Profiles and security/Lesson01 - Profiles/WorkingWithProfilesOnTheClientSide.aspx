<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="WorkingWithProfilesOnTheClientSide.aspx.cs" Inherits="Msts.Topics.Chapter13___Profiles_and_security.Lesson01___Profiles.WorkingWithProfilesOnTheClientSide" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        $(function () {
            var $loadProfile = $("#loadProfile");
            var $waitDialog = $("#waitDialog");
            var $profileDialog = $("#profileDialog");
            var $profileInfo = $("#profileInfo");
            var $saveProfile = $("#saveProfile", $profileDialog);
            var $masterPage = $("input:text[id$=masterPage]", $profileDialog);
            var $theme = $("input:text[id$=theme]", $profileDialog);
            var $language = $("input:text[id$=language]", $profileDialog);
            var formValidation;
            var viewModel = {
                masterPage: ko.observable(),
                profileLoaded: ko.observable(false),
                theme: ko.observable(),
                language: ko.observable(),
                lastLogin: ko.observable()
            };

            function loadProfile() {
                $profileInfo.hide();

                Sys.Services.ProfileService.load(null, function (msg) {
                    console.log("%o", msg);
                    console.log("%o", Sys.Services.ProfileService.properties);
                    viewModel.masterPage(Sys.Services.ProfileService.properties.MasterPage);
                    viewModel.theme(Sys.Services.ProfileService.properties.Theme);
                    viewModel.language(Sys.Services.ProfileService.properties.Language);
                    viewModel.lastLogin(Sys.Services.ProfileService.properties.LastLogin);

                    viewModel.profileLoaded(true);

                    $profileInfo.show();
                }, function (error) {

                }, null);
            }

            loadProfile();

            $profileDialog.dialog({
                modal: true,
                autoOpen: false,
                open: function (e, ui) {
                    $(this).parent().appendTo("form");
                    formValidation = $(this).closest("form").validate();
                }
            });

            $waitDialog.dialog({
                modal: true,
                autoOpen: false,
                closeOnEscape: false,
                open: function (e, ui) {
                    $(this).closest(".ui-dialog").find(".ui-dialog-titlebar-close").hide();
                }
            });

            $loadProfile.click(function (e) {
                e.preventDefault();

                $profileDialog.dialog("open");
            });

            $saveProfile.click(function (e) {
                e.preventDefault();

                $waitDialog.dialog("open");

                Sys.Services.ProfileService.properties.MasterPage = $masterPage.val();
                Sys.Services.ProfileService.properties.Theme = $theme.val();
                Sys.Services.ProfileService.properties.Language = $language.val();

                Sys.Services.ProfileService.save(
                    null,
                    function (msg) {
                        console.log("msg: %o", msg);
                        $waitDialog.dialog("close");
                        $profileDialog.dialog("close");
                    },
                    function (err) {
                        console.log("error: %o", err);
                        $waitDialog.dialog("close");
                    },
                    null);
            });

            ko.applyBindings(viewModel);
        });
    </script>
    <asp:ScriptManagerProxy runat="server" ID="smp">
        <ProfileService />
    </asp:ScriptManagerProxy>
    <h1>
        User profiles
    </h1>
    <h2>
        On the client side
    </h2>
    <h3>
        After saving the profile settings refresh the page to see your new values applied
    </h3>

    <div id="#profileInfo" data-bind="visible: profileLoaded">
        <div><span><b>MasterPage:</b></span></div>
        <div><span data-bind="text: masterPage"></span></div>
        <div><span><b>Theme:</b></span></div>
        <div><span data-bind="text: theme"></span></div>
        <div><span><b>Language:</b></span></div>
        <div><span data-bind="text: language"></span></div>
        <div><span><b>Last Login:</b></span></div>
        <div><span data-bind="text: lastLogin"></span></div>
    </div>

    <a href="#" id="loadProfile">Update Profile</a>

    <div id="waitDialog" style="display:none;">
        <div>
            Loading...
        </div>
    </div>
    <div id="profileDialog" style="display:none;">
        <div>
            <fieldset>
                <legend>
                    Edit profile settings
                </legend>
                <div>
                    <asp:Label Text="MasterPage" runat="server" AssociatedControlID="masterPage" />
                </div>
                <div>
                    <asp:TextBox runat="server" ID="masterPage" data-bind="value: masterPage" />
                </div>
                <div>
                    <asp:Label Text="Theme" runat="server" AssociatedControlID="theme" />
                </div>
                <div>
                    <asp:TextBox runat="server" ID="theme" data-bind="value: theme" />
                </div>
                <div>
                    <asp:Label Text="Language" runat="server" AssociatedControlID="language" />
                </div>
                <div>
                    <asp:TextBox runat="server" ID="language" data-bind="value: language" />
                </div>
                <div>
                    <a href="#" id="saveProfile">Save Profile</a>
                </div>
            </fieldset>
        </div>
    </div>
</asp:Content>
