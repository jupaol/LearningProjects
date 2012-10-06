<%@ Page Title="" Language="C#" MasterPageFile="~/Topics/Chapter02/Lesson01 - MasterPages/ClassicMaster.Master" AutoEventWireup="true" CodeBehind="ParsingGeoLocationUsingLinqToXml.aspx.cs" Inherits="Msts.Topics.Chapter11___LINQ.Lesson01___LINQ_to_Objects.ParsingGeoLocationUsingLinqToXml" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
    div#map{
	    width:100%;
	    height:350px;
    }
    </style>
    <script src="http://maps.googleapis.com/maps/api/js?sensor=false"></script>
    <script>
        $(function () {
            var $call = $("input:submit[id$=call]");
            var $target = $("input:text[id$=target]");
            var $map = $("#map");
            var viewModel = {
                ip1: ko.observable(""),
                countryCode: ko.observable(""),
                regionCode: ko.observable(""),
                regionName: ko.observable(""),
                zipCode: ko.observable(""),
                MetroCode: ko.observable(""),
                Latitude: ko.observable(""),
                Longitude: ko.observable("")
            };

            $call.click(function (e) {
                e.preventDefault();

                $.ajax({
                    url: "<%: this.ResolveClientUrl("~/Topics/Chapter11%20-%20LINQ/Lesson01%20-%20LINQ%20to%20Objects/ParsingGeoLocationUsingLinqToXml.aspx/GetIPLocation") %>",
                    type: "POST",
                    contentType: "application/json; charset=utf-8;",
                    dataType: "json",
                    data: "{ip:'"+$target.val()+"'}",
                    async: true,
                    cache: false,
                    success: function (msg) {
                        //console.log(msg);
                        //console.log($(msg));
                        //console.log($(msg).text());

                        //var $xml = $(msg);

                        //console.log($xml);
                        //console.log($xml.find("DomainUser"));
                        //console.log($xml.find("DomainUser").find("FirstName"));
                        //console.log($xml.find("DomainUser").find("FirstName").text());
                        
                        //viewModel.ip1($xml.find("DomainUser").find("FirstName").eq(0).text());

                        console.log("msg: %o", msg.d);

                        viewModel.ip1(msg.d.IP);
                        viewModel.countryCode(msg.d.CountryCode);
                        viewModel.regionCode(msg.d.RegionCode);
                        viewModel.regionName(msg.d.RegionName);
                        viewModel.zipCode(msg.d.ZipCode);
                        viewModel.MetroCode(msg.d.MetroCode);
                        viewModel.Latitude(msg.d.Latitude);
                        viewModel.Longitude(msg.d.Longitude);

                        var model = ko.mapping.fromJS(viewModel, ko.mapping.fromJS(msg.d));

                        ko.applyBindings(model);

                        console.log("combined model: %o", model);

                        loadMap();
                    },
                    error: function (XHResponse, errorMessage, errorCode) {
                        console.log("AJAX Error: %o", XHResponse);
                        $call.prop("disabled", false);
                    },
                    beforeSend: function () {
                        $call.prop("disabled", true);
                    },
                    complete: function () {
                        $call.prop("disabled", false);
                    }
                });
            });

            function loadMap() {
                var la = new google.maps.LatLng(viewModel.Latitude(), viewModel.Longitude());
                //var la = new google.maps.LatLng(37.4192, -122.057);
                var opt = {
                    zoom: 4,
                    center: la,
                    mapTypeId: google.maps.MapTypeId.ROADMAP
                };
                var map = new google.maps.Map(document.getElementById("map"), opt);
                var marker = new google.maps.Marker({
                    position: la,
                    map: map,
                    title: "IP/Domain location"
                });
            }
        });
    </script>
    <h1>
        Parsing IP Geo-Location XML results from: <a href="http://freegeoip.net/static/index.html">http://freegeoip.net/static/index.html</a>
        and showing the results using Google maps API
    </h1>
    <div>
        <asp:Label ID="Label1" Text="Enter IP or domain (google.com)" runat="server" AssociatedControlID="target" />
    </div>
    <div>
        <asp:TextBox runat="server" ID="target" Text="google.com" />
    </div>
    <div>
        <asp:Button Text="Call Service" runat="server" ID="call" />
    </div>
    <div>
        <div id="res">
            <div>
                <b>IP:</b> <span data-bind="text: ip1"></span>
            </div>
            <div>
                <b>
                    Country code:
                </b>
                <span data-bind="text: countryCode"></span>
            </div>
            <div>
                <b>
                    Region code:
                </b>
                <span data-bind="text: regionCode"></span>
            </div>
            <div>
                <b>
                    Region name:
                </b>
                <span data-bind="text: regionName"></span>
            </div>
            <div>
                <b>
                    Zipcode:
                </b>
                <span data-bind="text: zipCode"></span>
            </div>
            <div>
                <b>
                    Metro code:
                </b>
                <span data-bind="text: MetroCode"></span>
            </div>
            <div>
                <b>
                    Latitude:
                </b>
                <span data-bind="text: Latitude"></span>
            </div>
            <div>
                <b>
                    Longitude:
                </b>
                <span data-bind="text: Longitude"></span>
            </div>
            <div>
                <b>
                    Country Info:
                </b>
                <span data-bind="text: Country.Name"></span>
            </div>
        </div>
    </div>
    <div>
        <div id="map">

        </div>
    </div>
</asp:Content>
