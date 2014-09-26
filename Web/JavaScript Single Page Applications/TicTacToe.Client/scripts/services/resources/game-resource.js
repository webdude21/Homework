'use strict';

ticTacToeApp.factory('GameResource', function ($http, baseUrl, authorization) {
    var gamesApi = baseUrl + '/api/games';
    var createGameEndPoint = gamesApi + "/create";
    var joinGameEndPoint = gamesApi + "/join?gameId=";
    var gameStatusEndPoint = gamesApi + "?gameId=";
    var playGameEndPoint = gamesApi + '/play';

    function createGame() {
        return $http.post(createGameEndPoint, {}, {headers: authorization.getAuthorizationHeader()})
    }

    function joinGame(gameId){
        return $http.post(joinGameEndPoint + gameId, {}, {headers: authorization.getAuthorizationHeader()})
    }

    function getGameStatus(gameid){
        return $http.get(gameStatusEndPoint + gameid, {headers: authorization.getAuthorizationHeader()})
    }

    function getAllGames(){
        return $http.get(gamesApi, {headers: authorization.getAuthorizationHeader()});
    }

    function playTurn(gameData){
        return $http.post(playGameEndPoint, gameData, {headers: authorization.getAuthorizationHeader()});
    }

    return{
        createGame: createGame,
        joinGame: joinGame,
        getGameStatus: getGameStatus,
        getAllGames: getAllGames,
        playTurn: playTurn
    }
});