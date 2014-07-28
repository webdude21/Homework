/// <reference path="sheep-and-rams.ts"/>
/// <reference path="high-score.ts"/>

module GameInit {
    export function start() {
        var HIGH_SCORE_HEADER = '----------- These are the champions -----------';
        var localStorageName = 'SheepAndRamsGame';
        var localStoreHandler = new HighScore.LocalStorageHandler(localStorageName);
        var userInputBox = (<HTMLInputElement>document.getElementById('user-input-box'));
        var guessButton = document.getElementById('play-game');
        var clearHighScores = document.getElementById('clear-high-scores');
        var displayHighScores = document.getElementById('display-high-scores');

        displayHighScores.addEventListener('click', function () {
            jsConsole.clear();
            jsConsole.writeLine(HIGH_SCORE_HEADER);
            var highScore = localStoreHandler.getHighScores();

            if (highScore && highScore.length > 0) {
                highScore.sort(function (playerOne, playerTwo) {
                    return playerOne.playerScore - playerTwo.playerScore;
                });

                highScore.forEach(function (playerEntry) {
                    jsConsole.writeLine('Player: ' + playerEntry.playerName + ' - Trials: ' + playerEntry.playerScore);
                });
            }
        });


        clearHighScores.addEventListener('click', function () {
            HighScore.LocalStorageHandler.clearLocalStorage();
        });

        var resultPrintFunction = function (str:string) {
            jsConsole.writeLine(str);
        };
        var userPrompt = function (message:string, defaultValue:string) {
            return window.prompt(message, defaultValue);
        };

        var savePlayerScoreFunc = function (playerName:string, playerScore:string) {
            localStoreHandler.savePlayer(playerName, playerScore);
        };

        var clearButton = document.getElementById('clear-console');
        clearButton.addEventListener('click', function () {
            jsConsole.clear();
        });

        var game = new SheepAndRams.Game(_.random, resultPrintFunction,
            userPrompt, savePlayerScoreFunc, true);

        guessButton.addEventListener('click', function () {
            game.userGuess(userInputBox.value);
        });
    }

}

window.addEventListener('load', GameInit.start);