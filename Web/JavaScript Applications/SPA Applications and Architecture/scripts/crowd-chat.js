'use strict';

var crowdChat = angular
    .module('crowdChat', ['ngRoute'])
    .config(function ($routeProvider) {
        $routeProvider
            .when('/chat', {
                templateUrl: 'templates/chat.html'
            })
            .otherwise({redirectTo: '/chat'});
    });