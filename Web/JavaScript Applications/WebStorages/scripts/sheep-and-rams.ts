module SheepAndRams {
    var NUMBER_OF_DIGITS = 4;
    var RAM = 'R';
    var SHEEP = 'S';

    export class Game {
        numberToBeGuessed:number;
        numberOfTries:number;

        constructor(private userInputBox:HTMLInputElement, private randomFunction:(from:number, to:number) => number, private resultPrint:(str:string) => void, cheatingEnabled?:boolean) {

            this.numberOfTries = 0;
            this.numberToBeGuessed = this.randomFunction(1000, 9999);
            if (cheatingEnabled) {
                console.log(this.numberToBeGuessed);
            }
        }

        getUserInput() {
            var userInput = parseInt(this.userInputBox.value, 10);
            if (isNaN(userInput) || userInput < 1000 || userInput > 9999) {
                throw new RangeError("Please provide a number between 1000 and 9999")
            }

            return userInput;
        }

        userGuess() {
            var guess;

            try {
                guess = this.getUserInput();
                var result = this.evaluateUserGuess(guess);
                this.resultPrint('You have ' + result.ramsCount + ' rams and '
                    + result.sheepCount + ' sheep!');
                this.numberOfTries += 1;
            } catch (err) {
                if (err instanceof RangeError) {
                    this.resultPrint('Please input a number between 1000 and 9999');
                } else {
                    throw err;
                }
            }
        }

        userHasWon() {
            this.resultPrint('Congratulations! You have Won!')
        }


        private evaluateUserGuess(guess) {
            var sheep = 0;

            var rams = this.checkForRams(guess);

            if (rams.ramsCount < 4) {
                sheep = this.checkForSheep(guess, rams.leftToGuess);
            } else {
                this.userHasWon();
            }

            return {
                sheepCount: sheep,
                ramsCount: rams.ramsCount
            };
        }

        private checkForRams(guess) {
            var userGuessAsString = guess.toString();
            var numberToBeGuessedAsString = this.numberToBeGuessed.toString();
            var leftToGuess = [];
            var ramsCount = 0;

            for (var index = 0; index < NUMBER_OF_DIGITS; index++) {
                var currentChar = userGuessAsString[index];
                if (currentChar === numberToBeGuessedAsString[index]) {
                    ramsCount++;
                    leftToGuess[index] = RAM;
                } else {
                    leftToGuess[index] = numberToBeGuessedAsString[index];
                }
            }

            return {
                ramsCount: ramsCount,
                leftToGuess: leftToGuess
            }
        }

        private checkForSheep(userGuess, leftToGuess) {
            var userGuessAsString = userGuess.toString();
            var sheepCount = 0;

            for (var i = 0; i < NUMBER_OF_DIGITS; i++) {
                for (var j = 0; j < NUMBER_OF_DIGITS; j++) {
                    if (j != i && (userGuessAsString[i] === leftToGuess[j])) {
                        sheepCount++;
                        leftToGuess[i] = SHEEP;
                    }
                }
            }

            return sheepCount;
        }
    }
}