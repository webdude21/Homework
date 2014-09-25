'use strict';

ticTacToeApp.controller('ListGamesController',
    function ListGamesController($scope, identity, auth, messageBox, $location, GameResource) {
        var MESSAGE_BOX_SELECTOR = '#message-box';
        var LOGIN_BEFORE_GETTING_THE_LIST = 'You must login in to view the available games!';

        if (!identity.isAuthenticated()) {
            $location.path('/signup');
            messageBox.error(LOGIN_BEFORE_GETTING_THE_LIST, MESSAGE_BOX_SELECTOR);
            return;
        }

        GameResource.getAllGames().success(function (games) {
            $scope.gameList = games;
        });

    });
