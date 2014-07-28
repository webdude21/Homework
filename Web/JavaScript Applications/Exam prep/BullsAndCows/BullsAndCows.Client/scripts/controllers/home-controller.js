'use strict';

bullsAndCows.controller('HomeController',
    function HomeController($scope, $location, dataProvider) {
        if (!dataProvider.isUserLoggedIn()){
            $location.path("/login");
            return;
        }

        $.scope.userSession.nickname = dataProvider.user.getNickname();
    });