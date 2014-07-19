module SheepAndRams {
    var NUMBER_OF_DIGITS = 4;
    var RAM = 'R';
    var SHEEP = 'S';
    var USED = 'U';
    var WIN_TEXT = 'Congratulations! You have Won!';
    var MIN = 1000;
    var MAX = 9999;
    var VALIDATION_TEXT = 'Please input a number between ' + MIN + ' and ' + MAX;
    var DEFAULT_PLAYER_NAME = 'Unnamed master';

    export class Game {
        numberToBeGuessed:number;
        numberOfTries:number;

        constructor(private randomFunction:(from:number, to:number) => number, private resultPrint:(str:string) => void, private highScorePrompt:(message:string, defaultValue:string) => string, private saveState:(playerName:string, playerScore:string) => void, cheatingEnabled?:boolean) {

            this.numberOfTries = 0;
            this.numberToBeGuessed = this.randomFunction(MIN, MAX);
            if (cheatingEnabled) {
                console.log(this.numberToBeGuessed);
            }
        }

        private static parseUserInput(userInput:string) {
            var userInputAsInt = parseInt(userInput, 10);
            if (isNaN(userInputAsInt) || userInputAsInt < MIN || userInputAsInt > MAX) {
                throw new RangeError(VALIDATION_TEXT);
            }

            SheepAndRams.Game.convertToCharArray(userInputAsInt.toString());
            return (userInputAsInt.toString());
        }

        public userGuess(userInput:string) {
            var guess;

            try {
                guess = SheepAndRams.Game.parseUserInput(userInput);
                this.numberOfTries += 1;
                var result = this.evaluateUserGuess(guess);
                var resultString = 'You have ' + result.ramsCount + ' rams and '
                    + result.sheepCount + ' sheep! You have tried to guess ' + this.numberOfTries + ' times!';
                this.resultPrint(resultString);
            } catch (err) {
                if (err instanceof RangeError) {
                    this.resultPrint(VALIDATION_TEXT);
                } else {
                    throw err;
                }
            }
        }

        private playerHasWon() {
            this.resultPrint(WIN_TEXT);
            var player = this.highScorePrompt("Please enter your name", DEFAULT_PLAYER_NAME) || DEFAULT_PLAYER_NAME;
            this.saveState(player, this.numberOfTries.toString());
        }

        private evaluateUserGuess(guess:string[]) {
            var sheep = 0;

            var rams = this.checkForRams(guess);

            if (rams.ramsCount < 4) {
                sheep = this.checkForSheep(guess, rams.leftToGuess);
            } else {
                this.playerHasWon();
            }

            return {
                sheepCount: sheep,
                ramsCount: rams.ramsCount
            };
        }

        private static convertToCharArray(str:string) {
            var result = [];
            for (var i = 0; i < str.length; i++) {
                result.push(str[i]);
            }

            return result;
        }

        private checkForRams(guess:string[]) {
            var numberToBeGuessedAsString = SheepAndRams.Game.convertToCharArray(this.numberToBeGuessed.toString());
            var leftToGuess = [];
            var ramsCount = 0;

            for (var index = 0; index < NUMBER_OF_DIGITS; index++) {
                var currentChar = guess[index];
                if (currentChar === numberToBeGuessedAsString[index]) {
                    ramsCount++;
                    leftToGuess[index] = RAM;
                    guess[index] = USED;
                } else {
                    leftToGuess[index] = numberToBeGuessedAsString[index];
                }
            }

            return {
                ramsCount: ramsCount,
                leftToGuess: leftToGuess
            }
        }

        private checkForSheep(userGuess:string[], leftToGuess:string[]) {
            var sheepCount = 0;

            for (var i = 0; i < NUMBER_OF_DIGITS; i++) {
                for (var j = 0; j < NUMBER_OF_DIGITS; j++) {
                    if ((userGuess[i] === leftToGuess[j])) {
                        sheepCount++;
                        userGuess[i] = USED;
                        leftToGuess[j] = SHEEP;
                    }
                }
            }

            return sheepCount;
        }
    }
}