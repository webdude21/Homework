/// <reference path="sheep-and-rams.ts"/>
/// <reference path="local-storage-high-score.ts"/>

window.onload = function () {
    var saveHighScoreSaver = new HighScore.LocalStorage();
    var userInputBox = (<HTMLInputElement>document.getElementById('user-input-box'));
    var guessButton = document.getElementById('play-game');
    var clearHighScores = document.getElementById('clear-high-scores');
    var displayHighScores = document.getElementById('display-high-scores');

    displayHighScores.addEventListener('click', saveHighScoreSaver.displayHighScore);
    clearHighScores.addEventListener('click', saveHighScoreSaver.clearLocalStorage);

    var resultPrintFunction = function (str:string) {
        jsConsole.writeLine(str);
    };
    var userPrompt = function (message:string, defaultValue:string) {
        return window.prompt(message, defaultValue);
    };


    var savePlayerScoreFunc = saveHighScoreSaver.savePlayer;

    var clearButton = document.getElementById('clear-console');
    clearButton.addEventListener('click', function () {
        jsConsole.clear();
    });

    var game = new SheepAndRams.Game(userInputBox, _.random, resultPrintFunction,
        userPrompt, savePlayerScoreFunc, true);
    guessButton.addEventListener('click', function () {
        game.userGuess();
    });
};
