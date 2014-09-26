'use strict';

ticTacToeApp.controller('CreateGameController',
    function CreateGameController($scope, identity, auth, notifier, $location, GameResource) {
        var JOIN_BEFORE_PLAYING = 'You must login in to start playing!';

        if (!identity.isAuthenticated()) {
            $location.path('/register');
            notifier.error(JOIN_BEFORE_PLAYING);
            return;
        }

        GameResource.createGame().then(function (response) {
            $scope.currentGame = response.data;
            $location.path('/game/' + JSON.parse(response.data))
        }, (function (err) {
            notifier.error(err.data.Message);
        }));
    });
