<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02 - Master - themes - caching/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="CloningDomWithJQuery.aspx.cs" Inherits="Msts.Topics.Chapter09___Scripts.Lesson03___JQuery.CloningDomWithJQuery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .highlight {
            background-color:yellow;
            cursor: pointer;
        }
    </style>
    <script>
        $(function () {
            var $addNew = $("#addNew");
            var $fileUploads = $("#fileUploads");
            var index = 1;
            var fileBaseName = "file";
            var $fileItems = $(".file-item", $fileUploads);

            $addNew.button();

            $fileItems.hover(function () {
                $(this).toggleClass("highlight");
            }, function () {
                $(this).toggleClass("highlight");
            });

            $addNew.on("click", function (e) {
                e.preventDefault();

                var $target = $fileUploads.find(".file-item:first");
                var $clone = $target.clone(true);
                var $delete = $("<input type='button' value='Remove' />");

                index++;

                $clone.find("label:first").attr("for", fileBaseName + index);
                $clone.find("input:file:first").attr("id", fileBaseName + index);
                $delete.attr("id", "remove" + index);
                $delete.click(removeItem).button();
                $clone.append($delete);

                $fileUploads.append($clone).fadeOut("slow").fadeIn("slow");
            });

            function removeItem(e) {
                e.preventDefault();
                $(this).closest(".file-item").fadeOut("slow", function (x) {
                    $(x).remove();
                });
                index--;
            }
        });
    </script>
    <h1>
        Cloning DOM elements with JQuery
    </h1>
    <div id="fileUploads">
        <div class="file-item">
            <div>
                <hr />
                <div>
                    <label for="file1">
                        Please select a file:
                    </label>
                </div>
                <div>
                    <input type="file" id="file1" />
                </div>
            </div>
        </div>
    </div>
    <hr />
    <div class="actions">
        <div>
            <label for="addNew">
                If you want to upload additional files click 'Add new...'
            </label>
            <input type="button" id="addNew" value="Add new..." />
        </div>
    </div>
</asp:Content>
