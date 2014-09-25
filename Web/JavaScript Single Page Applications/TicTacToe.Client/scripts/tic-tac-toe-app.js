'use strict';

var ticTacToeApp = angular
    .module('ticTacToeApp', ['ngResource', 'ngRoute'])
    .config(function($routeProvider, $httpProvider) {
        $routeProvider
            .when('/home', {
                templateUrl: 'templates/home.html'
            })
            .when('/login', {
                templateUrl: 'templates/login.html'
            })
            .when('/signup', {
                templateUrl: 'templates/signup.html'
            })
            .when('/join', {
                templateUrl: 'templates/game.html'
            })
            .when('/create', {
                templateUrl: 'templates/create.html'
            })
            .when('/list-games', {
                templateUrl: 'templates/list-games.html'
            })
            .when('/game/:id', {
                templateUrl: 'templates/game.html'
            })
            .otherwise({redirectTo: '/home'});
    })
    .constant('baseUrl', 'http://localhost:33257')
    .constant('author', 'Webdude')
    .constant('authorLink', 'http://webdude.eu');