'use strict';

var ticTacToeApp = angular
    .module('ticTacToeApp', ['ngResource', 'ngRoute', 'ngCookies', 'ngSanitize'])
    .config(function($routeProvider) {
        $routeProvider
            .when('/login', {
                templateUrl: 'templates/login.html'
            })
            .when('/register', {
                templateUrl: 'templates/register.html'
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
    .value('toastr', toastr)
    .constant('baseUrl', 'http://localhost:33257')
    .constant('author', 'Webdude')
    .constant('appName', 'TicTacToe')
    .constant('authorLink', 'http://webdude.eu');