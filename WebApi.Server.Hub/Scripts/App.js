'use strict';

angular.module("AspNetWebApiSignalRDemo", [])

.service("SignalrService", function () {
    var notificationHubProxy = null;

    this.initialize = function () {
        $.connection.hub.logging = true;
        notificationHubProxy = $.connection.chatHub;

        notificationHubProxy.client.CustomData = function (rq,t) {
            console.log(rq.Name + ": " + rq.Message);
            console.log(t);

        };

        $.connection.hub.start().done(function () {
            console.log("started");
        }).fail(function (result) {
            console.log(result);
        });
    };
})

.controller("AppController", ["SignalrService", function (signalrService) {
    signalrService.initialize();
}]);