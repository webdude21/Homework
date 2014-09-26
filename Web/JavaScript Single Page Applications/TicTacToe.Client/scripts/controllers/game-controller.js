'use strict';

ticTacToeApp.controller('GameController',
    function GameController($scope, identity, auth, notifier, $location, GameResource, $routeParams) {
        var JOIN_BEFORE_PLAYING = 'You must login in to start playing!';

        var gameId = $routeParams.id;

        if (!identity.isAuthenticated()) {
            $location.path('/register');
            notifier.error(JOIN_BEFORE_PLAYING);
            return;
        }

        setInterval(retrieveGameStatus, 2000);

        function retrieveGameStatus(){
            GameResource.getGameStatus(gameId).then(function (response) {
                $scope.currentGame = response.data;
            }, (function (response) {
                notifier.error(response.data.Message);
                $location.path('/list-games');
            }));
        }

        retrieveGameStatus();

        $scope.tryToPlay = function (row, col) {
            if ($scope.currentGame.Board[row * 3 + col] === '-') {
                var turnInfo = {
                    GameId: gameId,
                    Row: row + 1,
                    Col: col + 1
                };

                GameResource.playTurn(turnInfo)
                    .then(function (response) {
                        $scope.currentGame = response.data;
                    }, (function (response) {
                        notifier.error(response.data.Message);
                    }));
            }
        }

    });
