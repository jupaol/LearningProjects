<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="WorkingWithProfilesOnTheClientSide.aspx.cs" Inherits="Msts.Topics.Chapter13___Profiles_and_security.Lesson01___Profiles.WorkingWithProfilesOnTheClientSide" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        $(function () {
            var $loadProfile = $("#loadProfile");
            var $waitDialog = $("#waitDialog");
            var $profileDialog = $("#profileDialog");
            var $masterPage = $("#masterPage", $profileDialog);
            var $saveProfile = $("#saveProfile", $profileDialog);
            var viewModel = {
                masterPage: ko.observable(),
                profileLoaded: ko.observable(false),
                theme: ko.observable(),
                language: ko.observable(),
                lastLogin: ko.observable()
            };

            Sys.Services.ProfileService.load(null, function (msg) {
                console.log("%o", msg);
                console.log("%o", Sys.Services.ProfileService.properties);
                viewModel.masterPage(Sys.Services.ProfileService.properties.MasterPage);
                viewModel.theme(Sys.Services.ProfileService.properties.Theme);
                viewModel.language(Sys.Services.ProfileService.properties.Language);
                viewModel.lastLogin(Sys.Services.ProfileService.properties.LastLogin);

                viewModel.profileLoaded(true);
            }, function (error) {

            }, null);

            $profileDialog.dialog({
                modal: true,
                autoOpen: false
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
                alert("before validate");
                $(this).closest("form").validate();
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
        <form>
        <div>
            <fieldset>
                <legend>
                    Edit profile settings
                </legend>
                <div>
                    <label for="masterPage">Master Page</label>
                </div>
                <div>
                    <input type="text" id="masterPage" data-bind="value: masterPage" class="required" />
                </div>
                <div>
                    <label for="theme">Theme</label>
                </div>
                <div>
                    <input type="text" id="theme" data-bind="value: theme" />
                </div>
                <div>
                    <label for="language">Language</label>
                </div>
                <div>
                    <input type="text" id="language" data-bind="value: language" />
                </div>
                <div>
                    <a href="#" id="saveProfile">Save Profile</a>
                </div>
            </fieldset>
        </div>
        </form>
    </div>
</asp:Content>
