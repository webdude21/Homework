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

        $scope.joinCurrentGame = function (gameId){
            GameResource.joinGame(gameId).success(function (currentGame) {
                $scope.currentGame = currentGame;
                $location.path('/game/:' + gameId);
            }).error(function(err){
                messageBox.error(err.Message, MESSAGE_BOX_SELECTOR);
                $location.path('/list-games');
            });
        };

        $scope.playCurrentGame = function (gameId){
            GameResource.getGameStatus(gameId).success(function (currentGame) {
                $scope.currentGame = currentGame;
                $location.path('/game/' + gameId);
            }).error(function(err){
                messageBox.error(err.Message, MESSAGE_BOX_SELECTOR);
                $location.path('/list-games');
            });
        };

        GameResource.getAllGames().success(function (games) {
            $scope.gameList = games;
        });

    });
