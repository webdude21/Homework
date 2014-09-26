'use strict';

bullsAndCowsApp.controller('GameController',
    function GameController($scope, identity, auth, messageBox, $location, GameResource, $routeParams) {
        var MESSAGE_BOX_SELECTOR = '#message-box';
        var JOIN_BEFORE_PLAYING = 'You must login in to start playing!';

        var gameId = $routeParams.id;

        if (!identity.isAuthenticated()) {
            $location.path('/signup');
            messageBox.error(JOIN_BEFORE_PLAYING, MESSAGE_BOX_SELECTOR);
            return;
        }

        setInterval(retrieveGameStatus, 2000);

        function retrieveGameStatus(){
            GameResource.getGameStatus(gameId).then(function (response) {
                $scope.currentGame = response.data;
            }, (function (response) {
                messageBox.error(response.data.Message, MESSAGE_BOX_SELECTOR);
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
                        messageBox.error(response.data.Message, MESSAGE_BOX_SELECTOR);
                    }));
            }
        }

    });
