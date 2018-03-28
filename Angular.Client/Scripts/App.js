'use strict';

angular.module("AspNetWebApiSignalRDemo", [])

    .service("SignalrService", function () {
        var notificationHubProxy = null;

        this.initialize = function () {

            var chatHub = $.connection.chatHub;
            $.connection.hub.url = "http://localhost:4201/signalr";
            // Declare a function on the chat hub so the server can invoke it          
            // Create a function that the hub can call to broadcast messages.
            chatHub.client.CustomData = function (rq, t) {
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