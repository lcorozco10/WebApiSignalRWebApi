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

.controller("AppController", ["SignalrService", function (SignalrService) {
    SignalrService.initialize();
}]);


/*
 var contosoChatHubProxy = $.connection.chatHub;
    contosoChatHubProxy.client.AddCustomChatMessageToPage = function (name, message) {
        console.log(name + ' ' + message);
    };
    var x;
    $.connection.hub.start()
    .done(function() {
        console.log('Now connected, connection ID=' + $.connection.hub.id);
        $.connection.hub.received(function (data) {
            console.log(data.A[0]);
            x = data;
            contosoChatHubProxy.client.addCustomChatMessageToPage = function (message) {
                console.log(message.UserName + ' ' + message.Message);
            };

        });

        })
    .fail(function () { console.log('Could not connect'); });


*/