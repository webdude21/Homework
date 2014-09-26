'use strict';

var ticTacToeApp = angular
    .module('ticTacToeApp', ['ngResource', 'ngRoute', 'ngCookies', 'ngSanitize'])
    .config(function($routeProvider) {
        $routeProvider
            .when('/login', {
                templateUrl: 'templates/login.html'
            })
            .when('/signup', {
                templateUrl: 'templates/signup.html'
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
            .otherwise({redirectTo: '/list-games'});
    })
    .constant('baseUrl', 'http://localhost:33257')
    .constant('author', 'Webdude')
    .constant('appName', 'TicTacToe')
    .constant('authorLink', 'http://webdude.eu');