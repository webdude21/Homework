'use strict';

ticTacToeApp.controller('GameController',
    function GameController($scope, identity, auth, messageBox, $location, GameResource, $routeParams) {
        var MESSAGE_BOX_SELECTOR = '#message-box';
        var JOIN_BEFORE_PLAYING = 'You must login in to start playing!';

        var gameId = $routeParams.id;

        if (!identity.isAuthenticated()) {
            $location.path('/signup');
            messageBox.error(JOIN_BEFORE_PLAYING, MESSAGE_BOX_SELECTOR);
            return;
        }

        GameResource.getGameStatus(gameId).success(function (currentGame) {
            $scope.currentGame = currentGame;
        }).error(function(err){
            messageBox.error(err.Message, MESSAGE_BOX_SELECTOR);
            $location.path('/list-games');
        });

        $scope.tryToPlay = function (row, col) {
            if ($scope.currentGame.Board[row * 3 + col] === '-' && [0, 3, 4, 5].indexOf($scope.currentGame.Status) === -1) {
                ticTacToeData.playGame($scope.gameId, row + 1, col + 1, auth.access_token())
                    .then(function () {
                        getGameStatus();
                    }, function (e) {
                        console.log(e)
                    });
            }
        }

    });
