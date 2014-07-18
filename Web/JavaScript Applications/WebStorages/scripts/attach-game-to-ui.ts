/// <reference path="sheep-and-rams.ts"/>

window.onload = function(){
    var userInputBox = (<HTMLInputElement>document.getElementById('user-input-box'));
    var guessButton = document.getElementById('play-game');
    var resultPrintFunction = jsConsole.writeLine;
    var game = new SheepAndRams.Game(userInputBox, _.random, resultPrintFunction, true);
    guessButton.addEventListener('click', function(){
        game.userGuess();
    });
};
