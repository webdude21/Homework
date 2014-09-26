'use strict';

ticTacToeApp.controller('ListGamesController',
    function ListGamesController($scope, identity, notifier, auth, $location, GameResource) {
        var LOGIN_BEFORE_GETTING_THE_LIST = 'You must login in to view the available games!';

        if (!identity.isAuthenticated()) {
            $location.path('/register');
            notifier.error(LOGIN_BEFORE_GETTING_THE_LIST);
            return;
        }

        $scope.joinCurrentGame = function (gameId) {
            GameResource.joinGame(gameId)
                .then(function (response) {
                    $scope.currentGame = response.data;
                    $location.path('/game/' + gameId);
                }, (function (err) {
                    notifier.error(err.data.Message);
                    $location.path('/list-games');
                }));
        };

        $scope.playCurrentGame = function (gameId) {
            GameResource.getGameStatus(gameId)
                .then(function (response) {
                    $scope.currentGame = response.data;
                    $location.path('/game/' + gameId);
                }, (function (err) {
                    notifier.error(err.data.Message);
                    $location.path('/list-games');
                }));
        };

        GameResource.getAllGames().success(function (games) {
            $scope.gameList = games;
        });
    });
