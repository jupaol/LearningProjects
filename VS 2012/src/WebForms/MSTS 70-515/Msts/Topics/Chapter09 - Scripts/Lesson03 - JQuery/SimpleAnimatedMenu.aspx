<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="SimpleAnimatedMenu.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery.SimpleAnimatedMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        $(function () {
            var $menu = $("#menu");
            var $items = $(".menu-item", $menu);
            var $titles = $(".menu-title", $items);
            var $contents = $(".menu-content", $items);

            $menu.css("cursor", "pointer");

            $items.hover(function () {
                $(".menu-content", $(this)).stop().slideDown('slow');
            }, function () {
                $(".menu-content", $(this)).stop().slideUp('slow');
            });

            $contents.hide();
        });
    </script>
    <h1>
        Simple JQuery animated menu
    </h1>
    <div id="menu">
        <div class="menu-item">
            <div class="menu-title">
                Menu 1
            </div>
            <div class="menu-content">
                Menu 1 content
            </div>
        </div>
        <div class="menu-item">
            <div class="menu-title">
                Menu 2
            </div>
            <div class="menu-content">
                Menu 2 content
            </div>
        </div>
        <div class="menu-item">
            <div class="menu-title">
                Menu 3
            </div>
            <div class="menu-content">
                Menu 3 content
            </div>
        </div>
    </div>
</asp:Content>
