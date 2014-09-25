'use strict';

ticTacToeApp.factory('GameResource', function ($http, baseUrl, authorization) {
    var gamesApi = baseUrl + '/api/games';
    var createGameEndPoint = gamesApi + "/create";
    var joinGameEndPoint = gamesApi + "/join";
    var gameStatusEndPoint = gamesApi + "/status";
    var gameListEndPoint = gamesApi + "/get";

    function createGame() {
        return $http.post(createGameEndPoint, {}, {headers: authorization.getAuthorizationHeader()})
    }

    function joinGame(gameId){
        return $http.post(joinGameEndPoint + '/' + gameId, {}, {headers: authorization.getAuthorizationHeader()})
    }

    function getGameStatus(gameid){
        return $http.post(gameStatusEndPoint, gameid, {headers: authorization.getAuthorizationHeader()})
    }

    function getAllGames(){
        return $http.get(gameListEndPoint, {headers: authorization.getAuthorizationHeader()});
    }

    return{
        createGame: createGame,
        joinGame: joinGame,
        getGameStatus: getGameStatus,
        getAllGames: getAllGames
    }
});