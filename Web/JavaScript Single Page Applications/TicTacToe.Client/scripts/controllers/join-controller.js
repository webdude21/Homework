'use strict';

ticTacToeApp.controller('JoinGameController',
    function JoinGameController($scope, identity, auth, messageBox, $location, GameResource, $routeParams) {
        var MESSAGE_BOX_SELECTOR = '#message-box';
        var JOIN_BEFORE_PLAYING = 'You must login in to start playing!';

        var gameId = $routeParams.id;

        if (!identity.isAuthenticated()) {
            $location.path('/signup');
            messageBox.error(JOIN_BEFORE_PLAYING, MESSAGE_BOX_SELECTOR);
            return;
        }

        GameResource.joinGame(gameId).success(function (currentGame) {
            $scope.currentGame = currentGame;
        }).error(function(err){
            messageBox.error(err.Message, MESSAGE_BOX_SELECTOR);
            $location.path('/list-games');
        });

    });
