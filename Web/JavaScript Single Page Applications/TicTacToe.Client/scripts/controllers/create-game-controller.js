'use strict';

ticTacToeApp.controller('CreateGameController',
    function CreateGameController($scope, identity, auth, messageBox, $location, GameResource) {
        var MESSAGE_BOX_SELECTOR = '#message-box';
        var JOIN_BEFORE_PLAYING = 'You must login in to start playing!';

        if (!identity.isAuthenticated()) {
            $location.path('/signup');
            messageBox.error(JOIN_BEFORE_PLAYING, MESSAGE_BOX_SELECTOR);
            return;
        }

        GameResource.createGame().success(function (currentGame) {
            $scope.currentGame = currentGame;
            console.dir(currentGame);
        });
    });
