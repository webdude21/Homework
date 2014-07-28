'use strict';

var bullsAndCows = angular
    .module('bullsAndCows', ['ngRoute'])
    .config(function ($routeProvider) {
        $routeProvider
            .when('/home', {
                templateUrl: 'templates/home.html'
            })
            .when('/login', {
                templateUrl: 'templates/login.html'
            })
            .otherwise({redirectTo: '/home'});
    });